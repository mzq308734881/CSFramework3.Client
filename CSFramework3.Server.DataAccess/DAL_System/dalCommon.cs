///*************************************************************************/
///*
///* 文件名    ：dalCommon.cs                                
///* 程序说明  : 公共数据层
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework3.Interfaces.Interfaces_Bridge;
using System.Data;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_Base;
using System.Data.SqlClient;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    public class dalCommon : dalBase, IBridge_CommonData
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="user">当前用户登录信息</param>
        public dalCommon(Loginer user) : base(user) { }

        public bool TestConnection()
        {
            string sql = "SELECT COUNT(*) FROM tb_DataSet";

            //取系统数据库的帐套数据表
            object o = DataProvider.Instance.ExecuteScalar(Globals.DEF_SYSTEM_DB, sql);
            return true;
        }

        public DataTable GetSystemDataSet()
        {
            string sql = "SELECT * FROM tb_DataSet";

            //取系统数据库的帐套数据表
            return DataProvider.Instance.GetTable(Globals.DEF_SYSTEM_DB, sql, "tb_DataSet");
        }

        /// <summary>
        /// 获取物理表的字段
        /// </summary>
        /// <param name="tableName">物理表名</param>
        /// <returns></returns>
        public DataTable GetTableFields(string tableName)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_sys_GetTableFieldType");
            sp.AddParam("@TableName", SqlDbType.VarChar, 50, tableName);
            return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, "tb_TableFieldTypeData");
        }

        /// <summary>
        /// 获取业务单据名称定义
        /// </summary>
        /// <returns></returns>
        public DataTable GetBusinessTables()
        {
            string SQL = "SELECT * FROM sys_BusinessTables ORDER BY ModuleID,SortID";
            return DataProvider.Instance.GetTable(_Loginer.DBName, SQL, "sys_BusinessTables");
        }

        /// <summary>
        /// 获取模块名称定义
        /// </summary>
        /// <returns></returns>
        public DataTable GetModules()
        {
            return DataProvider.Instance.GetTable(_Loginer.DBName, "SELECT * FROM sys_Modules", "sys_Modules");
        }

        /// <summary>
        /// 获取表的所有字段
        /// </summary>
        /// <param name="tableName">表名</param>
        public DataTable GetTableFieldsDef(string tableName, bool onlyDisplayField)
        {
            string flag = onlyDisplayField ? "N" : "Y";
            string sql = "sp_sys_GetTableFieldsForPicker '" + tableName + "','" + flag + "' ";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "Fields");
        }


        public DataTable GetDB4Backup()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT DBName,DataSetName FROM dbo.tb_DataSet");
            sb.AppendLine("UNION ");
            sb.AppendLine("SELECT 'CSFramework3.System','系统数据库'");

            //取系统数据库里的资料表
            return DataProvider.Instance.GetTable(Globals.DEF_SYSTEM_DB, sb.ToString(), "DB");
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="DBNAME">数据名称。如：CSFramework22.Normal</param>
        /// <param name="BKPATH">备份路径。如：C:\</param>
        public bool BackupDatabase(string DBNAME, string BKPATH)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("p_BackupDB");
            sp.AddParam("@DBNAME", SqlDbType.NVarChar, 100, DBNAME);
            sp.AddParam("@BKPATH", SqlDbType.NVarChar, 260, BKPATH);
            DataProvider.Instance.ExecuteNoQuery(Globals.DEF_MASTER_DB, sp.SqlCommand);
            return true;
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="BKFILE">备份的文件。如：C:\CSFramework22.Normal_2010.bak</param>
        /// <param name="DBNAME">数据名称。如：CSFramework22.Normal</param>
        public bool RestoreDatabase(string BKFILE, string DBNAME)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("p_RestoreDB");
            sp.AddParam("@BKFILE", SqlDbType.NVarChar, 1000, BKFILE);
            sp.AddParam("@DBNAME", SqlDbType.NVarChar, 100, DBNAME);
            DataProvider.Instance.ExecuteNoQuery(Globals.DEF_MASTER_DB, sp.SqlCommand);
            return true;
        }

        /// <summary>
        /// 获取备份历史记录
        /// </summary>
        /// <param name="topList">返回的记录数</param>
        /// <returns></returns>
        public DataTable GetBackupHistory(int topList)
        {
            string sql = "SELECT TOP " + topList.ToString() + " * FROM sys_BackupHistory ORDER BY BackupTime DESC ";
            return DataProvider.Instance.GetTable(Globals.DEF_MASTER_DB, sql, "sys_BackupHistory");
        }

        public string GetDataSN(string dataCode, bool asHeader)
        {
            SqlConnection conn = DataProvider.Instance.CreateConnection(_Loginer.DBName);
            string no = DocNoTool.GetDataSN(conn, dataCode, asHeader);
            conn.Close();
            return no;
        }


        public DataTable SearchOutstanding(string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType)
        {
            //outstandingType:AR/AP/ALL

            if (outstandingType == "AR")
            {
                SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_QueryOutstandingAR");
                sp.AddParam("@InvoiceNo", SqlDbType.VarChar, 20, invoiceNo);
                sp.AddParam("@CustomerCode", SqlDbType.VarChar, 20, customer);
                sp.AddParam("@FromDate", SqlDbType.VarChar, 8, ConvertEx.ToCharYYYYMMDD(dateFrom));
                sp.AddParam("@ToDate", SqlDbType.VarChar, 8, ConvertEx.ToCharYYYYMMDD(dateTo));
                sp.AddParam("@EndDate", SqlDbType.VarChar, 8, ConvertEx.ToCharYYYYMMDD(dateEnd));
                return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, "Outstanding" + outstandingType);
            }

            if (outstandingType == "AP")
            {
                SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_QueryOutstandingAP");
                sp.AddParam("@InvoiceNo", SqlDbType.VarChar, 20, invoiceNo);
                sp.AddParam("@SupplierCode", SqlDbType.VarChar, 20, customer);
                sp.AddParam("@FromDate", SqlDbType.VarChar, 8, ConvertEx.ToCharYYYYMMDD(dateFrom));
                sp.AddParam("@ToDate", SqlDbType.VarChar, 8, ConvertEx.ToCharYYYYMMDD(dateTo));
                sp.AddParam("@EndDate", SqlDbType.VarChar, 8, ConvertEx.ToCharYYYYMMDD(dateEnd));
                return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, "Outstanding" + outstandingType);
            }

            return null;
        }

    }
}
