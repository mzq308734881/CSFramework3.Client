namespace CSFramework3.PurchaseModule
{
    partial class frmPurchaseModuleMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseModuleMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPurchaseMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRpt01 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRpt02 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listReports = new DevExpress.XtraEditors.ImageListBoxControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnGRN = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnPO = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ilReports
            // 
            this.ilReports.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilReports.ImageStream")));
            this.ilReports.Images.SetKeyName(0, "16_ArrayWhite.bmp");
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pictureBox2);
            this.pnlContainer.Controls.Add(this.listReports);
            this.pnlContainer.Controls.Add(this.panelControl3);
            this.pnlContainer.Controls.Add(this.btnGRN);
            this.pnlContainer.Controls.Add(this.simpleButton1);
            this.pnlContainer.Controls.Add(this.panelControl1);
            this.pnlContainer.Controls.Add(this.panelControl2);
            this.pnlContainer.Controls.Add(this.panelControl5);
            this.pnlContainer.Controls.Add(this.menuStrip1);
            this.pnlContainer.Controls.Add(this.btnPO);
            this.pnlContainer.Size = new System.Drawing.Size(700, 504);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPurchaseMain,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(2, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menuPurchaseMain
            // 
            this.menuPurchaseMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPO,
            this.menuItemQuo,
            this.menuStockIn,
            this.menuReports});
            this.menuPurchaseMain.Name = "menuPurchaseMain";
            this.menuPurchaseMain.Size = new System.Drawing.Size(71, 20);
            this.menuPurchaseMain.Text = "采购模块";
            // 
            // menuItemPO
            // 
            this.menuItemPO.Name = "menuItemPO";
            this.menuItemPO.Size = new System.Drawing.Size(152, 22);
            this.menuItemPO.Text = "采购订单";
            this.menuItemPO.Click += new System.EventHandler(this.menuItemPO_Click);
            // 
            // menuItemQuo
            // 
            this.menuItemQuo.Name = "menuItemQuo";
            this.menuItemQuo.Size = new System.Drawing.Size(152, 22);
            this.menuItemQuo.Text = "报价单";
            this.menuItemQuo.Click += new System.EventHandler(this.menuItemQuo_Click);
            // 
            // menuStockIn
            // 
            this.menuStockIn.Name = "menuStockIn";
            this.menuStockIn.Size = new System.Drawing.Size(152, 22);
            this.menuStockIn.Text = "入仓单";
            this.menuStockIn.Click += new System.EventHandler(this.menuGRN_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRpt01,
            this.menuRpt02});
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(152, 22);
            this.menuReports.Text = "采购模块报表";
            // 
            // menuRpt01
            // 
            this.menuRpt01.Name = "menuRpt01";
            this.menuRpt01.Size = new System.Drawing.Size(165, 22);
            this.menuRpt01.Text = "采购订单汇总表";
            this.menuRpt01.Click += new System.EventHandler(this.menuRpt01_Click);
            // 
            // menuRpt02
            // 
            this.menuRpt02.Name = "menuRpt02";
            this.menuRpt02.Size = new System.Drawing.Size(165, 22);
            this.menuRpt02.Text = "入仓明细报表";
            this.menuRpt02.Click += new System.EventHandler(this.menuRpt02_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(85, 20);
            this.toolStripMenuItem1.Text = "顶级菜单II";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panelControl5
            // 
            this.panelControl5.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl5.Appearance.Options.UseBackColor = true;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.label9);
            this.panelControl5.Controls.Add(this.label10);
            this.panelControl5.Location = new System.Drawing.Point(165, 186);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(165, 49);
            this.panelControl5.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = "采购物料报价";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "报价单";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 425);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(696, 77);
            this.panelControl2.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CSFramework3.PurchaseModule.Properties.Resources.logo_for_app1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 160;
            this.pictureBox1.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Location = new System.Drawing.Point(165, 84);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(182, 57);
            this.panelControl1.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "货料采购，采购订单管理";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "采购订单";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Location = new System.Drawing.Point(165, 289);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(182, 58);
            this.panelControl3.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "入仓单";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "物料入仓管理";
            // 
            // listReports
            // 
            this.listReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listReports.HotTrackItems = true;
            this.listReports.ImageList = this.ilReports;
            this.listReports.Location = new System.Drawing.Point(511, 56);
            this.listReports.Name = "listReports";
            this.listReports.Size = new System.Drawing.Size(189, 363);
            this.listReports.TabIndex = 53;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::CSFramework3.PurchaseModule.Properties.Resources.bk_reg;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(700, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // btnGRN
            // 
            this.btnGRN.Enabled = false;
            this.btnGRN.Image = global::CSFramework3.PurchaseModule.Properties.Resources._48_GRN;
            this.btnGRN.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnGRN.Location = new System.Drawing.Point(59, 273);
            this.btnGRN.Name = "btnGRN";
            this.btnGRN.Size = new System.Drawing.Size(84, 84);
            this.btnGRN.TabIndex = 42;
            this.btnGRN.Text = "入仓单";
            this.btnGRN.Click += new System.EventHandler(this.menuGRN_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Image = global::CSFramework3.PurchaseModule.Properties.Resources._48_SalesInvoice;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(59, 170);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(84, 84);
            this.simpleButton1.TabIndex = 39;
            this.simpleButton1.Text = "报价单";
            // 
            // btnPO
            // 
            this.btnPO.Image = global::CSFramework3.PurchaseModule.Properties.Resources._48_Quotation;
            this.btnPO.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPO.Location = new System.Drawing.Point(59, 69);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(84, 84);
            this.btnPO.TabIndex = 1;
            this.btnPO.Text = "采购订单";
            this.btnPO.Click += new System.EventHandler(this.menuItemPO_Click);
            // 
            // frmPurchaseModuleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(700, 504);
            this.Name = "frmPurchaseModuleMain";
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPO;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPurchaseMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemPO;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnGRN;
        private System.Windows.Forms.ToolStripMenuItem menuStockIn;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripMenuItem menuRpt01;
        private System.Windows.Forms.ToolStripMenuItem menuRpt02;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.ImageListBoxControl listReports;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
