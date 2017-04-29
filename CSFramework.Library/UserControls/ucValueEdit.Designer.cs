namespace CSFramework.Library.UserControls
{
    partial class ucValueEdit
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
            this._InnerLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this._InnerLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _InnerLookUpEdit
            // 
            this._InnerLookUpEdit.Location = new System.Drawing.Point(0, 0);
            this._InnerLookUpEdit.Name = "_InnerLookUpEdit";
            this._InnerLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._InnerLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", 30, "数值"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 70, "名称")});
            this._InnerLookUpEdit.Properties.NullText = "";
            this._InnerLookUpEdit.Size = new System.Drawing.Size(100, 21);
            this._InnerLookUpEdit.TabIndex = 0;
            // 
            // ucValueEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._InnerLookUpEdit);
            this.Name = "ucValueEdit";
            this.Size = new System.Drawing.Size(100, 21);
            this.Load += new System.EventHandler(this.ucValueEdit_Load);
            this.SizeChanged += new System.EventHandler(this.ucValueEdit_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this._InnerLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit _InnerLookUpEdit;
    }
}
