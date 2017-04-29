///*************************************************************************/
///*
///* 文件名    ：IMsg.cs                                
///* 程序说明  : 消息显示接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework.Core
{
    /// <summary>
    /// 消息显示接口
    /// </summary>
    public interface IMsg
    {
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        void UpdateMessage(string msg);
    }
}
