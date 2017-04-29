///*************************************************************************/
///*
///* 文件名    ：frmBase.cs                              
///* 程序说明  : 所有窗体基类,继承XtraForm用于设置皮肤
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
using CSFramework.Common;
using CSFramework3.Interfaces;

namespace CSFramework.Library
{
    /// <summary>
    /// 所有窗体基类,继承XtraForm用于设置皮肤
    /// </summary>
    public partial class frmBase : XtraForm, IFormBase
    {

        public DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel;

        public frmBase()
        {
            InitializeComponent();
            this.DefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.LoadSkin();
        }

        #region IFormBase 成員

        /// <summary>
        /// 加载皮肤
        /// </summary>
        public void LoadSkin()
        {
            if (SystemConfig.CurrentConfig != null) SetSkin(SystemConfig.CurrentConfig.SkinName);
        }

        /// <summary>
        /// 设置窗体皮肤
        /// </summary>
        /// <param name="skinName">名称</param>
        public void SetSkin(string skinName)
        {
            this.DefaultLookAndFeel.LookAndFeel.SkinName = skinName;
        }

        #endregion
    }
}