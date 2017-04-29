///*************************************************************************/
///*
///* 文件名    ：UpdateType.cs                                      
///* 程序说明  : 数据窗体的操作类型
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
    /// 数据窗体的操作类型
    /// </summary>
    public enum UpdateType
    {
        None,

        /// <summary>
        /// 新增状态
        /// </summary>
        Add,

        /// <summary>
        /// 修改状态
        /// </summary>
        Modify
    }
}
