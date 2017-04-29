///*************************************************************************/
///*
///* 文件名    ：IObserver.cs                                
///* 程序说明  : 观察者接口
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
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 发送通知
        /// </summary>
        void Notify();
    }

}
