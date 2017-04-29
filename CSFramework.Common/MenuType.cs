///*************************************************************************/
///*
///* 文件名    ：MenuType.cs                                 
///* 程序说明  : 菜单类型定义
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CSFramework.Common
{
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        Unknow = 0,

        /// <summary>
        /// 模块主菜单(一级菜单)
        /// </summary>
        Module = 1, //

        /// <summary>
        /// 数据窗体菜单
        /// </summary>
        DataForm = 2,

        /// <summary>
        /// 父级菜单(下面有子菜单)
        /// </summary>
        ItemOwner = 3,

        /// <summary>
        /// 报表菜单
        /// </summary>
        Report = 4,

        /// <summary>
        /// 独立功能(用于扩展)
        /// </summary>
        Action = 5,

        /// <summary>
        /// 对话框
        /// </summary>
        Dialog = 6
    }

    /// <summary>
    /// 菜单标记(Tag)
    /// </summary>
    public class MenuItemTag
    {
        private MenuType _type;
        private int _FormAuthorities;
        private int _moduleID;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">菜单类型</param>
        /// <param name="moduleID">模块编号</param>
        /// <param name="formAuthorities">窗体的可用权限</param>
        public MenuItemTag(MenuType type, int moduleID, int formAuthorities)
        {
            _type = type;
            _moduleID = moduleID;
            _FormAuthorities = formAuthorities;
        }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType MenuType { get { return _type; } }

        /// <summary>
        /// 模块编号
        /// </summary>
        public int ModuleID { get { return _moduleID; } }

        /// <summary>
        /// 窗体的可用权限
        /// </summary>
        public int FormAuthorities { get { return _FormAuthorities; } }
    }

}

