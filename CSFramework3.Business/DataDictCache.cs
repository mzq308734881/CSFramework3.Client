///*************************************************************************/
///*
///* 文件名    ：DataDictCache.cs      
///
///* 程序说明  : 数据字典缓存数据
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework3.Bridge;


namespace CSFramework3.Business
{
    /*
     数据字典缓存数据
     */
    public class DataDictCache
    {

        private DataDictCache() { } /*私有构造器,不允许外部创建实例*/

        #region 缓存数据唯一实例

        private static DataDictCache _Cache = null;

        /// <summary>
        /// 缓存数据唯一实例
        /// </summary>
        public static DataDictCache Cache
        {
            get
            {
                if (_Cache == null)
                {
                    _Cache = new DataDictCache();
                    _Cache.DownloadBaseCacheData();//下载基本数据                    
                }
                return _Cache;
            }
        }
        #endregion

        #region 外部使用的静态方法

        /// <summary>
        /// 刷新缓存数据
        /// </summary>
        public static void RefreshCache()
        {
            DataDictCache.Cache.DownloadBaseCacheData();
        }

        /// <summary>
        /// 刷新单个数据字典
        /// </summary>
        /// <param name="tableName">字典表名</param>
        public static void RefreshCache(string tableName)
        {
            DataTable cache = DataDictCache.Cache.GetCacheTableData(tableName);

            if (cache != null) //有客户窗体引用缓存数据时才更新
            {
                IBridge_DataDict bridge = BridgeFactory.CreateDataDictBridge(tableName, "");
                DataTable data = bridge.GetDataDictByTableName(tableName);
                cache.Rows.Clear();
                foreach (DataRow row in data.Rows) cache.ImportRow(row);
                cache.AcceptChanges();
            }
        }

        #endregion

        #region 2.数据表缓存数据. 局域变易及属性定义

        private DataSet _AllDataDicts = null;

        private DataTable _BusinessTables = null;
        public DataTable BusinessTables { get { return _BusinessTables; } }

        private DataTable _StockType = null;
        public DataTable StockType { get { return _StockType; } }

        private DataTable _Currency = null;
        public DataTable Currency { get { return _Currency; } }

        private DataTable _PayType = null;
        public DataTable PayType { get { return _PayType; } }

        private DataTable _User = null; //用户表
        public DataTable User { get { return _User; } }

        private DataTable _Person = null; //营销员
        public DataTable Person { get { return _Person; } }

        private DataTable _Storage = null; //仓库
        public DataTable Storage { get { return _Storage; } }

        private DataTable _Unit = null;
        public DataTable Unit { get { return _Unit; } }

        private DataTable _DepartmentData = null;
        public DataTable DepartmentData { get { return _DepartmentData; } }

        private DataTable _CustomerAttributes = null;
        public DataTable CustomerAttributes { get { return _CustomerAttributes; } }

        private DataTable _Bank = null;
        public DataTable Bank { get { return _Bank; } }

        private DataTable _CommonDataDictType = null;
        public DataTable CommonDataDictType { get { return _CommonDataDictType; } }

        private DataTable _Location = null;
        public DataTable Location { get { return _Location; } }

        #endregion


        public void DownloadBaseCacheData()
        {
            IBridge_DataDict bridge = BridgeFactory.CreateDataDictBridge("");

            //下载小字典表数据
            _AllDataDicts = bridge.DownloadDicts();

            //跟据存储过程返回数据表的顺序取
            _BusinessTables = _AllDataDicts.Tables[1];
            _User = _AllDataDicts.Tables[2];
            _Person = _AllDataDicts.Tables[3];
            _CustomerAttributes = _AllDataDicts.Tables[4];
            _Bank = _AllDataDicts.Tables[5];
            _CommonDataDictType = _AllDataDicts.Tables[6];
            _PayType = _AllDataDicts.Tables[7];
            _Currency = _AllDataDicts.Tables[8];
            _Location = _AllDataDicts.Tables[9];
            _DepartmentData = _AllDataDicts.Tables[10];

            //调用数据表名
            _AllDataDicts.Tables[1].TableName = sys_BusinessTables.__TableName;
            _AllDataDicts.Tables[2].TableName = TUser.__TableName;
            _AllDataDicts.Tables[3].TableName = tb_Person.__TableName;
            _AllDataDicts.Tables[4].TableName = tb_CustomerAttribute.__TableName;
            _AllDataDicts.Tables[5].TableName = "#Bank"; //tb_CommDataDictType表的银行类别的记录
            _AllDataDicts.Tables[6].TableName = tb_CommDataDictType.__TableName;
            _AllDataDicts.Tables[7].TableName = tb_PayType.__TableName;
            _AllDataDicts.Tables[8].TableName = tb_Currency.__TableName;
            _AllDataDicts.Tables[9].TableName = tb_Location.__TableName;
            _AllDataDicts.Tables[10].TableName = "#Dept"; //tb_CommDataDictType表的部门类别的记录

        }

        /// <summary>
        /// 跟据表名取数据表实例
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <returns></returns>
        private DataTable GetCacheTableData(string tableName)
        {
            foreach (DataTable dt in _AllDataDicts.Tables)
            {
                if (dt.TableName.ToUpper() == tableName.ToUpper()) return dt;
            }

            DataTable cache = null;
            //if (tableName == tb_CommDataDictType.__TableName) cache = _CommonDataDictType;            
            return cache;
        }

        /// <summary>
        ///删除字典数据某一行数据
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <param name="keyField">主键</param>
        /// <param name="key">主键值</param>
        public void DeleteCacheRow(string tableName, string keyField, string key)
        {
            DataTable cach = this.GetCacheTableData(tableName);
            if (cach != null)
            {
                DataRow[] rows = cach.Select(keyField + "='" + key + "'");
                if (rows.Length > 0)
                    cach.Rows.Remove(rows[0]);
                cach.AcceptChanges();
            }
        }
    }
}
