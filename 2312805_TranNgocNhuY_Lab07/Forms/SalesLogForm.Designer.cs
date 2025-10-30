namespace _2312805_TranNgocNhuY_lab07.Forms
{
    partial class SalesLogForm
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
            this.listViewSalesLog = new System.Windows.Forms.ListView();
            this.clmnStt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmlnCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewSalesLog
            // 
            this.listViewSalesLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnStt,
            this.clmnTableName,
            this.clmnStatus,
            this.cmlnCapacity,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewSalesLog.FullRowSelect = true;
            this.listViewSalesLog.GridLines = true;
            this.listViewSalesLog.HideSelection = false;
            this.listViewSalesLog.Location = new System.Drawing.Point(12, 12);
            this.listViewSalesLog.Name = "listViewSalesLog";
            this.listViewSalesLog.Size = new System.Drawing.Size(500, 242);
            this.listViewSalesLog.TabIndex = 1;
            this.listViewSalesLog.UseCompatibleStateImageBehavior = false;
            this.listViewSalesLog.View = System.Windows.Forms.View.Details;
            // 
            // clmnStt
            // 
            this.clmnStt.Text = "Tên hóa đơn";
            this.clmnStt.Width = 150;
            // 
            // clmnTableName
            // 
            this.clmnTableName.Text = "Ngày thanh toán";
            this.clmnTableName.Width = 150;
            // 
            // clmnStatus
            // 
            this.clmnStatus.Text = "Tên tài khoản";
            this.clmnStatus.Width = 100;
            // 
            // cmlnCapacity
            // 
            this.cmlnCapacity.Text = "Số tiền";
            this.cmlnCapacity.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Giảm giá";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Thuế";
            this.columnHeader2.Width = 100;
            // 
            // SalesLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 266);
            this.Controls.Add(this.listViewSalesLog);
            this.Name = "SalesLogForm";
            this.Text = "SaleLogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSalesLog;
        private System.Windows.Forms.ColumnHeader clmnStt;
        private System.Windows.Forms.ColumnHeader clmnTableName;
        private System.Windows.Forms.ColumnHeader clmnStatus;
        private System.Windows.Forms.ColumnHeader cmlnCapacity;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}