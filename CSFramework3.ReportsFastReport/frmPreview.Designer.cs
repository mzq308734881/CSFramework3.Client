namespace CSFramework3.ReportsFastReport
{
    partial class frmPreview
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
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.cbExportTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // previewControl1
            // 
            this.previewControl1.Buttons = ((FastReport.PreviewButtons)((((((((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Open)
                        | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Find)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.Outline)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Edit)
                        | FastReport.PreviewButtons.Watermark)
                        | FastReport.PreviewButtons.Navigator)));
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(0, 0);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.Size = new System.Drawing.Size(867, 512);
            this.previewControl1.TabIndex = 0;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(732, 0);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(68, 25);
            this.btnSendEmail.TabIndex = 1;
            this.btnSendEmail.Text = "发邮件";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // cbExportTypes
            // 
            this.cbExportTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportTypes.FormattingEnabled = true;
            this.cbExportTypes.Location = new System.Drawing.Point(611, 3);
            this.cbExportTypes.Name = "cbExportTypes";
            this.cbExportTypes.Size = new System.Drawing.Size(115, 20);
            this.cbExportTypes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(541, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "附件类型：";
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbExportTypes);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.previewControl1);
            this.Name = "frmPreview";
            this.Text = "报表预览窗体";
            this.Load += new System.EventHandler(this.frmPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.ComboBox cbExportTypes;
        private System.Windows.Forms.Label label1;
    }
}