///*************************************************************************/
///*
///* 文件名    ：IButtonList.cs                                
///* 程序说明  : 按钮列表接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// 按钮列表接口
    /// </summary>
    public interface IButtonList
    {
        /// <summary>
        /// 添加一组按钮
        /// </summary>
        /// <param name="buttons">按钮对象数组</param>
        void AddRange(IButtonInfo[] buttons);

        /// <summary>
        /// 添加一组按钮
        /// </summary>
        /// <param name="buttons">按钮对象集合</param>
        void AddRange(IList buttons);

        /// <summary>
        /// 跟据名称获取某个按钮
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns></returns>
        IButtonInfo GetButtonByName(string name);

        /// <summary>
        /// 转换为按钮数组
        /// </summary>
        /// <returns></returns>
        IButtonInfo[] ToArray();

        /// <summary>
        /// 转换为按钮对象集合
        /// </summary>
        /// <returns></returns>
        IList ToList();
    }
}
