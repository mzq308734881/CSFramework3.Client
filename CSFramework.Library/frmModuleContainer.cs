///*************************************************************************/
///*
///* 文件名    ：frmModuleContainer.cs     
///*
///* 程序说明  : 模块主窗体容器
///*              用于加载模块的主窗体, 组合到MDI主窗体的TabPageControl中.
///*              (每个TabPageControl.TabPage页嵌套一个模块主界面)
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
using System.Collections;
using CSFramework3.Interfaces;

namespace CSFramework.Library
{
    /// <summary>
    /// 模块主窗体容器
    /// </summary>
    public partial class frmModuleContainer : CSFramework.Library.frmBaseChild
    {
        public frmModuleContainer()
        {
            InitializeComponent();
        }

        private void frmModuleContainer_Load(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// 显示模块主窗体容器的按钮
        /// </summary>
        public override void InitButtons()
        {
            IMdiForm mdi = (IMdiForm)this.MdiParent;
            _buttons.AddRange(mdi.MdiButtons);

            _buttons.GetButtonByName("btnClose").Enable = false;
            this.ControlBox = false;
        }
    }
}
