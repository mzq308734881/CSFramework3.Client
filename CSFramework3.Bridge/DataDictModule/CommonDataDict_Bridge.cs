///*************************************************************************/
///*
///* 文件名    ：CommonDataDict_Bridge.cs
///*
///* 程序说明  : 公共数据字典桥接类定义
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
using System.ServiceModel;
using System.Data;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_DataDict;
using CSFramework3.WebServiceReference.WCF_DataDictService;

namespace CSFramework3.Bridge.DataDictModule
{
    public class ADODirect_CommonDataDict
    {
        private IBridge_CommonDataDict _DAL_Instance = null;//数据层实例

        public ADODirect_CommonDataDict()
        {
            _DAL_Instance = new dalCommonDataDict(Loginer.CurrentUser);
        }

        public IBridge_CommonDataDict GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_CommonDataDict : IBridge_CommonDataDict
    {

        public WebService_CommonDataDict()
        {

        }

        #region IBridge_CommonDataDict Members

        public System.Data.DataTable SearchBy(int dataType)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SearchCommonType(loginTicket, dataType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool AddCommonType(int code, string name)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.AddCommonType(loginTicket, code, name);
            }
        }

        public bool DeleteCommonType(int code)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.DeleteCommonType(loginTicket, code);
            }
        }

        public bool IsExistsCommonType(int code)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.IsExistsCommonType(loginTicket, code);
            }
        }

        #endregion
    }
}
