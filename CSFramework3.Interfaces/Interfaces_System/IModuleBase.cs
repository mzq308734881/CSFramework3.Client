///*************************************************************************/
///*
///* 文件名    ：IModuleBase.cs                                
///* 程序说明  : 模块主窗体接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace CSFramework3.Interfaces
{

    /// <summary>
    /// 模块主窗体接口
    /// </summary>
    public interface IModuleBase
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        /// <returns></returns>
        ModuleID ModuleID { get; }

        /// <summary>
        /// 模块名称
        /// </summary>
        /// <returns></returns>
        string ModuleName { get; }

        /// <summary>
        /// 模块主窗体的菜单
        /// </summary>
        /// <returns></returns>
        MenuStrip GetModuleMenu();

        /// <summary>
        /// 模块主窗体功能按钮所在的容器 
        /// </summary>
        /// <returns></returns>
        Control GetContainer();

        /// <summary>
        /// 设置模块的权限
        /// </summary>
        /// <param name="securityInfo">权限信息</param>
        void SetSecurity(object securityInfo);

        /// <summary>
        /// 初始化模块主窗体的按钮
        /// </summary>
        void InitButton();

        /// <summary>
        /// 初始化模块主窗体的菜单
        /// </summary>
        void InitMenu();
    }

    /// <summary>
    /// 模块信息
    /// </summary>
    public class ModuleInfo
    {
        private Assembly _ModuleAssembly = null;
        private ModuleID _ModuleID = ModuleID.None;
        private string _ModuleName = string.Empty;
        private string _ModuleFile = string.Empty;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="asm">模块的程序集</param>
        /// <param name="id">模块编号</param>
        /// <param name="name">模块名称</param>
        /// <param name="file">模块文件</param>
        public ModuleInfo(Assembly asm, ModuleID id, string name, string file)
        {
            _ModuleAssembly = asm;
            _ModuleFile = file;
            _ModuleID = id;
            _ModuleName = name;
        }

        /// <summary>
        /// 加载DLL文件后存储程序集的对象引用
        /// </summary>
        public Assembly ModuleAssembly
        {
            get { return _ModuleAssembly; }
            set { _ModuleAssembly = value; }
        }

        /// <summary>
        /// 模块文件(*.DLL)
        /// </summary>
        public string ModuleFile
        {
            get { return _ModuleFile; }
            set { _ModuleFile = value; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }

        /// <summary>
        /// 模块编号
        /// </summary>
        public ModuleID ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }
    }
}
