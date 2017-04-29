
namespace CSFramework.Library
{
    partial class frmModifyPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyPwd));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccount = new DevExpress.XtraEditors.TextEdit();
            this.txtPwdS = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwdF = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPwd = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataset = new DevExpress.XtraEditors.LookUpEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label10);
            this.panelControl1.Controls.Add(this.txtDataset);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.txtAccount);
            this.panelControl1.Controls.Add(this.txtPwdS);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtPwdF);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtOldPwd);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Size = new System.Drawing.Size(449, 269);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(185, 279);
            this.btnOk.Size = new System.Drawing.Size(85, 25);
            this.btnOk.Text = "修改(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 279);
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.label9);
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(449, 69);
            this.panelControl2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Location = new System.Drawing.Point(0, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(449, 2);
            this.label9.TabIndex = 16;
            this.label9.Text = "label9";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(385, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "请输入用户旧密码与新密码,然後按\'确定\'按钮 ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "修改密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "登录账号：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(158, 129);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(219, 21);
            this.txtAccount.TabIndex = 8;
            // 
            // txtPwdS
            // 
            this.txtPwdS.Location = new System.Drawing.Point(158, 217);
            this.txtPwdS.Name = "txtPwdS";
            this.txtPwdS.Properties.PasswordChar = '*';
            this.txtPwdS.Size = new System.Drawing.Size(219, 21);
            this.txtPwdS.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "确认新密码：";
            // 
            // txtPwdF
            // 
            this.txtPwdF.Location = new System.Drawing.Point(158, 189);
            this.txtPwdF.Name = "txtPwdF";
            this.txtPwdF.Properties.PasswordChar = '*';
            this.txtPwdF.Size = new System.Drawing.Size(219, 21);
            this.txtPwdF.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "新密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "旧密码：";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(158, 158);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Properties.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(219, 21);
            this.txtOldPwd.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(12, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(425, 2);
            this.label7.TabIndex = 15;
            this.label7.Text = "label7";
            // 
            // txtDataset
            // 
            this.txtDataset.Enabled = false;
            this.txtDataset.Location = new System.Drawing.Point(158, 80);
            this.txtDataset.Name = "txtDataset";
            this.txtDataset.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDataset.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataSetID", 100, "帐套编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataSetName", 200, "帐套名称")});
            this.txtDataset.Properties.NullText = "";
            this.txtDataset.Properties.PopupWidth = 300;
            this.txtDataset.Size = new System.Drawing.Size(219, 21);
            this.txtDataset.TabIndex = 230;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 14);
            this.label8.TabIndex = 229;
            this.label8.Text = "帐套：";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(157, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(220, 2);
            this.label10.TabIndex = 231;
            this.label10.Text = "label10";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CSFramework.Library.ResImage.csframework16;
            this.pictureBox2.Location = new System.Drawing.Point(1, 313);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(17, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "C/S框架网 www.csframework.com";
            // 
            // frmModifyPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(449, 331);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox2);
            this.Name = "frmModifyPwd";
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.frmModifyPwd_Load);
            this.Activated += new System.EventHandler(this.frmModifyPwd_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModifyPwd_KeyDown);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtAccount;
        private DevExpress.XtraEditors.TextEdit txtPwdS;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtPwdF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtOldPwd;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit txtDataset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;

    }
}
