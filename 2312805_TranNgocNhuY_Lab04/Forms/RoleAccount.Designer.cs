namespace _2312805_TranNgocNhuY_Lab04.Forms
{
    partial class RoleAccount
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
            this.dtgvRoleAccount = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRoleAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvRoleAccount
            // 
            this.dtgvRoleAccount.BackgroundColor = System.Drawing.Color.White;
            this.dtgvRoleAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvRoleAccount.Location = new System.Drawing.Point(12, 12);
            this.dtgvRoleAccount.Name = "dtgvRoleAccount";
            this.dtgvRoleAccount.RowHeadersWidth = 51;
            this.dtgvRoleAccount.RowTemplate.Height = 24;
            this.dtgvRoleAccount.Size = new System.Drawing.Size(776, 259);
            this.dtgvRoleAccount.TabIndex = 1;
            // 
            // RoleAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 285);
            this.Controls.Add(this.dtgvRoleAccount);
            this.Name = "RoleAccount";
            this.Text = "RoleAccount";
            this.Load += new System.EventHandler(this.RoleAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRoleAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvRoleAccount;
    }
}