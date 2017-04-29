///*************************************************************************/
///*
///* 文件名    ：ucValueEdit.cs                              
///* 程序说明  : 编号-标题自定义控件.
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
using System.Drawing.Design;
using System.Collections;
using DevExpress.XtraEditors;

namespace CSFramework.Library.UserControls
{
    /// <summary>
    /// 编号-标题自定义控件.
    /// </summary>
    public partial class ucValueEdit : UserControl
    {
        private DataTable _ItemsData;
        private string _Seperator = "-";
        private string[] _ItemsValue = new string[] { };

        public ucValueEdit()
        {
            InitializeComponent();

            _ItemsData = new DataTable();
            _ItemsData.Columns.Add("Value", typeof(string));
            _ItemsData.Columns.Add("Name", typeof(string));

            _InnerLookUpEdit.Properties.DisplayMember = "Name";
            _InnerLookUpEdit.Properties.ValueMember = "Value";
            _InnerLookUpEdit.Properties.DataSource = _ItemsData;
        }

        private void ucValueEdit_Load(object sender, EventArgs e)
        {
            SetItems(_ItemsValue);
        }

        private void ucValueEdit_SizeChanged(object sender, EventArgs e)
        {
            _InnerLookUpEdit.Width = this.Width;
            this.Height = _InnerLookUpEdit.Height;
        }

        [Category("Appearance")]
        [Description("嵌套的LookUpEdit控件")]
        public LookUpEdit InnerLookupEdit
        {
            get { return _InnerLookUpEdit; }
        }

        [DefaultValue("-")]
        [Description("值与显示名称中间的分隔符.如:A - 类型A")]
        public string ItemValueSeperator
        {
            get { return _Seperator; }
            set { _Seperator = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design", typeof(UITypeEditor))]
        [Category("Appearance")]
        [Description("自定义数据列表.如: A - 类型A ")]
        public string[] Items
        {
            get { return _ItemsValue; }
            set { SetItems(value); }
        }

        /// <summary>
        /// 将String[]转换为DataTable
        /// </summary>
        /// <param name="values"></param>
        private void SetItems(string[] values)
        {
            _ItemsValue = values;
            _ItemsData.Rows.Clear();

            if (values.Length == 0) return;

            string[] P;
            foreach (string item in values)
            {
                string V = ""; string N = "";
                if (item.Trim() != "")
                {
                    P = item.Split(new char[] { char.Parse(_Seperator) });
                    V = P.Length >= 1 ? P[0] : "";
                    N = P.Length == 2 ? P[1] : "";
                }
                _ItemsData.Rows.Add(new object[] { V, N });
            }

            this.RefreshDataSource();
        }

        private void RefreshDataSource()
        {
            _InnerLookUpEdit.Properties.DataSource = null;
            _InnerLookUpEdit.Properties.DataSource = _ItemsData;
        }

    }
}
