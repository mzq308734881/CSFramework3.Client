
///*************************************************************************/
///*
///* 文件名    ：CommonData.cs      
///
///* 程序说明  : 系统公共数据
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.Common;
using CSFramework3.Models;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Bridge;
using CSFramework3.Interfaces;

namespace CSFramework3.Business
{
    /// <summary>
    /// 系统公共数据
    /// </summary>
    public class CommonData
    {
        private static TCompanyInfo _CompanyInfo = null;

        /// <summary>
        /// 公司资料
        /// </summary>
        public static TCompanyInfo CompanyInfo
        {
            get { return _CompanyInfo; }
        }

        /// <summary>
        /// 获取系统所需公共信息
        /// </summary>
        public static void GetCommonInfos()
        {
            bllCompanyInfo bll = new bllCompanyInfo();
            bll.GetSummaryData(false);

            //获取公司资料
            DataTable dt = bll.SummaryTable;
            if (dt.Rows.Count > 0)
                _CompanyInfo = (TCompanyInfo)DataConverter.DataRowToObject(dt.Rows[0], typeof(TCompanyInfo));
            else
                _CompanyInfo = new TCompanyInfo();
        }

        /// <summary>
        /// 获取系统业务表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBusinessTables()
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetBusinessTables();
        }

        public static string GetDataSN(string dataCode, bool asHeader)
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetDataSN(dataCode, asHeader);
        }

        /// <summary>
        /// 获取系统模块
        /// </summary>
        /// <returns></returns>
        public static DataTable GetModules()
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetModules();
        }

        /// <summary>
        /// 获取表的所有字段
        /// </summary>
        /// <param name="tableName">表名</param>
        public static DataTable GetTableFieldsDef(string tableName, bool onlyDisplayField)
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetTableFieldsDef(tableName, onlyDisplayField);
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetDataDict(string tableName)
        {
            IBridge_DataDict bridge = BridgeFactory.CreateDataDictBridge(tableName, "");
            return bridge.GetSummaryData();
        }

        /// <summary>
        /// 获取帐套
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSystemDataSet()
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetSystemDataSet();
        }

        public DataTable GetDB4Backup()
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetDB4Backup();
        }

        public DataTable GetBackupHistory(int topList)
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.GetBackupHistory(topList);
        }

        public bool BackupDatabase(string DBNAME, string BKPATH)
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.BackupDatabase(DBNAME, BKPATH);
        }

        public bool RestoreDatabase(string BKFILE, string DBNAME)
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.RestoreDatabase(BKFILE, DBNAME);
        }

        public static DataTable SearchOutstanding(string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType)
        {
            IBridge_CommonData bridge = BridgeFactory.CreateCommonDataBridge();
            return bridge.SearchOutstanding(invoiceNo, customer, dateFrom, dateTo, dateEnd, outstandingType);
        }
    }
}
