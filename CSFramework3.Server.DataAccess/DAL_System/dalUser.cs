///*************************************************************************/
///*
///* 文件名    ：dalUser.cs                                
///* 程序说明  : 用户数据字典的DAL层
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework.ORM;
using CSFramework3.Interfaces;
using CSFramework3.Server.DataAccess.DAL_Base;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 用户数据字典的DAL层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(TUser), true)]
    public class dalUser : dalBaseDataDict, IBridge_User
    {
        public dalUser(Loginer loginer)
            : base(loginer)
        {
            _KeyName = TUser.__KeyName; //主键字段
            _TableName = TUser.__TableName;//表名
            _ModelType = typeof(TUser);
        }

        /// <summary>
        /// 跟据表名创建SQL命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == TUser.__TableName) ORM = typeof(TUser);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }

        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetUsers()
        {
            string sql = "select * from [tb_MyUser]";

            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_MyUser");
        }

        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public bool ExistsUser(string account)
        {
            string sql = "select count(*) from [tb_MyUser] where [Account]=@Account";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@Account", SqlDbType.VarChar, account);
            object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) > 0;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account">登录帐号</param>
        public void Logout(string account)
        {
            SqlCommandBase cmd = SqlBuilder.BuildSqlProcedure("sp_Logout");
            cmd.AddParam("@Account", SqlDbType.VarChar, account);
            DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userID">登录帐号</param>
        /// <returns></returns>
        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            SqlCommandBase cmd = SqlBuilder.BuildSqlProcedure("sp_Login");
            cmd.AddParam("@Account", SqlDbType.VarChar, loginUser.Account);
            cmd.AddParam("@Password", SqlDbType.VarChar, loginUser.Password);
            cmd.AddParam("@DataSetID", SqlDbType.VarChar, loginUser.DataSetID);
            cmd.AddParam("@LoginUserType", SqlDbType.Char, LoginUserType);
            DataSet ds = DataProvider.Instance.GetDataSet(loginUser.DataSetDBName, cmd.SqlCommand);
            if (ds.Tables.Count == 2)
            {
                string error = ConvertEx.ToString(ds.Tables[1].Rows[0][0]);
                if (error.Trim() != string.Empty) throw new CustomException(error); //抛出异常

                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 跟据Novell网帐号获取系统帐号
        /// </summary>
        /// <param name="novellAccount">Novell网帐号</param>
        /// <returns></returns>
        public DataTable GetUserByNovellID(string novellAccount)
        {
            string sql = "select * from [tb_MyUser] where [NovellAccount]=@novellAccount";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@novellAccount", SqlDbType.VarChar, novellAccount);
            DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, TUser.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取当前用户的系统权限
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <returns></returns>
        public DataTable GetUserAuthorities(Loginer user)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_MyGetAuthorities");
            sp.AddParam("@UserOrGroup", SqlDbType.VarChar, user.Account);
            sp.AddParam("@Type", SqlDbType.Int, 1);
            DataTable dt = DataProvider.Instance.GetTable(user.DBName, sp.SqlCommand, TUserRole.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取用户所属组
        /// </summary>
        /// <param name="account">当前用户</param>
        /// <returns></returns>
        public DataTable GetUserGroups(string account)
        {
            string SQL = "SELECT * FROM tb_MyUserGroup WHERE GroupCode IN (SELECT GroupCode FROM tb_MyUserGroupRe WHERE Account=@Account)";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(SQL);
            cmd.AddParam("@Account", SqlDbType.VarChar, account);
            DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, TUserGroup.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        public DataTable GetUser(string account)
        {
            string sql = "select * from [tb_MyUser] where [Account]=@Account";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@Account", SqlDbType.VarChar, account);
            DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, TUser.__TableName);
            return dt;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        public bool DeleteUser(string account)
        {
            string sql = "Delete [tb_MyUser] where [Account]=@Account";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@Account", SqlDbType.VarChar, account);
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool ModifyPassword(string account, string pwd)
        {
            string sql = "update tb_MyUser set password=@password where account=@account";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("password", SqlDbType.VarChar, pwd);
            cmd.AddParam("account", SqlDbType.VarChar, account);
            object o = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) != 0;
        }

        public DataTable GetUserDirect(string account, string DBName)
        {
            string sql = "select * from [tb_MyUser] where [Account]=@Account";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@Account", SqlDbType.VarChar, account);
            DataTable dt = DataProvider.Instance.GetTable(DBName, cmd.SqlCommand, TUser.__TableName);
            return dt;
        }

        public bool ModifyPwdDirect(string account, string pwd, string DBName)
        {
            string sql = "update tb_MyUser set password=@password where account=@account";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("password", SqlDbType.VarChar, pwd);
            cmd.AddParam("account", SqlDbType.VarChar, account);
            object o = DataProvider.Instance.ExecuteNoQuery(DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) != 0;
        }


        public DataSet GetUserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            StringBuilder sb = new StringBuilder("select * from [tb_MyUser] where 1=1 ");

            if (createDateFrom.Year > 1901)
                sb.Append(" AND CONVERT(VARCHAR,[CreateTime],112)>='" + createDateFrom.ToString("yyyyMMdd") + "'");

            if (createDateTo.Year > 1901)
                sb.Append(" AND CONVERT(VARCHAR,[CreateTime],112)<='" + createDateTo.ToString("yyyyMMdd") + "'");

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sb.ToString());
            return DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
        }
    }
}
