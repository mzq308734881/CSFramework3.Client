
///*************************************************************************/
///*
///* 文件名    ：User_Bridge.cs
///*
///* 程序说明  : 用户管理数据层桥接单元
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSFramework3.Interfaces;
using System.Data;
using CSFramework.Common;
using CSFramework.Core;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.WebServiceReference.WCF_SystemSecurityService;

namespace CSFramework3.Bridge.SystemModule
{
    public class ADODirect_User
    {
        private IBridge_User _DAL_Instance = null;//数据层实例

        public ADODirect_User()
        {
            _DAL_Instance = new dalUser(Loginer.CurrentUser);
        }

        public IBridge_User GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_User : IBridge_User
    {

        public WebService_User()
        {
        }

        #region IBridge_User Members

        public DataTable GetUserAuthorities(Loginer user)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserAuthorities(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public void Logout(string account)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.U_Logout(loginTicket);
            }
        }

        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] bsLoginUser = ZipTools.CompressionObject(loginUser);
                byte[] receivedData = client.U_Login(validationTicket, bsLoginUser, LoginUserType);
                DataSet ds = ZipTools.DecompressionDataSet(receivedData);
                return ds.Tables[0];
            }
        }

        public DataTable GetUserDirect(string account, string DBName)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.U_GetUserDirect(validationTicket, account, DBName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool ModifyPwdDirect(string account, string pwd, string DBName)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.U_ModifyPwdDirect(validationTicket, account, pwd, DBName);
            }
        }

        public System.Data.DataTable GetUsers()
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUsers(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetUser(string account)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUser(loginTicket, account);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetUserGroups(string account)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserGroups(loginTicket, account);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetUserByNovellID(string novellAccount)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserByNovellID(loginTicket, novellAccount);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool Update(System.Data.DataSet ds)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] userData = ZipTools.CompressionDataSet(ds);
                return client.U_UpdateUser(loginTicket, userData);
            }
        }

        public bool DeleteUser(string account)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.U_DeleteUser(loginTicket, account);
            }
        }

        public bool ExistsUser(string account)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.U_ExistsUser(loginTicket, account);
            }
        }

        public bool ModifyPassword(string account, string pwd)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.U_ModifyPassword(loginTicket, account, pwd);
            }
        }

        public DataSet GetUserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = client.U_GetUserReportData(loginTicket, createDateFrom, createDateTo);
                return ZipTools.DecompressionDataSet(bs);
            }
        }

        #endregion
    }
}
