///*************************************************************************/
///*
///* 文件名    ：IFuzzySearchSupportable.cs                                
///* 程序说明  : 支持模糊查询的接口,用于frmFuzzySearch窗体
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// 支持模糊查询的接口,用于frmFuzzySearch窗体
    /// </summary>
    public interface IFuzzySearchSupportable
    {
        string FuzzySearchName { get; }
        DataTable FuzzySearch(string content);
    }
}
