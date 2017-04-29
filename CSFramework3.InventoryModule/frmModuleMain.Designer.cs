namespace CSFramework3.InventoryModule
{
    partial class frmModuleMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMainInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdj = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbReports = new DevExpress.XtraEditors.ImageListBoxControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnStockOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdj = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbReports)).BeginInit();
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
            this.pnlContainer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.Appearance.Options.UseBackColor = true;
            this.pnlContainer.Controls.Add(this.pictureBox2);
            this.pnlContainer.Controls.Add(this.lbReports);
            this.pnlContainer.Controls.Add(this.panelControl4);
            this.pnlContainer.Controls.Add(this.panelControl5);
            this.pnlContainer.Controls.Add(this.btnStockOut);
            this.pnlContainer.Controls.Add(this.btnStockIn);
            this.pnlContainer.Controls.Add(this.panelControl3);
            this.pnlContainer.Controls.Add(this.panelControl2);
            this.pnlContainer.Controls.Add(this.panelControl1);
            this.pnlContainer.Controls.Add(this.btnAdj);
            this.pnlContainer.Controls.Add(this.btnCheck);
            this.pnlContainer.Size = new System.Drawing.Size(695, 542);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainInventory});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(695, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "存库模块";
            // 
            // menuMainInventory
            // 
            this.menuMainInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStockIn,
            this.menuItemStockOut,
            this.menuItemAdj,
            this.menuItemCheck});
            this.menuMainInventory.Name = "menuMainInventory";
            this.menuMainInventory.Size = new System.Drawing.Size(71, 20);
            this.menuMainInventory.Text = "库存模块";
            // 
            // menuItemStockIn
            // 
            this.menuItemStockIn.Name = "menuItemStockIn";
            this.menuItemStockIn.Size = new System.Drawing.Size(152, 22);
            this.menuItemStockIn.Text = "入库单";
            this.menuItemStockIn.Click += new System.EventHandler(this.menuItemStockIn_Click);
            // 
            // menuItemStockOut
            // 
            this.menuItemStockOut.Name = "menuItemStockOut";
            this.menuItemStockOut.Size = new System.Drawing.Size(152, 22);
            this.menuItemStockOut.Text = "出库单";
            this.menuItemStockOut.Click += new System.EventHandler(this.menuItemStockOut_Click);
            // 
            // menuItemAdj
            // 
            this.menuItemAdj.Name = "menuItemAdj";
            this.menuItemAdj.Size = new System.Drawing.Size(152, 22);
            this.menuItemAdj.Text = "调整单";
            this.menuItemAdj.Click += new System.EventHandler(this.menuItemAdj_Click);
            // 
            // menuItemCheck
            // 
            this.menuItemCheck.Name = "menuItemCheck";
            this.menuItemCheck.Size = new System.Drawing.Size(152, 22);
            this.menuItemCheck.Text = "库存盘点";
            this.menuItemCheck.Click += new System.EventHandler(this.menuItemCheck_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "库存盘点库存盘点库存盘点";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "库存盘点";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "库存查询库存查询库存查询库存查询";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "調整單";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Location = new System.Drawing.Point(158, 293);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(207, 52);
            this.panelControl1.TabIndex = 28;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Location = new System.Drawing.Point(161, 389);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(254, 59);
            this.panelControl2.TabIndex = 29;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.pictureBox1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 467);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(691, 73);
            this.panelControl3.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CSFramework3.InventoryModule.Properties.Resources.logo_for_app1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.label2);
            this.panelControl4.Controls.Add(this.label7);
            this.panelControl4.Location = new System.Drawing.Point(161, 187);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(254, 59);
            this.panelControl4.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "库存查询库存查询库存查询库存查询";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "出库单";
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.label8);
            this.panelControl5.Controls.Add(this.label9);
            this.panelControl5.Location = new System.Drawing.Point(161, 77);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(207, 52);
            this.panelControl5.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "入库单";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "库存盘点库存盘点库存盘点";
            // 
            // lbReports
            // 
            this.lbReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReports.HotTrackItems = true;
            this.lbReports.ImageList = this.ilReports;
            this.lbReports.Location = new System.Drawing.Point(501, 56);
            this.lbReports.Name = "lbReports";
            this.lbReports.Size = new System.Drawing.Size(189, 363);
            this.lbReports.TabIndex = 55;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::CSFramework3.InventoryModule.Properties.Resources.bk_reg;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(695, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 56;
            this.pictureBox2.TabStop = false;
            // 
            // btnStockOut
            // 
            this.btnStockOut.Image = global::CSFramework3.InventoryModule.Properties.Resources._48_StockTaking;
            this.btnStockOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStockOut.Location = new System.Drawing.Point(59, 171);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(84, 84);
            this.btnStockOut.TabIndex = 43;
            this.btnStockOut.Text = "出库单";
            this.btnStockOut.Click += new System.EventHandler(this.menuItemStockOut_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.Image = global::CSFramework3.InventoryModule.Properties.Resources._48_Adjustment;
            this.btnStockIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStockIn.Location = new System.Drawing.Point(59, 69);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(84, 84);
            this.btnStockIn.TabIndex = 42;
            this.btnStockIn.Text = "入库单";
            this.btnStockIn.Click += new System.EventHandler(this.menuItemStockIn_Click);
            // 
            // btnAdj
            // 
            this.btnAdj.Enabled = false;
            this.btnAdj.Image = global::CSFramework3.InventoryModule.Properties.Resources._48_NewProduct;
            this.btnAdj.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAdj.Location = new System.Drawing.Point(59, 373);
            this.btnAdj.Name = "btnAdj";
            this.btnAdj.Size = new System.Drawing.Size(84, 84);
            this.btnAdj.TabIndex = 18;
            this.btnAdj.Text = "調整單";
            this.btnAdj.Click += new System.EventHandler(this.menuItemAdj_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Image = global::CSFramework3.InventoryModule.Properties.Resources._48_SalaryParmater;
            this.btnCheck.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCheck.Location = new System.Drawing.Point(59, 271);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(84, 84);
            this.btnCheck.TabIndex = 16;
            this.btnCheck.Text = "库存盘点";
            this.btnCheck.Click += new System.EventHandler(this.menuItemCheck_Click);
            // 
            // frmModuleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(695, 542);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmModuleMain";
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMainInventory;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheck;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.SimpleButton btnAdj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton btnStockOut;
        private DevExpress.XtraEditors.SimpleButton btnStockIn;
        private System.Windows.Forms.ToolStripMenuItem menuItemStockIn;
        private System.Windows.Forms.ToolStripMenuItem menuItemStockOut;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdj;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.ImageListBoxControl lbReports;
    }
}
