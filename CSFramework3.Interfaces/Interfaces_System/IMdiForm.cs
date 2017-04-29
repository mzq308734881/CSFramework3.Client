///*************************************************************************/
///*
///* 文件名    ：IMdiForm.cs                                
///* 程序说明  : MDI主窗体接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// MDI主窗体接口
    /// </summary>
    public interface IMdiForm
    {
        /// <summary>
        ///主窗体的工具栏 
        /// </summary>
        IToolbarRegister MdiToolbar { get; set; }

        /// <summary>
        /// 主窗体的观察者
        /// </summary>
        IObserver[] MdiObservers { get; }

        /// <summary>
        /// 注册主窗体工具栏的按钮
        /// </summary>
        void RegisterMdiButtons();

        /// <summary>
        /// 主窗体上的按钮集合
        /// </summary>
        IList MdiButtons { get; }

        /// <summary>
        /// 所有模块主菜单的集合
        /// </summary>
        MenuStrip MainMenu { get; }

        /// <summary>
        /// 显示模块的主窗体
        /// </summary>
        void ShowModuleContainerForm();
    }
}
