
///*************************************************************************/
///*
///* 文件名    ：Product_Bridge.cs
///*
///* 程序说明  : 产品数据字典桥接单元
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
using System.Reflection;
using CSFramework.Common;
using System.Data;
using CSFramework.Core;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_DataDict;
using CSFramework3.WebServiceReference.WCF_DataDictService;

namespace CSFramework3.Bridge.DataDictModule
{
    public class ADODirect_Product
    {
        private IBridge_Product _DAL_Instance = null;//数据层实例

        public ADODirect_Product()
        {
            _DAL_Instance = new dalProduct(Loginer.CurrentUser);
        }

        public IBridge_Product GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_Product : IBridge_Product
    {
        public WebService_Product()
        {
        }

        #region IBridge_Product 成员

        public DataTable FuzzySearch(string content)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.FuzzySearchProduct(loginTicket, content);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        #endregion
    }

}
