///*************************************************************************/
///*
///* 文件名    ：dalUserGroup.cs                                
///* 程序说明  : 用户组数据字典的DAL层
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
using CSFramework3.Server.DataAccess.DAL_Base;
using CSFramework3.Interfaces.Interfaces_Bridge;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 用户组数据字典的DAL层 
    /// </summary>
    [DefaultORM_UpdateMode(typeof(TUserGroup), true)]
    public class dalUserGroup : dalBaseDataDict, IBridge_UserGroup
    {
        public dalUserGroup(Loginer loginer)
            : base(loginer)
        { }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == TUserGroup.__TableName) ORM = typeof(TUserGroup);
            if (tableName == TUserGroupRe.__TableName) ORM = typeof(TUserGroupRe);
            if (tableName == TUserRole.__TableName) ORM = typeof(TUserRole);
            if (tableName == TFormTagName.__TableName) ORM = typeof(TFormTagName);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            //支持两种SQL命令生成器
            return new GenerateSqlCmdByTableFields(ORM);
        }

        /// <summary>
        /// 获取权限功能点定义
        /// </summary>
        /// <returns></returns>
        public DataTable GetAuthorityItem()
        {
            string sql = " select * from dbo.tb_MyAuthorityItem order by AuthorityValue";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_MyAuthorityItem");
        }

        /// <summary>
        /// 获取所有用户组
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserGroup()
        {
            string sql = "select * from [tb_MyUserGroup]";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_MyUserGroup");
        }

        /// <summary>
        /// 检查用户组是否存在
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <returns></returns>
        public bool CheckNoExists(string groupCode)
        {
            string sql = "select count(*) from [tb_MyUserGroup] where [GroupCode]=@GroupCode";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@GroupCode", SqlDbType.VarChar, groupCode);
            object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) > 0;
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <returns></returns>
        public bool DeleteGroupByKey(string groupCode)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_MyDeleteGroupData");
            sp.AddParam("@GroupCode", SqlDbType.VarChar, groupCode);
            object o = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, sp.SqlCommand);
            return ConvertEx.ToInt(o) != 0;
        }

        /// <summary>
        /// 获取用户组的权限信息，包括组的用户，组的权限
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <returns></returns>
        public DataSet GetUserGroup(string groupCode)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_MyGetGroupData");
            sp.AddParam("@GroupCode", SqlDbType.VarChar, groupCode);
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, sp.SqlCommand);
            ds.Tables[BusinessDataSetIndex.Groups].TableName = TUserGroup.__TableName;
            ds.Tables[BusinessDataSetIndex.GroupUsers].TableName = TUserGroupRe.__TableName;
            ds.Tables[BusinessDataSetIndex.GroupAuthorities].TableName = TUserRole.__TableName;
            ds.Tables[BusinessDataSetIndex.GroupAvailableUser].TableName = "GroupAvailableUser";
            return ds;
        }

        /// <summary>
        /// 获取窗体的可用权限值
        /// </summary>
        /// <param name="account">登录帐号</param>
        /// <param name="moduleID">模块编号</param>
        /// <param name="menuName">菜单名称</param>
        /// <returns></returns>
        public int GetFormAuthority(string account, int moduleID, string menuName)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_GetFormAuthority");
            sp.AddParam("@account", SqlDbType.VarChar, account);
            sp.AddParam("@moduleID", SqlDbType.Int, moduleID);
            sp.AddParam("@menuName", SqlDbType.VarChar, menuName);
            object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, sp.SqlCommand);
            return ConvertEx.ToInt(o);
        }

        /// <summary>
        /// 获取自定义按钮名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetFormTagCustomName()
        {
            string sql = "select * from [tb_MyFormTagName]";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_MyFormTagName");
        }
    }
}
