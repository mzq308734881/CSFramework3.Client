///*************************************************************************/
///*
///* 文件名    ：ORM_FieldAttribute.cs    
///*
///* 程序说明  : 对象关系映射ORM - 字段特性定义
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework.ORM
{
    /// <summary>
    /// 对象关系映射ORM - 字段特性定义
    /// </summary>
    public class ORM_FieldAttribute : Attribute
    {
        private SqlDbType _type; //数据类型
        private int _size; //字段长度
        private bool _isLookup;//是否是视图或Lookup字段
        private bool _isAddOrUpdate;//是否需要更新的字段
        private bool _isPrimaryKey; //是否主键字段  isid/ 32bit string
        private bool _isForeignKey;//是否外键字段 isid /32bit string
        private bool _isDocFieldName;//是否单据号码 
        
        /// <summary>
        /// SqlDbType数据类型
        /// </summary>
        public SqlDbType Type { get { return _type; } }

        /// <summary>
        /// 字段长度
        /// </summary>
        public int Size { get { return _size; } }

        /// <summary>
        /// 是否视图或Lookup参照字段(参照字段不能新增和修改)
        /// </summary>
        public bool IsLookup { get { return _isLookup; } }

        /// <summary>
        /// 是否更新字段
        /// </summary>
        public bool IsAddOrUpdate { get { return _isAddOrUpdate; } }

        /// <summary>
        /// 是否主键字段
        /// </summary>
        public bool IsPrimaryKey { get { return _isPrimaryKey; } }

        /// <summary>
        /// 是否外键字段
        /// </summary>
        public bool IsForeignKey { get { return _isForeignKey; } }

        /// <summary>
        /// 是否单据号码
        /// </summary>
        public bool IsDocFieldName { get { return _isDocFieldName; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="size">字段长度</param>
        /// <param name="islookup">是否是视图或Lookup字段</param>
        /// <param name="isAddorUpdate">是否需要更新的字段</param>
        /// <param name="isPrimaryKey">是否主键字段</param>
        /// <param name="isForeignKey">是否外键字段</param>
        /// <param name="isDocFieldName">是否单据号码</param>
        public ORM_FieldAttribute(SqlDbType type, int size,
            bool islookup, bool isAddorUpdate, bool isPrimaryKey,
            bool isForeignKey, bool isDocFieldName)
        {
            _type = type;
            _size = size;
            _isLookup = islookup;
            _isAddOrUpdate = isAddorUpdate;
            _isPrimaryKey = isPrimaryKey;
            _isForeignKey = isForeignKey;
            _isDocFieldName = isDocFieldName;
        }

    }
}
