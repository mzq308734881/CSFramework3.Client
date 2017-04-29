///*************************************************************************/
///*
///* 文件名    ：ORMTools.cs    
///*
///* 程序说明  :  ORM工具类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CSFramework.ORM
{
    /// <summary>
    /// ORM工具类
    /// </summary>
    public class ORMTools
    {
        /// <summary>
        /// 创建临时表
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTempTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("colName", typeof(System.String)));
            dt.Columns.Add(new DataColumn("colType", typeof(System.String)));
            dt.Columns.Add(new DataColumn("colSqlDbType", typeof(System.String)));
            dt.Columns.Add(new DataColumn("colLength", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("colIsLookup", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("colIsAddOrUpdate", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("colIsPrimaryKey", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("colIsForeignKey", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("colIsNumberKey", typeof(System.Boolean)));
            return dt;
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="tableName">物理表名</param>
        /// <returns></returns>
        public static DataTable GetTableStructure(string connectionString, string tableName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = conn;
            selectCmd.CommandText = "sp_help";
            selectCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter para = new SqlParameter("@objname", tableName);
            selectCmd.Parameters.Add(para);

            SqlDataAdapter da = new SqlDataAdapter(selectCmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            conn.Dispose();

            return ds.Tables[1]; //表结构
        }

        /// <summary>
        /// 创建表结构数据,用于在Grid内显示数据.
        /// </summary>
        /// <param name="dtColumns">从SQL内取到的字段列表</param>
        /// <param name="dbtype">使用数据库定义的字段长度</param>
        /// <returns></returns>
        public static DataTable CreateMapList(DataTable dtColumns, bool dbType)
        {
            DataTable dt = CreateTempTable();

            foreach (DataRow dr in dtColumns.Rows)
            {
                DataRow drStuct = dt.NewRow();
                drStuct["colName"] = dr["Column_Name"];
                drStuct["colType"] = dr["Type"].ToString();
                drStuct["colSqlDbType"] = SqlTypeName2SqlType(dr["Type"].ToString());

                int length = 0;
                if (dbType)
                    length = Convert.ToInt32(dr["Length"]);
                else
                    length = Convert.ToInt32(dr["Type"].ToString() == "numeric" ? dr["Prec"] : dr["Length"]);

                drStuct["colLength"] = length;
                drStuct["colIsLookup"] = false;
                drStuct["colIsAddOrUpdate"] = true;
                drStuct["colIsPrimaryKey"] = false;
                drStuct["colIsNumberKey"] = false;
                drStuct["colIsForeignKey"] = false;

                dt.Rows.Add(drStuct);
            }

            return dt;
        }

        /// <summary>
        /// 将SQLServer数据类型（如：varchar）转换为.Net类型（如：String）
        /// </summary>
        /// <param name="sqlTypeString">SQLServer数据类型</param>
        /// <returns></returns>
        public static string SqlTypeName2DotNetType(string sqlTypeString)
        {
            string[] SqlTypeNames = new string[] { "int", "varchar","bit" ,"datetime","decimal","float","image","money",
                "ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
                "real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary"};

            string[] DotNetTypes = new string[] {"int", "string","bool" ,"DateTime","Decimal","Double","Byte[]","Single",
                "string","string","DateTime","Int16","string","Int64","Byte[]","string","string","Decimal",
                "Single","Single", "Object","Byte[]","Byte","Guid","Byte[]"};

            int i = Array.IndexOf(SqlTypeNames, sqlTypeString.ToLower());

            return DotNetTypes[i];
        }

        /// <summary>
        /// 将SQLServer数据类型名称（如：varchar）转换为.Net中SqlDbType类型（如：SqlDbType.VarChar）
        /// </summary>
        /// <param name="sqlTypeString">SQLServer数据类型名称</param>
        /// <returns></returns>
        public static SqlDbType SqlTypeName2SqlType(string sqlTypeString)
        {
            string[] SqlTypeNames = new string[] { "int", "varchar","bit" ,"datetime","decimal","float","image","money",
                "ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
                "real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary","xml"};

            SqlDbType[] SqlTypes = new SqlDbType[] {SqlDbType.Int,SqlDbType.VarChar,SqlDbType.Bit ,SqlDbType.DateTime,SqlDbType.Decimal,SqlDbType.Float,SqlDbType.Image,SqlDbType.Money,
                SqlDbType.NText,SqlDbType.NVarChar,SqlDbType.SmallDateTime,SqlDbType.SmallInt,SqlDbType.Text,SqlDbType.BigInt,SqlDbType.Binary,SqlDbType.Char,SqlDbType.NChar,SqlDbType.Decimal,
                SqlDbType.Real,SqlDbType.SmallMoney, SqlDbType.Variant,SqlDbType.Timestamp,SqlDbType.TinyInt,SqlDbType.UniqueIdentifier,SqlDbType.VarBinary,SqlDbType.Xml};

            int i = Array.IndexOf(SqlTypeNames, sqlTypeString.ToLower());

            return SqlTypes[i];
        }

        /// <summary>
        /// 获取用户表和视图
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetU_V(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "select * from sysobjects where type in('U','V') order by name ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
