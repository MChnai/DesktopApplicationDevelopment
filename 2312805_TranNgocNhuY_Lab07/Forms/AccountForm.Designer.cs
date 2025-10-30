namespace _2312805_TranNgocNhuY_lab07.Forms
{
    partial class AccountForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvwAccount = new System.Windows.Forms.ListView();
            this.mnAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnPass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbFunction = new System.Windows.Forms.GroupBox();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.txtSearchUserName = new System.Windows.Forms.TextBox();
            this.btnPassManagement = new System.Windows.Forms.Button();
            this.btnAccountManagement = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchVaiTròToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.grbFunction.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvwAccount);
            this.groupBox3.Location = new System.Drawing.Point(12, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 212);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách tài khoản";
            // 
            // lvwAccount
            // 
            this.lvwAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mnAccountName,
            this.clmnFullName,
            this.clmnEmail,
            this.clmnPhone,
            this.clmnPass,
            this.clmnDate});
            this.lvwAccount.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwAccount.FullRowSelect = true;
            this.lvwAccount.GridLines = true;
            this.lvwAccount.HideSelection = false;
            this.lvwAccount.Location = new System.Drawing.Point(6, 21);
            this.lvwAccount.Name = "lvwAccount";
            this.lvwAccount.Size = new System.Drawing.Size(596, 185);
            this.lvwAccount.TabIndex = 12;
            this.lvwAccount.UseCompatibleStateImageBehavior = false;
            this.lvwAccount.View = System.Windows.Forms.View.Details;
            // 
            // mnAccountName
            // 
            this.mnAccountName.Text = "Tên tài khoản";
            this.mnAccountName.Width = 200;
            // 
            // clmnFullName
            // 
            this.clmnFullName.Text = "Tên đầy đủ";
            this.clmnFullName.Width = 200;
            // 
            // clmnEmail
            // 
            this.clmnEmail.Text = "Email";
            this.clmnEmail.Width = 150;
            // 
            // clmnPhone
            // 
            this.clmnPhone.Text = "Số điện thoại";
            this.clmnPhone.Width = 150;
            // 
            // clmnPass
            // 
            this.clmnPass.Text = "Mật khẩu";
            this.clmnPass.Width = 150;
            // 
            // clmnDate
            // 
            this.clmnDate.Text = "Ngày tạo";
            this.clmnDate.Width = 150;
            // 
            // grbFunction
            // 
            this.grbFunction.Controls.Add(this.cbbRole);
            this.grbFunction.Controls.Add(this.txtSearchUserName);
            this.grbFunction.Controls.Add(this.btnPassManagement);
            this.grbFunction.Controls.Add(this.btnAccountManagement);
            this.grbFunction.Controls.Add(this.label2);
            this.grbFunction.Controls.Add(this.label1);
            this.grbFunction.Location = new System.Drawing.Point(18, 12);
            this.grbFunction.Name = "grbFunction";
            this.grbFunction.Size = new System.Drawing.Size(596, 132);
            this.grbFunction.TabIndex = 15;
            this.grbFunction.TabStop = false;
            this.grbFunction.Text = "Chức năng";
            // 
            // cbbRole
            // 
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Location = new System.Drawing.Point(177, 60);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(403, 24);
            this.cbbRole.TabIndex = 2;
            this.cbbRole.SelectedIndexChanged += new System.EventHandler(this.cbbRole_SelectedIndexChanged);
            // 
            // txtSearchUserName
            // 
            this.txtSearchUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchUserName.Location = new System.Drawing.Point(177, 33);
            this.txtSearchUserName.Name = "txtSearchUserName";
            this.txtSearchUserName.Size = new System.Drawing.Size(403, 22);
            this.txtSearchUserName.TabIndex = 1;
            this.txtSearchUserName.TextChanged += new System.EventHandler(this.txtRoleName_TextChanged);
            // 
            // btnPassManagement
            // 
            this.btnPassManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassManagement.Location = new System.Drawing.Point(135, 93);
            this.btnPassManagement.Name = "btnPassManagement";
            this.btnPassManagement.Size = new System.Drawing.Size(139, 25);
            this.btnPassManagement.TabIndex = 6;
            this.btnPassManagement.Text = "Quản lý mật khẩu";
            this.btnPassManagement.UseVisualStyleBackColor = true;
            this.btnPassManagement.Click += new System.EventHandler(this.btnPassManagement_Click);
            // 
            // btnAccountManagement
            // 
            this.btnAccountManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountManagement.Location = new System.Drawing.Point(6, 93);
            this.btnAccountManagement.Name = "btnAccountManagement";
            this.btnAccountManagement.Size = new System.Drawing.Size(123, 25);
            this.btnAccountManagement.TabIndex = 6;
            this.btnAccountManagement.Text = "Quản lý tài khoản";
            this.btnAccountManagement.UseVisualStyleBackColor = true;
            this.btnAccountManagement.Click += new System.EventHandler(this.btnAccountManagement_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm theo role";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm theo tên tài khoản";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaTàiKhoảnToolStripMenuItem,
            this.xemDanhSáchVaiTròToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 52);
            // 
            // xóaTàiKhoảnToolStripMenuItem
            // 
            this.xóaTàiKhoảnToolStripMenuItem.Name = "xóaTàiKhoảnToolStripMenuItem";
            this.xóaTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.xóaTàiKhoảnToolStripMenuItem.Text = "Xóa tài khoản";
            this.xóaTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.xóaTàiKhoảnToolStripMenuItem_Click);
            // 
            // xemDanhSáchVaiTròToolStripMenuItem
            // 
            this.xemDanhSáchVaiTròToolStripMenuItem.Name = "xemDanhSáchVaiTròToolStripMenuItem";
            this.xemDanhSáchVaiTròToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.xemDanhSáchVaiTròToolStripMenuItem.Text = "Xem danh sách vai trò";
            this.xemDanhSáchVaiTròToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchVaiTròToolStripMenuItem_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 373);
            this.Controls.Add(this.grbFunction);
            this.Controls.Add(this.groupBox3);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountForm";
            this.groupBox3.ResumeLayout(false);
            this.grbFunction.ResumeLayout(false);
            this.grbFunction.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvwAccount;
        private System.Windows.Forms.GroupBox grbFunction;
        private System.Windows.Forms.TextBox txtSearchUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPassManagement;
        private System.Windows.Forms.Button btnAccountManagement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.ColumnHeader mnAccountName;
        private System.Windows.Forms.ColumnHeader clmnFullName;
        private System.Windows.Forms.ColumnHeader clmnEmail;
        private System.Windows.Forms.ColumnHeader clmnPhone;
        private System.Windows.Forms.ColumnHeader clmnPass;
        private System.Windows.Forms.ColumnHeader clmnDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchVaiTròToolStripMenuItem;
    }
}