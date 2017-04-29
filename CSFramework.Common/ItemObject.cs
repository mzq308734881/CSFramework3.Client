///*************************************************************************/
///*
///* 文件名    ：ItemObject.cs                                   
///* 程序说明  : 用于扩展Tag标记的自定义对象
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework.Common
{
    /// <summary>
    /// 用于扩展Tag标记的自定义对象
    /// </summary>
    public class TagObject
    {
        private string _KeyName;
        private object _Value;

        public TagObject() { }
        public TagObject(string keyName, object value)
        {
            KeyName = keyName;
            Value = value;
        }

        /// <summary>
        /// 对象引用
        /// </summary>
        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        /// <summary>
        /// 键
        /// </summary>
        public string KeyName
        {
            get { return _KeyName; }
            set { _KeyName = value; }
        }

        /// <summary>
        /// 返回该对象的说明
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return KeyName;
        }
    }

    /// <summary>
    /// 用于扩展.Items集合类型的自定义对象
    /// </summary>
    public class ItemObject : TagObject
    {
        protected object _Tag;

        public ItemObject(string keyName, object value, object tag)
            : this(keyName, value)
        {
            _Tag = tag;
        }

        public ItemObject(string keyName, object value)
            : base(keyName, value)
        {
            _Tag = null;
        }

        public override string ToString()
        {
            return KeyName;
        }

        public object Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }
    }
}
