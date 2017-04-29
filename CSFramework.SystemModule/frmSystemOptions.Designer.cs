namespace CSFramework.SystemModule
{
    partial class frmSystemOptions
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chkExitAppIfOldVer = new DevExpress.XtraEditors.CheckEdit();
            this.chkCheckVer = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtUpgraderIP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtUpgraderPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rgUpgraderType = new DevExpress.XtraEditors.RadioGroup();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.rgAuthType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkLocalLog = new DevExpress.XtraEditors.CheckEdit();
            this.txtSkins = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkDoubleClickIntoEditMode = new DevExpress.XtraEditors.CheckEdit();
            this.btnApplySkin = new DevExpress.XtraEditors.SimpleButton();
            this.chkAllowRunMultiInstance = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExitAppIfOldVer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheckVer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpgraderIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpgraderPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgUpgraderType.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgAuthType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocalLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkins.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoubleClickIntoEditMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowRunMultiInstance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Size = new System.Drawing.Size(652, 398);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(450, 409);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(547, 409);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage4;
            this.xtraTabControl1.Size = new System.Drawing.Size(652, 398);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage4});
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.groupControl3);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(645, 368);
            this.xtraTabPage4.Text = "版本升级";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.chkExitAppIfOldVer);
            this.groupControl3.Controls.Add(this.chkCheckVer);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.panelControl3);
            this.groupControl3.Controls.Add(this.panelControl2);
            this.groupControl3.Controls.Add(this.rgUpgraderType);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(645, 368);
            this.groupControl3.TabIndex = 1;
            // 
            // chkExitAppIfOldVer
            // 
            this.chkExitAppIfOldVer.EditValue = true;
            this.chkExitAppIfOldVer.Location = new System.Drawing.Point(85, 85);
            this.chkExitAppIfOldVer.Name = "chkExitAppIfOldVer";
            this.chkExitAppIfOldVer.Properties.Caption = "禁止运行未更新版本的程序";
            this.chkExitAppIfOldVer.Size = new System.Drawing.Size(209, 19);
            this.chkExitAppIfOldVer.TabIndex = 15;
            // 
            // chkCheckVer
            // 
            this.chkCheckVer.EditValue = true;
            this.chkCheckVer.Location = new System.Drawing.Point(85, 50);
            this.chkCheckVer.Name = "chkCheckVer";
            this.chkCheckVer.Properties.Caption = "运行程序时检查新版本";
            this.chkCheckVer.Size = new System.Drawing.Size(209, 19);
            this.chkCheckVer.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(96, 119);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "升级类型：";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.textEdit1);
            this.panelControl3.Controls.Add(this.labelControl9);
            this.panelControl3.Location = new System.Drawing.Point(110, 267);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(386, 33);
            this.panelControl3.TabIndex = 13;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(66, 5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(312, 21);
            this.textEdit1.TabIndex = 3;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(4, 8);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 14);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "共享目录：";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.txtUpgraderIP);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txtUpgraderPort);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Location = new System.Drawing.Point(111, 187);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(385, 33);
            this.panelControl2.TabIndex = 7;
            // 
            // txtUpgraderIP
            // 
            this.txtUpgraderIP.EditValue = "";
            this.txtUpgraderIP.Location = new System.Drawing.Point(65, 5);
            this.txtUpgraderIP.Name = "txtUpgraderIP";
            this.txtUpgraderIP.Size = new System.Drawing.Size(100, 21);
            this.txtUpgraderIP.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "服务器IP：";
            // 
            // txtUpgraderPort
            // 
            this.txtUpgraderPort.EditValue = "";
            this.txtUpgraderPort.Location = new System.Drawing.Point(222, 5);
            this.txtUpgraderPort.Name = "txtUpgraderPort";
            this.txtUpgraderPort.Size = new System.Drawing.Size(46, 21);
            this.txtUpgraderPort.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(180, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "端口：";
            // 
            // rgUpgraderType
            // 
            this.rgUpgraderType.Enabled = false;
            this.rgUpgraderType.Location = new System.Drawing.Point(87, 126);
            this.rgUpgraderType.Name = "rgUpgraderType";
            this.rgUpgraderType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.rgUpgraderType.Properties.Appearance.Options.UseBackColor = true;
            this.rgUpgraderType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "使用TCP/IP通信下载文件"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "网络盘共享目录复制文件")});
            this.rgUpgraderType.Size = new System.Drawing.Size(452, 176);
            this.rgUpgraderType.TabIndex = 11;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(645, 368);
            this.xtraTabPage1.Text = "普通设置";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.rgAuthType);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.chkLocalLog);
            this.groupControl1.Controls.Add(this.txtSkins);
            this.groupControl1.Controls.Add(this.chkDoubleClickIntoEditMode);
            this.groupControl1.Controls.Add(this.btnApplySkin);
            this.groupControl1.Controls.Add(this.chkAllowRunMultiInstance);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(645, 368);
            this.groupControl1.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(48, 213);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 13;
            this.labelControl8.Text = "登录授权：";
            // 
            // rgAuthType
            // 
            this.rgAuthType.Location = new System.Drawing.Point(114, 213);
            this.rgAuthType.Name = "rgAuthType";
            this.rgAuthType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "系统自定义权限验证用户"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Novell网用户验证"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Windows域用户登录")});
            this.rgAuthType.Size = new System.Drawing.Size(242, 94);
            this.rgAuthType.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(48, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "皮肤设置：";
            // 
            // chkLocalLog
            // 
            this.chkLocalLog.Location = new System.Drawing.Point(112, 149);
            this.chkLocalLog.Name = "chkLocalLog";
            this.chkLocalLog.Properties.Caption = "开启本地日志.保存用户对系统的操作记录";
            this.chkLocalLog.Size = new System.Drawing.Size(263, 19);
            this.chkLocalLog.TabIndex = 5;
            // 
            // txtSkins
            // 
            this.txtSkins.Location = new System.Drawing.Point(114, 50);
            this.txtSkins.Name = "txtSkins";
            this.txtSkins.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSkins.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtSkins.Size = new System.Drawing.Size(223, 21);
            this.txtSkins.TabIndex = 0;
            // 
            // chkDoubleClickIntoEditMode
            // 
            this.chkDoubleClickIntoEditMode.Location = new System.Drawing.Point(112, 124);
            this.chkDoubleClickIntoEditMode.Name = "chkDoubleClickIntoEditMode";
            this.chkDoubleClickIntoEditMode.Properties.Caption = "双击查询表格进入编辑状态";
            this.chkDoubleClickIntoEditMode.Size = new System.Drawing.Size(248, 19);
            this.chkDoubleClickIntoEditMode.TabIndex = 4;
            // 
            // btnApplySkin
            // 
            this.btnApplySkin.Location = new System.Drawing.Point(347, 49);
            this.btnApplySkin.Name = "btnApplySkin";
            this.btnApplySkin.Size = new System.Drawing.Size(99, 23);
            this.btnApplySkin.TabIndex = 2;
            this.btnApplySkin.Text = "应用皮肤";
            this.btnApplySkin.Click += new System.EventHandler(this.btnApplySkin_Click);
            // 
            // chkAllowRunMultiInstance
            // 
            this.chkAllowRunMultiInstance.Location = new System.Drawing.Point(112, 96);
            this.chkAllowRunMultiInstance.Name = "chkAllowRunMultiInstance";
            this.chkAllowRunMultiInstance.Properties.Caption = "允许运行程序多个实例";
            this.chkAllowRunMultiInstance.Size = new System.Drawing.Size(248, 19);
            this.chkAllowRunMultiInstance.TabIndex = 3;
            // 
            // frmSystemOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 455);
            this.Name = "frmSystemOptions";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.frmSystemOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExitAppIfOldVer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheckVer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpgraderIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpgraderPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgUpgraderType.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgAuthType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocalLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkins.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoubleClickIntoEditMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowRunMultiInstance.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit txtSkins;
        private DevExpress.XtraEditors.SimpleButton btnApplySkin;
        private DevExpress.XtraEditors.CheckEdit chkAllowRunMultiInstance;
        private DevExpress.XtraEditors.CheckEdit chkDoubleClickIntoEditMode;
        private DevExpress.XtraEditors.CheckEdit chkLocalLog;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtUpgraderIP;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtUpgraderPort;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.RadioGroup rgUpgraderType;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.RadioGroup rgAuthType;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.CheckEdit chkCheckVer;
        private DevExpress.XtraEditors.CheckEdit chkExitAppIfOldVer;


    }
}