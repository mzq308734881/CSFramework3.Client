///*************************************************************************/
///*
///* 文件名    ：GenerateSqlCmdBase.cs    
///*
///* 程序说明  : ＳＱＬ命令生成器基类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace CSFramework.ORM
{
    /// <summary>
    /// ＳＱＬ命令生成器基类
    /// </summary>
    public class GenerateSqlCmdBase : IGenerateSqlCommand
    {
        //Insert SQL语句
        protected string _sqlInsert = string.Empty;

        //Update SQL语句
        protected string _sqlUpdate = string.Empty;

        //Delete SQL语句
        protected string _sqlDelete = string.Empty;

        //Insert SQL命令
        protected SqlCommand _cmdInsert = null;

        //Update SQL命令
        protected SqlCommand _cmdUpdate = null;

        //Delete SQL命令
        protected SqlCommand _cmdDelete = null;

        /// <summary>
        /// 单号字段名
        /// </summary>
        protected string _DocNoFieldName = string.Empty;

        /// <summary>
        /// 主键字段名
        /// </summary>
        protected string _PrimaryFieldName = string.Empty;

        /// <summary>
        /// 外键字段名
        /// </summary>
        protected string _ForeignFieldName = string.Empty;

        /// <summary>
        /// 是否主表
        /// </summary>
        protected bool _IsSummary = true;

        /// <summary>
        /// 获取单号字段名
        /// </summary>
        /// <returns></returns>
        public string GetDocNoFieldName() { return _DocNoFieldName; }

        /// <summary>
        /// 获取主键字段名
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryFieldName() { return _PrimaryFieldName; }

        /// <summary>
        /// 获取外键字段名
        /// </summary>
        /// <returns></returns>
        public string GetForeignFieldName() { return _ForeignFieldName; }

        /// <summary>
        /// 是否主表
        /// </summary>
        /// <returns></returns>
        public bool IsSummary() { return _IsSummary; }


        /// <summary>
        /// 生成插入记录的SQL命令
        /// </summary>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public SqlCommand GetInsertCommand(SqlTransaction tran)
        {
            _cmdInsert.CommandText = _sqlInsert;
            _cmdInsert.Connection = tran.Connection;
            _cmdInsert.Transaction = tran;
            return _cmdInsert;
        }

        /// <summary>
        /// 生成更新记录的SQL命令
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        public SqlCommand GetUpdateCommand(SqlTransaction tran)
        {
            _cmdUpdate.CommandText = _sqlUpdate;
            _cmdUpdate.Connection = tran.Connection;
            _cmdUpdate.Transaction = tran;
            return _cmdUpdate;
        }


        /// <summary>
        /// 生成删除记录的SQL命令
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        public SqlCommand GetDeleteCommand(SqlTransaction tran)
        {
            _cmdDelete.CommandText = _sqlDelete;
            _cmdDelete.Connection = tran.Connection;
            _cmdDelete.Transaction = tran;
            return _cmdDelete;
        }

        #region 生成SQL语句

        /// <summary>
        /// 生成插入记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        public string GernerateInsertSql(string tableName, string keyName, IList field)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into " + tableName + " ( ");
                foreach (ColoumnProperty colProper in field)
                {
                    sb.Append("[" + colProper.ColumnName + "],");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(" ) values ( ");
                foreach (ColoumnProperty colProper in field)
                {
                    sb.Append("@" + colProper.ColumnName + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(" )");
                return sb.ToString();
            }
            catch
            { return string.Empty; }
        }

        /// <summary>
        /// 生成更新记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        public string GernerateUpdateSql(string tableName, string keyName, IList field)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Update " + tableName + " set ");
                foreach (ColoumnProperty colProper in field)
                {
                    if (!colProper.IsPrimaryKey)
                        sb.Append("[" + colProper.ColumnName + "]=@" + colProper.ColumnName + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(" where 1=1 " + SplitKeyName(keyName));
                return sb.ToString();
            }
            catch
            { return string.Empty; }
        }

        /// <summary>
        /// 生成删除记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        public string GernerateDeleteSql(string tableName, string keyName, IList field)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Delete " + tableName + " where 1=1" + SplitKeyName(keyName));
                return sb.ToString();
            }
            catch
            { return string.Empty; }
        }

        /// <summary>
        /// 复合主键处理
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        protected string SplitKeyName(string keyName)
        {
            StringBuilder strBuilder = new StringBuilder();
            string[] arrayStr = keyName.Split(',');
            foreach (string tempKeyName in arrayStr)
            {
                if (tempKeyName == "") continue;
                strBuilder.Append(" and " + tempKeyName + "=@" + tempKeyName);
            }

            return strBuilder.ToString();
        }

        #endregion
    }
}
