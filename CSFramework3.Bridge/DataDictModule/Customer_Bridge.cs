
///*************************************************************************/
///*
///* 文件名    ：Customer_Bridge.cs
///*
///* 程序说明  : 客户数据字典桥接类定义
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
using CSFramework.Core;
using CSFramework.Common;
using System.Data;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_DataDict;
using CSFramework3.WebServiceReference.WCF_DataDictService;

namespace CSFramework3.Bridge.DataDictModule
{
    /// <summary>
    /// 客户管理的ADO Direct桥接功能
    /// </summary>
    public class ADODirect_Customer
    {
        //数据层实例,实现桥接口IBridge_Customer
        private IBridge_Customer _DAL_Instance = null;

        //构造器
        public ADODirect_Customer()
        {
            _DAL_Instance = new dalCustomer(Loginer.CurrentUser);
        }

        //获取桥接功能实例
        public IBridge_Customer GetInstance()
        {
            return _DAL_Instance;
        }
    }

    /// <summary>
    /// 客户管理WebService桥接功能
    /// </summary>
    public class WebService_Customer : IBridge_Customer
    {

        public WebService_Customer()
        {
        }

        #region IBridge_Customer 成员

        public DataTable SearchBy(string CustomerFrom, string CustomerTo, string Name, string Attribute)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.FuzzySearchCustomer(loginTicket, CustomerFrom, CustomerTo, Name, Attribute);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable GetCustomerByAttributeCodes(string attributeCodes, bool nameWithCode)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetCustomerByAttributeCodes(loginTicket, attributeCodes, nameWithCode);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable FuzzySearch(string content)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.FuzzySearchCustomerByContent(loginTicket, content);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable FuzzySearch(string attributeCodes, string content)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.FuzzySearchCustomerByAttributes(loginTicket, attributeCodes, content);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        #endregion
    }
}
