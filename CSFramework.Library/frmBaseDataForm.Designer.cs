namespace CSFramework.Library
{
    partial class frmBaseDataForm
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
            this.components = new System.ComponentModel.Container();
            this.tpSummary = new DevExpress.XtraTab.XtraTabPage();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tcBusiness = new DevExpress.XtraTab.XtraTabControl();
            this.tpDetail = new DevExpress.XtraTab.XtraTabPage();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.gcNavigator = new DevExpress.XtraEditors.GroupControl();
            this.lblAboutInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.controlNavigatorSummary = new DevExpress.XtraEditors.ControlNavigator();
            this.timeLocal = new System.Windows.Forms.Timer(this.components);
            this.txtFocusForSave = new System.Windows.Forms.TextBox();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Size = new System.Drawing.Size(775, 483);
            this.tpSummary.Text = "数据查询";
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.tcBusiness);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Location = new System.Drawing.Point(0, 26);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(782, 513);
            this.pnlSummary.TabIndex = 121;
            // 
            // tcBusiness
            // 
            this.tcBusiness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcBusiness.Location = new System.Drawing.Point(0, 0);
            this.tcBusiness.Name = "tcBusiness";
            this.tcBusiness.SelectedTabPage = this.tpSummary;
            this.tcBusiness.Size = new System.Drawing.Size(782, 513);
            this.tcBusiness.TabIndex = 0;
            this.tcBusiness.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpSummary,
            this.tpDetail});
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(775, 483);
            this.tpDetail.Text = "数据编辑";
            // 
            // toolTipController1
            // 
            this.toolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // gcNavigator
            // 
            this.gcNavigator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gcNavigator.Controls.Add(this.lblAboutInfo);
            this.gcNavigator.Controls.Add(this.pictureBox1);
            this.gcNavigator.Controls.Add(this.lblPrompt);
            this.gcNavigator.Controls.Add(this.controlNavigatorSummary);
            this.gcNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcNavigator.Location = new System.Drawing.Point(0, 0);
            this.gcNavigator.Name = "gcNavigator";
            this.gcNavigator.Padding = new System.Windows.Forms.Padding(2);
            this.gcNavigator.Size = new System.Drawing.Size(782, 26);
            this.gcNavigator.TabIndex = 123;
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblAboutInfo.ForeColor = System.Drawing.Color.Silver;
            this.lblAboutInfo.Location = new System.Drawing.Point(407, 2);
            this.lblAboutInfo.Name = "lblAboutInfo";
            this.lblAboutInfo.Size = new System.Drawing.Size(197, 22);
            this.lblAboutInfo.TabIndex = 42;
            this.lblAboutInfo.Text = "关于C/S框架|www.csframework.com";
            this.lblAboutInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSFramework.Library.ResImage.info;
            this.pictureBox1.Location = new System.Drawing.Point(10, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblPrompt.Location = new System.Drawing.Point(28, 5);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(145, 14);
            this.lblPrompt.TabIndex = 40;
            this.lblPrompt.Text = "操作提示(Operation Tips)";
            // 
            // controlNavigatorSummary
            // 
            this.controlNavigatorSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.controlNavigatorSummary.Buttons.Append.Visible = false;
            this.controlNavigatorSummary.Buttons.CancelEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.Edit.Visible = false;
            this.controlNavigatorSummary.Buttons.EndEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.NextPage.Visible = false;
            this.controlNavigatorSummary.Buttons.PrevPage.Visible = false;
            this.controlNavigatorSummary.Buttons.Remove.Visible = false;
            this.controlNavigatorSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlNavigatorSummary.Location = new System.Drawing.Point(604, 2);
            this.controlNavigatorSummary.Name = "controlNavigatorSummary";
            this.controlNavigatorSummary.Size = new System.Drawing.Size(176, 22);
            this.controlNavigatorSummary.TabIndex = 37;
            this.controlNavigatorSummary.Text = "controlNavigator1";
            this.controlNavigatorSummary.TextStringFormat = " {0} of {1}";
            // 
            // timeLocal
            // 
            this.timeLocal.Interval = 1000;
            // 
            // txtFocusForSave
            // 
            this.txtFocusForSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFocusForSave.Location = new System.Drawing.Point(421, 265);
            this.txtFocusForSave.Name = "txtFocusForSave";
            this.txtFocusForSave.Size = new System.Drawing.Size(0, 15);
            this.txtFocusForSave.TabIndex = 122;
            // 
            // frmBaseDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 539);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.gcNavigator);
            this.Controls.Add(this.txtFocusForSave);
            this.Name = "frmBaseDataForm";
            this.Text = "MDI程序-编辑数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseDataForm_FormClosing);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraTab.XtraTabPage tpSummary;
        public System.Windows.Forms.Panel pnlSummary;
        public DevExpress.XtraTab.XtraTabControl tcBusiness;
        public DevExpress.XtraTab.XtraTabPage tpDetail;
        private DevExpress.Utils.ToolTipController toolTipController1;
        public DevExpress.XtraEditors.GroupControl gcNavigator;
        public DevExpress.XtraEditors.ControlNavigator controlNavigatorSummary;
        private System.Windows.Forms.Timer timeLocal;
        public System.Windows.Forms.TextBox txtFocusForSave;
        protected System.Windows.Forms.Label lblPrompt;
        protected System.Windows.Forms.Label lblAboutInfo;
        protected System.Windows.Forms.PictureBox pictureBox1;

    }
}