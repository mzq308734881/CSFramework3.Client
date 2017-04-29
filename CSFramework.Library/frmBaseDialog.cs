///*************************************************************************/
///*
///* 文件名    ：frmBaseDialog.cs                              
///* 程序说明  : 对话框窗体基类
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

namespace CSFramework.Library
{
    /// <summary>
    ///  对话框窗体基类. 
    /// </summary>
    public partial class frmBaseDialog : frmBase
    {
        public frmBaseDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
