///*************************************************************************/
///*
///* 文件名    ：ucDT_CustomerLookup.cs                              
///* 程序说明  : 客户选择框用户控件.
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
using DevExpress.XtraEditors.Controls;
using CSFramework3.Business;

namespace CSFramework.Library.UserControls
{
    /// <summary>
    /// 客户选择框用户控件
    /// </summary>
    public partial class ucDT_CustomerLookup : UserControl
    {
        private string _ValueMember = "CustomerCode";
        private string _DisplayMember = "NativeName";
        private string _AttributeCodes = ",";
        private bool _ShowEnglishName = false;
        private bool _NameWithCode = true;

        public ucDT_CustomerLookup()
        {
            InitializeComponent();
        }

        private void ucDT_CustomerLookup_Load(object sender, EventArgs e)
        {
            //
        }

        public override string Text
        {
            get
            {
                return (string)this.EditValue;
            }
            set
            {
                this.EditValue = value;
            }
        }

        public object EditValue
        {
            get
            {
                return lookUpEdit.EditValue;
            }
            set
            {
                lookUpEdit.EditValue = value;
            }
        }

        [Description("下拉窗体的栏位列表")]
        public LookUpColumnInfoCollection VisibleColumns
        {
            get { return lookUpEdit.Properties.Columns; }
        }

        [Description("用于取值的字段名称")]
        public string defValueMember
        {
            get { return _ValueMember; }
            set { _ValueMember = value; }
        }

        [Description("用于显示的字段名称")]
        public string defDisplayMember
        {
            get { return _DisplayMember; }
            set { _DisplayMember = value; }
        }

        [Description("客户属性")]
        public string defAttributeCodes
        {
            get { return _AttributeCodes; }
            set { _AttributeCodes = value; }
        }

        [Description("显示客户的英文名")]
        [DefaultValue(true)]
        public bool defShowEnglishName
        {
            get { return _ShowEnglishName; }
            set
            {
                _ShowEnglishName = value;

                if (_ShowEnglishName)
                {
                    _DisplayMember = "EnglishName";
                }
                else
                {
                    _DisplayMember = "NativeName";
                }
            }
        }

        [Description("客户名称前面显示编号")]
        [DefaultValue(true)]
        public bool defNameWithCode
        {
            get { return _NameWithCode; }
            set { _NameWithCode = value; }
        }

        /// <summary>
        /// 获取客户数据
        /// </summary>
        public void DoRetriveData()
        {
            DataTable data = new bllCustomer().GetCustomerByAttributeCodes(_AttributeCodes, _NameWithCode);
            this.DoBindingDataSource(data);
        }

        /// <summary>
        /// 绑定自定义数据
        /// </summary>
        /// <param name="datasource"></param>
        public void DoBindingDataSource(DataTable datasource)
        {
            lookUpEdit.Properties.Columns[1].FieldName = _DisplayMember;//客户名称
            lookUpEdit.Properties.ValueMember = _ValueMember;
            lookUpEdit.Properties.DisplayMember = _DisplayMember;
            lookUpEdit.Properties.DataSource = datasource;
        }

    }
}
