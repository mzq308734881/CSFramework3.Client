///*************************************************************************/
///*
///* 文件名    ：ColoumnProperty.cs     
///*
///* 程序说明  : 字段属性，一个简单的实体类
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
    /// 字段属性
    /// </summary>
    public class ColoumnProperty
    {
        private string _columnName;
        private bool _isPrimaryKey;

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        public ColoumnProperty(string columnName, bool isPrimaryKey)
        {
            _columnName = columnName;
            _isPrimaryKey = isPrimaryKey;
        }
    }

}
