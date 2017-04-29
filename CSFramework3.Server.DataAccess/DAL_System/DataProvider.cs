///*************************************************************************/
///*
///* 文件名    ：DataProvider.cs                                
///* 程序说明  : SQLServer数据库访问层
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using CSFramework.Common;
using CSFramework.Core;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// SQLServer数据库访问层
    /// </summary>
    public class DataProvider
    {
        /// <summary>
        /// 访问层实例
        /// </summary>
        private static DataProvider _Instance = null;

        /// <summary>
        ///  访问层实例
        /// </summary>
        public static DataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataProvider();
                }

                return _Instance;
            }
        }

        /// <summary>
        /// 创建指定帐号的SQL连接.
        /// </summary>
        /// <param name="DBName">帐套的数据库名或系统数据库名</param>
        /// <returns></returns>
        public SqlConnection CreateConnection(string DBName)
        {
            //下面的代码是按帐套创建数据库连接
            if (String.IsNullOrEmpty(DBName)) throw new Exception("没指定帐套，无法获取数据！");

            string sConn;

            //连接系统数据库，取连接配置参数(INI文件)
            if (DBName == Globals.DEF_SYSTEM_DB)
                sConn = SqlConfiguration.CurrentConnectionString;
            else if (DBName == Globals.DEF_MASTER_DB)
            {
                sConn = SqlConfiguration.CurrentConnectionString;
                sConn = sConn.Replace(Globals.DEF_SYSTEM_DB, Globals.DEF_MASTER_DB);
            }
            else
            {
                //连接帐套数据库
                DataRow current = DataSetCache.FindDataSet(DBName);
                if (current == null) throw new Exception("无效的帐套数据库名！");

                //连接帐套数据库, 要跟据帐套参数定义创建连接字符串 
                sConn = "Server={0};Database={1};User ID={2};Password={3};Connection TimeOut=180;";
                sConn = String.Format(sConn,
                    current["ServerIP"].ToString(),
                    current["DBName"].ToString(),
                    current["DBUserName"].ToString(),
                    current["DBUserPassword"].ToString());
            }

            SqlConnection conn = new SqlConnection(sConn);
            if (conn.State != ConnectionState.Connecting) conn.Open();
            return conn;
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="sql">SQL 查询语句</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        public DataTable GetTable(string DBName, string sql, string tableName)
        {
            SqlConnection conn = this.CreateConnection(DBName);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable(tableName);
            adp.Fill(dt);

            conn.Close();
            conn.Dispose();
            return dt;
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="command">SQL查询命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        public DataTable GetTable(string DBName, SqlCommand command, string tableName)
        {
            SqlConnection connection = command.Connection;
            try
            {
                if (command.Connection == null) command.Connection = this.CreateConnection(DBName);
                DataTable table = new DataTable(tableName);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                this.CloseConnection(connection);
                return table;
            }
            catch (System.Exception ex)
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 获取多个数据表(数据集）
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="sql">SQL查询语句</param>
        /// <returns></returns>
        public DataSet GetDataSet(string DBName, string sql)
        {
            SqlConnection conn = this.CreateConnection(DBName);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);

            conn.Close();
            conn.Dispose();
            return ds;
        }

        /// <summary>
        /// 执行SQL命令，并返回查询结果的第一行的第一列。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public object ExecuteScalar(string DBName, string sql)
        {
            SqlConnection conn = this.CreateConnection(DBName);
            SqlCommand cmd = new SqlCommand(sql, conn);
            object o = cmd.ExecuteScalar();
            conn.Close();
            conn.Dispose();
            return o;
        }

        /// <summary>
        /// 执行SQL语句并返回受影响的行数。
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecuteNoQuery(string DBName, string sql)
        {
            SqlConnection conn = this.CreateConnection(DBName);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int ret = cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            return ret;
        }


        /// <summary>
        /// 在事务内提交数据
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="SQL">SQL语句</param>
        /// <returns></returns>
        public int ExecuteNoQuery(SqlTransaction trans, string SQL)
        {
            SqlCommand cmd = new SqlCommand(SQL, trans.Connection, trans);
            int iValue = cmd.ExecuteNonQuery();
            return iValue;
        }


        /// <summary>
        /// 执行SQL语句并返回受影响的行数。
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="command">SQL命令</param>
        /// <returns></returns>
        public int ExecuteNoQuery(string DBName, SqlCommand command)
        {
            SqlConnection connection = command.Connection;
            try
            {
                if (command.Connection == null) command.Connection = this.CreateConnection(DBName);
                int ret = command.ExecuteNonQuery();
                this.CloseConnection(connection);
                return ret;
            }
            catch (System.Exception ex)
            {
                this.CloseConnection(connection);
                throw ex;
            }
        }

        /// <summary>
        /// 执行SQL命令返回第一行第一列的值
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="command">SQL命令</param>
        /// <returns></returns>
        public object ExecuteScalar(string DBName, SqlCommand command)
        {
            SqlConnection connection = command.Connection;
            try
            {
                if (command.Connection == null) command.Connection = this.CreateConnection(DBName);
                object ret = command.ExecuteScalar();
                this.CloseConnection(connection);
                return ret;
            }
            catch (System.Exception ex)
            {
                this.CloseConnection(connection);
                throw ex;
            }
        }

        /// <summary>
        /// 在事务内提交数据
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="SQL">SQL语句</param>
        /// <returns></returns>
        public object ExecuteScalar(SqlTransaction trans, string SQL)
        {
            SqlCommand cmd = new SqlCommand(SQL, trans.Connection, trans);
            object ret = cmd.ExecuteScalar();
            return ret;
        }

        /// <summary>
        /// 执行SQL语句并返回受影响的行数。
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="command">SQL命令</param>
        /// <returns></returns>
        public int ExecuteSQL(string DBName, SqlCommand command)
        {
            SqlConnection connection = command.Connection;
            try
            {
                if (command.Connection == null) command.Connection = this.CreateConnection(DBName);
                int iValue = command.ExecuteNonQuery();
                this.CloseConnection(connection);
                return iValue;
            }
            catch (System.Exception ex)
            {
                this.CloseConnection(connection);
                throw ex;
            }
        }
        /// <summary>
        /// 执行SQL语句并返回受影响的行数。
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="command">SQL命令</param>
        /// <returns></returns>
        public int ExecuteSQL(string DBName, string SQL)
        {
            SqlConnection connection = this.CreateConnection(DBName);
            try
            {
                SqlCommand cmd = new SqlCommand(SQL, connection);
                int iValue = cmd.ExecuteNonQuery();
                this.CloseConnection(connection);
                return iValue;
            }
            catch (System.Exception ex)
            {
                this.CloseConnection(connection);
                throw ex;
            }
        }

        /// <summary>
        /// 在事务内提交数据
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="SQL">SQL语句</param>
        /// <returns></returns>
        public int ExecuteSQL(SqlTransaction trans, string SQL)
        {
            SqlCommand cmd = new SqlCommand(SQL, trans.Connection, trans);
            int iValue = cmd.ExecuteNonQuery();
            return iValue;
        }

        /// <summary>
        /// 获取多个数据表(数据集）
        /// </summary>
        /// <param name="DBName">帐套的数据库名</param>
        /// <param name="command">SQL命令</param>
        /// <returns></returns>
        public DataSet GetDataSet(string DBName, SqlCommand command)
        {
            SqlConnection connection = command.Connection;
            try
            {
                if (command.Connection == null) command.Connection = this.CreateConnection(DBName);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                this.CloseConnection(connection);
                return ds;
            }
            catch (System.Exception ex)
            {
                this.CloseConnection(connection);
                throw ex;
            }
        }

        /// <summary>
        /// 关闭SQL连接
        /// </summary>
        /// <param name="connection">当前连接</param>
        private void CloseConnection(SqlConnection connection)
        {
            if (connection == null) return;
            if (connection.State != ConnectionState.Closed) connection.Close();
        }

    }

    /// <summary>
    ///系统帐套缓存数据
    /// </summary>
    public class DataSetCache
    {
        /// <summary>
        /// 帐套数据
        /// </summary>
        private static DataTable _SystemDataSets = null;

        /// <summary>
        /// 帐套数据
        /// </summary>
        public static DataTable SystemDataSets
        {
            get
            {
                if (_SystemDataSets == null)
                {
                    _SystemDataSets = new dalCommon(null).GetSystemDataSet();
                }

                return _SystemDataSets;
            }
        }

        public static DataRow FindDataSet(string DBName)
        {
            DataRow[] rows = SystemDataSets.Select("DBName='" + DBName + "'");
            if (rows.Length > 0)
                return rows[0];
            else
                return null;
        }

    }

}
