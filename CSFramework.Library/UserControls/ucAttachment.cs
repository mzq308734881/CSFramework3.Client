///*************************************************************************/
///*
///* 文件名    ：ucAttachment.cs                              
///* 程序说明  : 附件管理自定义控件
///*               这个控件只是个载体, 具体业务由实现IAttachmentStorage接口的类完成. 
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CSFramework3.Business;
using CSFramework.Common;
using CSFramework3.Interfaces;

namespace CSFramework.Library.UserControls
{
    /// <summary>
    /// 提交附件资料的事件
    /// </summary>
    /// <param name="data">附件资料</param>
    public delegate void PostAttachmentData(object data);

    /// <summary>
    /// 附件管理自定义控件.    
    /// </summary>
    public partial class ucAttachment : UserControl
    {
        //是否立即提交数据
        private bool _ImmediatelyPost = false;

        //附件管理存储策略
        private IAttachmentStorage _Storage = null; 

        /// <summary>
        /// 附件管理策略
        /// </summary>
        public IAttachmentStorage StorateStrategy
        {
            get { return _Storage; }
            set { _Storage = value; }
        }

        public ucAttachment()
        {
            InitializeComponent();
        }

        private void ucAttachment_Load(object sender, EventArgs e)
        {
            //
        }

        private PostAttachmentData _OnPostAttachmentData;

        /// <summary>
        /// 保存附件数据
        /// </summary>
        [Description("保存附件数据")]
        public event PostAttachmentData OnPostAttachmentData
        {
            add { _OnPostAttachmentData += value; }
            remove { _OnPostAttachmentData -= value; }
        }

        /// <summary>
        /// 即时提交数据
        /// </summary>
        [DefaultValue(false)]
        [Description("即时提交数据")]
        public bool ImmediatelyPost
        {
            get { return _ImmediatelyPost; }
            set { _ImmediatelyPost = value; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //检查文件名是否存在
                if (_Storage.Exists(Path.GetFileName(dlg.FileName)))
                    Msg.Warning("附件已经存在！");
                else
                {
                    _Storage.AddFile(dlg.FileName);
                    if (_ImmediatelyPost && (_OnPostAttachmentData != null))
                        _OnPostAttachmentData(_Storage.AttachmentStorage);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gvSummary.IsValidRowHandle(gvSummary.FocusedRowHandle))
            {
                if (Msg.AskQuestion("确定要删除此附件吗？"))
                {
                    string fileName = gvSummary.GetDataRow(gvSummary.FocusedRowHandle)["FileName"].ToString();
                    _Storage.DeleteFile(fileName);
                    if (_ImmediatelyPost && (_OnPostAttachmentData != null))
                        _OnPostAttachmentData(_Storage.AttachmentStorage);
                }
            }
            else
            {
                Msg.Warning("请选择一个附件！");
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (gvSummary.IsValidRowHandle(gvSummary.FocusedRowHandle))
            {
                string fileName = gvSummary.GetDataRow(gvSummary.FocusedRowHandle)["FileName"].ToString();
                _Storage.SaveAs(fileName);
            }
            else
            {
                Msg.Warning("请选择一个附件！");
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (gvSummary.IsValidRowHandle(gvSummary.FocusedRowHandle))
            {
                string fileName = gvSummary.GetDataRow(gvSummary.FocusedRowHandle)["FileName"].ToString();
                _Storage.OpenFile(fileName);
            }
            else
            {
                Msg.Warning("请选择一个附件！");
            }
        }

        /// <summary>
        /// 绑定表格控件的数据源
        /// </summary>
        public void DoBindDataSource()
        {
            if (_Storage != null)
            {
                gcSummary.DataSource = null;
                gcSummary.DataSource = _Storage.AttachmentStorage;
            }
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        public void DoRejectChanges()
        {
            _Storage.AttachmentStorage.RejectChanges();
            this.DoBindDataSource();
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="currentState">按钮状态</param>
        public void DoSetButtonState(UpdateType currentState)
        {
            bool onEditMode = (currentState == UpdateType.Modify) || (currentState == UpdateType.Add);
            btnAdd.Enabled = onEditMode;
            btnDel.Enabled = onEditMode;

            menuDrop.Enabled = onEditMode; //删除

            //不受状态控制
            btnSaveAs.Enabled = true;//另存为
            menuOpen.Enabled = true;
            menuSaveAs.Enabled = true;
        }

        private void ucAttachment_SizeChanged(object sender, EventArgs e)
        {
            colFileTitle.Width = this.Width - colIconSmall.Width - 15;
        }
    }
}
