
///*************************************************************************/
///*
///* 文件名    ：frmSalesMain.cs   
///* 程序说明  : 销售模块主窗体
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
using CSFramework3.Interfaces;
using CSFramework.Library;
using CSFramework.Common;
using CSFramework3.ReportsFastReport;

namespace CSFramework3.SalesModule
{
    /// <summary>
    /// 销售模块主窗体
    /// </summary>
    public partial class frmSalesMain : CSFramework.Library.frmModuleBase
    {
        public frmSalesMain()
        {
            InitializeComponent();

            _ModuleID = ModuleID.SalesModule; //设置模块编号
            _ModuleName = ModuleNames.SalesModule;//设置模块名称
            menuMainSalesModule.Text = ModuleNames.SalesModule; //与AssemblyModuleEntry.ModuleName定义相同

            this.MainMenuStrip = this.menuMainSalesModule;

            SetMenuTag();
        }

        public override MenuStrip GetModuleMenu()
        {
            return this.menuMainSalesModule;
        }

        /// <summary>
        /// 设置菜单标记。初始化窗体的可用权限
        /// 请参考MenuItemTag类定义
        /// </summary>
        private void SetMenuTag()
        {
            menuMainSalesSystem.Text = ModuleNames.SalesModule; //与AssemblyModuleEntry.ModuleName定义相同
            menuMainSalesSystem.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.SalesModule, AuthorityCategory.NONE);
            menuSalesOrder.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SalesModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemInvoice.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SalesModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemAR.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SalesModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemReports.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.PurchaseModule, AuthorityCategory.NONE);
            menuRpt01.Tag = new MenuItemTag(MenuType.Report, (int)ModuleID.PurchaseModule, AuthorityCategory.REPORT_ACTION_VALUE);
            menuRpt02.Tag = new MenuItemTag(MenuType.Report, (int)ModuleID.PurchaseModule, AuthorityCategory.REPORT_ACTION_VALUE);
            menuRpt03.Tag = new MenuItemTag(MenuType.Report, (int)ModuleID.PurchaseModule, AuthorityCategory.REPORT_ACTION_VALUE);
        }

        /// <summary>
        /// 设置模块主界面的权限
        /// </summary>        
        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                //设置按钮权限
                //SetButtonSecurity(btnStock, (ToolStrip)securityInfo);

                //设置按钮说明Panel的权限
                //panelControl1.Visible = btnStock.Enabled;

                this.LoadReportList(menuItemReports, lbReports);
            }
        }

        private void menuSalesOrder_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmSO), menuSalesOrder);
        }

        private void menuItemInvoice_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmSO), menuItemInvoice);
        }

        private void menuItemAR_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmSO), menuItemAR);
        }

        private void menuRpt01_Click(object sender, EventArgs e)
        {
            frmReportSO.Execute("", "");
        }

        private void menuRpt02_Click(object sender, EventArgs e)
        {
            frmReportSO.Execute("", "");
        }

        private void menuRpt03_Click(object sender, EventArgs e)
        {
            frmReportSO.Execute("", "");
        }

    }
}
