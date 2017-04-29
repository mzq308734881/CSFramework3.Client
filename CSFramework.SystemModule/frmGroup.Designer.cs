namespace CSFramework.SystemModule
{
    partial class frmGroup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtGroupName = new DevExpress.XtraEditors.MemoEdit();
            this.txtGroupCode = new DevExpress.XtraEditors.TextEdit();
            this.labGroupName = new System.Windows.Forms.Label();
            this.labMemo = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.treeAuthority = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gcAvailableUser = new DevExpress.XtraEditors.GroupControl();
            this.lbAvailableUser = new System.Windows.Forms.ListBox();
            this.btnAllToLeft = new DevExpress.XtraEditors.SimpleButton();
            this.gcSelectedUser = new DevExpress.XtraEditors.GroupControl();
            this.lbSelectedUser = new System.Windows.Forms.ListBox();
            this.btnSingleToLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnSingleToRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllToRight = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAvailableUser)).BeginInit();
            this.gcAvailableUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSelectedUser)).BeginInit();
            this.gcSelectedUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.groupControl1);
            this.tpSummary.Size = new System.Drawing.Size(885, 610);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Location = new System.Drawing.Point(0, 28);
            this.pnlSummary.Size = new System.Drawing.Size(892, 640);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(892, 640);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.splitContainerControl1);
            this.tpDetail.Size = new System.Drawing.Size(885, 610);
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(892, 28);
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
            this.controlNavigatorSummary.Location = new System.Drawing.Point(714, 2);
            this.controlNavigatorSummary.Size = new System.Drawing.Size(176, 24);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(517, 2);
            this.lblAboutInfo.Size = new System.Drawing.Size(197, 24);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtGroupName);
            this.groupControl3.Controls.Add(this.txtGroupCode);
            this.groupControl3.Controls.Add(this.labGroupName);
            this.groupControl3.Controls.Add(this.labMemo);
            this.groupControl3.Location = new System.Drawing.Point(2, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(291, 105);
            this.groupControl3.TabIndex = 27;
            this.groupControl3.Text = "组基本信息";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(49, 51);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(224, 48);
            this.txtGroupName.TabIndex = 12;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(49, 26);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(224, 21);
            this.txtGroupCode.TabIndex = 8;
            // 
            // labGroupName
            // 
            this.labGroupName.AutoSize = true;
            this.labGroupName.Location = new System.Drawing.Point(8, 29);
            this.labGroupName.Name = "labGroupName";
            this.labGroupName.Size = new System.Drawing.Size(35, 14);
            this.labGroupName.TabIndex = 1;
            this.labGroupName.Text = "组名:";
            // 
            // labMemo
            // 
            this.labMemo.AutoSize = true;
            this.labMemo.Location = new System.Drawing.Point(8, 53);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(31, 14);
            this.labMemo.TabIndex = 3;
            this.labMemo.Text = "备注";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.treeAuthority);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(580, 610);
            this.groupControl2.TabIndex = 26;
            this.groupControl2.Text = "组权限";
            // 
            // treeAuthority
            // 
            this.treeAuthority.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeAuthority.CheckBoxes = true;
            this.treeAuthority.ContextMenuStrip = this.contextMenuStrip1;
            this.treeAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAuthority.ImageIndex = 0;
            this.treeAuthority.ImageList = this.imageList1;
            this.treeAuthority.Location = new System.Drawing.Point(2, 23);
            this.treeAuthority.Name = "treeAuthority";
            this.treeAuthority.SelectedImageIndex = 0;
            this.treeAuthority.Size = new System.Drawing.Size(576, 585);
            this.treeAuthority.TabIndex = 0;
            this.treeAuthority.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeAuthority_NodeMouseDoubleClick);
            this.treeAuthority.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeAuthority_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangeName});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // menuChangeName
            // 
            this.menuChangeName.Name = "menuChangeName";
            this.menuChangeName.Size = new System.Drawing.Size(118, 22);
            this.menuChangeName.Text = "修改名称";
            this.menuChangeName.Click += new System.EventHandler(this.menuChangeName_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Module.ico");
            this.imageList1.Images.SetKeyName(1, "skin16.ico");
            this.imageList1.Images.SetKeyName(2, "item.png");
            this.imageList1.Images.SetKeyName(3, "SignleForm.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "适用工厂:*";
            // 
            // gcSummary
            // 
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.Location = new System.Drawing.Point(2, 23);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.Size = new System.Drawing.Size(881, 585);
            this.gcSummary.TabIndex = 0;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroupCode,
            this.colGroupName});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            // 
            // colGroupCode
            // 
            this.colGroupCode.Caption = "组编号";
            this.colGroupCode.FieldName = "GroupCode";
            this.colGroupCode.Name = "colGroupCode";
            this.colGroupCode.Visible = true;
            this.colGroupCode.VisibleIndex = 0;
            this.colGroupCode.Width = 190;
            // 
            // colGroupName
            // 
            this.colGroupName.Caption = "说明";
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 1;
            this.colGroupName.Width = 462;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcSummary);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(885, 610);
            this.groupControl1.TabIndex = 2;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.gcAvailableUser);
            this.groupControl4.Controls.Add(this.btnAllToLeft);
            this.groupControl4.Controls.Add(this.gcSelectedUser);
            this.groupControl4.Controls.Add(this.btnSingleToLeft);
            this.groupControl4.Controls.Add(this.btnSingleToRight);
            this.groupControl4.Controls.Add(this.btnAllToRight);
            this.groupControl4.Location = new System.Drawing.Point(2, 113);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(291, 401);
            this.groupControl4.TabIndex = 34;
            this.groupControl4.Text = "组用户资料";
            // 
            // gcAvailableUser
            // 
            this.gcAvailableUser.Controls.Add(this.lbAvailableUser);
            this.gcAvailableUser.Location = new System.Drawing.Point(3, 26);
            this.gcAvailableUser.Name = "gcAvailableUser";
            this.gcAvailableUser.Size = new System.Drawing.Size(122, 368);
            this.gcAvailableUser.TabIndex = 27;
            this.gcAvailableUser.Text = "可选用户";
            // 
            // lbAvailableUser
            // 
            this.lbAvailableUser.BackColor = System.Drawing.Color.Gainsboro;
            this.lbAvailableUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAvailableUser.FormattingEnabled = true;
            this.lbAvailableUser.ItemHeight = 14;
            this.lbAvailableUser.Location = new System.Drawing.Point(2, 23);
            this.lbAvailableUser.Name = "lbAvailableUser";
            this.lbAvailableUser.Size = new System.Drawing.Size(118, 340);
            this.lbAvailableUser.TabIndex = 0;
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllToLeft.Appearance.Options.UseFont = true;
            this.btnAllToLeft.Location = new System.Drawing.Point(128, 230);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(32, 21);
            this.btnAllToLeft.TabIndex = 32;
            this.btnAllToLeft.Text = "<<";
            this.btnAllToLeft.Click += new System.EventHandler(this.pbAllToLeft_Click);
            // 
            // gcSelectedUser
            // 
            this.gcSelectedUser.Controls.Add(this.lbSelectedUser);
            this.gcSelectedUser.Location = new System.Drawing.Point(163, 26);
            this.gcSelectedUser.Name = "gcSelectedUser";
            this.gcSelectedUser.Size = new System.Drawing.Size(122, 370);
            this.gcSelectedUser.TabIndex = 28;
            this.gcSelectedUser.Text = "已选用户";
            // 
            // lbSelectedUser
            // 
            this.lbSelectedUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectedUser.FormattingEnabled = true;
            this.lbSelectedUser.ItemHeight = 14;
            this.lbSelectedUser.Location = new System.Drawing.Point(2, 23);
            this.lbSelectedUser.Name = "lbSelectedUser";
            this.lbSelectedUser.Size = new System.Drawing.Size(118, 340);
            this.lbSelectedUser.TabIndex = 2;
            // 
            // btnSingleToLeft
            // 
            this.btnSingleToLeft.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleToLeft.Appearance.Options.UseFont = true;
            this.btnSingleToLeft.Location = new System.Drawing.Point(128, 186);
            this.btnSingleToLeft.Name = "btnSingleToLeft";
            this.btnSingleToLeft.Size = new System.Drawing.Size(32, 21);
            this.btnSingleToLeft.TabIndex = 31;
            this.btnSingleToLeft.Text = "<";
            this.btnSingleToLeft.Click += new System.EventHandler(this.pbSingleToLeft_Click);
            // 
            // btnSingleToRight
            // 
            this.btnSingleToRight.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleToRight.Appearance.Options.UseFont = true;
            this.btnSingleToRight.Location = new System.Drawing.Point(128, 117);
            this.btnSingleToRight.Name = "btnSingleToRight";
            this.btnSingleToRight.Size = new System.Drawing.Size(32, 21);
            this.btnSingleToRight.TabIndex = 29;
            this.btnSingleToRight.Text = ">";
            this.btnSingleToRight.Click += new System.EventHandler(this.pbSingleToRight_Click);
            // 
            // btnAllToRight
            // 
            this.btnAllToRight.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllToRight.Appearance.Options.UseFont = true;
            this.btnAllToRight.Location = new System.Drawing.Point(128, 73);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(32, 21);
            this.btnAllToRight.TabIndex = 30;
            this.btnAllToRight.Text = ">>";
            this.btnAllToRight.Click += new System.EventHandler(this.pbAllToRight_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(885, 610);
            this.splitContainerControl1.SplitterPosition = 299;
            this.splitContainerControl1.TabIndex = 39;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(892, 668);
            this.Name = "frmGroup";
            this.Text = "用户组管理";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Controls.SetChildIndex(this.txtFocusForSave, 0);
            this.Controls.SetChildIndex(this.gcNavigator, 0);
            this.Controls.SetChildIndex(this.pnlSummary, 0);
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAvailableUser)).EndInit();
            this.gcAvailableUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSelectedUser)).EndInit();
            this.gcSelectedUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label labMemo;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TreeView treeAuthority;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit txtGroupName;
        private DevExpress.XtraEditors.TextEdit txtGroupCode;
        private System.Windows.Forms.Label labGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupCode;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl gcAvailableUser;
        private System.Windows.Forms.ListBox lbAvailableUser;
        private DevExpress.XtraEditors.SimpleButton btnAllToLeft;
        private DevExpress.XtraEditors.GroupControl gcSelectedUser;
        private System.Windows.Forms.ListBox lbSelectedUser;
        private DevExpress.XtraEditors.SimpleButton btnSingleToLeft;
        private DevExpress.XtraEditors.SimpleButton btnSingleToRight;
        private DevExpress.XtraEditors.SimpleButton btnAllToRight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuChangeName;

    }
}
