///*************************************************************************/
///*
///* 文件名    ：frmModuleBase.cs     
///*
///* 程序说明  : 模块主窗体基类.实现IModuleBase接口。
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSFramework3.Interfaces;
using CSFramework.Common;

namespace CSFramework.Library
{
    /// <summary>
    /// 模块主窗体基类
    /// </summary>
    public partial class frmModuleBase : frmBase, IModuleBase
    {
        protected ModuleID _ModuleID = ModuleID.None;
        protected string _ModuleName = "";

        public frmModuleBase()
        {
            InitializeComponent();
        }

        #region IModuleBase Members

        /// <summary>
        /// 获取模块的主菜单
        /// </summary>
        /// <returns></returns>
        public virtual MenuStrip GetModuleMenu()
        {
            return null;
        }

        /// <summary>
        /// 模块编号
        /// </summary>
        /// <returns></returns>
        public virtual ModuleID ModuleID { get { return _ModuleID; } }

        /// <summary>
        /// 模块名称
        /// </summary>
        /// <returns></returns>
        public virtual string ModuleName { get { return _ModuleName; } }

        //模块主窗体容器
        public virtual Control GetContainer()
        {
            return this.pnlContainer;
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        public virtual void InitButton()
        {
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        public virtual void InitMenu()
        {
        }

        #endregion

        /// <summary>
        /// 模块主窗体上的按钮事件
        /// </summary>
        public virtual void OnButtonClick(object sender, EventArgs e)
        {
            if (sender == null) return;

            if (sender is Control)
            {
                if ((sender as Control).Tag != null)
                {
                    ToolStripItem item = (sender as Control).Tag as ToolStripItem;
                    item.PerformClick();
                }
            }
        }

        /// <summary>
        /// 设置模块主窗体的权限.
        /// </summary>
        /// <param name="securityInfo">权限信息(系统主菜单或自它自定义对象)</param>
        public virtual void SetSecurity(object securityInfo) { }

        /// <summary>
        /// 加载自定义报表
        /// </summary>
        /// <param name="menuReports">报表菜单</param>
        /// <param name="lbReports">报表项显示控件</param>
        protected void LoadReportList(ToolStripMenuItem menuReports, ImageListBoxControl lbReports)
        {
            lbReports.ImageList = this.ilReports;

            foreach (ToolStripItem item in menuReports.DropDownItems)
            {
                if (item is ToolStripSeparator) continue;
                lbReports.Items.Add(new ItemObject(item.Text, item), 0);
            }
            lbReports.Click += new EventHandler(OnReportsClick);
        }

        /// <summary>
        /// 打开报表, 实际是调用菜单的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnReportsClick(object sender, EventArgs e)
        {
            ItemObject item = (sender as ImageListBoxControl).SelectedValue as ItemObject;
            if ((item != null) && (item.Value is ToolStripItem))
                (item.Value as ToolStripItem).PerformClick();
        }

    }
}