namespace CSFramework.SystemModule
{
    partial class frmMenuAuth
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
            this.gcMenus = new DevExpress.XtraGrid.GridControl();
            this.gvMenus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMenuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuths = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pcActions = new DevExpress.XtraEditors.PanelControl();
            this.pnlDetail = new DevExpress.XtraEditors.PanelControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.splitContainerControl1);
            this.tpSummary.Size = new System.Drawing.Size(904, 483);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Size = new System.Drawing.Size(911, 513);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(911, 513);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.pnlDetail);
            this.tpDetail.Text = "此页隐藏";
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(911, 26);
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
            this.controlNavigatorSummary.Location = new System.Drawing.Point(733, 2);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(536, 2);
            // 
            // gcMenus
            // 
            this.gcMenus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMenus.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcMenus.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcMenus.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcMenus.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcMenus.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcMenus.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcMenus.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcMenus.Location = new System.Drawing.Point(0, 0);
            this.gcMenus.MainView = this.gvMenus;
            this.gcMenus.Name = "gcMenus";
            this.gcMenus.Size = new System.Drawing.Size(684, 483);
            this.gcMenus.TabIndex = 0;
            this.gcMenus.UseEmbeddedNavigator = true;
            this.gcMenus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenus});
            // 
            // gvMenus
            // 
            this.gvMenus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMenuName,
            this.colMenuCaption,
            this.colAuths,
            this.colModuleID,
            this.colMenuType});
            this.gvMenus.GridControl = this.gcMenus;
            this.gvMenus.Name = "gvMenus";
            this.gvMenus.OptionsBehavior.Editable = false;
            this.gvMenus.OptionsView.ColumnAutoWidth = false;
            this.gvMenus.OptionsView.ShowFooter = true;
            this.gvMenus.OptionsView.ShowGroupPanel = false;
            this.gvMenus.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMenus_FocusedRowChanged);
            // 
            // colMenuName
            // 
            this.colMenuName.Caption = "菜单名称";
            this.colMenuName.FieldName = "MenuName";
            this.colMenuName.Name = "colMenuName";
            this.colMenuName.OptionsColumn.AllowEdit = false;
            this.colMenuName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMenuName.OptionsColumn.ShowInCustomizationForm = false;
            this.colMenuName.OptionsFilter.AllowAutoFilter = false;
            this.colMenuName.OptionsFilter.AllowFilter = false;
            this.colMenuName.Visible = true;
            this.colMenuName.VisibleIndex = 0;
            this.colMenuName.Width = 155;
            // 
            // colMenuCaption
            // 
            this.colMenuCaption.Caption = "标题";
            this.colMenuCaption.FieldName = "MenuCaption";
            this.colMenuCaption.Name = "colMenuCaption";
            this.colMenuCaption.OptionsColumn.AllowEdit = false;
            this.colMenuCaption.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMenuCaption.OptionsColumn.ShowInCustomizationForm = false;
            this.colMenuCaption.OptionsFilter.AllowAutoFilter = false;
            this.colMenuCaption.OptionsFilter.AllowFilter = false;
            this.colMenuCaption.Visible = true;
            this.colMenuCaption.VisibleIndex = 1;
            this.colMenuCaption.Width = 119;
            // 
            // colAuths
            // 
            this.colAuths.Caption = "可用权限";
            this.colAuths.FieldName = "Auths";
            this.colAuths.Name = "colAuths";
            this.colAuths.OptionsColumn.AllowEdit = false;
            this.colAuths.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAuths.OptionsColumn.ShowInCustomizationForm = false;
            this.colAuths.OptionsFilter.AllowAutoFilter = false;
            this.colAuths.OptionsFilter.AllowFilter = false;
            this.colAuths.Visible = true;
            this.colAuths.VisibleIndex = 2;
            this.colAuths.Width = 64;
            // 
            // colModuleID
            // 
            this.colModuleID.Caption = "模块名称";
            this.colModuleID.FieldName = "ModuleID";
            this.colModuleID.Name = "colModuleID";
            this.colModuleID.OptionsColumn.AllowEdit = false;
            this.colModuleID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colModuleID.OptionsColumn.ShowInCustomizationForm = false;
            this.colModuleID.OptionsFilter.AllowAutoFilter = false;
            this.colModuleID.OptionsFilter.AllowFilter = false;
            this.colModuleID.Visible = true;
            this.colModuleID.VisibleIndex = 3;
            this.colModuleID.Width = 88;
            // 
            // colMenuType
            // 
            this.colMenuType.Caption = "菜单类型";
            this.colMenuType.FieldName = "MenuType";
            this.colMenuType.Name = "colMenuType";
            this.colMenuType.OptionsColumn.AllowEdit = false;
            this.colMenuType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMenuType.OptionsColumn.ShowInCustomizationForm = false;
            this.colMenuType.OptionsFilter.AllowAutoFilter = false;
            this.colMenuType.OptionsFilter.AllowFilter = false;
            this.colMenuType.Visible = true;
            this.colMenuType.VisibleIndex = 4;
            this.colMenuType.Width = 95;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcMenus);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.pcActions);
            this.splitContainerControl1.Panel2.MinSize = 190;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(904, 483);
            this.splitContainerControl1.SplitterPosition = 684;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pcActions
            // 
            this.pcActions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcActions.Location = new System.Drawing.Point(0, 0);
            this.pcActions.Name = "pcActions";
            this.pcActions.Size = new System.Drawing.Size(214, 483);
            this.pcActions.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(775, 483);
            this.pnlDetail.TabIndex = 0;
            // 
            // frmMenuAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(911, 539);
            this.Name = "frmMenuAuth";
            this.Text = "分配菜单权限";
            this.Load += new System.EventHandler(this.frmMenuAuth_Load);
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMenus;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl pcActions;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuName;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colAuths;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleID;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuType;
        private DevExpress.XtraEditors.PanelControl pnlDetail;
    }
}
