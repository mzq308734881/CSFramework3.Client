
///*************************************************************************/
///*
///* 文件名    ：SO_Bridge.cs
///*
///* 程序说明  : 销售发票数据层桥接单元
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

namespace CSFramework3.Bridge.SalesModule
{
    public class ADODirect_SO
    {
        private IBridge_SO _DAL_Instance = null;//数据层实例

        public ADODirect_SO()
        {
            _DAL_Instance = new dalSO(Loginer.CurrentUser);
        }

        public IBridge_SO GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_SO : IBridge_SO
    {

        public WebService_SO()
        {
        }

        #region IBridge_SO 成员

        public System.Data.DataSet GetBusinessByKey(string keyValue)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SO_GetBusinessByKey(loginTicket, keyValue);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SO_GetReportData(loginTicket, DocNoFrom, DocNoTo, DateFrom, DateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SO_GetSummaryByParam(loginTicket, docNoFrom, docNoTo, docDateFrom, docDateTo);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public SaveResult Update(DataSet saveData)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(saveData);
                byte[] receivedData = client.SO_Update(loginTicket, bs);
                return ZipTools.DecompressionObject(receivedData) as SaveResult;
            }
        }

        public bool Delete(string keyValue)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.SO_Delete(loginTicket, keyValue);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.SO_CheckNoExists(loginTicket, keyValue);
            }
        }

        public void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate)
        {
            using (SalesModuleServiceClient client = SoapClientFactory.CreateSalesModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.SO_ApprovalBusiness(loginTicket, keyValue, flagApp, appUser, appDate);
            }
        }

        #endregion
    }

}
