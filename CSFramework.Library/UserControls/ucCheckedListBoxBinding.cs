///*************************************************************************/
///*
///* 文件名    ：ucCheckedListBoxBinding.cs                              
///* 程序说明  : 绑定带分隔符字符串的数据
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
using System.Collections;

namespace CSFramework.Library.UserControls
{
    /// <summary>
    /// 绑定带分隔符字符串的数据
    /// </summary>
    public partial class ucCheckedListBoxBinding : UserControl
    {
        private string _EditValue = "";
        private string _Seperator = ",";

        [DefaultValue(",")]
        [Description("多个值中间的分隔符.如:AA,BB,CC")]
        public string ItemSeperator
        {
            get { return _Seperator; }
            set { _Seperator = value; }
        }

        public ucCheckedListBoxBinding()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return this.EditValue;
            }
            set
            {
                this.EditValue = value;
            }
        }

        [Description("返回列表中已勾选的值,以分隔符隔开")]
        public string EditValue
        {
            get
            {
                _EditValue = this.GetItemCheckedValue();
                return _EditValue;
            }
            set
            {
                _EditValue = value;
                this.SetItemChecked(value);
            }
        }

        public void BindingDataSource(string[] items)
        {
            foreach (string item in items)
            {
                lists.Items.Add(item, item, CheckState.Unchecked, true);
            }
        }

        public void BindingDataSource(DataTable dataSource, string valueMember, string displayMember)
        {
            foreach (DataRow row in dataSource.Rows)
            {
                lists.Items.Add(row[valueMember], row[displayMember].ToString(), CheckState.Unchecked, true);
            }
        }

        private void SetItemChecked(string value)
        {
            string[] items = value.Split(new string[] { _Seperator }, StringSplitOptions.None);

            lists.UnCheckAll();
            foreach (CheckedListBoxItem item in lists.Items)
            {
                foreach (string s in items)
                {
                    if (s.ToLower() == item.Value.ToString().ToLower())
                    {
                        item.CheckState = CheckState.Checked;
                        break;
                    }
                }
            }
        }

        private string GetItemCheckedValue()
        {
            string result = "";
            foreach (CheckedListBoxItem item in lists.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    result = result + "," + item.Value;
                }
            }

            return result == "" ? "" : result + _Seperator;
        }

        private EventHandler _OnCheckStateChanged = null;
        public event EventHandler OnCheckStateChanged
        {
            add { _OnCheckStateChanged += value; }
            remove { _OnCheckStateChanged -= value; }
        }

        private void lists_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_OnCheckStateChanged != null) _OnCheckStateChanged(lists, e);
        }

        private void lists_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_OnCheckStateChanged != null) _OnCheckStateChanged(lists, e);
        }
    }
}
