
///*************************************************************************/
///*
///* 文件名    ：UserGroup_Bridge.cs
///*
///* 程序说明  : 用户组管理数据层桥接单元
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework.Core;
using CSFramework.Common;
using System.Data;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.WebServiceReference.WCF_SystemSecurityService;

namespace CSFramework3.Bridge.SystemModule
{
    /// <summary>
    /// 用户组数据层桥接功能
    /// </summary>
    public class ADODirect_UserGroup
    {
        private IBridge_UserGroup _DAL_Instance = null;//数据层实例

        public ADODirect_UserGroup()
        {
            _DAL_Instance = new dalUserGroup(Loginer.CurrentUser);
        }

        public IBridge_UserGroup GetInstance()
        {
            return _DAL_Instance;
        }
    }

    /// <summary>
    /// 用户组WCF中间层桥接功能
    /// </summary>
    public class WebService_UserGroup : IBridge_UserGroup
    {

        public WebService_UserGroup()
        {
        }

        #region IBridge_UserGroup Members

        public System.Data.DataTable GetAuthorityItem()
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetAuthorityItem(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetUserGroup()
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetUserGroup(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataSet GetUserGroup(string groupCode)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetUserGroupByCode(loginTicket, groupCode);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataTable GetFormTagCustomName()
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetFormTagCustomName(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool CheckNoExists(string groupCode)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_CheckNoExists(loginTicket, groupCode);
            }
        }

        public bool DeleteGroupByKey(string groupCode)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_DeleteGroupByKey(loginTicket, groupCode);
            }
        }

        public int GetFormAuthority(string account, int moduleID, string menuName)
        {
            using (SystemSecurityServiceClient client = SoapClientFactory.CreateSecurityClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_GetFormAuthority(loginTicket, account, moduleID, menuName);
            }
        }

        #endregion
    }
}
