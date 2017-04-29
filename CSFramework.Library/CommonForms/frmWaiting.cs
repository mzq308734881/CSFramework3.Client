using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CSFramework.Library
{
    public partial class frmWaiting : XtraForm
    {
        private static frmWaiting _Instance = null;

        private frmWaiting()
        {
            InitializeComponent();
        }

        public static void ShowMe(Form owner)
        {
            ShowMe(owner, "");
        }

        public static void ShowMe(Form owner, string message)
        {
            owner.UseWaitCursor = true;

            if (_Instance == null || _Instance.IsDisposed) _Instance = new frmWaiting();
            _Instance.Owner = owner;
            _Instance.lblMsg.Text = String.IsNullOrEmpty(message) ? _Instance.lblMsg.Text : message;
            _Instance.lblMsg.Invalidate();
            _Instance.Show();

            Application.DoEvents();
        }

        public static void ShowMe(Form owner, string message, bool disableOwner)
        {
            owner.UseWaitCursor = true;
            owner.Enabled = !disableOwner;

            if (_Instance == null || _Instance.IsDisposed) _Instance = new frmWaiting();
            _Instance.Owner = owner;
            _Instance.lblMsg.Text = String.IsNullOrEmpty(message) ? _Instance.lblMsg.Text : message;
            _Instance.lblMsg.Invalidate();
            _Instance.Show();

            Application.DoEvents();
        }

        public static void HideMe(Form owner)
        {
            owner.UseWaitCursor = false;
            owner.Enabled = true;

            if (_Instance != null)
            {
                _Instance.Close();
                _Instance = null;
            }

            Application.DoEvents();
        }

        private void frmWaiting_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
