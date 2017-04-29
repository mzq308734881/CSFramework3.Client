///*************************************************************************/
///*
///* 文件名    ：frmSystemMain.cs                   
///* 程序说明  : 系统管理模块主窗体
///* 原创作者  ：孙中吕 
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
using CSFramework.Library;
using System.Reflection;
using CSFramework3.Interfaces;
using CSFramework.Common;
using DevExpress.XtraEditors;

namespace CSFramework.SystemModule
{
    /// <summary>
    /// 系统管理模块主窗体
    /// </summary>
    public partial class frmSystemMain : frmModuleBase
    {
        public frmSystemMain()
        {
            InitializeComponent();

            _ModuleID = ModuleID.SystemManage; //设置模块编号
            _ModuleName = ModuleNames.SystemManage;//设置模块名称
            menuStrip1.Text = ModuleNames.SystemManage; //与AssemblyModuleEntry.ModuleName定义相同

            this.MainMenuStrip = this.menuStrip1;

            SetMenuTag();
        }

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        private void SetMenuTag()
        {
            menuSystemManager.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
            menuItemUserMgr.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuItemAuth.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuItemSetup.Tag = new MenuItemTag(MenuType.Dialog, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
            menuItemSetup.Tag = new MenuItemTag(MenuType.Dialog, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
            menuCompanyInfo.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuCustomMenuAuth.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.DATA_ACTION_VALUE + ButtonAuthority.EX_01);
            menuLog.Tag = new MenuItemTag(MenuType.Dialog, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
            menuItemBackup.Tag = new MenuItemTag(MenuType.Dialog, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
        }

        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                //SetButtonSecurity(btnUser, menuItemUserMgr);
                //SetButtonSecurity(btnAuth, menuItemAuth);
                //SetButtonSecurity(btnSetup, menuItemSetup);
                //SetButtonSecurity(btnLog, menuLog);
                //SetButtonSecurity(btnCompanyInfo, menuCompanyInfo);
                //SetButtonSecurity(btnCustomMenuAuth, menuCustomMenuAuth);
            }
        }

        private void menuItemUserMgr_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmUser), sender as ToolStripMenuItem);
        }

        private void menuItemAuth_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmGroup), sender as ToolStripMenuItem);
        }

        private void menuCompanyInfo_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCompanyInfo), sender as ToolStripMenuItem);
        }

        private void menuCustomMenuAuth_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmMenuAuth), sender as ToolStripMenuItem);
        }

        private void menuItemSetup_Click(object sender, EventArgs e)
        {
            new frmSystemOptions().ShowDialog();
        }

        private void menuLog_Click(object sender, EventArgs e)
        {
            frmLogConfig.Execute("");
        }

        private void menuItemBackup_Click(object sender, EventArgs e)
        {
            new frmBackupDB().ShowDialog();
        }
    }
}

