///*************************************************************************/
///*
///* 文件名    ：ORM_ObjectClassAttribute.cs    
///*
///* 程序说明  : 对象关系映射ORM - 数据表对应的实体对象特性定义
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework.ORM
{
    /// <summary>
    /// 对象关系映射ORM - 数据表对应的实体对象特性定义
    /// </summary>
    public class ORM_ObjectClassAttribute : Attribute
    {
        private string _TableName; //物理表名,用于控制生成SQL语句Update (表) ....
        private string _PrimaryKey; //主键, 用于控制生成SQL语句的 Where @key=key
        private bool _isSummaryTable;//是否主表，明细表为false

        /// <summary>
        /// 是否主表，明细表为false
        /// </summary>
        public bool IsSummaryTable { get { return _isSummaryTable; } }

        /// <summary>
        /// 物理表名,用于控制生成SQL语句Update (表) ....
        /// </summary>
        public string TableName { get { return _TableName; } }

        /// <summary>
        /// 主键, 用于控制生成SQL语句的 Where @key=key
        /// </summary>
        public string PrimaryKey { get { return _PrimaryKey; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="tableName">物理表名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="isSummaryTable">是否主表</param>
        public ORM_ObjectClassAttribute(string tableName, string primaryKey, bool isSummaryTable)
        {
            _TableName = tableName;
            _PrimaryKey = primaryKey;
            _isSummaryTable = isSummaryTable;
        }
    }
}
