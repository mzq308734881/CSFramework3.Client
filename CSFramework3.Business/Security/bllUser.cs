
///*************************************************************************/
///*
///* 文件名    ：bllUser.cs        
///
///* 程序说明  : 用户管理的业务逻辑层
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework3.Business.BLL_Base;
using CSFramework3.WebServiceReference;
using System.ServiceModel;
using CSFramework.Core;
using CSFramework3.Bridge;
using CSFramework3.Bridge.SystemModule;

namespace CSFramework3.Business.Security
{
    /// <summary>
    /// 用户管理的业务逻辑层
    /// </summary>
    public class bllUser : bllBaseDataDict
    {
        private IBridge_User _MyBridge;

        public bllUser()
        {
            _KeyFieldName = TUser.__KeyName; //主键字段
            _SummaryTableName = TUser.__TableName;//表名
            _WriteDataLog = false;//是否保存日志                    
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TUser));
            _MyBridge = this.CreateBridge();
        }

        /// <summary>
        /// 创建实现了桥接接口的通信通道
        /// </summary>
        /// <returns></returns>
        private IBridge_User CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_User().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_User();

            return null;
        }

        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUsers()
        {
            _SummaryTable = _MyBridge.GetUsers();

            SetDefault(_SummaryTable);
            return _SummaryTable;
        }

        protected override void SetDefault(DataTable data)
        {
            data.Columns[TUser.IsLocked].DefaultValue = 0;
            data.Columns[TUser.CreateTime].DefaultValue = DateTime.Now;
        }

        public override bool Delete(string account)
        {
            return _MyBridge.DeleteUser(account);
        }

        /// <summary>
        /// 获取指定用户数据
        /// </summary>
        /// <param name="account">用户帐号</param>
        /// <returns></returns>
        public DataTable GetUser(string account)
        {
            return _MyBridge.GetUser(account);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="data">用户数据</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Update(DataTable data, UpdateType type)
        {
            DataSet ds = this.CreateDataset(data, type);
            return _MyBridge.Update(ds);
        }

        public override bool CheckNoExists(string account)
        {
            return _MyBridge.ExistsUser(account);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="account">用户帐号</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool ModifyPassword(string account, string pwd)
        {
            return _MyBridge.ModifyPassword(account, pwd);
        }

        /// <summary>
        /// 跟据Novell帐号获取用户登录帐号
        /// </summary>
        /// <param name="novellAccount">Novell帐号</param>
        /// <returns></returns>
        public DataTable GetUserByNovellID(string novellAccount)
        {
            return _MyBridge.GetUserByNovellID(novellAccount);
        }

        public void Validate(LoginUser user)
        {
            if (CheckNoExists(user.Account))
                throw new Exception("用户已经存在!");
        }

        public static void ValidateLogin(string userID, string password)
        {
            if (userID.Trim() == "")
                throw new Exception("用户编号不正确或不能为空!");

            if (password.Trim() == "")
                throw new Exception("密码不正确或不能为空!");
        }

        public DataTable GetUserDirect(string account, string DBName)
        {
            return _MyBridge.GetUserDirect(account, DBName);
        }

        public bool ModifyPasswordDirect(string account, string pwd, string DBName)
        {
            return _MyBridge.ModifyPwdDirect(account, pwd, DBName);
        }

        public DataTable GetUserGroups(string account)
        {
            return _MyBridge.GetUserGroups(account);
        }

        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            return _MyBridge.Login(loginUser, LoginUserType);
        }

        public DataTable GetUserAuthorities(Loginer user)
        {
            return _MyBridge.GetUserAuthorities(user);
        }

        public void Logout(string account)
        {
            _MyBridge.Logout(account);
        }

        public DataSet GetUserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            return _MyBridge.GetUserReportData(createDateFrom, createDateTo);
        }
    }
}
