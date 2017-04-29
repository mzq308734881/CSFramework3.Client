
///*************************************************************************/
///*
///* 文件名    ：AR_Bridge.cs
///*
///* 程序说明  : 财务模块应收款数据层桥接单元
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
using CSFramework3.WebServiceReference.WCF_AccountModuleService;

namespace CSFramework3.Bridge.SalesModule
{
    /// <summary>
    /// DAL层桥接功能
    /// </summary>
    public class ADODirect_AR
    {
        private IBridge_AR _DAL_Instance = null;//数据层实例

        public ADODirect_AR()
        {
            _DAL_Instance = new dalAR(Loginer.CurrentUser);
        }

        public IBridge_AR GetInstance()
        {
            return _DAL_Instance;
        }
    }

    /// <summary>
    /// WEB服务桥接功能代理层
    /// </summary>
    public class WebService_AR : IBridge_AR
    {

        public WebService_AR()
        {
        }

        #region IBridge_AR 成员

        public System.Data.DataSet GetBusinessByKey(string keyValue)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.AR_GetBusinessByKey(loginTicket, keyValue);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.AR_GetSummaryByParam(loginTicket, docNoFrom, docNoTo, docDateFrom, docDateTo);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public SaveResult Update(DataSet saveData)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(saveData);
                byte[] receivedData = client.AR_Update(loginTicket, bs);
                return ZipTools.DecompressionObject(receivedData) as SaveResult;
            }
        }

        public bool Delete(string keyValue)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.AR_Delete(loginTicket, keyValue);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.AR_CheckNoExists(loginTicket, keyValue);
            }
        }

        public void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.AR_ApprovalBusiness(loginTicket, keyValue, flagApp, appUser, appDate);
            }
        }

            /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.AR_GetReportData(loginTicket, DocNoFrom, DocNoTo, DateFrom, DateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public DataSet GetReportData_Checklist(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            using (AccountModuleServiceClient client = SoapClientFactory.CreateAccountModuleServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.AR_GetReportData_Checklist(loginTicket, DocNoFrom, DocNoTo, DateFrom, DateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        #endregion
    }

}
