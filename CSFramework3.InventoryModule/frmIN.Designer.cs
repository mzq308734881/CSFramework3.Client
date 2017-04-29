namespace CSFramework3.InventoryModule
{
    partial class frmIN
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIN));
            this.gcFindGroup = new DevExpress.XtraEditors.PanelControl();
            this.txt_DocDateTo = new DevExpress.XtraEditors.DateEdit();
            this.txt_DocDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.txt_DocNoTo = new DevExpress.XtraEditors.TextEdit();
            this.txt_DocNoFrom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnEmpty = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colINNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit13 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlagApp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit18 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit31 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSupplierName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtRefNo = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtSupplierCode = new CSFramework.Library.UserControls.ucDT_CustomerEditor();
            this.lbStateName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocationID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.chkFlagApp = new DevExpress.XtraEditors.CheckEdit();
            this.txtDeliver = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtAppUser = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.txtAppDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocUser = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl36 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.txtINNO = new DevExpress.XtraEditors.TextEdit();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colD_Queue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colD_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemLookUpEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemLookUpEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit14 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelDetailPage = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFindGroup)).BeginInit();
            this.gcFindGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocNoTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocNoFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFlagApp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtINNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetailPage)).BeginInit();
            this.panelDetailPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.gcSummary);
            this.tpSummary.Controls.Add(this.gcFindGroup);
            this.tpSummary.Size = new System.Drawing.Size(965, 565);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Size = new System.Drawing.Size(972, 595);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(972, 595);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.panelDetailPage);
            this.tpDetail.Size = new System.Drawing.Size(965, 565);
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(972, 26);
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
            this.controlNavigatorSummary.Location = new System.Drawing.Point(794, 2);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(597, 2);
            // 
            // gcFindGroup
            // 
            this.gcFindGroup.Controls.Add(this.txt_DocDateTo);
            this.gcFindGroup.Controls.Add(this.txt_DocDateFrom);
            this.gcFindGroup.Controls.Add(this.txt_DocNoTo);
            this.gcFindGroup.Controls.Add(this.txt_DocNoFrom);
            this.gcFindGroup.Controls.Add(this.labelControl4);
            this.gcFindGroup.Controls.Add(this.labelControl3);
            this.gcFindGroup.Controls.Add(this.labelControl2);
            this.gcFindGroup.Controls.Add(this.labelControl1);
            this.gcFindGroup.Controls.Add(this.pictureBox3);
            this.gcFindGroup.Controls.Add(this.btnEmpty);
            this.gcFindGroup.Controls.Add(this.btnQuery);
            this.gcFindGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcFindGroup.Location = new System.Drawing.Point(0, 0);
            this.gcFindGroup.Name = "gcFindGroup";
            this.gcFindGroup.Size = new System.Drawing.Size(965, 57);
            this.gcFindGroup.TabIndex = 0;
            // 
            // txt_DocDateTo
            // 
            this.txt_DocDateTo.EditValue = null;
            this.txt_DocDateTo.Location = new System.Drawing.Point(380, 30);
            this.txt_DocDateTo.Name = "txt_DocDateTo";
            this.txt_DocDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_DocDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_DocDateTo.Size = new System.Drawing.Size(117, 21);
            this.txt_DocDateTo.TabIndex = 3;
            // 
            // txt_DocDateFrom
            // 
            this.txt_DocDateFrom.EditValue = null;
            this.txt_DocDateFrom.Location = new System.Drawing.Point(380, 3);
            this.txt_DocDateFrom.Name = "txt_DocDateFrom";
            this.txt_DocDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_DocDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_DocDateFrom.Size = new System.Drawing.Size(117, 21);
            this.txt_DocDateFrom.TabIndex = 2;
            // 
            // txt_DocNoTo
            // 
            this.txt_DocNoTo.Location = new System.Drawing.Point(150, 30);
            this.txt_DocNoTo.Name = "txt_DocNoTo";
            this.txt_DocNoTo.Size = new System.Drawing.Size(117, 21);
            this.txt_DocNoTo.TabIndex = 1;
            // 
            // txt_DocNoFrom
            // 
            this.txt_DocNoFrom.Location = new System.Drawing.Point(150, 3);
            this.txt_DocNoFrom.Name = "txt_DocNoFrom";
            this.txt_DocNoFrom.Size = new System.Drawing.Size(117, 21);
            this.txt_DocNoFrom.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(335, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "至：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(299, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "单据日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(104, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "至：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(68, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "单据号码：";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(584, 6);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(62, 41);
            this.btnEmpty.TabIndex = 5;
            this.btnEmpty.Text = "清空(&E)";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(519, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(62, 41);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询(&S)";
            // 
            // gcSummary
            // 
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.Location = new System.Drawing.Point(0, 57);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit13,
            this.repositoryItemLookUpEdit18,
            this.repositoryItemLookUpEdit30,
            this.repositoryItemLookUpEdit31});
            this.gcSummary.Size = new System.Drawing.Size(965, 508);
            this.gcSummary.TabIndex = 0;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colINNO,
            this.colDocDate,
            this.colRefNo,
            this.colSupplierCode,
            this.colSupplierName,
            this.colDepartment,
            this.colDeliver,
            this.colLocationID,
            this.colRemark,
            this.colCreationDate,
            this.colCreatedBy,
            this.colLastUpdateDate,
            this.colLastUpdatedBy,
            this.colFlagApp,
            this.colAppUser,
            this.colAppDate});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            // 
            // colINNO
            // 
            this.colINNO.Caption = "入仓单号";
            this.colINNO.FieldName = "INNO";
            this.colINNO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colINNO.Name = "colINNO";
            this.colINNO.SummaryItem.DisplayFormat = "记录：{0}";
            this.colINNO.SummaryItem.FieldName = "DocNo";
            this.colINNO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colINNO.Visible = true;
            this.colINNO.VisibleIndex = 0;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "入仓日期";
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 1;
            // 
            // colRefNo
            // 
            this.colRefNo.Caption = "来源单号";
            this.colRefNo.FieldName = "RefNo";
            this.colRefNo.Name = "colRefNo";
            this.colRefNo.Visible = true;
            this.colRefNo.VisibleIndex = 2;
            this.colRefNo.Width = 94;
            // 
            // colSupplierCode
            // 
            this.colSupplierCode.Caption = "供应商";
            this.colSupplierCode.FieldName = "SupplierCode";
            this.colSupplierCode.Name = "colSupplierCode";
            this.colSupplierCode.Visible = true;
            this.colSupplierCode.VisibleIndex = 3;
            // 
            // colSupplierName
            // 
            this.colSupplierName.Caption = "供应商名称";
            this.colSupplierName.FieldName = "SupplierName";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.Visible = true;
            this.colSupplierName.VisibleIndex = 4;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "交货部门";
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 5;
            this.colDepartment.Width = 111;
            // 
            // colDeliver
            // 
            this.colDeliver.Caption = "交货人";
            this.colDeliver.FieldName = "Deliver";
            this.colDeliver.Name = "colDeliver";
            this.colDeliver.Visible = true;
            this.colDeliver.VisibleIndex = 6;
            this.colDeliver.Width = 85;
            // 
            // colLocationID
            // 
            this.colLocationID.Caption = "仓库";
            this.colLocationID.ColumnEdit = this.repositoryItemLookUpEdit13;
            this.colLocationID.FieldName = "LocationID";
            this.colLocationID.Name = "colLocationID";
            this.colLocationID.Visible = true;
            this.colLocationID.VisibleIndex = 7;
            // 
            // repositoryItemLookUpEdit13
            // 
            this.repositoryItemLookUpEdit13.AutoHeight = false;
            this.repositoryItemLookUpEdit13.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit13.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "仓库名称")});
            this.repositoryItemLookUpEdit13.Name = "repositoryItemLookUpEdit13";
            this.repositoryItemLookUpEdit13.NullText = "";
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 8;
            // 
            // colCreationDate
            // 
            this.colCreationDate.Caption = "制单日期";
            this.colCreationDate.FieldName = "CreationDate";
            this.colCreationDate.Name = "colCreationDate";
            this.colCreationDate.Visible = true;
            this.colCreationDate.VisibleIndex = 9;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "制单人";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 10;
            // 
            // colLastUpdateDate
            // 
            this.colLastUpdateDate.Caption = "修改日期";
            this.colLastUpdateDate.FieldName = "LastUpdateDate";
            this.colLastUpdateDate.Name = "colLastUpdateDate";
            this.colLastUpdateDate.Visible = true;
            this.colLastUpdateDate.VisibleIndex = 11;
            // 
            // colLastUpdatedBy
            // 
            this.colLastUpdatedBy.Caption = "修改人";
            this.colLastUpdatedBy.FieldName = "LastUpdatedBy";
            this.colLastUpdatedBy.Name = "colLastUpdatedBy";
            this.colLastUpdatedBy.Visible = true;
            this.colLastUpdatedBy.VisibleIndex = 12;
            // 
            // colFlagApp
            // 
            this.colFlagApp.Caption = "审核";
            this.colFlagApp.FieldName = "FlagApp";
            this.colFlagApp.Name = "colFlagApp";
            this.colFlagApp.Visible = true;
            this.colFlagApp.VisibleIndex = 13;
            // 
            // colAppUser
            // 
            this.colAppUser.Caption = "审核人";
            this.colAppUser.FieldName = "AppUser";
            this.colAppUser.Name = "colAppUser";
            this.colAppUser.Visible = true;
            this.colAppUser.VisibleIndex = 14;
            // 
            // colAppDate
            // 
            this.colAppDate.Caption = "审核日期";
            this.colAppDate.FieldName = "AppDate";
            this.colAppDate.Name = "colAppDate";
            this.colAppDate.Visible = true;
            this.colAppDate.VisibleIndex = 15;
            // 
            // repositoryItemLookUpEdit18
            // 
            this.repositoryItemLookUpEdit18.AutoHeight = false;
            this.repositoryItemLookUpEdit18.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit18.Name = "repositoryItemLookUpEdit18";
            this.repositoryItemLookUpEdit18.NullText = "";
            // 
            // repositoryItemLookUpEdit30
            // 
            this.repositoryItemLookUpEdit30.AutoHeight = false;
            this.repositoryItemLookUpEdit30.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit30.Name = "repositoryItemLookUpEdit30";
            this.repositoryItemLookUpEdit30.NullText = "";
            // 
            // repositoryItemLookUpEdit31
            // 
            this.repositoryItemLookUpEdit31.AutoHeight = false;
            this.repositoryItemLookUpEdit31.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit31.Name = "repositoryItemLookUpEdit31";
            this.repositoryItemLookUpEdit31.NullText = "";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtSupplierName);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtRefNo);
            this.panelControl1.Controls.Add(this.txtRemark);
            this.panelControl1.Controls.Add(this.txtSupplierCode);
            this.panelControl1.Controls.Add(this.lbStateName);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtLocationID);
            this.panelControl1.Controls.Add(this.labelControl23);
            this.panelControl1.Controls.Add(this.labelControl22);
            this.panelControl1.Controls.Add(this.labelControl20);
            this.panelControl1.Controls.Add(this.labelControl18);
            this.panelControl1.Controls.Add(this.labelControl17);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.chkFlagApp);
            this.panelControl1.Controls.Add(this.txtDeliver);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.txtAppUser);
            this.panelControl1.Controls.Add(this.labelControl37);
            this.panelControl1.Controls.Add(this.txtAppDate);
            this.panelControl1.Controls.Add(this.labelControl21);
            this.panelControl1.Controls.Add(this.txtDepartment);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.txtDocUser);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.txtDocDate);
            this.panelControl1.Controls.Add(this.labelControl36);
            this.panelControl1.Controls.Add(this.labelControl24);
            this.panelControl1.Controls.Add(this.txtINNO);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(961, 238);
            this.panelControl1.TabIndex = 0;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.EditValue = "";
            this.txtSupplierName.Location = new System.Drawing.Point(189, 90);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(417, 21);
            this.txtSupplierName.TabIndex = 235;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(611, 69);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(7, 14);
            this.labelControl12.TabIndex = 234;
            this.labelControl12.Text = "*";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(220, 149);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 232;
            this.labelControl5.Text = "来源单号：";
            // 
            // txtRefNo
            // 
            this.txtRefNo.EditValue = "";
            this.txtRefNo.Location = new System.Drawing.Point(291, 147);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(100, 21);
            this.txtRefNo.TabIndex = 233;
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "无备注";
            this.txtRemark.Location = new System.Drawing.Point(88, 174);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(518, 54);
            this.txtRemark.TabIndex = 231;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.CustomerAttributeCodes = ",SPL,";
            this.txtSupplierCode.CustomerNameControl = this.txtSupplierName;
            this.txtSupplierCode.CustomerNameField = "NativeName";
            this.txtSupplierCode.Location = new System.Drawing.Point(87, 90);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSupplierCode.Size = new System.Drawing.Size(100, 21);
            this.txtSupplierCode.TabIndex = 230;
            this.txtSupplierCode.OnSetResult += new CSFramework.Library.SearchCallBack(this.txtSupplierCode_OnSetResult);
            // 
            // lbStateName
            // 
            this.lbStateName.AutoSize = true;
            this.lbStateName.ForeColor = System.Drawing.Color.Green;
            this.lbStateName.Location = new System.Drawing.Point(344, 19);
            this.lbStateName.Name = "lbStateName";
            this.lbStateName.Size = new System.Drawing.Size(65, 14);
            this.lbStateName.TabIndex = 38;
            this.lbStateName.Text = "(查看模式)";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(445, 1);
            this.label2.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 36;
            this.label1.Text = "入仓单(IN-Stock In)";
            // 
            // txtLocationID
            // 
            this.txtLocationID.Location = new System.Drawing.Point(88, 147);
            this.txtLocationID.Name = "txtLocationID";
            this.txtLocationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLocationID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", 80, "仓库代码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", 100, "仓库")});
            this.txtLocationID.Properties.NullText = "";
            this.txtLocationID.Properties.PopupWidth = 180;
            this.txtLocationID.Size = new System.Drawing.Size(100, 21);
            this.txtLocationID.TabIndex = 22;
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl23.Appearance.Options.UseForeColor = true;
            this.labelControl23.Location = new System.Drawing.Point(397, 124);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(7, 14);
            this.labelControl23.TabIndex = 18;
            this.labelControl23.Text = "*";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl22.Appearance.Options.UseForeColor = true;
            this.labelControl22.Location = new System.Drawing.Point(195, 124);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(7, 14);
            this.labelControl22.TabIndex = 16;
            this.labelControl22.Text = "*";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl20.Appearance.Options.UseForeColor = true;
            this.labelControl20.Location = new System.Drawing.Point(397, 66);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(7, 14);
            this.labelControl20.TabIndex = 7;
            this.labelControl20.Text = "*";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Appearance.Options.UseForeColor = true;
            this.labelControl18.Location = new System.Drawing.Point(195, 151);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(7, 14);
            this.labelControl18.TabIndex = 23;
            this.labelControl18.Text = "*";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(41, 151);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(36, 14);
            this.labelControl17.TabIndex = 21;
            this.labelControl17.Text = "仓库：";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.Location = new System.Drawing.Point(611, 94);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(7, 14);
            this.labelControl11.TabIndex = 12;
            this.labelControl11.Text = "*";
            // 
            // chkFlagApp
            // 
            this.chkFlagApp.Location = new System.Drawing.Point(504, 38);
            this.chkFlagApp.Name = "chkFlagApp";
            this.chkFlagApp.Properties.Caption = "是否审核";
            this.chkFlagApp.Properties.DisplayValueChecked = "Y";
            this.chkFlagApp.Properties.DisplayValueUnchecked = "N";
            this.chkFlagApp.Properties.ValueChecked = "Y";
            this.chkFlagApp.Properties.ValueUnchecked = "N";
            this.chkFlagApp.Size = new System.Drawing.Size(87, 19);
            this.chkFlagApp.TabIndex = 2;
            // 
            // txtDeliver
            // 
            this.txtDeliver.Location = new System.Drawing.Point(291, 118);
            this.txtDeliver.Name = "txtDeliver";
            this.txtDeliver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDeliver.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Account", 80, "用户帐号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", 100, "用户名")});
            this.txtDeliver.Properties.ImmediatePopup = true;
            this.txtDeliver.Properties.NullText = "";
            this.txtDeliver.Properties.PopupWidth = 180;
            this.txtDeliver.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.txtDeliver.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDeliver.Size = new System.Drawing.Size(100, 21);
            this.txtDeliver.TabIndex = 17;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(232, 122);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 14);
            this.labelControl10.TabIndex = 19;
            this.labelControl10.Text = "交货人：";
            // 
            // txtAppUser
            // 
            this.txtAppUser.Location = new System.Drawing.Point(506, 118);
            this.txtAppUser.Name = "txtAppUser";
            this.txtAppUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAppUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Account", 80, "用户帐号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", 100, "用户名")});
            this.txtAppUser.Properties.NullText = "";
            this.txtAppUser.Properties.PopupWidth = 180;
            this.txtAppUser.Size = new System.Drawing.Size(100, 21);
            this.txtAppUser.TabIndex = 33;
            // 
            // labelControl37
            // 
            this.labelControl37.Location = new System.Drawing.Point(447, 120);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(48, 14);
            this.labelControl37.TabIndex = 32;
            this.labelControl37.Text = "审批人：";
            // 
            // txtAppDate
            // 
            this.txtAppDate.EditValue = new System.DateTime(2010, 10, 29, 0, 0, 0, 0);
            this.txtAppDate.Location = new System.Drawing.Point(506, 147);
            this.txtAppDate.Name = "txtAppDate";
            this.txtAppDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAppDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAppDate.Size = new System.Drawing.Size(100, 21);
            this.txtAppDate.TabIndex = 35;
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(435, 151);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(60, 14);
            this.labelControl21.TabIndex = 34;
            this.labelControl21.Text = "审批日期：";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(88, 118);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataCode", 80, "部门编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NativeName", 100, "部门名称")});
            this.txtDepartment.Properties.ImmediatePopup = true;
            this.txtDepartment.Properties.NullText = "";
            this.txtDepartment.Properties.PopupWidth = 180;
            this.txtDepartment.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.txtDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDepartment.Size = new System.Drawing.Size(100, 21);
            this.txtDepartment.TabIndex = 15;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(17, 122);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "交货部门：";
            // 
            // txtDocUser
            // 
            this.txtDocUser.Location = new System.Drawing.Point(506, 63);
            this.txtDocUser.Name = "txtDocUser";
            this.txtDocUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDocUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Account", 80, "用户帐号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", 100, "用户名")});
            this.txtDocUser.Properties.NullText = "";
            this.txtDocUser.Properties.PopupWidth = 180;
            this.txtDocUser.Size = new System.Drawing.Size(100, 21);
            this.txtDocUser.TabIndex = 20;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(17, 66);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "入仓单号：";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(447, 65);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 14);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "制单人：";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(41, 177);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(36, 14);
            this.labelControl9.TabIndex = 26;
            this.labelControl9.Text = "备注：";
            // 
            // txtDocDate
            // 
            this.txtDocDate.EditValue = new System.DateTime(2010, 10, 1, 0, 0, 0, 0);
            this.txtDocDate.Location = new System.Drawing.Point(291, 63);
            this.txtDocDate.Name = "txtDocDate";
            this.txtDocDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDocDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDocDate.Size = new System.Drawing.Size(100, 21);
            this.txtDocDate.TabIndex = 6;
            // 
            // labelControl36
            // 
            this.labelControl36.Location = new System.Drawing.Point(217, 67);
            this.labelControl36.Name = "labelControl36";
            this.labelControl36.Size = new System.Drawing.Size(60, 14);
            this.labelControl36.TabIndex = 6;
            this.labelControl36.Text = "入仓日期：";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(29, 94);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(48, 14);
            this.labelControl24.TabIndex = 9;
            this.labelControl24.Text = "供应商：";
            // 
            // txtINNO
            // 
            this.txtINNO.EditValue = "";
            this.txtINNO.Location = new System.Drawing.Point(88, 63);
            this.txtINNO.Name = "txtINNO";
            this.txtINNO.Size = new System.Drawing.Size(100, 21);
            this.txtINNO.TabIndex = 4;
            // 
            // gcDetail
            // 
            this.gcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetail.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDetail.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDetail.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDetail.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDetail.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcDetail.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcDetail.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDetail.Location = new System.Drawing.Point(2, 2);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4,
            this.repositoryItemLookUpEdit5,
            this.repositoryItemLookUpEdit6,
            this.repositoryItemLookUpEdit7,
            this.repositoryItemLookUpEdit8,
            this.repositoryItemLookUpEdit9,
            this.repositoryItemLookUpEdit10,
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit1,
            this.repositoryItemLookUpEdit12,
            this.repositoryItemButtonEdit2,
            this.repositoryItemButtonEdit3,
            this.repositoryItemLookUpEdit11,
            this.repositoryItemLookUpEdit14,
            this.repositoryItemLookUpEdit15,
            this.repositoryItemComboBox2});
            this.gcDetail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcDetail.Size = new System.Drawing.Size(957, 298);
            this.gcDetail.TabIndex = 1;
            this.gcDetail.UseEmbeddedNavigator = true;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colD_Queue,
            this.colD_ProductCode,
            this.colD_ProductName,
            this.colD_Quantity,
            this.colD_Remark});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.OptionsView.ShowFooter = true;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colD_Queue
            // 
            this.colD_Queue.Caption = "#";
            this.colD_Queue.FieldName = "Queue";
            this.colD_Queue.Name = "colD_Queue";
            // 
            // colD_ProductCode
            // 
            this.colD_ProductCode.Caption = "货品编码";
            this.colD_ProductCode.ColumnEdit = this.repositoryItemButtonEdit2;
            this.colD_ProductCode.FieldName = "ProductCode";
            this.colD_ProductCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colD_ProductCode.Name = "colD_ProductCode";
            this.colD_ProductCode.SummaryItem.DisplayFormat = "{0}";
            this.colD_ProductCode.SummaryItem.FieldName = "StockCode";
            this.colD_ProductCode.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colD_ProductCode.Visible = true;
            this.colD_ProductCode.VisibleIndex = 0;
            this.colD_ProductCode.Width = 111;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // colD_ProductName
            // 
            this.colD_ProductName.Caption = "货品名称";
            this.colD_ProductName.FieldName = "ProductName";
            this.colD_ProductName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colD_ProductName.Name = "colD_ProductName";
            this.colD_ProductName.OptionsColumn.AllowEdit = false;
            this.colD_ProductName.OptionsColumn.ReadOnly = true;
            this.colD_ProductName.Visible = true;
            this.colD_ProductName.VisibleIndex = 1;
            this.colD_ProductName.Width = 262;
            // 
            // colD_Quantity
            // 
            this.colD_Quantity.Caption = "数量";
            this.colD_Quantity.FieldName = "Quantity";
            this.colD_Quantity.Name = "colD_Quantity";
            this.colD_Quantity.SummaryItem.DisplayFormat = "{0}";
            this.colD_Quantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colD_Quantity.Visible = true;
            this.colD_Quantity.VisibleIndex = 2;
            this.colD_Quantity.Width = 115;
            // 
            // colD_Remark
            // 
            this.colD_Remark.Caption = "备注";
            this.colD_Remark.FieldName = "Remark";
            this.colD_Remark.Name = "colD_Remark";
            this.colD_Remark.Visible = true;
            this.colD_Remark.VisibleIndex = 3;
            this.colD_Remark.Width = 307;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SpecName", 40, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SpecName", 140, "说明")});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            this.repositoryItemLookUpEdit5.NullText = "";
            // 
            // repositoryItemLookUpEdit6
            // 
            this.repositoryItemLookUpEdit6.AutoHeight = false;
            this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
            this.repositoryItemLookUpEdit6.NullText = "";
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WID", 60, "仓库号码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WName", 200, "仓库名称")});
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            this.repositoryItemLookUpEdit7.PopupWidth = 200;
            // 
            // repositoryItemLookUpEdit8
            // 
            this.repositoryItemLookUpEdit8.AutoHeight = false;
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit8.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CertID", 80, "证明书编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PCNO", 80, "申购合约"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TakeNo", 80, "提单号码")});
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            this.repositoryItemLookUpEdit8.PopupWidth = 250;
            // 
            // repositoryItemLookUpEdit9
            // 
            this.repositoryItemLookUpEdit9.AutoHeight = false;
            this.repositoryItemLookUpEdit9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit9.Name = "repositoryItemLookUpEdit9";
            this.repositoryItemLookUpEdit9.NullText = "";
            // 
            // repositoryItemLookUpEdit10
            // 
            this.repositoryItemLookUpEdit10.AutoHeight = false;
            this.repositoryItemLookUpEdit10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit10.Name = "repositoryItemLookUpEdit10";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemLookUpEdit12
            // 
            this.repositoryItemLookUpEdit12.AutoHeight = false;
            this.repositoryItemLookUpEdit12.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit12.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            this.repositoryItemLookUpEdit12.Name = "repositoryItemLookUpEdit12";
            this.repositoryItemLookUpEdit12.NullText = "";
            // 
            // repositoryItemButtonEdit3
            // 
            this.repositoryItemButtonEdit3.AutoHeight = false;
            this.repositoryItemButtonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit3.Name = "repositoryItemButtonEdit3";
            // 
            // repositoryItemLookUpEdit11
            // 
            this.repositoryItemLookUpEdit11.AutoHeight = false;
            this.repositoryItemLookUpEdit11.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit11.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StorageCode", 100, "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StorageName", 200, "仓库名称")});
            this.repositoryItemLookUpEdit11.ImmediatePopup = true;
            this.repositoryItemLookUpEdit11.Name = "repositoryItemLookUpEdit11";
            this.repositoryItemLookUpEdit11.NullText = "";
            this.repositoryItemLookUpEdit11.PopupWidth = 300;
            this.repositoryItemLookUpEdit11.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.repositoryItemLookUpEdit11.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemLookUpEdit14
            // 
            this.repositoryItemLookUpEdit14.AutoHeight = false;
            this.repositoryItemLookUpEdit14.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit14.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitCode", 100, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", 200, "名称")});
            this.repositoryItemLookUpEdit14.ImmediatePopup = true;
            this.repositoryItemLookUpEdit14.Name = "repositoryItemLookUpEdit14";
            this.repositoryItemLookUpEdit14.NullText = "";
            this.repositoryItemLookUpEdit14.PopupWidth = 300;
            this.repositoryItemLookUpEdit14.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.repositoryItemLookUpEdit14.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemLookUpEdit15
            // 
            this.repositoryItemLookUpEdit15.AutoHeight = false;
            this.repositoryItemLookUpEdit15.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit15.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitCode", 100, "单位编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", 200, "单位名称")});
            this.repositoryItemLookUpEdit15.ImmediatePopup = true;
            this.repositoryItemLookUpEdit15.Name = "repositoryItemLookUpEdit15";
            this.repositoryItemLookUpEdit15.NullText = "";
            this.repositoryItemLookUpEdit15.PopupWidth = 300;
            this.repositoryItemLookUpEdit15.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.repositoryItemLookUpEdit15.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // panelDetailPage
            // 
            this.panelDetailPage.Controls.Add(this.panelControl2);
            this.panelDetailPage.Controls.Add(this.panelControl1);
            this.panelDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetailPage.Location = new System.Drawing.Point(0, 0);
            this.panelDetailPage.Name = "panelDetailPage";
            this.panelDetailPage.Size = new System.Drawing.Size(965, 565);
            this.panelDetailPage.TabIndex = 2;
            this.panelDetailPage.Text = "入仓单明细数据";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcDetail);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 261);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(961, 302);
            this.panelControl2.TabIndex = 2;
            // 
            // frmIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(972, 621);
            this.Name = "frmIN";
            this.Text = "入仓单 (Stock In)";
            this.Load += new System.EventHandler(this.frmIN_Load);
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFindGroup)).EndInit();
            this.gcFindGroup.ResumeLayout(false);
            this.gcFindGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocNoTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DocNoFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFlagApp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtINNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetailPage)).EndInit();
            this.panelDetailPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl gcFindGroup;
        private DevExpress.XtraEditors.SimpleButton btnEmpty;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_DocNoTo;
        private DevExpress.XtraEditors.TextEdit txt_DocNoFrom;
        private DevExpress.XtraEditors.DateEdit txt_DocDateFrom;
        private DevExpress.XtraEditors.DateEdit txt_DocDateTo;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colINNO;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliver;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit txtAppUser;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.DateEdit txtAppDate;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LookUpEdit txtDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit txtDocUser;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit txtDocDate;
        private DevExpress.XtraEditors.LabelControl labelControl36;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.TextEdit txtINNO;
        private DevExpress.XtraEditors.LookUpEdit txtDeliver;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit13;
        private DevExpress.XtraGrid.Columns.GridColumn colFlagApp;
        private DevExpress.XtraGrid.Columns.GridColumn colAppUser;
        private DevExpress.XtraGrid.Columns.GridColumn colAppDate;
        private DevExpress.XtraEditors.CheckEdit chkFlagApp;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colD_Queue;
        private DevExpress.XtraGrid.Columns.GridColumn colD_ProductCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colD_ProductName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit11;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colD_Quantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit15;
        private DevExpress.XtraGrid.Columns.GridColumn colD_Remark;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit10;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit14;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LookUpEdit txtLocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit18;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit30;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit31;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStateName;
        private CSFramework.Library.UserControls.ucDT_CustomerEditor txtSupplierCode;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtRefNo;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.GroupControl panelDetailPage;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraEditors.TextEdit txtSupplierName;
    }
}
