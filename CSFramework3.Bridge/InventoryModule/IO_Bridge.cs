
///*************************************************************************/
///*
///* 文件名    ：IO_Bridge.cs
///*
///* 程序说明  : 出仓单数据层桥接单元
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework3.Interfaces;
using CSFramework.Core;
using CSFramework.Common;
using System.Data;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_Business;
using CSFramework3.WebServiceReference.WCF_SalesModuleService;
using CSFramework3.WebServiceReference.WCF_InventoryModuleService;

namespace CSFramework3.Bridge.SalesModule
{
    /// <summary>
    /// DAL层桥接功能
    /// </summary>
    public class ADODirect_IO
    {
        private IBridge_IO _DAL_Instance = null;//数据层实例

        public ADODirect_IO()
        {
            _DAL_Instance = new dalIO(Loginer.CurrentUser);
        }

        public IBridge_IO GetInstance()
        {
            return _DAL_Instance;
        }
    }

    /// <summary>
    /// WEB服务桥接功能代理层
    /// </summary>
    public class WebService_IO : IBridge_IO
    {

        public WebService_IO()
        {
        }

        #region IBridge_IO 成员

        public System.Data.DataSet GetBusinessByKey(string keyValue)
        {
            using (InventoryModuleServiceClient client = SoapClientFactory.CreateInventoryModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.IO_GetBusinessByKey(loginTicket, keyValue);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            using (InventoryModuleServiceClient client = SoapClientFactory.CreateInventoryModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.IO_GetSummaryByParam(loginTicket, docNoFrom, docNoTo, docDateFrom, docDateTo);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public SaveResult Update(DataSet saveData)
        {
            using (InventoryModuleServiceClient client = SoapClientFactory.CreateInventoryModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(saveData);
                byte[] receivedData = client.IO_Update(loginTicket, bs);
                return ZipTools.DecompressionObject(receivedData) as SaveResult;
            }
        }

        public bool Delete(string keyValue)
        {
            using (InventoryModuleServiceClient client = SoapClientFactory.CreateInventoryModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.IO_Delete(loginTicket, keyValue);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (InventoryModuleServiceClient client = SoapClientFactory.CreateInventoryModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.IO_CheckNoExists(loginTicket, keyValue);
            }
        }

        public void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate)
        {
            using (InventoryModuleServiceClient client = SoapClientFactory.CreateInventoryModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.IO_ApprovalBusiness(loginTicket, keyValue, flagApp, appUser, appDate);
            }
        }

        #endregion
    }

}
