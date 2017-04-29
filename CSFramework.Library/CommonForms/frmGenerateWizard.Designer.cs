namespace CSFramework.Library
{
    partial class frmGenerateWizard
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
            this.rgItems = new DevExpress.XtraEditors.RadioGroup();
            this.btnGen = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.pnlDocNo = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.rgItems.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocNo)).BeginInit();
            this.pnlDocNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgItems
            // 
            this.rgItems.Location = new System.Drawing.Point(5, 5);
            this.rgItems.Name = "rgItems";
            this.rgItems.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgItems.Properties.Appearance.Options.UseFont = true;
            this.rgItems.Size = new System.Drawing.Size(313, 138);
            this.rgItems.TabIndex = 0;
            this.rgItems.SelectedIndexChanged += new System.EventHandler(this.rgItems_SelectedIndexChanged);
            // 
            // btnGen
            // 
            this.btnGen.Image = global::CSFramework.Library.ResImage.ButtonCascade;
            this.btnGen.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnGen.Location = new System.Drawing.Point(241, 149);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(77, 67);
            this.btnGen.TabIndex = 1;
            this.btnGen.Text = "生成单据";
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "单据号码：";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(92, 33);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(118, 21);
            this.textEdit1.TabIndex = 3;
            // 
            // pnlDocNo
            // 
            this.pnlDocNo.Controls.Add(this.textEdit1);
            this.pnlDocNo.Controls.Add(this.labelControl1);
            this.pnlDocNo.Location = new System.Drawing.Point(5, 149);
            this.pnlDocNo.Name = "pnlDocNo";
            this.pnlDocNo.Size = new System.Drawing.Size(230, 67);
            this.pnlDocNo.TabIndex = 5;
            this.pnlDocNo.Text = "请输入单据号码：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.rgItems);
            this.panelControl1.Controls.Add(this.btnGen);
            this.panelControl1.Controls.Add(this.pnlDocNo);
            this.panelControl1.Location = new System.Drawing.Point(12, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(323, 221);
            this.panelControl1.TabIndex = 6;
            // 
            // frmGenerateWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 271);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单据自动生成向导";
            ((System.ComponentModel.ISupportInitialize)(this.rgItems.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocNo)).EndInit();
            this.pnlDocNo.ResumeLayout(false);
            this.pnlDocNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup rgItems;
        private DevExpress.XtraEditors.SimpleButton btnGen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl pnlDocNo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}