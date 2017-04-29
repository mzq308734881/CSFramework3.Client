namespace CSFramework.Library.UserControls
{
    partial class ucCheckEdit
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
            this._CheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this._ButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this._CheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ButtonEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _CheckEdit
            // 
            this._CheckEdit.Location = new System.Drawing.Point(0, 1);
            this._CheckEdit.Name = "_CheckEdit";
            this._CheckEdit.Properties.Caption = "";
            this._CheckEdit.Size = new System.Drawing.Size(20, 19);
            this._CheckEdit.TabIndex = 0;
            this._CheckEdit.CheckedChanged += new System.EventHandler(this._CheckEdit_CheckedChanged);
            // 
            // _ButtonEdit
            // 
            this._ButtonEdit.Enabled = false;
            this._ButtonEdit.Location = new System.Drawing.Point(17, 0);
            this._ButtonEdit.Name = "_ButtonEdit";
            this._ButtonEdit.Size = new System.Drawing.Size(85, 21);
            this._ButtonEdit.TabIndex = 1;
            // 
            // ucCheckEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ButtonEdit);
            this.Controls.Add(this._CheckEdit);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(2000, 21);
            this.MinimumSize = new System.Drawing.Size(25, 21);
            this.Name = "ucCheckEdit";
            this.Size = new System.Drawing.Size(107, 21);
            this.Load += new System.EventHandler(this.ucCheckEdit_Load);
            this.SizeChanged += new System.EventHandler(this.ucCheckEdit_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this._CheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ButtonEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit _CheckEdit;
        private DevExpress.XtraEditors.ButtonEdit _ButtonEdit;
    }
}
