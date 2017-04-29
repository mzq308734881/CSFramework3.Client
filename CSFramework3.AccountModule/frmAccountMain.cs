
///*************************************************************************/
///*
///* 文件名    ：frmAccountMain.cs    
///* 程序说明  : 财务模块主窗体
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
using CSFramework.Common;
using CSFramework.Library;
using CSFramework3.Interfaces;

namespace CSFramework3.AccountModule
{
    public partial class frmAccountMain : CSFramework.Library.frmModuleBase
    {

        public frmAccountMain()
        {
            InitializeComponent();

            _ModuleID = ModuleID.AccountModule; //设置模块编号
            _ModuleName = ModuleNames.AccountModule;//设置模块名称
            menuStrip1.Text = ModuleNames.AccountModule; //与AssemblyModuleEntry.ModuleName定义相同

            this.MainMenuStrip = this.menuStrip1;

            this.SetMenuTag();
        }

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        private void SetMenuTag()
        {
            menuAccountMain.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.AccountModule, AuthorityCategory.NONE);
            menuItemAR.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.AccountModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemAP.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.AccountModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemOutstanding.Tag = new MenuItemTag(MenuType.Dialog, (int)ModuleID.AccountModule, AuthorityCategory.NONE);
        }

        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                this.LoadReportList(menuReports, listReports);
            }
        }

        private void menuItemAR_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmAR), menuItemAR);
        }

        private void menuItemAP_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmAP), menuItemAP);
        }

        private void menuItemOutstanding_Click(object sender, EventArgs e)
        {
            frmQueryOutstanding.Execute_Query(OutstandingType.None);
        }

        private void menuARRpt_Click(object sender, EventArgs e)
        {
            CSFramework3.ReportsFastReport.frmReportAR.Execute("", "");
        }

        private void menuAPRpt_Click(object sender, EventArgs e)
        {
           CSFramework3.ReportsFastReport.frmReportAP.Execute("", "");
        }

    }
}
