using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace CSFramework.Tools.ClassGenerator
{
    partial class frmClassGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassGenerator));
            this.gcStuct = new DevExpress.XtraGrid.GridControl();
            this.gvStuct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLookup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditLookup = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsAddOrUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditAddOrUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsPrimaryKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditIsPrimaryKey = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsForeignKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditIsForeignKey = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsNumberKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditNumberKey = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtPrimaryKey = new DevExpress.XtraEditors.TextEdit();
            this.cbxDbType = new DevExpress.XtraEditors.CheckEdit();
            this.txtCode = new DevExpress.XtraEditors.MemoEdit();
            this.btnGetStuct = new DevExpress.XtraEditors.SimpleButton();
            this.btnTableFields = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetTables = new DevExpress.XtraEditors.SimpleButton();
            this.txtSpaceName = new DevExpress.XtraEditors.TextEdit();
            this.lbxTables = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.btnClass = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.chkSummaryTable = new DevExpress.XtraEditors.CheckEdit();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.tabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveCS = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.tabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.chkExportToFileORM = new DevExpress.XtraEditors.CheckEdit();
            this.chkPreviewCode = new DevExpress.XtraEditors.CheckEdit();
            this.label44 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutpup_ORM = new DevExpress.XtraEditors.TextEdit();
            this.label45 = new DevExpress.XtraEditors.LabelControl();
            this.chkGenFields = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1 = new DevExpress.XtraEditors.PanelControl();
            this.txtConnString = new DevExpress.XtraEditors.MemoEdit();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtComment = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtClassName = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox3 = new DevExpress.XtraEditors.GroupControl();
            this.chkExportToFileBLL = new DevExpress.XtraEditors.CheckEdit();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtUsingNamespace = new DevExpress.XtraEditors.MemoEdit();
            this.chkPreviewBLL = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox4 = new DevExpress.XtraEditors.GroupControl();
            this.txtFormName = new DevExpress.XtraEditors.TextEdit();
            this.chkBusinessLog = new DevExpress.XtraEditors.CheckEdit();
            this.label21 = new DevExpress.XtraEditors.LabelControl();
            this.label20 = new DevExpress.XtraEditors.LabelControl();
            this.label41 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutpup_BLL_Business = new DevExpress.XtraEditors.TextEdit();
            this.label40 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutpup_BLL_DataDict = new DevExpress.XtraEditors.TextEdit();
            this.label23 = new DevExpress.XtraEditors.LabelControl();
            this.label22 = new DevExpress.XtraEditors.LabelControl();
            this.btnGenBLLBusiness = new DevExpress.XtraEditors.SimpleButton();
            this.label32 = new DevExpress.XtraEditors.LabelControl();
            this.label33 = new DevExpress.XtraEditors.LabelControl();
            this.txtORM = new DevExpress.XtraEditors.TextEdit();
            this.label19 = new DevExpress.XtraEditors.LabelControl();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.label18 = new DevExpress.XtraEditors.LabelControl();
            this.txtBllNamespace = new DevExpress.XtraEditors.TextEdit();
            this.label17 = new DevExpress.XtraEditors.LabelControl();
            this.label16 = new DevExpress.XtraEditors.LabelControl();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.label14 = new DevExpress.XtraEditors.LabelControl();
            this.txtDAL = new DevExpress.XtraEditors.TextEdit();
            this.txtConcretelyName = new DevExpress.XtraEditors.TextEdit();
            this.btnGenBLLDataDict = new DevExpress.XtraEditors.SimpleButton();
            this.label46 = new DevExpress.XtraEditors.LabelControl();
            this.label47 = new DevExpress.XtraEditors.LabelControl();
            this.label48 = new DevExpress.XtraEditors.LabelControl();
            this.txtBLL = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox2 = new DevExpress.XtraEditors.GroupControl();
            this.chkExportToFileDAL = new DevExpress.XtraEditors.CheckEdit();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtUsingNamespace_DAL = new DevExpress.XtraEditors.MemoEdit();
            this.chkPreviewDAL = new DevExpress.XtraEditors.CheckEdit();
            this.label42 = new DevExpress.XtraEditors.LabelControl();
            this.label43 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutpup_DAL_DataDict = new DevExpress.XtraEditors.TextEdit();
            this.txtOutpup_DAL_Business = new DevExpress.XtraEditors.TextEdit();
            this.label30 = new DevExpress.XtraEditors.LabelControl();
            this.label37 = new DevExpress.XtraEditors.LabelControl();
            this.btnGenDALBusiness = new DevExpress.XtraEditors.SimpleButton();
            this.label24 = new DevExpress.XtraEditors.LabelControl();
            this.label25 = new DevExpress.XtraEditors.LabelControl();
            this.txtORM_DAL = new DevExpress.XtraEditors.TextEdit();
            this.label26 = new DevExpress.XtraEditors.LabelControl();
            this.label27 = new DevExpress.XtraEditors.LabelControl();
            this.label28 = new DevExpress.XtraEditors.LabelControl();
            this.txtNamespace_DAL = new DevExpress.XtraEditors.TextEdit();
            this.label29 = new DevExpress.XtraEditors.LabelControl();
            this.label31 = new DevExpress.XtraEditors.LabelControl();
            this.label34 = new DevExpress.XtraEditors.LabelControl();
            this.txtDAL_DAL = new DevExpress.XtraEditors.TextEdit();
            this.txtConcretelyName_DAL = new DevExpress.XtraEditors.TextEdit();
            this.btnGenDALDataDict = new DevExpress.XtraEditors.SimpleButton();
            this.label35 = new DevExpress.XtraEditors.LabelControl();
            this.label36 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtSolutionFolder = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcStuct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStuct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditAddOrUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsPrimaryKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsForeignKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditNumberKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimaryKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpaceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbxTables.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSummaryTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExportToFileORM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreviewCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_ORM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenFields.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassName.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExportToFileBLL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsingNamespace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreviewBLL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBusinessLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_BLL_Business.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_BLL_DataDict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtORM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBllNamespace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcretelyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLL.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExportToFileDAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsingNamespace_DAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreviewDAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_DAL_DataDict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_DAL_Business.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtORM_DAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamespace_DAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDAL_DAL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcretelyName_DAL.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSolutionFolder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcStuct
            // 
            this.gcStuct.Location = new System.Drawing.Point(3, 203);
            this.gcStuct.MainView = this.gvStuct;
            this.gcStuct.Name = "gcStuct";
            this.gcStuct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditLookup,
            this.repositoryItemCheckEditAddOrUpdate,
            this.repositoryItemCheckEditIsPrimaryKey,
            this.repositoryItemCheckEditNumberKey,
            this.repositoryItemCheckEditIsForeignKey});
            this.gcStuct.Size = new System.Drawing.Size(778, 282);
            this.gcStuct.TabIndex = 30;
            this.gcStuct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStuct});
            // 
            // gvStuct
            // 
            this.gvStuct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colType,
            this.colLength,
            this.colIsLookup,
            this.colIsAddOrUpdate,
            this.colIsPrimaryKey,
            this.colIsForeignKey,
            this.colIsNumberKey});
            this.gvStuct.GridControl = this.gcStuct;
            this.gvStuct.Name = "gvStuct";
            this.gvStuct.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvStuct.OptionsFilter.AllowFilterEditor = false;
            this.gvStuct.OptionsFilter.AllowMRUFilterList = false;
            this.gvStuct.OptionsView.ColumnAutoWidth = false;
            this.gvStuct.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "列名";
            this.colName.FieldName = "colName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 111;
            // 
            // colType
            // 
            this.colType.Caption = "类型";
            this.colType.FieldName = "colType";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            this.colType.Width = 122;
            // 
            // colLength
            // 
            this.colLength.Caption = "长度";
            this.colLength.FieldName = "colLength";
            this.colLength.Name = "colLength";
            this.colLength.Visible = true;
            this.colLength.VisibleIndex = 2;
            this.colLength.Width = 56;
            // 
            // colIsLookup
            // 
            this.colIsLookup.Caption = "是否查询列";
            this.colIsLookup.ColumnEdit = this.repositoryItemCheckEditLookup;
            this.colIsLookup.FieldName = "colIsLookup";
            this.colIsLookup.Name = "colIsLookup";
            this.colIsLookup.Visible = true;
            this.colIsLookup.VisibleIndex = 3;
            this.colIsLookup.Width = 90;
            // 
            // repositoryItemCheckEditLookup
            // 
            this.repositoryItemCheckEditLookup.AutoHeight = false;
            this.repositoryItemCheckEditLookup.Name = "repositoryItemCheckEditLookup";
            // 
            // colIsAddOrUpdate
            // 
            this.colIsAddOrUpdate.Caption = "是否新增修改列";
            this.colIsAddOrUpdate.ColumnEdit = this.repositoryItemCheckEditAddOrUpdate;
            this.colIsAddOrUpdate.FieldName = "colIsAddOrUpdate";
            this.colIsAddOrUpdate.Name = "colIsAddOrUpdate";
            this.colIsAddOrUpdate.Visible = true;
            this.colIsAddOrUpdate.VisibleIndex = 4;
            this.colIsAddOrUpdate.Width = 113;
            // 
            // repositoryItemCheckEditAddOrUpdate
            // 
            this.repositoryItemCheckEditAddOrUpdate.AutoHeight = false;
            this.repositoryItemCheckEditAddOrUpdate.Name = "repositoryItemCheckEditAddOrUpdate";
            // 
            // colIsPrimaryKey
            // 
            this.colIsPrimaryKey.Caption = "是否主键列";
            this.colIsPrimaryKey.ColumnEdit = this.repositoryItemCheckEditIsPrimaryKey;
            this.colIsPrimaryKey.FieldName = "colIsPrimaryKey";
            this.colIsPrimaryKey.Name = "colIsPrimaryKey";
            this.colIsPrimaryKey.Visible = true;
            this.colIsPrimaryKey.VisibleIndex = 5;
            this.colIsPrimaryKey.Width = 88;
            // 
            // repositoryItemCheckEditIsPrimaryKey
            // 
            this.repositoryItemCheckEditIsPrimaryKey.AutoHeight = false;
            this.repositoryItemCheckEditIsPrimaryKey.Name = "repositoryItemCheckEditIsPrimaryKey";
            // 
            // colIsForeignKey
            // 
            this.colIsForeignKey.Caption = "是否外键";
            this.colIsForeignKey.ColumnEdit = this.repositoryItemCheckEditIsForeignKey;
            this.colIsForeignKey.FieldName = "colIsForeignKey";
            this.colIsForeignKey.Name = "colIsForeignKey";
            this.colIsForeignKey.Visible = true;
            this.colIsForeignKey.VisibleIndex = 6;
            this.colIsForeignKey.Width = 73;
            // 
            // repositoryItemCheckEditIsForeignKey
            // 
            this.repositoryItemCheckEditIsForeignKey.AutoHeight = false;
            this.repositoryItemCheckEditIsForeignKey.Name = "repositoryItemCheckEditIsForeignKey";
            // 
            // colIsNumberKey
            // 
            this.colIsNumberKey.Caption = "是否流水号";
            this.colIsNumberKey.ColumnEdit = this.repositoryItemCheckEditNumberKey;
            this.colIsNumberKey.FieldName = "colIsNumberKey";
            this.colIsNumberKey.Name = "colIsNumberKey";
            this.colIsNumberKey.Visible = true;
            this.colIsNumberKey.VisibleIndex = 7;
            this.colIsNumberKey.Width = 86;
            // 
            // repositoryItemCheckEditNumberKey
            // 
            this.repositoryItemCheckEditNumberKey.AutoHeight = false;
            this.repositoryItemCheckEditNumberKey.Name = "repositoryItemCheckEditNumberKey";
            // 
            // txtPrimaryKey
            // 
            this.txtPrimaryKey.Location = new System.Drawing.Point(95, 168);
            this.txtPrimaryKey.Name = "txtPrimaryKey";
            this.txtPrimaryKey.Size = new System.Drawing.Size(119, 21);
            this.txtPrimaryKey.TabIndex = 37;
            // 
            // cbxDbType
            // 
            this.cbxDbType.EditValue = true;
            this.cbxDbType.Enabled = false;
            this.cbxDbType.Location = new System.Drawing.Point(377, 82);
            this.cbxDbType.Name = "cbxDbType";
            this.cbxDbType.Properties.Caption = "数据库字符集";
            this.cbxDbType.Size = new System.Drawing.Size(98, 19);
            this.cbxDbType.TabIndex = 40;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.EditValue = "";
            this.txtCode.Location = new System.Drawing.Point(3, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(774, 531);
            this.txtCode.TabIndex = 41;
            // 
            // btnGetStuct
            // 
            this.btnGetStuct.Location = new System.Drawing.Point(95, 135);
            this.btnGetStuct.Name = "btnGetStuct";
            this.btnGetStuct.Size = new System.Drawing.Size(119, 26);
            this.btnGetStuct.TabIndex = 43;
            this.btnGetStuct.Text = "取表结构";
            this.btnGetStuct.Click += new System.EventHandler(this.btnGetStuct_Click);
            // 
            // btnTableFields
            // 
            this.btnTableFields.Location = new System.Drawing.Point(109, 535);
            this.btnTableFields.Name = "btnTableFields";
            this.btnTableFields.Size = new System.Drawing.Size(115, 26);
            this.btnTableFields.TabIndex = 44;
            this.btnTableFields.Text = "生成表结构静态类";
            this.btnTableFields.Click += new System.EventHandler(this.btnTableFields_Click);
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(95, 50);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(119, 26);
            this.btnGetTables.TabIndex = 45;
            this.btnGetTables.Text = "取用户表和视图";
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // txtSpaceName
            // 
            this.txtSpaceName.EditValue = "CSFramework3.Models";
            this.txtSpaceName.Location = new System.Drawing.Point(392, 168);
            this.txtSpaceName.Name = "txtSpaceName";
            this.txtSpaceName.Size = new System.Drawing.Size(377, 21);
            this.txtSpaceName.TabIndex = 46;
            // 
            // lbxTables
            // 
            this.lbxTables.Location = new System.Drawing.Point(95, 81);
            this.lbxTables.Name = "lbxTables";
            this.lbxTables.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lbxTables.Size = new System.Drawing.Size(201, 21);
            this.lbxTables.TabIndex = 48;
            this.lbxTables.SelectedIndexChanged += new System.EventHandler(this.lbxTables_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.label5.Appearance.Options.UseForeColor = true;
            this.label5.Location = new System.Drawing.Point(234, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 14);
            this.label5.TabIndex = 49;
            this.label5.Text = "(必须填写!)";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(41, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 17);
            this.labelControl1.TabIndex = 50;
            this.labelControl1.Text = "步骤1:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(41, 140);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 17);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "步骤2:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(15, 535);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 17);
            this.labelControl3.TabIndex = 52;
            this.labelControl3.Text = "步骤3:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSFramework.Tools.ClassGenerator.Properties.Resources.ClassGeneratorORM;
            this.pictureBox1.Location = new System.Drawing.Point(619, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.label7.Appearance.Options.UseForeColor = true;
            this.label7.Location = new System.Drawing.Point(220, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 14);
            this.label7.TabIndex = 54;
            this.label7.Text = "(请选择一张表)";
            // 
            // btnClass
            // 
            this.btnClass.Location = new System.Drawing.Point(230, 536);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(116, 26);
            this.btnClass.TabIndex = 57;
            this.btnClass.Text = "生成实体类(对象)";
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(29, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "连接SQL:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(54, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 24;
            this.label11.Text = "类名:";
            // 
            // chkSummaryTable
            // 
            this.chkSummaryTable.EditValue = true;
            this.chkSummaryTable.Location = new System.Drawing.Point(321, 82);
            this.chkSummaryTable.Name = "chkSummaryTable";
            this.chkSummaryTable.Properties.Caption = "主表";
            this.chkSummaryTable.Size = new System.Drawing.Size(50, 19);
            this.chkSummaryTable.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(30, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 14);
            this.label12.TabIndex = 36;
            this.label12.Text = "主键:";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(327, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 14);
            this.label13.TabIndex = 39;
            this.label13.Text = "命名空间:";
            // 
            // tabControl2
            // 
            this.tabControl2.Location = new System.Drawing.Point(3, 28);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabPage = this.tabPage4;
            this.tabControl2.Size = new System.Drawing.Size(788, 597);
            this.tabControl2.TabIndex = 58;
            this.tabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPage3,
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.tabPage4,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Controls.Add(this.txtCode);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(781, 567);
            this.tabPage4.Text = "生成的代码";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveCS);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 535);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 29);
            this.panel1.TabIndex = 42;
            // 
            // btnSaveCS
            // 
            this.btnSaveCS.Location = new System.Drawing.Point(125, 2);
            this.btnSaveCS.Name = "btnSaveCS";
            this.btnSaveCS.Size = new System.Drawing.Size(114, 26);
            this.btnSaveCS.TabIndex = 46;
            this.btnSaveCS.Text = "保存到文件(*.cs)";
            this.btnSaveCS.Click += new System.EventHandler(this.btnSaveCS_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(5, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(114, 26);
            this.btnCopy.TabIndex = 45;
            this.btnCopy.Text = "复制到剪贴板";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkExportToFileORM);
            this.tabPage3.Controls.Add(this.chkPreviewCode);
            this.tabPage3.Controls.Add(this.label44);
            this.tabPage3.Controls.Add(this.txtOutpup_ORM);
            this.tabPage3.Controls.Add(this.label45);
            this.tabPage3.Controls.Add(this.chkGenFields);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.gcStuct);
            this.tabPage3.Controls.Add(this.btnClass);
            this.tabPage3.Controls.Add(this.labelControl3);
            this.tabPage3.Controls.Add(this.btnTableFields);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(781, 567);
            this.tabPage3.Text = "生成->ORM";
            // 
            // chkExportToFileORM
            // 
            this.chkExportToFileORM.EditValue = true;
            this.chkExportToFileORM.Location = new System.Drawing.Point(634, 540);
            this.chkExportToFileORM.Name = "chkExportToFileORM";
            this.chkExportToFileORM.Properties.Caption = "输出到.cs文件";
            this.chkExportToFileORM.Size = new System.Drawing.Size(137, 19);
            this.chkExportToFileORM.TabIndex = 97;
            // 
            // chkPreviewCode
            // 
            this.chkPreviewCode.EditValue = true;
            this.chkPreviewCode.Location = new System.Drawing.Point(470, 540);
            this.chkPreviewCode.Name = "chkPreviewCode";
            this.chkPreviewCode.Properties.Caption = "生成代码后跳到预览页面";
            this.chkPreviewCode.Size = new System.Drawing.Size(158, 19);
            this.chkPreviewCode.TabIndex = 96;
            // 
            // label44
            // 
            this.label44.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label44.Appearance.Options.UseForeColor = true;
            this.label44.Location = new System.Drawing.Point(107, 492);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 14);
            this.label44.TabIndex = 95;
            this.label44.Text = "输出目录:";
            // 
            // txtOutpup_ORM
            // 
            this.txtOutpup_ORM.EditValue = "";
            this.txtOutpup_ORM.Location = new System.Drawing.Point(109, 509);
            this.txtOutpup_ORM.Name = "txtOutpup_ORM";
            this.txtOutpup_ORM.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutpup_ORM.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOutpup_ORM.Properties.Appearance.Options.UseFont = true;
            this.txtOutpup_ORM.Properties.Appearance.Options.UseForeColor = true;
            this.txtOutpup_ORM.Size = new System.Drawing.Size(666, 21);
            this.txtOutpup_ORM.TabIndex = 94;
            // 
            // label45
            // 
            this.label45.Appearance.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label45.Appearance.Options.UseFont = true;
            this.label45.Appearance.Options.UseForeColor = true;
            this.label45.Location = new System.Drawing.Point(2, 493);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(83, 42);
            this.label45.TabIndex = 93;
            this.label45.Text = "ORM";
            // 
            // chkGenFields
            // 
            this.chkGenFields.EditValue = true;
            this.chkGenFields.Location = new System.Drawing.Point(352, 540);
            this.chkGenFields.Name = "chkGenFields";
            this.chkGenFields.Properties.Caption = "生成字段名常量";
            this.chkGenFields.Size = new System.Drawing.Size(112, 19);
            this.chkGenFields.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConnString);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGetTables);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSpaceName);
            this.groupBox1.Controls.Add(this.btnGetStuct);
            this.groupBox1.Controls.Add(this.lbxTables);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cbxDbType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPrimaryKey);
            this.groupBox1.Controls.Add(this.chkSummaryTable);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 197);
            this.groupBox1.TabIndex = 60;
            // 
            // txtConnString
            // 
            this.txtConnString.AllowDrop = true;
            this.txtConnString.EditValue = "Server=.\\SQLEXPRESS;DataBase=CSFramework3.Normal;Integrated Security=True;";
            this.txtConnString.Location = new System.Drawing.Point(95, 5);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(509, 39);
            this.txtConnString.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label6.Appearance.Options.UseForeColor = true;
            this.label6.Location = new System.Drawing.Point(772, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(7, 14);
            this.label6.TabIndex = 64;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label4.Appearance.Options.UseForeColor = true;
            this.label4.Location = new System.Drawing.Point(299, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(7, 14);
            this.label4.TabIndex = 63;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label3.Appearance.Options.UseForeColor = true;
            this.label3.Location = new System.Drawing.Point(217, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(7, 14);
            this.label3.TabIndex = 62;
            this.label3.Text = "*";
            // 
            // txtComment
            // 
            this.txtComment.EditValue = "";
            this.txtComment.Location = new System.Drawing.Point(392, 141);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(377, 21);
            this.txtComment.TabIndex = 61;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(327, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 14);
            this.labelControl4.TabIndex = 60;
            this.labelControl4.Text = "注释:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 59;
            this.label2.Text = "用户表和视图:";
            // 
            // label1
            // 
            this.label1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.label1.Appearance.Options.UseForeColor = true;
            this.label1.Location = new System.Drawing.Point(320, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 14);
            this.label1.TabIndex = 58;
            this.label1.Text = "(类名字头为\"tb_\", 在这里可自定义)";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(95, 107);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(201, 21);
            this.txtClassName.TabIndex = 23;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupBox3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(781, 567);
            this.xtraTabPage1.Text = "生成 -> BLL";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkExportToFileBLL);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.txtUsingNamespace);
            this.groupBox3.Controls.Add(this.chkPreviewBLL);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Controls.Add(this.txtOutpup_BLL_Business);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.txtOutpup_BLL_DataDict);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.btnGenBLLBusiness);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.txtORM);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtBllNamespace);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtDAL);
            this.groupBox3.Controls.Add(this.txtConcretelyName);
            this.groupBox3.Controls.Add(this.btnGenBLLDataDict);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.label47);
            this.groupBox3.Controls.Add(this.label48);
            this.groupBox3.Controls.Add(this.txtBLL);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 567);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.Text = "生成业务逻辑层代码";
            // 
            // chkExportToFileBLL
            // 
            this.chkExportToFileBLL.EditValue = true;
            this.chkExportToFileBLL.Location = new System.Drawing.Point(609, 300);
            this.chkExportToFileBLL.Name = "chkExportToFileBLL";
            this.chkExportToFileBLL.Properties.Caption = "输出到.cs文件";
            this.chkExportToFileBLL.Size = new System.Drawing.Size(137, 19);
            this.chkExportToFileBLL.TabIndex = 98;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CSFramework.Tools.ClassGenerator.Properties.Resources.ClassGeneratorBLL;
            this.pictureBox2.Location = new System.Drawing.Point(622, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(149, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 89;
            this.pictureBox2.TabStop = false;
            // 
            // txtUsingNamespace
            // 
            this.txtUsingNamespace.EditValue = "CSFramework3.Models\r\nCSFramework.Common\r\nCSFramework.Core.Interfaces\r\nCSFramework" +
                ".Core.Log\r\nCSFramework3.Server.DataAccess\r\nCSFramework.Core\r\nCSFramework.Core.BL" +
                "L_Base";
            this.txtUsingNamespace.Location = new System.Drawing.Point(145, 176);
            this.txtUsingNamespace.Name = "txtUsingNamespace";
            this.txtUsingNamespace.Size = new System.Drawing.Size(309, 120);
            this.txtUsingNamespace.TabIndex = 88;
            // 
            // chkPreviewBLL
            // 
            this.chkPreviewBLL.EditValue = true;
            this.chkPreviewBLL.Location = new System.Drawing.Point(609, 323);
            this.chkPreviewBLL.Name = "chkPreviewBLL";
            this.chkPreviewBLL.Properties.Caption = "生成代码后跳到预览页面";
            this.chkPreviewBLL.Size = new System.Drawing.Size(158, 19);
            this.chkPreviewBLL.TabIndex = 84;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFormName);
            this.groupBox4.Controls.Add(this.chkBusinessLog);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Location = new System.Drawing.Point(45, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 75);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.Text = "业务单据BLL选项";
            // 
            // txtFormName
            // 
            this.txtFormName.Location = new System.Drawing.Point(98, 24);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(147, 21);
            this.txtFormName.TabIndex = 72;
            // 
            // chkBusinessLog
            // 
            this.chkBusinessLog.Location = new System.Drawing.Point(98, 52);
            this.chkBusinessLog.Name = "chkBusinessLog";
            this.chkBusinessLog.Properties.Caption = "版本历史记录(ISupportBusinessLog)";
            this.chkBusinessLog.Size = new System.Drawing.Size(221, 19);
            this.chkBusinessLog.TabIndex = 74;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(251, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 14);
            this.label21.TabIndex = 75;
            this.label21.Text = "如:frmCustomer";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(32, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 14);
            this.label20.TabIndex = 73;
            this.label20.Text = "窗体名称:";
            // 
            // label41
            // 
            this.label41.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label41.Appearance.Options.UseForeColor = true;
            this.label41.Location = new System.Drawing.Point(46, 476);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(52, 14);
            this.label41.TabIndex = 82;
            this.label41.Text = "输出目录:";
            // 
            // txtOutpup_BLL_Business
            // 
            this.txtOutpup_BLL_Business.EditValue = "";
            this.txtOutpup_BLL_Business.Location = new System.Drawing.Point(48, 493);
            this.txtOutpup_BLL_Business.Name = "txtOutpup_BLL_Business";
            this.txtOutpup_BLL_Business.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutpup_BLL_Business.Properties.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.txtOutpup_BLL_Business.Properties.Appearance.Options.UseFont = true;
            this.txtOutpup_BLL_Business.Properties.Appearance.Options.UseForeColor = true;
            this.txtOutpup_BLL_Business.Size = new System.Drawing.Size(721, 21);
            this.txtOutpup_BLL_Business.TabIndex = 81;
            // 
            // label40
            // 
            this.label40.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label40.Appearance.Options.UseForeColor = true;
            this.label40.Location = new System.Drawing.Point(46, 394);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(52, 14);
            this.label40.TabIndex = 80;
            this.label40.Text = "输出目录:";
            // 
            // txtOutpup_BLL_DataDict
            // 
            this.txtOutpup_BLL_DataDict.EditValue = "";
            this.txtOutpup_BLL_DataDict.Location = new System.Drawing.Point(48, 411);
            this.txtOutpup_BLL_DataDict.Name = "txtOutpup_BLL_DataDict";
            this.txtOutpup_BLL_DataDict.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutpup_BLL_DataDict.Properties.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.txtOutpup_BLL_DataDict.Properties.Appearance.Options.UseFont = true;
            this.txtOutpup_BLL_DataDict.Properties.Appearance.Options.UseForeColor = true;
            this.txtOutpup_BLL_DataDict.Size = new System.Drawing.Size(723, 21);
            this.txtOutpup_BLL_DataDict.TabIndex = 79;
            // 
            // label23
            // 
            this.label23.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.label23.Appearance.Options.UseFont = true;
            this.label23.Appearance.Options.UseForeColor = true;
            this.label23.Location = new System.Drawing.Point(537, 525);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 17);
            this.label23.TabIndex = 77;
            this.label23.Text = "业务单据";
            // 
            // label22
            // 
            this.label22.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.label22.Appearance.Options.UseFont = true;
            this.label22.Appearance.Options.UseForeColor = true;
            this.label22.Location = new System.Drawing.Point(537, 446);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 17);
            this.label22.TabIndex = 76;
            this.label22.Text = "数据字典";
            // 
            // btnGenBLLBusiness
            // 
            this.btnGenBLLBusiness.Location = new System.Drawing.Point(611, 519);
            this.btnGenBLLBusiness.Name = "btnGenBLLBusiness";
            this.btnGenBLLBusiness.Size = new System.Drawing.Size(147, 26);
            this.btnGenBLLBusiness.TabIndex = 69;
            this.btnGenBLLBusiness.Text = "生成业务单据BLL代码";
            this.btnGenBLLBusiness.Click += new System.EventHandler(this.btnGenBLLBusiness_Click);
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(298, 124);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(87, 14);
            this.label32.TabIndex = 71;
            this.label32.Text = "如:tb_Customer";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(78, 123);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 14);
            this.label33.TabIndex = 70;
            this.label33.Text = "ORM模型:";
            // 
            // txtORM
            // 
            this.txtORM.Location = new System.Drawing.Point(145, 121);
            this.txtORM.Name = "txtORM";
            this.txtORM.Size = new System.Drawing.Size(147, 21);
            this.txtORM.TabIndex = 69;
            // 
            // label19
            // 
            this.label19.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Appearance.Options.UseForeColor = true;
            this.label19.Location = new System.Drawing.Point(45, 204);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 14);
            this.label19.TabIndex = 66;
            this.label19.Text = "(System.* 除外)";
            // 
            // label10
            // 
            this.label10.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.label10.Appearance.Options.UseForeColor = true;
            this.label10.Location = new System.Drawing.Point(45, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 65;
            this.label10.Text = "(断行符分开)";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(33, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 14);
            this.label18.TabIndex = 63;
            this.label18.Text = "业务层的命名空间:";
            // 
            // txtBllNamespace
            // 
            this.txtBllNamespace.EditValue = "CSFramework3.Business";
            this.txtBllNamespace.Location = new System.Drawing.Point(145, 149);
            this.txtBllNamespace.Name = "txtBllNamespace";
            this.txtBllNamespace.Size = new System.Drawing.Size(309, 21);
            this.txtBllNamespace.TabIndex = 64;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(298, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 14);
            this.label17.TabIndex = 62;
            this.label17.Text = "如:Customer";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(298, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 14);
            this.label16.TabIndex = 61;
            this.label16.Text = "如:bllCustomer";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(298, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 14);
            this.label15.TabIndex = 60;
            this.label15.Text = "如:dalCustomer";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(83, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 14);
            this.label14.TabIndex = 59;
            this.label14.Text = "DAL类名:";
            // 
            // txtDAL
            // 
            this.txtDAL.Location = new System.Drawing.Point(145, 93);
            this.txtDAL.Name = "txtDAL";
            this.txtDAL.Size = new System.Drawing.Size(147, 21);
            this.txtDAL.TabIndex = 58;
            // 
            // txtConcretelyName
            // 
            this.txtConcretelyName.Location = new System.Drawing.Point(145, 37);
            this.txtConcretelyName.Name = "txtConcretelyName";
            this.txtConcretelyName.Size = new System.Drawing.Size(147, 21);
            this.txtConcretelyName.TabIndex = 49;
            this.txtConcretelyName.EditValueChanged += new System.EventHandler(this.txtConcretelyName_EditValueChanged);
            // 
            // btnGenBLLDataDict
            // 
            this.btnGenBLLDataDict.Location = new System.Drawing.Point(613, 438);
            this.btnGenBLLDataDict.Name = "btnGenBLLDataDict";
            this.btnGenBLLDataDict.Size = new System.Drawing.Size(147, 26);
            this.btnGenBLLDataDict.TabIndex = 46;
            this.btnGenBLLDataDict.Text = "生成数据字典BLL代码";
            this.btnGenBLLDataDict.Click += new System.EventHandler(this.btnGenBLLDataDict_Click);
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(81, 40);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(52, 14);
            this.label46.TabIndex = 48;
            this.label46.Text = "具体名称:";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(45, 181);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(88, 14);
            this.label47.TabIndex = 54;
            this.label47.Text = "引用的名字空间:";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(86, 68);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(47, 14);
            this.label48.TabIndex = 51;
            this.label48.Text = "BLL类名:";
            // 
            // txtBLL
            // 
            this.txtBLL.Location = new System.Drawing.Point(145, 65);
            this.txtBLL.Name = "txtBLL";
            this.txtBLL.Size = new System.Drawing.Size(147, 21);
            this.txtBLL.TabIndex = 50;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupBox2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(781, 567);
            this.xtraTabPage2.Text = "生成 -> DAL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkExportToFileDAL);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.txtUsingNamespace_DAL);
            this.groupBox2.Controls.Add(this.chkPreviewDAL);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.txtOutpup_DAL_DataDict);
            this.groupBox2.Controls.Add(this.txtOutpup_DAL_Business);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.btnGenDALBusiness);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtORM_DAL);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtNamespace_DAL);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.txtDAL_DAL);
            this.groupBox2.Controls.Add(this.txtConcretelyName_DAL);
            this.groupBox2.Controls.Add(this.btnGenDALDataDict);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 567);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.Text = "生成数据访问层代码";
            // 
            // chkExportToFileDAL
            // 
            this.chkExportToFileDAL.EditValue = true;
            this.chkExportToFileDAL.Location = new System.Drawing.Point(616, 219);
            this.chkExportToFileDAL.Name = "chkExportToFileDAL";
            this.chkExportToFileDAL.Properties.Caption = "输出到.cs文件";
            this.chkExportToFileDAL.Size = new System.Drawing.Size(137, 19);
            this.chkExportToFileDAL.TabIndex = 99;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CSFramework.Tools.ClassGenerator.Properties.Resources.ClassGeneratorDAL;
            this.pictureBox3.Location = new System.Drawing.Point(622, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(149, 124);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 90;
            this.pictureBox3.TabStop = false;
            // 
            // txtUsingNamespace_DAL
            // 
            this.txtUsingNamespace_DAL.EditValue = "CSFramework3.Models\r\nCSFramework.Common\r\nCSFramework.ORM\r\nCSFramework.Core.DAL_Ba" +
                "se";
            this.txtUsingNamespace_DAL.Location = new System.Drawing.Point(146, 142);
            this.txtUsingNamespace_DAL.Name = "txtUsingNamespace_DAL";
            this.txtUsingNamespace_DAL.Size = new System.Drawing.Size(309, 126);
            this.txtUsingNamespace_DAL.TabIndex = 87;
            // 
            // chkPreviewDAL
            // 
            this.chkPreviewDAL.Location = new System.Drawing.Point(616, 244);
            this.chkPreviewDAL.Name = "chkPreviewDAL";
            this.chkPreviewDAL.Properties.Caption = "生成代码后跳到预览页面";
            this.chkPreviewDAL.Size = new System.Drawing.Size(158, 19);
            this.chkPreviewDAL.TabIndex = 86;
            // 
            // label42
            // 
            this.label42.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label42.Appearance.Options.UseForeColor = true;
            this.label42.Location = new System.Drawing.Point(50, 391);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(52, 14);
            this.label42.TabIndex = 85;
            this.label42.Text = "输出目录:";
            // 
            // label43
            // 
            this.label43.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label43.Appearance.Options.UseForeColor = true;
            this.label43.Location = new System.Drawing.Point(48, 274);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(52, 14);
            this.label43.TabIndex = 84;
            this.label43.Text = "输出目录:";
            // 
            // txtOutpup_DAL_DataDict
            // 
            this.txtOutpup_DAL_DataDict.EditValue = "";
            this.txtOutpup_DAL_DataDict.Location = new System.Drawing.Point(50, 291);
            this.txtOutpup_DAL_DataDict.Name = "txtOutpup_DAL_DataDict";
            this.txtOutpup_DAL_DataDict.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutpup_DAL_DataDict.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtOutpup_DAL_DataDict.Properties.Appearance.Options.UseFont = true;
            this.txtOutpup_DAL_DataDict.Properties.Appearance.Options.UseForeColor = true;
            this.txtOutpup_DAL_DataDict.Size = new System.Drawing.Size(724, 21);
            this.txtOutpup_DAL_DataDict.TabIndex = 83;
            // 
            // txtOutpup_DAL_Business
            // 
            this.txtOutpup_DAL_Business.EditValue = "";
            this.txtOutpup_DAL_Business.Location = new System.Drawing.Point(51, 408);
            this.txtOutpup_DAL_Business.Name = "txtOutpup_DAL_Business";
            this.txtOutpup_DAL_Business.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutpup_DAL_Business.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtOutpup_DAL_Business.Properties.Appearance.Options.UseFont = true;
            this.txtOutpup_DAL_Business.Properties.Appearance.Options.UseForeColor = true;
            this.txtOutpup_DAL_Business.Size = new System.Drawing.Size(725, 21);
            this.txtOutpup_DAL_Business.TabIndex = 82;
            // 
            // label30
            // 
            this.label30.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.label30.Appearance.Options.UseFont = true;
            this.label30.Appearance.Options.UseForeColor = true;
            this.label30.Location = new System.Drawing.Point(49, 434);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(60, 17);
            this.label30.TabIndex = 79;
            this.label30.Text = "业务单据";
            // 
            // label37
            // 
            this.label37.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.label37.Appearance.Options.UseFont = true;
            this.label37.Appearance.Options.UseForeColor = true;
            this.label37.Location = new System.Drawing.Point(48, 317);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(60, 17);
            this.label37.TabIndex = 78;
            this.label37.Text = "数据字典";
            // 
            // btnGenDALBusiness
            // 
            this.btnGenDALBusiness.Location = new System.Drawing.Point(620, 434);
            this.btnGenDALBusiness.Name = "btnGenDALBusiness";
            this.btnGenDALBusiness.Size = new System.Drawing.Size(147, 26);
            this.btnGenDALBusiness.TabIndex = 69;
            this.btnGenDALBusiness.Text = "生成业务单据DAL代码";
            this.btnGenDALBusiness.Click += new System.EventHandler(this.btnGenDALBusiness_Click);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(299, 88);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 14);
            this.label24.TabIndex = 71;
            this.label24.Text = "如:tb_Customer";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(84, 88);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 14);
            this.label25.TabIndex = 70;
            this.label25.Text = "ORM模型:";
            // 
            // txtORM_DAL
            // 
            this.txtORM_DAL.Location = new System.Drawing.Point(146, 85);
            this.txtORM_DAL.Name = "txtORM_DAL";
            this.txtORM_DAL.Size = new System.Drawing.Size(147, 21);
            this.txtORM_DAL.TabIndex = 69;
            // 
            // label26
            // 
            this.label26.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label26.Appearance.Options.UseForeColor = true;
            this.label26.Location = new System.Drawing.Point(46, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 14);
            this.label26.TabIndex = 66;
            this.label26.Text = "(System.* 除外)";
            // 
            // label27
            // 
            this.label27.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.label27.Appearance.Options.UseForeColor = true;
            this.label27.Location = new System.Drawing.Point(46, 193);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 14);
            this.label27.TabIndex = 65;
            this.label27.Text = "(断行符分开)";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(34, 115);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 14);
            this.label28.TabIndex = 63;
            this.label28.Text = "数据层的命名空间:";
            // 
            // txtNamespace_DAL
            // 
            this.txtNamespace_DAL.EditValue = "CSFramework3.Server.DataAccess";
            this.txtNamespace_DAL.Location = new System.Drawing.Point(146, 113);
            this.txtNamespace_DAL.Name = "txtNamespace_DAL";
            this.txtNamespace_DAL.Size = new System.Drawing.Size(309, 21);
            this.txtNamespace_DAL.TabIndex = 64;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(299, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 14);
            this.label29.TabIndex = 62;
            this.label29.Text = "如:Customer";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(299, 60);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 14);
            this.label31.TabIndex = 60;
            this.label31.Text = "如:dalCustomer";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(84, 60);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(50, 14);
            this.label34.TabIndex = 59;
            this.label34.Text = "DAL类名:";
            // 
            // txtDAL_DAL
            // 
            this.txtDAL_DAL.Location = new System.Drawing.Point(146, 57);
            this.txtDAL_DAL.Name = "txtDAL_DAL";
            this.txtDAL_DAL.Size = new System.Drawing.Size(147, 21);
            this.txtDAL_DAL.TabIndex = 58;
            // 
            // txtConcretelyName_DAL
            // 
            this.txtConcretelyName_DAL.Location = new System.Drawing.Point(146, 29);
            this.txtConcretelyName_DAL.Name = "txtConcretelyName_DAL";
            this.txtConcretelyName_DAL.Size = new System.Drawing.Size(147, 21);
            this.txtConcretelyName_DAL.TabIndex = 49;
            this.txtConcretelyName_DAL.EditValueChanged += new System.EventHandler(this.txtConcretelyName_DAL_EditValueChanged);
            // 
            // btnGenDALDataDict
            // 
            this.btnGenDALDataDict.Location = new System.Drawing.Point(618, 317);
            this.btnGenDALDataDict.Name = "btnGenDALDataDict";
            this.btnGenDALDataDict.Size = new System.Drawing.Size(147, 26);
            this.btnGenDALDataDict.TabIndex = 46;
            this.btnGenDALDataDict.Text = "生成数据字典DAL代码";
            this.btnGenDALDataDict.Click += new System.EventHandler(this.btnGenDALDataDict_Click);
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(82, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(52, 14);
            this.label35.TabIndex = 48;
            this.label35.Text = "具体名称:";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(46, 145);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(88, 14);
            this.label36.TabIndex = 54;
            this.label36.Text = "引用的名字空间:";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.groupControl1);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(781, 567);
            this.xtraTabPage3.Text = "生成->数据字典窗体";
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(781, 567);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "生成->数据字典窗体";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.groupControl2);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(781, 567);
            this.xtraTabPage4.Text = "生成->业务数据窗体";
            // 
            // groupControl2
            // 
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(781, 567);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "生成->业务数据窗体";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.groupControl3);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(781, 567);
            this.xtraTabPage5.Text = "生成->报表窗体";
            // 
            // groupControl3
            // 
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(781, 567);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "生成->报表窗体";
            // 
            // txtSolutionFolder
            // 
            this.txtSolutionFolder.EditValue = "E:\\CSFramework-ADO-标准版V2.2\\Source";
            this.txtSolutionFolder.Location = new System.Drawing.Point(97, 2);
            this.txtSolutionFolder.Name = "txtSolutionFolder";
            this.txtSolutionFolder.Size = new System.Drawing.Size(689, 21);
            this.txtSolutionFolder.TabIndex = 62;
            this.txtSolutionFolder.EditValueChanged += new System.EventHandler(this.txtSolutionFolder_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(11, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 17);
            this.labelControl5.TabIndex = 63;
            this.labelControl5.Text = "项目主目录:";
            // 
            // frmClassGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 624);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtSolutionFolder);
            this.Controls.Add(this.tabControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Pumpkin";
            this.MaximizeBox = false;
            this.Name = "frmClassGenerator";
            this.Text = "代码生成器 v2.01 - C/S框架网 www.csframework.com";
            this.Load += new System.EventHandler(this.frmClassGenerator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcStuct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStuct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditAddOrUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsPrimaryKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsForeignKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditNumberKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimaryKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpaceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbxTables.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSummaryTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExportToFileORM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreviewCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_ORM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenFields.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassName.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExportToFileBLL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsingNamespace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreviewBLL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBusinessLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_BLL_Business.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_BLL_DataDict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtORM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBllNamespace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcretelyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLL.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExportToFileDAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsingNamespace_DAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreviewDAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_DAL_DataDict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutpup_DAL_Business.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtORM_DAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamespace_DAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDAL_DAL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcretelyName_DAL.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSolutionFolder.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcStuct;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStuct;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colLength;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLookup;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditLookup;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAddOrUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditAddOrUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPrimaryKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditIsPrimaryKey;
        private DevExpress.XtraGrid.Columns.GridColumn colIsNumberKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditNumberKey;
        private DevExpress.XtraGrid.Columns.GridColumn colIsForeignKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditIsForeignKey;
        private DevExpress.XtraEditors.TextEdit txtPrimaryKey;
        private DevExpress.XtraEditors.CheckEdit cbxDbType;
        private DevExpress.XtraEditors.MemoEdit txtCode;
        private DevExpress.XtraEditors.SimpleButton btnGetStuct;
        private DevExpress.XtraEditors.SimpleButton btnTableFields;
        private DevExpress.XtraEditors.SimpleButton btnGetTables;
        private DevExpress.XtraEditors.TextEdit txtSpaceName;
        private DevExpress.XtraEditors.ComboBoxEdit lbxTables;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl label7;
        private DevExpress.XtraEditors.SimpleButton btnClass;
        private DevExpress.XtraEditors.LabelControl label9;
        private DevExpress.XtraEditors.LabelControl label11;
        private DevExpress.XtraEditors.CheckEdit chkSummaryTable;
        private DevExpress.XtraEditors.LabelControl label12;
        private DevExpress.XtraEditors.LabelControl label13;
        private DevExpress.XtraTab.XtraTabControl tabControl2;
        private DevExpress.XtraTab.XtraTabPage tabPage3;
        private DevExpress.XtraTab.XtraTabPage tabPage4;
        private DevExpress.XtraEditors.TextEdit txtClassName;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.PanelControl groupBox1;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.SimpleButton btnSaveCS;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.CheckEdit chkGenFields;
        private DevExpress.XtraEditors.TextEdit txtComment;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.CheckEdit chkPreviewCode;
        private DevExpress.XtraEditors.LabelControl label44;
        private DevExpress.XtraEditors.TextEdit txtOutpup_ORM;
        private DevExpress.XtraEditors.LabelControl label45;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupBox2;
        private DevExpress.XtraEditors.CheckEdit chkPreviewDAL;
        private DevExpress.XtraEditors.LabelControl label42;
        private DevExpress.XtraEditors.LabelControl label43;
        private DevExpress.XtraEditors.TextEdit txtOutpup_DAL_DataDict;
        private DevExpress.XtraEditors.TextEdit txtOutpup_DAL_Business;
        private DevExpress.XtraEditors.LabelControl label30;
        private DevExpress.XtraEditors.LabelControl label37;
        private SimpleButton btnGenDALBusiness;
        private DevExpress.XtraEditors.LabelControl label24;
        private DevExpress.XtraEditors.LabelControl label25;
        private DevExpress.XtraEditors.TextEdit txtORM_DAL;
        private DevExpress.XtraEditors.LabelControl label26;
        private DevExpress.XtraEditors.LabelControl label27;
        private DevExpress.XtraEditors.LabelControl label28;
        private DevExpress.XtraEditors.TextEdit txtNamespace_DAL;
        private DevExpress.XtraEditors.LabelControl label29;
        private DevExpress.XtraEditors.LabelControl label31;
        private DevExpress.XtraEditors.LabelControl label34;
        private DevExpress.XtraEditors.TextEdit txtDAL_DAL;
        private DevExpress.XtraEditors.TextEdit txtConcretelyName_DAL;
        private SimpleButton btnGenDALDataDict;
        private DevExpress.XtraEditors.LabelControl label35;
        private DevExpress.XtraEditors.LabelControl label36;
        private DevExpress.XtraEditors.GroupControl groupBox3;
        private DevExpress.XtraEditors.CheckEdit chkPreviewBLL;
        private DevExpress.XtraEditors.GroupControl groupBox4;
        private DevExpress.XtraEditors.TextEdit txtFormName;
        private DevExpress.XtraEditors.CheckEdit chkBusinessLog;
        private DevExpress.XtraEditors.LabelControl label21;
        private DevExpress.XtraEditors.LabelControl label20;
        private DevExpress.XtraEditors.LabelControl label41;
        private DevExpress.XtraEditors.TextEdit txtOutpup_BLL_Business;
        private DevExpress.XtraEditors.LabelControl label40;
        private DevExpress.XtraEditors.TextEdit txtOutpup_BLL_DataDict;
        private DevExpress.XtraEditors.LabelControl label23;
        private DevExpress.XtraEditors.LabelControl label22;
        private SimpleButton btnGenBLLBusiness;
        private DevExpress.XtraEditors.LabelControl label32;
        private DevExpress.XtraEditors.LabelControl label33;
        private DevExpress.XtraEditors.TextEdit txtORM;
        private DevExpress.XtraEditors.LabelControl label19;
        private DevExpress.XtraEditors.LabelControl label10;
        private DevExpress.XtraEditors.LabelControl label18;
        private DevExpress.XtraEditors.LabelControl label17;
        private DevExpress.XtraEditors.LabelControl label16;
        private DevExpress.XtraEditors.LabelControl label15;
        private DevExpress.XtraEditors.LabelControl label14;
        private DevExpress.XtraEditors.TextEdit txtDAL;
        private DevExpress.XtraEditors.TextEdit txtConcretelyName;
        private SimpleButton btnGenBLLDataDict;
        private DevExpress.XtraEditors.LabelControl label46;
        private DevExpress.XtraEditors.LabelControl label47;
        private DevExpress.XtraEditors.LabelControl label48;
        private DevExpress.XtraEditors.TextEdit txtBLL;
        private MemoEdit txtUsingNamespace_DAL;
        private MemoEdit txtUsingNamespace;
        private TextEdit txtBllNamespace;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private XtraTabPage xtraTabPage5;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private MemoEdit txtConnString;
        private TextEdit txtSolutionFolder;
        private LabelControl labelControl5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private CheckEdit chkExportToFileORM;
        private CheckEdit chkExportToFileBLL;
        private CheckEdit chkExportToFileDAL;
    }
}

