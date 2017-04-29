///*************************************************************************/
///*
///* 文件名    ：ucCheckedListBoxEditor.cs                              
///* 程序说明  : 支持输入的CheckedListBox控件.
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

namespace CSFramework.Library.UserControls
{
    /// <summary>
    /// 支持输入的CheckedListBox控件.
    /// </summary>
    public partial class ucCheckedListBoxEditor : UserControl
    {
        private string _EditValue = "";
        private string _Seperator = ",";

        public ucCheckedListBoxEditor()
        {
            InitializeComponent();
        }

        private void ucCheckedListBoxEditor_Load(object sender, EventArgs e)
        {
            this.Height = 21;

            popupEdit.Top = 0;
            popupEdit.Left = 0;
           // popupEdit.Width = this.Width;
        }

        private void ucCheckedListBoxEditor_SizeChanged(object sender, EventArgs e)
        {
            popupEdit.Width = this.Width;
        }

        [DefaultValue(",")]
        [Description("多个值中间的分隔符.如:AA,BB,CC")]
        public string ItemSeperator
        {
            get { return _Seperator; }
            set { _Seperator = value; }
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
                    result = result + _Seperator + item.Value;
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
            this.popupEdit.EditValue = this.EditValue;

            if (_OnCheckStateChanged != null) _OnCheckStateChanged(lists, e);
        }

        private void popupContainerControl1_SizeChanged(object sender, EventArgs e)
        {
            txtNewItem.Width = popupContainerControl1.Width - btnAdd.Width - 16;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNewItem.Text != string.Empty)
            {
                int index = lists.Items.Add(txtNewItem.Text, txtNewItem.Text, CheckState.Checked, true);
                lists.SelectedIndex = index;

                this.popupEdit.EditValue = this.EditValue;

                txtNewItem.Text = "";
                txtNewItem.Focus();
            }
        }

        private void popupEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.popupContainerControl1.Width < this.Width)
                this.popupContainerControl1.Width = this.Width;
        }

    }
}
