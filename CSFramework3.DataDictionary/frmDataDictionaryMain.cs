
///*************************************************************************/
///*
///* 文件名    ：frmDataDictionaryMain.cs    
///*
///* 程序说明  :  数据字典模块主窗体(演示用)
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

namespace CSFramework3.DataDictionary
{
    /// <summary>
    /// 数据字典模块主窗体(演示用)
    /// </summary>
    public partial class frmDataDictionaryMain : frmModuleBase
    {
        public frmDataDictionaryMain()
        {
            InitializeComponent();

            _ModuleID = ModuleID.DataDictionary; //设置模块编号
            _ModuleName = ModuleNames.DataDictionary;//设置模块名称
            menuMainDataDict.Text = ModuleNames.DataDictionary; //与AssemblyModuleEntry.ModuleName定义相同

            this.MainMenuStrip = this.menuStrip1;

            this.SetMenuTag();
        }

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        /// <summary>
        /// 设置菜单的权限，窗体的可用权限
        /// 请参考MenuItemTag类定义
        /// </summary>
        private void SetMenuTag()
        {
            menuMainDataDict.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.DataDictionary, AuthorityCategory.NONE);
            menuSales.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataDictionary, AuthorityCategory.MASTER_ACTION);
            menuCommonDataDict.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataDictionary, AuthorityCategory.MASTER_ACTION);
            menuItemCustomer.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataDictionary, AuthorityCategory.MASTER_ACTION);
            menuProduct.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataDictionary, AuthorityCategory.MASTER_ACTION);
            menuItemTestChild.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataDictionary, AuthorityCategory.MASTER_ACTION + ButtonAuthority.EX_01);
        }

        /// <summary>
        /// 设置模块主界面的按钮访问权限
        /// </summary>        
        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                btnSales.Enabled = menuSales.Enabled;
                btnCommonDataDict.Enabled = menuCommonDataDict.Enabled;
                btnCustomer.Enabled = menuItemCustomer.Enabled;
                btnProduct.Enabled = menuProduct.Enabled;
            }
        }

        // 菜单的Click事件与按钮的Click事件绑定同一个事件.
        private void menuItemCustomer_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCustomer), menuItemCustomer);
        }

        private void menuSales_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmPerson), menuSales);
        }

        private void menuCommonDataDict_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCommonDataDict), menuCommonDataDict);
        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmProduct), menuProduct);
        }

        private void menuLevel3_Click(object sender, EventArgs e)
        {
            Msg.ShowInformation("三级菜单打开窗体");
        }

        private void menuItemTestChild_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmTestChild), menuItemTestChild);
        }
    }
}

