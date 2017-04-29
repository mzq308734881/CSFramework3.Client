///*************************************************************************/
///*
///* 文件名    ：frmChangeTagName.cs    
///*
///* 程序说明  : 修改功能点名称
///*              权限窗体支持25个功能点，这些功能点名称可自定义
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
using CSFramework3.Business;
using CSFramework3.Business.Security;

namespace CSFramework.SystemModule
{
    /// <summary>
    /// 修改功能点名称
    /// </summary>
    public partial class frmChangeTagName : Form
    {
        /// <summary>
        /// 权限功能点对象
        /// </summary>
        private ActionNodeTag _tag;

        /// <summary>
        /// 树结点
        /// </summary>
        private TreeNode _node;

        private frmChangeTagName()
        {
            InitializeComponent();
        }

        private frmChangeTagName(TreeNode node)
        {
            _node = node;
            _tag = node.Tag as ActionNodeTag;
            InitializeComponent();

            this.textEdit1.Text = node.Text;
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <param name="node">树结点</param>
        public static void Execute(TreeNode node)
        {
            frmChangeTagName form = new frmChangeTagName(node);
            form.ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != _tag.TagNameOld)
            {
                if ((_tag.TagNameOld == "") || (_tag.TagNameDataRow == null))
                {//增加记录                    
                    _tag.TagNameDataRow = _tag.TagNameTable.NewRow();
                    _tag.TagNameDataRow["MenuName"] = _tag.TagMenuNameRef;
                    _tag.TagNameDataRow["TagValue"] = _tag.ActionValue;
                    _tag.TagNameDataRow["TagName"] = textEdit1.Text;
                    _tag.TagNameTable.Rows.Add(_tag.TagNameDataRow);
                }
                else
                {
                    _tag.TagNameDataRow["TagName"] = textEdit1.Text;
                }
                _node.Text = textEdit1.Text;
                _node.TreeView.Update();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangeTagName_Shown(object sender, EventArgs e)
        {
            textEdit1.Focus();
        }
    }
}
