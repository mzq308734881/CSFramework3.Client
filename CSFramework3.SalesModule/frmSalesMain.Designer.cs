namespace CSFramework3.SalesModule
{
    partial class frmSalesMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesMain));
            this.menuMainSalesModule = new System.Windows.Forms.MenuStrip();
            this.menuMainSalesSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalesOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAR = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRpt01 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRpt02 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRpt03 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbReports = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAR = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalesOrder = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.menuMainSalesModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
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
            this.pnlContainer.Controls.Add(this.lbReports);
            this.pnlContainer.Controls.Add(this.panelControl5);
            this.pnlContainer.Controls.Add(this.btnAR);
            this.pnlContainer.Controls.Add(this.panelControl4);
            this.pnlContainer.Controls.Add(this.simpleButton2);
            this.pnlContainer.Controls.Add(this.panelControl1);
            this.pnlContainer.Controls.Add(this.panelControl2);
            this.pnlContainer.Controls.Add(this.btnSalesOrder);
            this.pnlContainer.Size = new System.Drawing.Size(695, 553);
            // 
            // menuMainSalesModule
            // 
            this.menuMainSalesModule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainSalesSystem});
            this.menuMainSalesModule.Location = new System.Drawing.Point(0, 0);
            this.menuMainSalesModule.Name = "menuMainSalesModule";
            this.menuMainSalesModule.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuMainSalesModule.Size = new System.Drawing.Size(695, 24);
            this.menuMainSalesModule.TabIndex = 30;
            // 
            // menuMainSalesSystem
            // 
            this.menuMainSalesSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSalesOrder,
            this.menuItemInvoice,
            this.menuItemAR,
            this.menuItemReports});
            this.menuMainSalesSystem.Name = "menuMainSalesSystem";
            this.menuMainSalesSystem.Size = new System.Drawing.Size(65, 20);
            this.menuMainSalesSystem.Text = "销售模块";
            // 
            // menuSalesOrder
            // 
            this.menuSalesOrder.Name = "menuSalesOrder";
            this.menuSalesOrder.Size = new System.Drawing.Size(152, 22);
            this.menuSalesOrder.Text = "销售订单";
            this.menuSalesOrder.Click += new System.EventHandler(this.menuSalesOrder_Click);
            // 
            // menuItemInvoice
            // 
            this.menuItemInvoice.Name = "menuItemInvoice";
            this.menuItemInvoice.Size = new System.Drawing.Size(152, 22);
            this.menuItemInvoice.Text = "销售发票";
            this.menuItemInvoice.Click += new System.EventHandler(this.menuItemInvoice_Click);
            // 
            // menuItemAR
            // 
            this.menuItemAR.Name = "menuItemAR";
            this.menuItemAR.Size = new System.Drawing.Size(152, 22);
            this.menuItemAR.Text = "销售收款";
            this.menuItemAR.Click += new System.EventHandler(this.menuItemAR_Click);
            // 
            // menuItemReports
            // 
            this.menuItemReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRpt01,
            this.menuRpt02,
            this.menuRpt03});
            this.menuItemReports.Name = "menuItemReports";
            this.menuItemReports.Size = new System.Drawing.Size(152, 22);
            this.menuItemReports.Text = "报表";
            // 
            // menuRpt01
            // 
            this.menuRpt01.Name = "menuRpt01";
            this.menuRpt01.Size = new System.Drawing.Size(238, 22);
            this.menuRpt01.Text = "1. 销售月报表(Demo)";
            this.menuRpt01.Click += new System.EventHandler(this.menuRpt01_Click);
            // 
            // menuRpt02
            // 
            this.menuRpt02.Name = "menuRpt02";
            this.menuRpt02.Size = new System.Drawing.Size(238, 22);
            this.menuRpt02.Text = "2. 销售汇总表(按客户,销售员)";
            this.menuRpt02.Click += new System.EventHandler(this.menuRpt02_Click);
            // 
            // menuRpt03
            // 
            this.menuRpt03.Name = "menuRpt03";
            this.menuRpt03.Size = new System.Drawing.Size(238, 22);
            this.menuRpt03.Text = "3. 销售分析报表";
            this.menuRpt03.Click += new System.EventHandler(this.menuRpt03_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 472);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(691, 79);
            this.panelControl2.TabIndex = 37;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CSFramework3.SalesModule.Properties.Resources.logo_for_app1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 155;
            this.pictureBox1.TabStop = false;
            // 
            // lbReports
            // 
            this.lbReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReports.HotTrackItems = true;
            this.lbReports.ImageList = this.ilReports;
            this.lbReports.Location = new System.Drawing.Point(506, 55);
            this.lbReports.Name = "lbReports";
            this.lbReports.Size = new System.Drawing.Size(189, 406);
            this.lbReports.TabIndex = 38;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Location = new System.Drawing.Point(154, 77);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(243, 74);
            this.panelControl1.TabIndex = 39;
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
            this.label3.Text = "销售订单";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 40);
            this.label4.TabIndex = 25;
            this.label4.Text = "销售订单管理。在这里输入特别提示信息。";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.label6);
            this.panelControl4.Controls.Add(this.label7);
            this.panelControl4.Location = new System.Drawing.Point(154, 180);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(243, 74);
            this.panelControl4.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "销售发票";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 40);
            this.label7.TabIndex = 25;
            this.label7.Text = "销售发票管理。在这里输入特别提示信息。";
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.label8);
            this.panelControl5.Controls.Add(this.label9);
            this.panelControl5.Location = new System.Drawing.Point(154, 277);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(243, 74);
            this.panelControl5.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "销售收款单";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(237, 40);
            this.label9.TabIndex = 25;
            this.label9.Text = "销售收款管理。在这里输入特别提示信息。";
            // 
            // btnAR
            // 
            this.btnAR.Enabled = false;
            this.btnAR.Image = global::CSFramework3.SalesModule.Properties.Resources._48_GRNReturn;
            this.btnAR.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAR.Location = new System.Drawing.Point(59, 269);
            this.btnAR.Name = "btnAR";
            this.btnAR.Size = new System.Drawing.Size(84, 84);
            this.btnAR.TabIndex = 44;
            this.btnAR.Text = "销售收款";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Enabled = false;
            this.simpleButton2.Image = global::CSFramework3.SalesModule.Properties.Resources._48_SalesInvoice;
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton2.Location = new System.Drawing.Point(59, 172);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(84, 84);
            this.simpleButton2.TabIndex = 42;
            this.simpleButton2.Text = "销售发票";
            // 
            // btnSalesOrder
            // 
            this.btnSalesOrder.Image = global::CSFramework3.SalesModule.Properties.Resources._48_Quotation;
            this.btnSalesOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSalesOrder.Location = new System.Drawing.Point(59, 69);
            this.btnSalesOrder.Name = "btnSalesOrder";
            this.btnSalesOrder.Size = new System.Drawing.Size(84, 84);
            this.btnSalesOrder.TabIndex = 2;
            this.btnSalesOrder.Text = "销售订单";
            this.btnSalesOrder.Click += new System.EventHandler(this.menuSalesOrder_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::CSFramework3.SalesModule.Properties.Resources.bk_reg;
            this.pictureBox2.Location = new System.Drawing.Point(0, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(695, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 53;
            this.pictureBox2.TabStop = false;
            // 
            // frmSalesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(695, 553);
            this.Controls.Add(this.menuMainSalesModule);
            this.Name = "frmSalesMain";
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.Controls.SetChildIndex(this.menuMainSalesModule, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.menuMainSalesModule.ResumeLayout(false);
            this.menuMainSalesModule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMainSalesModule;
        private System.Windows.Forms.ToolStripMenuItem menuMainSalesSystem;
        private DevExpress.XtraEditors.SimpleButton btnSalesOrder;
        private System.Windows.Forms.ToolStripMenuItem menuSalesOrder;
        private DevExpress.XtraEditors.ImageListBoxControl lbReports;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem menuItemReports;
        private System.Windows.Forms.ToolStripMenuItem menuRpt01;
        private System.Windows.Forms.ToolStripMenuItem menuRpt02;
        private System.Windows.Forms.ToolStripMenuItem menuRpt03;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton btnAR;
        private System.Windows.Forms.ToolStripMenuItem menuItemInvoice;
        private System.Windows.Forms.ToolStripMenuItem menuItemAR;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
