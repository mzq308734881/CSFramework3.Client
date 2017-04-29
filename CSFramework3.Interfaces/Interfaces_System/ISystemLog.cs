///*************************************************************************/
///*
///* 文件名    ：ISystemLog.cs                                
///* 程序说明  : 系统日志接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// 系统日志接口
    /// </summary>
    public interface ISystemLog
    {
        /// <summary>
        /// 保存系统异常日志
        /// </summary>
        /// <param name="e">系统异常</param>
        /// <param name="reportUser">当前用户</param>
        void WriteException(Exception e, string reportUser);

        /// <summary>
        /// 其它日志
        /// </summary>
        /// <param name="log">日志内容</param>
        /// <param name="reportUser">当前用户</param>
        void WriteLog(string log, string reportUser);
    }
}
