namespace CSFramework.Library.UserControls
{
    partial class ucDT_UserLookup
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
            this.lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit
            // 
            this.lookUpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEdit.Location = new System.Drawing.Point(0, 0);
            this.lookUpEdit.Name = "lookUpEdit";
            this.lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Account", 80, "帐号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", 120, "姓名")});
            this.lookUpEdit.Properties.NullText = "";
            this.lookUpEdit.Size = new System.Drawing.Size(118, 21);
            this.lookUpEdit.TabIndex = 0;
            // 
            // ucDT_UserLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lookUpEdit);
            this.MaximumSize = new System.Drawing.Size(500, 21);
            this.Name = "ucDT_UserLookup";
            this.Size = new System.Drawing.Size(118, 21);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit;
    }
}
