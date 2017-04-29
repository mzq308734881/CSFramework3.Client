namespace CSFramework.Library.UserControls
{
    partial class ucAttachment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.menuOpenAttach = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIconSmall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colFileTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveAs = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            this.menuOpenAttach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcSummary
            // 
            this.gcSummary.ContextMenuStrip = this.menuOpenAttach;
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.Location = new System.Drawing.Point(0, 0);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gcSummary.Size = new System.Drawing.Size(196, 249);
            this.gcSummary.TabIndex = 1;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // menuOpenAttach
            // 
            this.menuOpenAttach.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuDrop,
            this.menuSaveAs});
            this.menuOpenAttach.Name = "menuOpenAttach";
            this.menuOpenAttach.Size = new System.Drawing.Size(119, 70);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(118, 22);
            this.menuOpen.Text = "打开附件";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuDrop
            // 
            this.menuDrop.Name = "menuDrop";
            this.menuDrop.Size = new System.Drawing.Size(118, 22);
            this.menuDrop.Text = "删除附件";
            this.menuDrop.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(118, 22);
            this.menuSaveAs.Text = "另存为...";
            this.menuSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIconSmall,
            this.colFileTitle});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsBehavior.Editable = false;
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowColumnHeaders = false;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            this.gvSummary.OptionsView.ShowIndicator = false;
            // 
            // colIconSmall
            // 
            this.colIconSmall.Caption = "图标";
            this.colIconSmall.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colIconSmall.FieldName = "IconSmall";
            this.colIconSmall.Name = "colIconSmall";
            this.colIconSmall.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colIconSmall.OptionsFilter.AllowAutoFilter = false;
            this.colIconSmall.OptionsFilter.AllowFilter = false;
            this.colIconSmall.Visible = true;
            this.colIconSmall.VisibleIndex = 0;
            this.colIconSmall.Width = 20;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            // 
            // colFileTitle
            // 
            this.colFileTitle.Caption = "文件标题";
            this.colFileTitle.FieldName = "FileTitle";
            this.colFileTitle.Name = "colFileTitle";
            this.colFileTitle.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFileTitle.OptionsFilter.AllowAutoFilter = false;
            this.colFileTitle.OptionsFilter.AllowFilter = false;
            this.colFileTitle.Visible = true;
            this.colFileTitle.VisibleIndex = 1;
            this.colFileTitle.Width = 165;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSaveAs);
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 251);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(196, 25);
            this.panelControl1.TabIndex = 2;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(137, 1);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(56, 21);
            this.btnSaveAs.TabIndex = 227;
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(53, 1);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(46, 21);
            this.btnDel.TabIndex = 226;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 21);
            this.btnAdd.TabIndex = 225;
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gcSummary);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(196, 249);
            this.panelControl2.TabIndex = 3;
            // 
            // ucAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "ucAttachment";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(200, 278);
            this.Load += new System.EventHandler(this.ucAttachment_Load);
            this.SizeChanged += new System.EventHandler(this.ucAttachment_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            this.menuOpenAttach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colIconSmall;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colFileTitle;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.ContextMenuStrip menuOpenAttach;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuDrop;
        private DevExpress.XtraEditors.SimpleButton btnSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
    }
}
