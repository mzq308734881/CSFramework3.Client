namespace CSFramework3.AccountModule
{
    partial class frmAccountMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountMain));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGRN = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPO = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAccountMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAR = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOutstanding = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuARRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAPRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.listReports = new DevExpress.XtraEditors.ImageListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listReports)).BeginInit();
            this.SuspendLayout();
            // 
            // ilReports
            // 
            this.ilReports.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilReports.ImageStream")));
            this.ilReports.Images.SetKeyName(0, "16_ArrayWhite.bmp");
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.listReports);
            this.pnlContainer.Controls.Add(this.menuStrip1);
            this.pnlContainer.Controls.Add(this.pictureBox2);
            this.pnlContainer.Controls.Add(this.panelControl3);
            this.pnlContainer.Controls.Add(this.btnGRN);
            this.pnlContainer.Controls.Add(this.simpleButton1);
            this.pnlContainer.Controls.Add(this.panelControl1);
            this.pnlContainer.Controls.Add(this.panelControl2);
            this.pnlContainer.Controls.Add(this.panelControl5);
            this.pnlContainer.Controls.Add(this.btnPO);
            this.pnlContainer.Size = new System.Drawing.Size(712, 491);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::CSFramework3.AccountModule.Properties.Resources.bk_reg;
            this.pictureBox2.Location = new System.Drawing.Point(1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(700, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 62;
            this.pictureBox2.TabStop = false;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Location = new System.Drawing.Point(173, 291);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(205, 58);
            this.panelControl3.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "帐款余额 － Outstanding";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "查询应收应付帐款余额。";
            // 
            // btnGRN
            // 
            this.btnGRN.Image = global::CSFramework3.AccountModule.Properties.Resources._48_Expense;
            this.btnGRN.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnGRN.Location = new System.Drawing.Point(67, 275);
            this.btnGRN.Name = "btnGRN";
            this.btnGRN.Size = new System.Drawing.Size(84, 84);
            this.btnGRN.TabIndex = 60;
            this.btnGRN.Text = "帐款余额";
            this.btnGRN.Click += new System.EventHandler(this.menuItemOutstanding_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::CSFramework3.AccountModule.Properties.Resources._48_GRNReturn;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(67, 172);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(84, 84);
            this.simpleButton1.TabIndex = 59;
            this.simpleButton1.Text = "应付款(AP)";
            this.simpleButton1.Click += new System.EventHandler(this.menuItemAP_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Location = new System.Drawing.Point(173, 86);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(205, 57);
            this.panelControl1.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "应收帐款资料管理，如销售单。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "应收款 － AR";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 412);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(708, 77);
            this.panelControl2.TabIndex = 57;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CSFramework3.AccountModule.Properties.Resources.logo_for_app1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 160;
            this.pictureBox1.TabStop = false;
            // 
            // panelControl5
            // 
            this.panelControl5.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl5.Appearance.Options.UseBackColor = true;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.label9);
            this.panelControl5.Controls.Add(this.label10);
            this.panelControl5.Location = new System.Drawing.Point(173, 188);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(205, 49);
            this.panelControl5.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = "应付帐款资料管理，如采购单。";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "应付款 － AP";
            // 
            // btnPO
            // 
            this.btnPO.Image = global::CSFramework3.AccountModule.Properties.Resources._48_SalesInvoice;
            this.btnPO.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPO.Location = new System.Drawing.Point(67, 71);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(84, 84);
            this.btnPO.TabIndex = 55;
            this.btnPO.Text = "应收款(AR)";
            this.btnPO.Click += new System.EventHandler(this.menuItemAR_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccountMain});
            this.menuStrip1.Location = new System.Drawing.Point(2, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menuAccountMain
            // 
            this.menuAccountMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAR,
            this.menuItemAP,
            this.menuItemOutstanding,
            this.menuReports});
            this.menuAccountMain.Name = "menuAccountMain";
            this.menuAccountMain.Size = new System.Drawing.Size(71, 20);
            this.menuAccountMain.Text = "财务管理";
            // 
            // menuItemAR
            // 
            this.menuItemAR.Name = "menuItemAR";
            this.menuItemAR.Size = new System.Drawing.Size(152, 22);
            this.menuItemAR.Text = "应收款(AR)";
            this.menuItemAR.Click += new System.EventHandler(this.menuItemAR_Click);
            // 
            // menuItemAP
            // 
            this.menuItemAP.Name = "menuItemAP";
            this.menuItemAP.Size = new System.Drawing.Size(152, 22);
            this.menuItemAP.Text = "应付款(AP)";
            this.menuItemAP.Click += new System.EventHandler(this.menuItemAP_Click);
            // 
            // menuItemOutstanding
            // 
            this.menuItemOutstanding.Name = "menuItemOutstanding";
            this.menuItemOutstanding.Size = new System.Drawing.Size(152, 22);
            this.menuItemOutstanding.Text = "帐款余额查询";
            this.menuItemOutstanding.Click += new System.EventHandler(this.menuItemOutstanding_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuARRpt,
            this.menuAPRpt});
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(152, 22);
            this.menuReports.Text = "财务模块报表";
            // 
            // menuARRpt
            // 
            this.menuARRpt.Name = "menuARRpt";
            this.menuARRpt.Size = new System.Drawing.Size(160, 22);
            this.menuARRpt.Text = "AR-应收款报表";
            this.menuARRpt.Click += new System.EventHandler(this.menuARRpt_Click);
            // 
            // menuAPRpt
            // 
            this.menuAPRpt.Name = "menuAPRpt";
            this.menuAPRpt.Size = new System.Drawing.Size(160, 22);
            this.menuAPRpt.Text = "AP-应付款报表";
            this.menuAPRpt.Click += new System.EventHandler(this.menuAPRpt_Click);
            // 
            // listReports
            // 
            this.listReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listReports.HotTrackItems = true;
            this.listReports.ImageList = this.ilReports;
            this.listReports.Location = new System.Drawing.Point(512, 57);
            this.listReports.Name = "listReports";
            this.listReports.Size = new System.Drawing.Size(189, 363);
            this.listReports.TabIndex = 64;
            // 
            // frmAccountMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(712, 491);
            this.Name = "frmAccountMain";
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnGRN;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnPO;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAccountMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemAR;
        private System.Windows.Forms.ToolStripMenuItem menuItemAP;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutstanding;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private DevExpress.XtraEditors.ImageListBoxControl listReports;
        private System.Windows.Forms.ToolStripMenuItem menuARRpt;
        private System.Windows.Forms.ToolStripMenuItem menuAPRpt;

    }
}
