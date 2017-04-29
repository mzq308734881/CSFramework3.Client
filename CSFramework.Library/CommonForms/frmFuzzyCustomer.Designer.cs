namespace CSFramework.Library
{
    partial class frmFuzzyCustomer
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNativeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnglishName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblAttribute = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcSummary);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Size = new System.Drawing.Size(867, 516);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(665, 522);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(762, 522);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.txtValue);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 61);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSFramework.Library.ResImage.find50x50;
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(423, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "内容：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(699, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(105, 27);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtValue
            // 
            this.txtValue.EditValue = "";
            this.txtValue.Location = new System.Drawing.Point(488, 19);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Properties.Appearance.Options.UseFont = true;
            this.txtValue.Size = new System.Drawing.Size(205, 26);
            this.txtValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(60, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "匹配编号和名称，请在结果中选择一条记录, 点击\'确认\'按钮或双表格返回结果.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(60, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "客戶资料查询";
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
            this.gcSummary.Location = new System.Drawing.Point(0, 61);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcSummary.Size = new System.Drawing.Size(867, 455);
            this.gcSummary.TabIndex = 0;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerCode,
            this.colNativeName,
            this.colEnglishName,
            this.colRegion,
            this.colCity,
            this.colTel,
            this.colFax,
            this.colEmail});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsBehavior.Editable = false;
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            this.gvSummary.DoubleClick += new System.EventHandler(this.gvSummary_DoubleClick);
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Caption = "客戶編號";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 0;
            this.colCustomerCode.Width = 80;
            // 
            // colNativeName
            // 
            this.colNativeName.Caption = "中文名稱";
            this.colNativeName.FieldName = "NativeName";
            this.colNativeName.Name = "colNativeName";
            this.colNativeName.Visible = true;
            this.colNativeName.VisibleIndex = 1;
            this.colNativeName.Width = 146;
            // 
            // colEnglishName
            // 
            this.colEnglishName.Caption = "英文名稱";
            this.colEnglishName.FieldName = "EnglishName";
            this.colEnglishName.Name = "colEnglishName";
            this.colEnglishName.Visible = true;
            this.colEnglishName.VisibleIndex = 2;
            this.colEnglishName.Width = 155;
            // 
            // colRegion
            // 
            this.colRegion.Caption = "地區";
            this.colRegion.FieldName = "Region";
            this.colRegion.Name = "colRegion";
            this.colRegion.Visible = true;
            this.colRegion.VisibleIndex = 3;
            this.colRegion.Width = 71;
            // 
            // colCity
            // 
            this.colCity.Caption = "城市";
            this.colCity.FieldName = "City";
            this.colCity.Name = "colCity";
            this.colCity.Visible = true;
            this.colCity.VisibleIndex = 4;
            this.colCity.Width = 69;
            // 
            // colTel
            // 
            this.colTel.Caption = "電話";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 5;
            this.colTel.Width = 95;
            // 
            // colFax
            // 
            this.colFax.Caption = "傳真";
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 6;
            this.colFax.Width = 90;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "電郵";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 7;
            this.colEmail.Width = 112;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 533);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "查询属性：";
            // 
            // lblAttribute
            // 
            this.lblAttribute.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAttribute.Appearance.Options.UseForeColor = true;
            this.lblAttribute.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAttribute.Location = new System.Drawing.Point(96, 533);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(540, 14);
            this.lblAttribute.TabIndex = 22;
            this.lblAttribute.Text = "未指定,";
            // 
            // frmFuzzyCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(867, 567);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblAttribute);
            this.Name = "frmFuzzyCustomer";
            this.Text = "客户资料查询窗体";
            this.Load += new System.EventHandler(this.frmFuzzyCustomer_Load);
            this.Shown += new System.EventHandler(this.frmFuzzyCustomer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFuzzyCustomer_KeyDown);
            this.Controls.SetChildIndex(this.lblAttribute, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNativeName;
        private DevExpress.XtraGrid.Columns.GridColumn colEnglishName;
        private DevExpress.XtraGrid.Columns.GridColumn colRegion;
        private DevExpress.XtraGrid.Columns.GridColumn colCity;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblAttribute;
    }
}
