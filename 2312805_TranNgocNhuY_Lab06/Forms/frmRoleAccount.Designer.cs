namespace _2312805_TranNgocNhuY_Lab06.Forms
{
    partial class frmRoleAccount
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
            this.lblStatistic = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvRoleAccount = new System.Windows.Forms.ListView();
            this.clmnStt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmlnNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkActivatedYes = new System.Windows.Forms.RadioButton();
            this.chkActivatedNo = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatistic
            // 
            this.lblStatistic.AutoSize = true;
            this.lblStatistic.Location = new System.Drawing.Point(433, 205);
            this.lblStatistic.Name = "lblStatistic";
            this.lblStatistic.Size = new System.Drawing.Size(64, 16);
            this.lblStatistic.TabIndex = 28;
            this.lblStatistic.Text = "Thống kê";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(300, 185);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(85, 32);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "Xóa";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(207, 185);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(87, 32);
            this.cmdUpdate.TabIndex = 5;
            this.cmdUpdate.Text = "Sửa";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(114, 185);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(87, 32);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "Thêm";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(10, 185);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(98, 32);
            this.cmdClear.TabIndex = 7;
            this.cmdClear.Text = "Nhập lại";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID Vai trò";
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(773, 196);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(85, 32);
            this.cmdExit.TabIndex = 29;
            this.cmdExit.Text = "Thoát";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Location = new System.Drawing.Point(100, 115);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(284, 22);
            this.txtNotes.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkActivatedNo);
            this.groupBox1.Controls.Add(this.chkActivatedYes);
            this.groupBox1.Controls.Add(this.cbbRole);
            this.groupBox1.Controls.Add(this.cmdDelete);
            this.groupBox1.Controls.Add(this.cmdUpdate);
            this.groupBox1.Controls.Add(this.cmdAdd);
            this.groupBox1.Controls.Add(this.cmdClear);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 235);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ghi chú";
            // 
            // txtAccountName
            // 
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.Location = new System.Drawing.Point(100, 33);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(284, 22);
            this.txtAccountName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // lsvRoleAccount
            // 
            this.lsvRoleAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnStt,
            this.clmnAccountName,
            this.clmnRole,
            this.clmnStatus,
            this.cmlnNotes});
            this.lsvRoleAccount.FullRowSelect = true;
            this.lsvRoleAccount.GridLines = true;
            this.lsvRoleAccount.HideSelection = false;
            this.lsvRoleAccount.Location = new System.Drawing.Point(6, 21);
            this.lsvRoleAccount.Name = "lsvRoleAccount";
            this.lsvRoleAccount.Size = new System.Drawing.Size(416, 141);
            this.lsvRoleAccount.TabIndex = 0;
            this.lsvRoleAccount.UseCompatibleStateImageBehavior = false;
            this.lsvRoleAccount.View = System.Windows.Forms.View.Details;
            this.lsvRoleAccount.Click += new System.EventHandler(this.lsvRoleAccount_Click);
            // 
            // clmnStt
            // 
            this.clmnStt.Text = "STT";
            this.clmnStt.Width = 50;
            // 
            // clmnAccountName
            // 
            this.clmnAccountName.Text = "Tên tài khoản";
            this.clmnAccountName.Width = 150;
            // 
            // clmnRole
            // 
            this.clmnRole.Text = "Vai trò";
            this.clmnRole.Width = 150;
            // 
            // clmnStatus
            // 
            this.clmnStatus.Text = "Trạng thái";
            this.clmnStatus.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvRoleAccount);
            this.groupBox2.Location = new System.Drawing.Point(430, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 178);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách vai trò - tài khoản";
            // 
            // cbbRole
            // 
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Location = new System.Drawing.Point(100, 70);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(284, 24);
            this.cbbRole.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trạng thái";
            // 
            // cmlnNotes
            // 
            this.cmlnNotes.Text = "Ghji chú";
            this.cmlnNotes.Width = 200;
            // 
            // chkActivatedYes
            // 
            this.chkActivatedYes.AutoSize = true;
            this.chkActivatedYes.Location = new System.Drawing.Point(98, 154);
            this.chkActivatedYes.Name = "chkActivatedYes";
            this.chkActivatedYes.Size = new System.Drawing.Size(91, 20);
            this.chkActivatedYes.TabIndex = 10;
            this.chkActivatedYes.TabStop = true;
            this.chkActivatedYes.Text = "Hoạt động";
            this.chkActivatedYes.UseVisualStyleBackColor = true;
            // 
            // chkActivatedNo
            // 
            this.chkActivatedNo.AutoSize = true;
            this.chkActivatedNo.Location = new System.Drawing.Point(207, 154);
            this.chkActivatedNo.Name = "chkActivatedNo";
            this.chkActivatedNo.Size = new System.Drawing.Size(129, 20);
            this.chkActivatedNo.TabIndex = 10;
            this.chkActivatedNo.TabStop = true;
            this.chkActivatedNo.Text = "Không hoạt động";
            this.chkActivatedNo.UseVisualStyleBackColor = true;
            // 
            // frmRoleAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 261);
            this.Controls.Add(this.lblStatistic);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmRoleAccount";
            this.Text = "frmRoleAccount";
            this.Load += new System.EventHandler(this.frmRoleAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatistic;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvRoleAccount;
        private System.Windows.Forms.ColumnHeader clmnStt;
        private System.Windows.Forms.ColumnHeader clmnAccountName;
        private System.Windows.Forms.ColumnHeader clmnRole;
        private System.Windows.Forms.ColumnHeader clmnStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader cmlnNotes;
        private System.Windows.Forms.RadioButton chkActivatedYes;
        private System.Windows.Forms.RadioButton chkActivatedNo;
    }
}