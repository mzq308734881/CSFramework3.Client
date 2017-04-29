///*************************************************************************/
///*
///* 文件名    ：IFormBase.cs                                
///* 程序说明  : 基类窗体接口
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
    /// 基类窗体接口
    /// </summary>
    public interface IFormBase
    {
        /// <summary>
        /// 设置窗体皮肤
        /// </summary>
        void LoadSkin();

        /// <summary>
        /// 设置窗体皮肤
        /// </summary>
        /// <param name="skinName">名称</param>
        void SetSkin(string skinName);
    }
}
