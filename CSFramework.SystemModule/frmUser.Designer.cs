namespace CSFramework.SystemModule
{
    partial class frmUser
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
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNovellAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomainName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastLoginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastLogoutTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlagAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoginCounter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword1 = new DevExpress.XtraEditors.TextEdit();
            this.labPassword1 = new System.Windows.Forms.Label();
            this.labPassword2 = new System.Windows.Forms.Label();
            this.chkIsLocked = new DevExpress.XtraEditors.CheckEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtTel = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtAccount = new DevExpress.XtraEditors.TextEdit();
            this.labEmail = new System.Windows.Forms.Label();
            this.labAccount = new System.Windows.Forms.Label();
            this.labTel = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.gcDetailEditor = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lbMyGroups = new DevExpress.XtraEditors.ListBoxControl();
            this.ucDataSets = new CSFramework.Library.UserControls.ucCheckedListBoxBinding();
            this.txtDomainName = new DevExpress.XtraEditors.MemoEdit();
            this.txtNovellAccount = new DevExpress.XtraEditors.MemoEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoginCounter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLastLogoutTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcPassword = new DevExpress.XtraEditors.GroupControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLocked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).BeginInit();
            this.gcDetailEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbMyGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomainName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNovellAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginCounter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastLogoutTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPassword)).BeginInit();
            this.gcPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.gcSummary);
            this.tpSummary.Size = new System.Drawing.Size(881, 498);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Location = new System.Drawing.Point(0, 28);
            this.pnlSummary.Size = new System.Drawing.Size(888, 528);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(888, 528);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.gcDetailEditor);
            this.tpDetail.Padding = new System.Windows.Forms.Padding(5);
            this.tpDetail.Size = new System.Drawing.Size(881, 498);
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(888, 28);
            // 
            // controlNavigatorSummary
            // 
            this.controlNavigatorSummary.Buttons.Append.Visible = false;
            this.controlNavigatorSummary.Buttons.CancelEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.Edit.Visible = false;
            this.controlNavigatorSummary.Buttons.EndEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.NextPage.Visible = false;
            this.controlNavigatorSummary.Buttons.PrevPage.Visible = false;
            this.controlNavigatorSummary.Buttons.Remove.Visible = false;
            this.controlNavigatorSummary.Location = new System.Drawing.Point(710, 2);
            this.controlNavigatorSummary.Size = new System.Drawing.Size(176, 24);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(513, 2);
            this.lblAboutInfo.Size = new System.Drawing.Size(197, 24);
            // 
            // gcSummary
            // 
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSummary.Location = new System.Drawing.Point(0, 0);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcSummary.Size = new System.Drawing.Size(881, 498);
            this.gcSummary.TabIndex = 7;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccount,
            this.colNovellAccount,
            this.colDomainName,
            this.colUserName,
            this.colTel,
            this.colEmail,
            this.colLastLoginTime,
            this.colLastLogoutTime,
            this.colIsLocked,
            this.colCreateTime,
            this.colFlagAdmin,
            this.colLoginCounter});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            // 
            // colAccount
            // 
            this.colAccount.AppearanceCell.Options.UseTextOptions = true;
            this.colAccount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAccount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAccount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAccount.Caption = "系统账号";
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 1;
            // 
            // colNovellAccount
            // 
            this.colNovellAccount.Caption = "Novell帐户";
            this.colNovellAccount.FieldName = "NovellAccount";
            this.colNovellAccount.Name = "colNovellAccount";
            this.colNovellAccount.Visible = true;
            this.colNovellAccount.VisibleIndex = 2;
            this.colNovellAccount.Width = 120;
            // 
            // colDomainName
            // 
            this.colDomainName.Caption = "域用户";
            this.colDomainName.FieldName = "DomainName";
            this.colDomainName.Name = "colDomainName";
            this.colDomainName.Visible = true;
            this.colDomainName.VisibleIndex = 3;
            this.colDomainName.Width = 107;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "用户名称";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.SummaryItem.DisplayFormat = "Count:{0}";
            this.colUserName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colTel
            // 
            this.colTel.AppearanceHeader.Options.UseTextOptions = true;
            this.colTel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTel.Caption = "电话";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 5;
            this.colTel.Width = 120;
            // 
            // colEmail
            // 
            this.colEmail.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmail.Caption = "邮件";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            this.colEmail.Width = 148;
            // 
            // colLastLoginTime
            // 
            this.colLastLoginTime.AppearanceCell.Options.UseTextOptions = true;
            this.colLastLoginTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastLoginTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colLastLoginTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastLoginTime.Caption = "最后登录时间";
            this.colLastLoginTime.FieldName = "LastLoginTime";
            this.colLastLoginTime.Name = "colLastLoginTime";
            this.colLastLoginTime.Visible = true;
            this.colLastLoginTime.VisibleIndex = 6;
            this.colLastLoginTime.Width = 100;
            // 
            // colLastLogoutTime
            // 
            this.colLastLogoutTime.Caption = "最后登出时间";
            this.colLastLogoutTime.FieldName = "LastLogoutTime";
            this.colLastLogoutTime.Name = "colLastLogoutTime";
            this.colLastLogoutTime.Visible = true;
            this.colLastLogoutTime.VisibleIndex = 7;
            this.colLastLogoutTime.Width = 96;
            // 
            // colIsLocked
            // 
            this.colIsLocked.AppearanceCell.Options.UseTextOptions = true;
            this.colIsLocked.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsLocked.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsLocked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsLocked.Caption = "锁定";
            this.colIsLocked.FieldName = "IsLocked";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.Visible = true;
            this.colIsLocked.VisibleIndex = 8;
            this.colIsLocked.Width = 44;
            // 
            // colCreateTime
            // 
            this.colCreateTime.AppearanceCell.Options.UseTextOptions = true;
            this.colCreateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 9;
            this.colCreateTime.Width = 100;
            // 
            // colFlagAdmin
            // 
            this.colFlagAdmin.Caption = "管理员";
            this.colFlagAdmin.FieldName = "FlagAdmin";
            this.colFlagAdmin.Name = "colFlagAdmin";
            this.colFlagAdmin.Visible = true;
            this.colFlagAdmin.VisibleIndex = 10;
            // 
            // colLoginCounter
            // 
            this.colLoginCounter.Caption = "登录次数";
            this.colLoginCounter.FieldName = "LoginCounter";
            this.colLoginCounter.Name = "colLoginCounter";
            this.colLoginCounter.Visible = true;
            this.colLoginCounter.VisibleIndex = 11;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(59, 57);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPassword2.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword2.Properties.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(117, 21);
            this.txtPassword2.TabIndex = 1;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(59, 30);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPassword1.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword1.Properties.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(117, 21);
            this.txtPassword1.TabIndex = 0;
            // 
            // labPassword1
            // 
            this.labPassword1.AutoSize = true;
            this.labPassword1.Location = new System.Drawing.Point(9, 32);
            this.labPassword1.Name = "labPassword1";
            this.labPassword1.Size = new System.Drawing.Size(47, 14);
            this.labPassword1.TabIndex = 108;
            this.labPassword1.Text = "第一次:";
            // 
            // labPassword2
            // 
            this.labPassword2.AutoSize = true;
            this.labPassword2.Location = new System.Drawing.Point(9, 59);
            this.labPassword2.Name = "labPassword2";
            this.labPassword2.Size = new System.Drawing.Size(47, 14);
            this.labPassword2.TabIndex = 109;
            this.labPassword2.Text = "第二次:";
            // 
            // chkIsLocked
            // 
            this.chkIsLocked.Location = new System.Drawing.Point(275, 37);
            this.chkIsLocked.Name = "chkIsLocked";
            this.chkIsLocked.Properties.Caption = "锁定用户";
            this.chkIsLocked.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkIsLocked.Properties.ValueChecked = "Y";
            this.chkIsLocked.Properties.ValueGrayed = "\"\"";
            this.chkIsLocked.Properties.ValueUnchecked = "N";
            this.chkIsLocked.Size = new System.Drawing.Size(97, 19);
            this.chkIsLocked.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(94, 209);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 21);
            this.txtEmail.TabIndex = 5;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(94, 181);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(278, 21);
            this.txtTel.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(94, 62);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(155, 21);
            this.txtUserName.TabIndex = 93;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(94, 36);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAccount.Properties.Appearance.Options.UseBackColor = true;
            this.txtAccount.Size = new System.Drawing.Size(155, 21);
            this.txtAccount.TabIndex = 92;
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Location = new System.Drawing.Point(23, 212);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(59, 14);
            this.labEmail.TabIndex = 105;
            this.labEmail.Text = "电子邮件:";
            // 
            // labAccount
            // 
            this.labAccount.AutoSize = true;
            this.labAccount.Location = new System.Drawing.Point(23, 39);
            this.labAccount.Name = "labAccount";
            this.labAccount.Size = new System.Drawing.Size(59, 14);
            this.labAccount.TabIndex = 103;
            this.labAccount.Text = "登录帐号:";
            // 
            // labTel
            // 
            this.labTel.AutoSize = true;
            this.labTel.Location = new System.Drawing.Point(23, 185);
            this.labTel.Name = "labTel";
            this.labTel.Size = new System.Drawing.Size(35, 14);
            this.labTel.TabIndex = 104;
            this.labTel.Text = "电话:";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(23, 65);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(35, 14);
            this.labUserName.TabIndex = 102;
            this.labUserName.Text = "姓名:";
            // 
            // gcDetailEditor
            // 
            this.gcDetailEditor.Controls.Add(this.groupControl1);
            this.gcDetailEditor.Controls.Add(this.ucDataSets);
            this.gcDetailEditor.Controls.Add(this.txtDomainName);
            this.gcDetailEditor.Controls.Add(this.txtNovellAccount);
            this.gcDetailEditor.Controls.Add(this.label10);
            this.gcDetailEditor.Controls.Add(this.label9);
            this.gcDetailEditor.Controls.Add(this.label8);
            this.gcDetailEditor.Controls.Add(this.label7);
            this.gcDetailEditor.Controls.Add(this.label6);
            this.gcDetailEditor.Controls.Add(this.txtLoginCounter);
            this.gcDetailEditor.Controls.Add(this.labelControl2);
            this.gcDetailEditor.Controls.Add(this.txtLastLogoutTime);
            this.gcDetailEditor.Controls.Add(this.labelControl1);
            this.gcDetailEditor.Controls.Add(this.gcPassword);
            this.gcDetailEditor.Controls.Add(this.label4);
            this.gcDetailEditor.Controls.Add(this.txtAccount);
            this.gcDetailEditor.Controls.Add(this.labUserName);
            this.gcDetailEditor.Controls.Add(this.chkIsLocked);
            this.gcDetailEditor.Controls.Add(this.labTel);
            this.gcDetailEditor.Controls.Add(this.labAccount);
            this.gcDetailEditor.Controls.Add(this.labEmail);
            this.gcDetailEditor.Controls.Add(this.txtUserName);
            this.gcDetailEditor.Controls.Add(this.txtTel);
            this.gcDetailEditor.Controls.Add(this.txtEmail);
            this.gcDetailEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetailEditor.Location = new System.Drawing.Point(5, 5);
            this.gcDetailEditor.Name = "gcDetailEditor";
            this.gcDetailEditor.Size = new System.Drawing.Size(871, 488);
            this.gcDetailEditor.TabIndex = 119;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lbMyGroups);
            this.groupControl1.Location = new System.Drawing.Point(398, 37);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(252, 343);
            this.groupControl1.TabIndex = 142;
            this.groupControl1.Text = "我所属的组列表";
            // 
            // lbMyGroups
            // 
            this.lbMyGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMyGroups.Location = new System.Drawing.Point(2, 23);
            this.lbMyGroups.Name = "lbMyGroups";
            this.lbMyGroups.Size = new System.Drawing.Size(248, 318);
            this.lbMyGroups.TabIndex = 0;
            // 
            // ucDataSets
            // 
            this.ucDataSets.EditValue = "";
            this.ucDataSets.Location = new System.Drawing.Point(94, 233);
            this.ucDataSets.Margin = new System.Windows.Forms.Padding(0);
            this.ucDataSets.Name = "ucDataSets";
            this.ucDataSets.Size = new System.Drawing.Size(278, 123);
            this.ucDataSets.TabIndex = 141;
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(94, 135);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(278, 40);
            this.txtDomainName.TabIndex = 140;
            // 
            // txtNovellAccount
            // 
            this.txtNovellAccount.Location = new System.Drawing.Point(94, 89);
            this.txtNovellAccount.Name = "txtNovellAccount";
            this.txtNovellAccount.Size = new System.Drawing.Size(278, 40);
            this.txtNovellAccount.TabIndex = 139;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(375, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 14);
            this.label10.TabIndex = 137;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(375, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 136;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(252, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 135;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 14);
            this.label7.TabIndex = 134;
            this.label7.Text = "域帐号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 132;
            this.label6.Text = "Novell帐号:";
            // 
            // txtLoginCounter
            // 
            this.txtLoginCounter.Location = new System.Drawing.Point(305, 359);
            this.txtLoginCounter.Name = "txtLoginCounter";
            this.txtLoginCounter.Size = new System.Drawing.Size(67, 21);
            this.txtLoginCounter.TabIndex = 130;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(251, 362);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 129;
            this.labelControl2.Text = "登录次数:";
            // 
            // txtLastLogoutTime
            // 
            this.txtLastLogoutTime.Location = new System.Drawing.Point(94, 359);
            this.txtLastLogoutTime.Name = "txtLastLogoutTime";
            this.txtLastLogoutTime.Size = new System.Drawing.Size(144, 21);
            this.txtLastLogoutTime.TabIndex = 128;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 362);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 127;
            this.labelControl1.Text = "上次登出:";
            // 
            // gcPassword
            // 
            this.gcPassword.Controls.Add(this.txtPassword2);
            this.gcPassword.Controls.Add(this.labPassword2);
            this.gcPassword.Controls.Add(this.labPassword1);
            this.gcPassword.Controls.Add(this.txtPassword1);
            this.gcPassword.Location = new System.Drawing.Point(94, 386);
            this.gcPassword.Name = "gcPassword";
            this.gcPassword.Size = new System.Drawing.Size(188, 92);
            this.gcPassword.TabIndex = 124;
            this.gcPassword.Text = "输入密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(252, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(888, 556);
            this.Name = "frmUser";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLocked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).EndInit();
            this.gcDetailEditor.ResumeLayout(false);
            this.gcDetailEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbMyGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomainName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNovellAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginCounter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastLogoutTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPassword)).EndInit();
            this.gcPassword.ResumeLayout(false);
            this.gcPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colLastLoginTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraEditors.TextEdit txtPassword2;
        private DevExpress.XtraEditors.TextEdit txtPassword1;
        private System.Windows.Forms.Label labPassword1;
        private System.Windows.Forms.Label labPassword2;
        private DevExpress.XtraEditors.CheckEdit chkIsLocked;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtTel;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtAccount;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.Label labAccount;
        private System.Windows.Forms.Label labTel;
        private System.Windows.Forms.Label labUserName;
        private DevExpress.XtraEditors.GroupControl gcDetailEditor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl gcPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colFlagAdmin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLastLogoutTime;
        private DevExpress.XtraEditors.TextEdit txtLoginCounter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn colLastLogoutTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginCounter;
        private DevExpress.XtraGrid.Columns.GridColumn colNovellAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colDomainName;
        private DevExpress.XtraEditors.MemoEdit txtDomainName;
        private DevExpress.XtraEditors.MemoEdit txtNovellAccount;
        private CSFramework.Library.UserControls.ucCheckedListBoxBinding ucDataSets;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl lbMyGroups;
    }
}
