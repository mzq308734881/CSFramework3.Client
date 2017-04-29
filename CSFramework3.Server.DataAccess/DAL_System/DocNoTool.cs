///*************************************************************************/
///*
///* 文件名    ：DocNoTool.cs                                
///* 程序说明  : 单据号码管理工具
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CSFramework.Common;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 单据号码管理工具
    /// </summary>
    public class DocNoTool
    {
        /// <summary>
        /// 在同一事务内生成单号
        /// </summary>
        /// <param name="tran">当前事务</param>
        /// <param name="DocNoName">单据名称</param>
        /// <returns></returns>
        public static string GetNumber(SqlTransaction tran, string DocNoName)
        {
            SqlCommand cmd = new SqlCommand("sp_GetNo '" + DocNoName + "'", tran.Connection, tran);
            object no = cmd.ExecuteScalar();
            return ConvertEx.ToString(no);
        }

        public static string GetDataSN(SqlTransaction tran, string dataCode, bool asHeader)
        {
            string SQL = "sp_GetDataSN '" + dataCode + "','" + (asHeader ? "Y" : "N") + "'";
            SqlCommand cmd = new SqlCommand(SQL, tran.Connection, tran);
            object no = cmd.ExecuteScalar();
            return ConvertEx.ToString(no);
        }

        public static string GetDataSN(SqlConnection conn, string dataCode, bool asHeader)
        {
            string SQL = "sp_GetDataSN '" + dataCode + "','" + (asHeader ? "Y" : "N") + "'";
            SqlCommand cmd = new SqlCommand(SQL, conn);
            object no = cmd.ExecuteScalar();
            return ConvertEx.ToString(no);
        }

    }
}
