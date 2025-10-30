namespace _2312805_TranNgocNhuY_Lab04.Forms
{
    partial class BillDetailsForm
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
            this.dtgrvBillDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvBillDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgrvBillDetail
            // 
            this.dtgrvBillDetail.BackgroundColor = System.Drawing.Color.White;
            this.dtgrvBillDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvBillDetail.GridColor = System.Drawing.Color.White;
            this.dtgrvBillDetail.Location = new System.Drawing.Point(12, 12);
            this.dtgrvBillDetail.Name = "dtgrvBillDetail";
            this.dtgrvBillDetail.RowHeadersVisible = false;
            this.dtgrvBillDetail.RowHeadersWidth = 51;
            this.dtgrvBillDetail.RowTemplate.Height = 24;
            this.dtgrvBillDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrvBillDetail.Size = new System.Drawing.Size(776, 243);
            this.dtgrvBillDetail.TabIndex = 2;
            // 
            // BillDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.dtgrvBillDetail);
            this.Name = "BillDetailsForm";
            this.Text = "BillDetailsForm";
            this.Load += new System.EventHandler(this.BillDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvBillDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgrvBillDetail;
    }
}