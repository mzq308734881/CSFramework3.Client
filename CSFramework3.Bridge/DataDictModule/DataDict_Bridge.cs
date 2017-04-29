
///*************************************************************************/
///*
///* 文件名    ：DataDict_Bridge.cs
///*
///* 程序说明  : 数据字典基类桥接定义
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
using CSFramework.Core;
using CSFramework.Common;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_Base;
using System.Reflection;
using System.Globalization;
using CSFramework3.Server.DataAccess.DAL_DataDict;
using CSFramework3.WebServiceReference.WCF_DataDictService;

namespace CSFramework3.Bridge.DataDictModule
{
    /// <summary>
    /// 数据字典的数据层桥接功能
    /// </summary>
    public class ADODirect_DataDict
    {
        //数据层实例
        private IBridge_DataDict _DAL_Instance = null;

        public ADODirect_DataDict(Type ORM)
        {
            //创建数据层的实例
            _DAL_Instance = dalBaseDataDict.CreateDalByORM(Loginer.CurrentUser, ORM.FullName);
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="derivedClassName">派生类的类名.如xxx.xx.x.dalProduct.(未指定类名则创建基类实例)</param>
        public ADODirect_DataDict(string derivedClassName)
        {
            //创建数据层的实例
            if (String.IsNullOrEmpty(derivedClassName))
            {
                _DAL_Instance = new dalBaseDataDict(Loginer.CurrentUser);
            }
            else
            {
                _DAL_Instance = dalBaseDataDict.CreateDalByClassName(Loginer.CurrentUser, derivedClassName);
            }
        }

        ///// <summary>
        ///// 构造器
        ///// </summary>
        ///// <param name="ORM">ORM类</param>
        ///// <param name="derivedClassName">派生类的类名,如xxx.xx.x.dalProduct,xxx.xx.x.dalPerson</param>
        //public ADODirect_DataDict(Type ORM, string derivedClassName)
        //    : this(derivedClassName)
        //{
        //    _DAL_Instance.ORM = ORM;
        //}

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="derivedClassName">派生类的类名,如xxx.xx.x.dalProduct,xxx.xx.x.dalPerson</param>
        public ADODirect_DataDict(string tableName, string derivedClassName)
            : this(derivedClassName)
        {
            _DAL_Instance.TableName = tableName;
        }

        public IBridge_DataDict GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_DataDict : IBridge_DataDict
    {
        private Type _ORM;
        private string _TableName;

        public WebService_DataDict()
        {
        }

        public WebService_DataDict(Type ORM)
            : this()
        {
            _ORM = ORM;

        }

        public WebService_DataDict(string tableName)
            : this()
        {
            _TableName = tableName;
        }

        #region IBridge_DataDict Members

        public Type ORM { get { return _ORM; } set { _ORM = value; } }
        public string TableName { get { return _TableName; } set { _TableName = value; } }

        public DataTable GetDataDictByTableName(string tableName)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataDictByTableName(loginTicket, tableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataSet DownloadDicts()
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.DownloadDicts(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public DataTable GetDataByKey(string key)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataByKey(loginTicket, _ORM.FullName, key);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSummaryData()
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetSummaryData(loginTicket, _ORM.FullName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool Update(System.Data.DataSet data)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(data);
                return client.Update(loginTicket, bs, _ORM.FullName);
            }
        }

        public SaveResultEx UpdateEx(System.Data.DataSet data)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(data);
                byte[] rt = client.UpdateEx(loginTicket, bs, _ORM.FullName);
                return (SaveResultEx)ZipTools.DecompressionObject(rt);
            }
        }

        public bool Delete(string keyValue)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.Delete(loginTicket, keyValue, _ORM.FullName);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (DataDictServiceClient client = SoapClientFactory.CreateDataDictClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.CheckNoExists(loginTicket, keyValue, _ORM.FullName);
            }
        }

        #endregion
    }

}
