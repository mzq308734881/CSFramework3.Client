///*************************************************************************/
///*
///* 文件名    ：ILogSupportable.cs                                
///* 程序说明  : 支持写入日志的接口
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
    /// 支持写入日志的接口
    /// </summary>
    public interface ILogSupportable
    {
        /// <summary>
        /// 写入单表日志
        /// </summary>        
        void WriteLog(DataTable original, DataTable changes);

        /// <summary>
        /// 写入多个表的日志,TableIndex=0:主表,1..n为明细表
        /// </summary>
        /// <param name="changes"></param>
        void WriteLog(DataSet original, DataSet changes);
    }
}
