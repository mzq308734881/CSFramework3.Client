///*************************************************************************/
///*
///* 文件名    ：AssemblyModuleEntry.cs                                
///* 程序说明  : 模块入口自定义特性.
///*              继承Attribute特性，用于标记该DLL是否系统或业务模块.
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CSFramework.Core;
using CSFramework3.Interfaces;

namespace CSFramework.Core
{
    /// <summary>
    /// 模块入口自定义特性
    /// </summary>
    public class AssemblyModuleEntry : Attribute
    {
        private ModuleID _moduleID;
        private string _moduleName;
        private string _moduleEntryNameSpace;

        /// <summary>
        /// 模块编号
        /// </summary>
        public ModuleID ModuleID { get { return _moduleID; } }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get { return _moduleName; } }

        /// <summary>
        /// 模块名字空间
        /// </summary>
        public string ModuleEntryNameSpace { get { return _moduleEntryNameSpace; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="moduleID">模块编号</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="moduleEntryNameSpace">模块名字空间</param>
        public AssemblyModuleEntry(ModuleID moduleID, string moduleName, string moduleEntryNameSpace)
        {
            _moduleID = moduleID;
            _moduleName = moduleName;
            _moduleEntryNameSpace = moduleEntryNameSpace;
        }

    }

}
