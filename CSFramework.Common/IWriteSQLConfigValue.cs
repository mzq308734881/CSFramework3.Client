///*************************************************************************/
///*
///* 文件名    ：IWriteSQLConfigValue.cs                                     
///* 程序说明  : 存储SQL连接配置的接口
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
    /// 存储SQL连接配置的接口
    /// </summary>
    public interface IWriteSQLConfigValue
    {
        /// <summary>
        /// 写入SQL的连接配置信息
        /// </summary>
        void Write();

        /// <summary>
        /// 读取SQL的连接配置信息
        /// </summary>
        void Read();

        /// <summary>
        /// SQL Server Name/IP
        /// </summary>
        string ServerName { get; set; }

        /// <summary>
        /// 连接的数据库
        /// </summary>
        string InitialCatalog { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        string BuildConnectionString();
    }

}


