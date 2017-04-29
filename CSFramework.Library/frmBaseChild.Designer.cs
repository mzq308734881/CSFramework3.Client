namespace CSFramework.Library
{
    partial class frmBaseChild
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
            this.SuspendLayout();
            // 
            // frmBaseChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 195);
            this.Name = "frmBaseChild";
            this.Text = "MDI子窗体基类";
            this.Activated += new System.EventHandler(this.frmBaseChild_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBaseChild_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseChild_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
    }
}