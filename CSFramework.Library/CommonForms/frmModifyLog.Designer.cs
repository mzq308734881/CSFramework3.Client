namespace CSFramework.Library
{
    partial class frmModifyLog
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
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLogUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOPType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKeyFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colD_FieldTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_OldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_NewValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_TableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkRowHeight = new DevExpress.XtraEditors.CheckEdit();
            this.cbBusiness = new DevExpress.XtraEditors.LookUpEdit();
            this.btnEmpty = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRowHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBusiness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(793, 490);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcSummary);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(786, 460);
            this.xtraTabPage1.Text = "历史记录";
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
            this.gcSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemMemoEdit1});
            this.gcSummary.Size = new System.Drawing.Size(786, 460);
            this.gcSummary.TabIndex = 2;
            this.gcSummary.UseEmbeddedNavigator = true;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLogUser,
            this.colLogDate,
            this.colOPType,
            this.colTableName,
            this.colKeyFieldName,
            this.colDocNo,
            this.colContent});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsBehavior.Editable = false;
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            this.gvSummary.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvSummary_FocusedRowChanged);
            // 
            // colLogUser
            // 
            this.colLogUser.Caption = "修改人";
            this.colLogUser.FieldName = "LogUser";
            this.colLogUser.Name = "colLogUser";
            this.colLogUser.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLogUser.OptionsFilter.AllowAutoFilter = false;
            this.colLogUser.OptionsFilter.AllowFilter = false;
            this.colLogUser.SummaryItem.DisplayFormat = "记录:{0}";
            this.colLogUser.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colLogUser.Visible = true;
            this.colLogUser.VisibleIndex = 0;
            this.colLogUser.Width = 82;
            // 
            // colLogDate
            // 
            this.colLogDate.Caption = "修改日期";
            this.colLogDate.FieldName = "LogDate";
            this.colLogDate.Name = "colLogDate";
            this.colLogDate.Visible = true;
            this.colLogDate.VisibleIndex = 1;
            this.colLogDate.Width = 84;
            // 
            // colOPType
            // 
            this.colOPType.Caption = "修改类型";
            this.colOPType.FieldName = "OPType";
            this.colOPType.Name = "colOPType";
            this.colOPType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOPType.OptionsFilter.AllowAutoFilter = false;
            this.colOPType.OptionsFilter.AllowFilter = false;
            this.colOPType.Width = 70;
            // 
            // colTableName
            // 
            this.colTableName.Caption = "表名";
            this.colTableName.FieldName = "TableName";
            this.colTableName.Name = "colTableName";
            this.colTableName.Visible = true;
            this.colTableName.VisibleIndex = 2;
            this.colTableName.Width = 139;
            // 
            // colKeyFieldName
            // 
            this.colKeyFieldName.Caption = "主键";
            this.colKeyFieldName.FieldName = "KeyFieldName";
            this.colKeyFieldName.Name = "colKeyFieldName";
            this.colKeyFieldName.Visible = true;
            this.colKeyFieldName.VisibleIndex = 3;
            this.colKeyFieldName.Width = 94;
            // 
            // colDocNo
            // 
            this.colDocNo.Caption = "主键值";
            this.colDocNo.FieldName = "DocNo";
            this.colDocNo.Name = "colDocNo";
            this.colDocNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDocNo.OptionsFilter.AllowAutoFilter = false;
            this.colDocNo.OptionsFilter.AllowFilter = false;
            this.colDocNo.Visible = true;
            this.colDocNo.VisibleIndex = 4;
            this.colDocNo.Width = 91;
            // 
            // colContent
            // 
            this.colContent.AppearanceCell.BackColor = System.Drawing.Color.LightYellow;
            this.colContent.AppearanceCell.Options.UseBackColor = true;
            this.colContent.Caption = "修改内容";
            this.colContent.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colContent.FieldName = "EditContent";
            this.colContent.Name = "colContent";
            this.colContent.Visible = true;
            this.colContent.VisibleIndex = 5;
            this.colContent.Width = 251;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcDetail);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(786, 460);
            this.xtraTabPage2.Text = "修改明细";
            // 
            // gcDetail
            // 
            this.gcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetail.Location = new System.Drawing.Point(0, 0);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit2});
            this.gcDetail.Size = new System.Drawing.Size(786, 460);
            this.gcDetail.TabIndex = 2;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colD_TableName,
            this.colD_FieldTitle,
            this.colD_OldValue,
            this.colD_NewValue});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.Editable = false;
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.OptionsView.ShowFooter = true;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colD_FieldTitle
            // 
            this.colD_FieldTitle.Caption = "字段名";
            this.colD_FieldTitle.FieldName = "FieldTitle";
            this.colD_FieldTitle.Name = "colD_FieldTitle";
            this.colD_FieldTitle.Visible = true;
            this.colD_FieldTitle.VisibleIndex = 1;
            this.colD_FieldTitle.Width = 116;
            // 
            // colD_OldValue
            // 
            this.colD_OldValue.Caption = "旧值";
            this.colD_OldValue.FieldName = "OldValue";
            this.colD_OldValue.Name = "colD_OldValue";
            this.colD_OldValue.Visible = true;
            this.colD_OldValue.VisibleIndex = 2;
            this.colD_OldValue.Width = 239;
            // 
            // colD_NewValue
            // 
            this.colD_NewValue.Caption = "新值";
            this.colD_NewValue.FieldName = "NewValue";
            this.colD_NewValue.Name = "colD_NewValue";
            this.colD_NewValue.Visible = true;
            this.colD_NewValue.VisibleIndex = 3;
            this.colD_NewValue.Width = 230;
            // 
            // colD_TableName
            // 
            this.colD_TableName.Caption = "表名";
            this.colD_TableName.FieldName = "TableName";
            this.colD_TableName.Name = "colD_TableName";
            this.colD_TableName.SummaryItem.DisplayFormat = "记录:{0}";
            this.colD_TableName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colD_TableName.Visible = true;
            this.colD_TableName.VisibleIndex = 0;
            this.colD_TableName.Width = 127;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.chkRowHeight);
            this.panelControl1.Controls.Add(this.cbBusiness);
            this.panelControl1.Controls.Add(this.btnEmpty);
            this.panelControl1.Controls.Add(this.btnQuery);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.pictureBox3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtDateTo);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtDateFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(793, 54);
            this.panelControl1.TabIndex = 1;
            // 
            // chkRowHeight
            // 
            this.chkRowHeight.Location = new System.Drawing.Point(533, 17);
            this.chkRowHeight.Name = "chkRowHeight";
            this.chkRowHeight.Properties.Caption = "自动调整行距";
            this.chkRowHeight.Size = new System.Drawing.Size(148, 19);
            this.chkRowHeight.TabIndex = 13;
            this.chkRowHeight.CheckedChanged += new System.EventHandler(this.chkRowHeight_CheckedChanged);
            // 
            // cbBusiness
            // 
            this.cbBusiness.Location = new System.Drawing.Point(137, 6);
            this.cbBusiness.Name = "cbBusiness";
            this.cbBusiness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBusiness.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormCaption", 150, "单据窗体列表")});
            this.cbBusiness.Properties.NullText = "";
            this.cbBusiness.Properties.PopupWidth = 150;
            this.cbBusiness.Size = new System.Drawing.Size(223, 21);
            this.cbBusiness.TabIndex = 12;
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(443, 7);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(62, 41);
            this.btnEmpty.TabIndex = 11;
            this.btnEmpty.Text = "清空(&E)";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(378, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(59, 42);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询(&S)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(73, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "选择单据：";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CSFramework.Library.ResImage.find50x50;
            this.pictureBox3.Location = new System.Drawing.Point(5, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(244, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "至";
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.Location = new System.Drawing.Point(260, 29);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateTo.Size = new System.Drawing.Size(100, 21);
            this.txtDateTo.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(77, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "修改日期：";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.Location = new System.Drawing.Point(137, 29);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateFrom.Size = new System.Drawing.Size(100, 21);
            this.txtDateFrom.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.xtraTabControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 54);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(793, 490);
            this.panelControl2.TabIndex = 2;
            // 
            // frmModifyLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(793, 544);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmModifyLog";
            this.Text = "用户修改数据的历史记录";
            this.Load += new System.EventHandler(this.frmModifyLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRowHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBusiness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtDateFrom;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnEmpty;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colOPType;
        private DevExpress.XtraGrid.Columns.GridColumn colLogUser;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTableName;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyFieldName;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colD_FieldTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colD_OldValue;
        private DevExpress.XtraGrid.Columns.GridColumn colD_NewValue;
        private DevExpress.XtraEditors.LookUpEdit cbBusiness;
        private DevExpress.XtraGrid.Columns.GridColumn colContent;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.CheckEdit chkRowHeight;
        private DevExpress.XtraGrid.Columns.GridColumn colD_TableName;
    }
}
