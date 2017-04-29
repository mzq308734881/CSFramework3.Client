namespace CSFramework.SystemModule
{
    partial class frmBackupDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupDB));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPathInServer = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtDBs1 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtDBs2 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDBList = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathInServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBs1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBs2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Size = new System.Drawing.Size(639, 398);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 414);
            this.btnOk.Size = new System.Drawing.Size(0, 31);
            this.btnOk.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(478, 406);
            this.btnCancel.Size = new System.Drawing.Size(115, 31);
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(639, 70);
            this.panelControl2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "备份/还原数据库";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(15, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Backup && Restore Database";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(570, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "服务器备份目录：";
            // 
            // txtPathInServer
            // 
            this.txtPathInServer.EditValue = "c:\\db_backup\\";
            this.txtPathInServer.Location = new System.Drawing.Point(132, 77);
            this.txtPathInServer.Name = "txtPathInServer";
            this.txtPathInServer.Size = new System.Drawing.Size(294, 21);
            this.txtPathInServer.TabIndex = 8;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.txtDBs1);
            this.groupControl1.Controls.Add(this.btnBackup);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtPathInServer);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Location = new System.Drawing.Point(20, 87);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(601, 126);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "备份数据库";
            // 
            // txtDBs1
            // 
            this.txtDBs1.Location = new System.Drawing.Point(132, 40);
            this.txtDBs1.Name = "txtDBs1";
            this.txtDBs1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDBs1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DBName", 200, "数据库名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataSetName", 200, "数据库说明")});
            this.txtDBs1.Properties.NullText = "";
            this.txtDBs1.Properties.PopupWidth = 400;
            this.txtDBs1.Size = new System.Drawing.Size(294, 21);
            this.txtDBs1.TabIndex = 12;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(458, 67);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(115, 31);
            this.btnBackup.TabIndex = 11;
            this.btnBackup.Text = "开始备份";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "数据库：";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtDBs2);
            this.groupControl2.Controls.Add(this.txtDBList);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.btnRestore);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Location = new System.Drawing.Point(20, 240);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(601, 126);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "还原数据库";
            // 
            // txtDBs2
            // 
            this.txtDBs2.Location = new System.Drawing.Point(132, 46);
            this.txtDBs2.Name = "txtDBs2";
            this.txtDBs2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDBs2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DBName", 200, "数据库名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataSetName", 200, "数据库说明")});
            this.txtDBs2.Properties.NullText = "";
            this.txtDBs2.Properties.PopupWidth = 400;
            this.txtDBs2.Size = new System.Drawing.Size(294, 21);
            this.txtDBs2.TabIndex = 15;
            this.txtDBs2.EditValueChanged += new System.EventHandler(this.txtDBs2_EditValueChanged);
            // 
            // txtDBList
            // 
            this.txtDBList.Location = new System.Drawing.Point(132, 79);
            this.txtDBList.Name = "txtDBList";
            this.txtDBList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDBList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BackupFileName", 330, "文件名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BackupTime", "备份时间", 120, DevExpress.Utils.FormatType.DateTime, "yyyy-MM-dd hh:mm:ss", true, DevExpress.Utils.HorzAlignment.Default)});
            this.txtDBList.Properties.DropDownRows = 8;
            this.txtDBList.Properties.NullText = "";
            this.txtDBList.Properties.PopupWidth = 500;
            this.txtDBList.Size = new System.Drawing.Size(294, 21);
            this.txtDBList.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "数据库：";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(458, 69);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(115, 31);
            this.btnRestore.TabIndex = 11;
            this.btnRestore.Text = "开始还原";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "请选择备份文件：";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(0, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(639, 2);
            this.label7.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(129, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "注：服务器必须存在此目录！";
            // 
            // frmBackupDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(639, 457);
            this.Name = "frmBackupDB";
            this.Text = "数据库备份/还原";
            this.Load += new System.EventHandler(this.frmBackupDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathInServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBs1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBs2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtPathInServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit txtDBs1;
        private DevExpress.XtraEditors.LookUpEdit txtDBList;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit txtDBs2;
        private System.Windows.Forms.Label label8;
    }
}
