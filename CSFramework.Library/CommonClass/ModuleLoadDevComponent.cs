///*************************************************************************/
///*
///* 文件名    ：ModuleLoadDevComponent.cs                              
///* 程序说明  : 加载引用Dev控件的模块
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework.Library;
using DevExpress.XtraTab;
using DevExpress.XtraNavBar;
using CSFramework.Common;
using DevExpress.XtraBars;
using CSFramework3.Interfaces;
using System.Windows.Forms;
using CSFramework.Core;

namespace CSFramework.Library
{
    /// <summary>
    /// 加载引用Dev控件的模块
    /// </summary>
    public class ModuleLoadDevComponent : ModuleLoaderBase
    {
        /// <summary>
        /// 每个模块对应一个TabPage, 將模块主窗体的Panel容器集成在主窗体的TabPage页内。
        /// 所有加载的模块主窗体的Panel容器都嵌套在主窗体的TabControl内。
        /// </summary>
        public override void LoadGUI(object mainTabControl)
        {
            if (mainTabControl == null) return;
            if ((mainTabControl is XtraTabControl) == false) return;

            //主窗体的TabControl组件
            XtraTabControl xtraTabControl = mainTabControl as XtraTabControl;

            try
            {
                //获取模块主窗体的Panel容器
                Control container = _ModuleMainForm.GetContainer();

                if (null != container)
                {
                    container.Dock = DockStyle.Fill;
                    XtraTabPage page = new XtraTabPage();
                    page.Tag = _ModuleMainForm; //模块窗体
                    page.Text = _ModuleMainForm.ModuleName;//取模块名称// this.GetCurrentModuleName();
                    page.Controls.Add(container); //嵌套在主窗体的TabControl内
                    xtraTabControl.TabPages.Add(page);
                }
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }
    }
}
