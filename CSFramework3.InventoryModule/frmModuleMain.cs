
///*************************************************************************/
///*
///* 文件名    ：frmModuleMain.cs    
///*
///* 程序说明  :  库存模块主窗体
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

namespace CSFramework3.InventoryModule
{
    /// <summary>
    /// 库存模块主窗体
    /// </summary>
    public partial class frmModuleMain : CSFramework.Library.frmModuleBase
    {
        public frmModuleMain()
        {
            InitializeComponent();

            _ModuleID = ModuleID.InventoryModule; //设置模块编号
            _ModuleName = ModuleNames.InventoryModule;//设置模块名称
            menuStrip1.Text = ModuleNames.InventoryModule; //与AssemblyModuleEntry.ModuleName定义相同

            this.MainMenuStrip = this.menuStrip1;

            this.SetMenuTag();
        }

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        private void SetMenuTag()
        {
            menuMainInventory.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.InventoryModule, AuthorityCategory.NONE);
            menuItemCheck.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.InventoryModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemAdj.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.InventoryModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuItemStockIn.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.InventoryModule, AuthorityCategory.BUSINESS_ACTION_VALUE + ButtonAuthority.GENERATE);
            menuItemStockOut.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.InventoryModule, AuthorityCategory.BUSINESS_ACTION_VALUE + ButtonAuthority.GENERATE);
        }

        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                //设置按钮权限
                btnAdj.Enabled = menuItemAdj.Enabled;
                btnCheck.Enabled = menuItemCheck.Enabled;
                btnStockIn.Enabled = menuItemStockIn.Enabled;
                btnStockOut.Enabled = menuItemStockOut.Enabled;
            }

            // this.LoadReportList(menuItemReports, lbReports);
        }

        private void menuItemCheck_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmIC), menuItemCheck);
        }

        private void menuItemAdj_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmIA), menuItemAdj);
        }

        private void menuItemStockIn_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmIN), menuItemStockIn);
        }

        private void menuItemStockOut_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmIO), menuItemStockOut);
        }

    }
}

