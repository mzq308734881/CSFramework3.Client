namespace CSFramework.Library.UserControls
{
    partial class ucCheckedListBoxBinding
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
            this.lists = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.lists)).BeginInit();
            this.SuspendLayout();
            // 
            // lists
            // 
            this.lists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lists.Location = new System.Drawing.Point(0, 0);
            this.lists.Name = "lists";
            this.lists.Size = new System.Drawing.Size(260, 200);
            this.lists.TabIndex = 0;
            this.lists.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lists_ItemCheck);
            this.lists.SelectedValueChanged += new System.EventHandler(this.lists_SelectedValueChanged);
            // 
            // ucCheckedListBoxBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lists);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCheckedListBoxBinding";
            this.Size = new System.Drawing.Size(260, 200);
            ((System.ComponentModel.ISupportInitialize)(this.lists)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl lists;
    }
}
