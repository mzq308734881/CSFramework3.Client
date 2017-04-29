using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace CSFramework.Library.UserControls
{
    public partial class ucWindowTitle : XtraUserControl
    {
        public ucWindowTitle()
        {
            InitializeComponent();
        }

        [Description("请设置窗体标题")]
        [DefaultValue("请设置窗体标题(Window Title)")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Description("操作状态")]
        [DefaultValue("(操作状态)")]
        public string StateName
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }


    }
}
