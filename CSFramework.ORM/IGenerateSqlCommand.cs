///*************************************************************************/
///*
///* 文件名    ：IGenerateSqlCommand.cs    
///*
///* 程序说明  : SQL生成器接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;

namespace CSFramework.ORM
{
    /// <summary>
    /// SQL生成器接口
    /// </summary>
    public interface IGenerateSqlCommand
    {
        /// <summary>
        /// 生成插入记录的SQL命令
        /// </summary>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        SqlCommand GetInsertCommand(SqlTransaction tran);

        /// <summary>
        /// 生成更新记录的SQL命令
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        SqlCommand GetUpdateCommand(SqlTransaction tran);

        /// <summary>
        /// 生成删除记录的SQL命令
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        SqlCommand GetDeleteCommand(SqlTransaction tran);

        /// <summary>
        /// 生成插入记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        string GernerateInsertSql(string tableName, string keyName, IList field);

        /// <summary>
        /// 生成更新记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        string GernerateUpdateSql(string tableName, string keyName, IList field);

        /// <summary>
        /// 生成删除记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        string GernerateDeleteSql(string tableName, string keyName, IList field);

        /// <summary>
        /// 单据号码
        /// </summary>
        /// <returns></returns>
        string GetDocNoFieldName();

        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        string GetPrimaryFieldName();

        /// <summary>
        /// 外键
        /// </summary>
        /// <returns></returns>
        string GetForeignFieldName();

        /// <summary>
        /// 是否主表
        /// </summary>
        /// <returns></returns>
        bool IsSummary();
    }
}
