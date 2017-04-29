using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSFramework.Library;
using CSFramework3.Business;
using CSFramework.Common;


namespace CSFramework.SystemModule
{
    public partial class frmBackupDB : frmBaseDialog
    {
        private DataTable _BackupHistory;

        public frmBackupDB()
        {
            InitializeComponent();
        }

        private void frmBackupDB_Load(object sender, EventArgs e)
        {
            DataTable data = new CommonData().GetDB4Backup();
            DataBinder.BindingLookupEditDataSource(txtDBs1, data, "DataSetName", "DBName");
            DataBinder.BindingLookupEditDataSource(txtDBs2, data, "DataSetName", "DBName");

            _BackupHistory = new CommonData().GetBackupHistory(100);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtDBs1.Text == "")
            {
                txtDBs1.Focus();
                return;
            }

            if (txtPathInServer.Text == "")
            {
                txtPathInServer.Focus();
                return;
            }

            try
            {
                SetButtonState(false);
                bool success = new CommonData().BackupDatabase(ConvertEx.ToString(txtDBs1.EditValue), txtPathInServer.Text);
                if (success)
                    Msg.ShowInformation("备份数据库成功！");
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
            SetButtonState(true);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtDBs2.Text == "")
            {
                txtDBs2.Focus();
                return;
            }

            if (txtDBList.Text == "")
            {
                txtDBList.Focus();
                return;
            }

            SetButtonState(false);
            try
            {
                string BKFILE = txtDBList.Properties.GetDataSourceValue("BackupPath", txtDBList.ItemIndex).ToString();
                bool success = new CommonData().RestoreDatabase(BKFILE, ConvertEx.ToString(txtDBs2.EditValue));
                if (success)
                    Msg.ShowInformation("还原数据库成功！请退出系统重新登录。");
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
            SetButtonState(true);
        }

        private void SetButtonState(bool enable)
        {
            btnBackup.Enabled = enable;
            btnRestore.Enabled = enable;
            btnCancel.Enabled = enable;
        }

        private void txtDBs2_EditValueChanged(object sender, EventArgs e)
        {
            if (ConvertEx.ToString(txtDBs2.EditValue) != "")
            {
                _BackupHistory.DefaultView.RowFilter = "DBName='" + ConvertEx.ToString(txtDBs2.EditValue) + "'";
                DataBinder.BindingLookupEditDataSource(txtDBList, _BackupHistory.DefaultView, "DBName", "DBName");
            }
            else
            {
                DataBinder.BindingLookupEditDataSource(txtDBList, _BackupHistory, "DBName", "DBName");
            }
        }

    }
}

