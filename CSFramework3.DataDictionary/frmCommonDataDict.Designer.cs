namespace CSFramework3.DataDictionary
{
    partial class frmCommonDataDict
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txt_CommonType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.btnEmpty = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDataCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNativeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnglishName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDetailEditor = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtDataCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNativeName = new DevExpress.XtraEditors.TextEdit();
            this.txtEnglishName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelCommonType = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddCommonType = new DevExpress.XtraEditors.SimpleButton();
            this.txtCommonTypeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCommonTypeId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDataType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CommonType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).BeginInit();
            this.gcDetailEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNativeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglishName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommonTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommonTypeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.tableLayoutPanel1);
            this.tpSummary.Size = new System.Drawing.Size(815, 565);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Size = new System.Drawing.Size(822, 595);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(822, 595);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.gcDetailEditor);
            this.tpDetail.Size = new System.Drawing.Size(815, 565);
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(822, 26);
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
            this.controlNavigatorSummary.Location = new System.Drawing.Point(644, 2);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(447, 2);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gcSummary, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 565);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.txt_CommonType);
            this.panelControl3.Controls.Add(this.labelControl25);
            this.panelControl3.Controls.Add(this.btnEmpty);
            this.panelControl3.Controls.Add(this.btnQuery);
            this.panelControl3.Controls.Add(this.pictureBox3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(809, 54);
            this.panelControl3.TabIndex = 11;
            // 
            // txt_CommonType
            // 
            this.txt_CommonType.Location = new System.Drawing.Point(140, 17);
            this.txt_CommonType.Name = "txt_CommonType";
            this.txt_CommonType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_CommonType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataType", 50, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", 100, "名称")});
            this.txt_CommonType.Properties.NullText = "";
            this.txt_CommonType.Size = new System.Drawing.Size(118, 21);
            this.txt_CommonType.TabIndex = 29;
            // 
            // labelControl25
            // 
            this.labelControl25.Location = new System.Drawing.Point(62, 20);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(72, 14);
            this.labelControl25.TabIndex = 25;
            this.labelControl25.Text = "按类型查询：";
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(374, 12);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(76, 28);
            this.btnEmpty.TabIndex = 21;
            this.btnEmpty.Text = "清空(&E)";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(290, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(73, 29);
            this.btnQuery.TabIndex = 20;
            this.btnQuery.Text = "查询(&S)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CSFramework3.DataDictionary.Properties.Resources.find50x50;
            this.pictureBox3.Location = new System.Drawing.Point(5, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
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
            this.gcSummary.Location = new System.Drawing.Point(3, 63);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gcSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcSummary.Size = new System.Drawing.Size(809, 499);
            this.gcSummary.TabIndex = 10;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDataType,
            this.colDataCode,
            this.colNativeName,
            this.colEnglishName});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            // 
            // colDataType
            // 
            this.colDataType.Caption = "类型";
            this.colDataType.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.SummaryItem.DisplayFormat = "{0}";
            this.colDataType.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 0;
            this.colDataType.Width = 115;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "名称")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // colDataCode
            // 
            this.colDataCode.Caption = "编号";
            this.colDataCode.FieldName = "DataCode";
            this.colDataCode.Name = "colDataCode";
            this.colDataCode.Visible = true;
            this.colDataCode.VisibleIndex = 1;
            this.colDataCode.Width = 108;
            // 
            // colNativeName
            // 
            this.colNativeName.Caption = "名称";
            this.colNativeName.FieldName = "NativeName";
            this.colNativeName.Name = "colNativeName";
            this.colNativeName.Visible = true;
            this.colNativeName.VisibleIndex = 2;
            this.colNativeName.Width = 195;
            // 
            // colEnglishName
            // 
            this.colEnglishName.Caption = "英文名";
            this.colEnglishName.FieldName = "EnglishName";
            this.colEnglishName.Name = "colEnglishName";
            this.colEnglishName.Visible = true;
            this.colEnglishName.VisibleIndex = 3;
            this.colEnglishName.Width = 198;
            // 
            // gcDetailEditor
            // 
            this.gcDetailEditor.Controls.Add(this.panelControl1);
            this.gcDetailEditor.Controls.Add(this.labelControl9);
            this.gcDetailEditor.Controls.Add(this.groupControl2);
            this.gcDetailEditor.Controls.Add(this.txtDataType);
            this.gcDetailEditor.Controls.Add(this.labelControl4);
            this.gcDetailEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetailEditor.Location = new System.Drawing.Point(0, 0);
            this.gcDetailEditor.Name = "gcDetailEditor";
            this.gcDetailEditor.Size = new System.Drawing.Size(815, 565);
            this.gcDetailEditor.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtDataCode);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtNativeName);
            this.panelControl1.Controls.Add(this.txtEnglishName);
            this.panelControl1.Location = new System.Drawing.Point(115, 214);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(414, 123);
            this.panelControl1.TabIndex = 39;
            // 
            // txtDataCode
            // 
            this.txtDataCode.Location = new System.Drawing.Point(64, 19);
            this.txtDataCode.Name = "txtDataCode";
            this.txtDataCode.Size = new System.Drawing.Size(121, 21);
            this.txtDataCode.TabIndex = 28;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(390, 53);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(7, 14);
            this.labelControl10.TabIndex = 38;
            this.labelControl10.Text = "*";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(191, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "(跟据类型自动生成)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "英文名：";
            // 
            // txtNativeName
            // 
            this.txtNativeName.Location = new System.Drawing.Point(64, 46);
            this.txtNativeName.Name = "txtNativeName";
            this.txtNativeName.Size = new System.Drawing.Size(320, 21);
            this.txtNativeName.TabIndex = 31;
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Location = new System.Drawing.Point(64, 72);
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(320, 21);
            this.txtEnglishName.TabIndex = 32;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(441, 57);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(7, 14);
            this.labelControl9.TabIndex = 37;
            this.labelControl9.Text = "*";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelCommonType);
            this.groupControl2.Controls.Add(this.btnAddCommonType);
            this.groupControl2.Controls.Add(this.txtCommonTypeName);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.txtCommonTypeId);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(115, 76);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(320, 115);
            this.groupControl2.TabIndex = 35;
            // 
            // btnDelCommonType
            // 
            this.btnDelCommonType.Location = new System.Drawing.Point(126, 78);
            this.btnDelCommonType.Name = "btnDelCommonType";
            this.btnDelCommonType.Size = new System.Drawing.Size(56, 22);
            this.btnDelCommonType.TabIndex = 35;
            this.btnDelCommonType.Text = "删除";
            this.btnDelCommonType.Click += new System.EventHandler(this.btnDelCommonType_Click);
            // 
            // btnAddCommonType
            // 
            this.btnAddCommonType.Location = new System.Drawing.Point(64, 78);
            this.btnAddCommonType.Name = "btnAddCommonType";
            this.btnAddCommonType.Size = new System.Drawing.Size(56, 22);
            this.btnAddCommonType.TabIndex = 34;
            this.btnAddCommonType.Text = "新增";
            this.btnAddCommonType.Click += new System.EventHandler(this.btnAddCommonType_Click);
            // 
            // txtCommonTypeName
            // 
            this.txtCommonTypeName.Location = new System.Drawing.Point(64, 51);
            this.txtCommonTypeName.Name = "txtCommonTypeName";
            this.txtCommonTypeName.Size = new System.Drawing.Size(239, 21);
            this.txtCommonTypeName.TabIndex = 33;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(22, 54);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 32;
            this.labelControl8.Text = "名称：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(128, 28);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 14);
            this.labelControl7.TabIndex = 31;
            this.labelControl7.Text = "数字,不能重复";
            // 
            // txtCommonTypeId
            // 
            this.txtCommonTypeId.Location = new System.Drawing.Point(64, 25);
            this.txtCommonTypeId.Name = "txtCommonTypeId";
            this.txtCommonTypeId.Size = new System.Drawing.Size(57, 21);
            this.txtCommonTypeId.TabIndex = 30;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(22, 28);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 29;
            this.labelControl6.Text = "编号：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(64, 5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(191, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "* 如没有公共数据类型请在这里增加";
            // 
            // txtDataType
            // 
            this.txtDataType.Location = new System.Drawing.Point(115, 52);
            this.txtDataType.Name = "txtDataType";
            this.txtDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDataType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataType", 50, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", 100, "名称")});
            this.txtDataType.Properties.NullText = "";
            this.txtDataType.Size = new System.Drawing.Size(320, 21);
            this.txtDataType.TabIndex = 34;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 55);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "公共数据类型：";
            // 
            // frmCommonDataDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(822, 621);
            this.Name = "frmCommonDataDict";
            this.Text = "公共数据字典窗体";
            this.Load += new System.EventHandler(this.frmCommonDataDict_Load);
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CommonType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).EndInit();
            this.gcDetailEditor.ResumeLayout(false);
            this.gcDetailEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNativeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglishName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommonTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommonTypeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LookUpEdit txt_CommonType;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.SimpleButton btnEmpty;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colNativeName;
        private DevExpress.XtraGrid.Columns.GridColumn colEnglishName;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCode;
        private DevExpress.XtraEditors.GroupControl gcDetailEditor;
        private DevExpress.XtraEditors.TextEdit txtNativeName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDataCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEnglishName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit txtDataType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCommonTypeId;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnAddCommonType;
        private DevExpress.XtraEditors.TextEdit txtCommonTypeName;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnDelCommonType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
