namespace _2312805_TranNgocNhuY_lab07.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdminManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewTables = new System.Windows.Forms.ListView();
            this.clmnStt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmlnCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewBillDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckoutTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFoods = new System.Windows.Forms.ComboBox();
            this.btnAddFoodToBill = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminManagement,
            this.menuViewAccount});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdminManagement
            // 
            this.menuAdminManagement.Name = "menuAdminManagement";
            this.menuAdminManagement.Size = new System.Drawing.Size(141, 24);
            this.menuAdminManagement.Text = "Quản trị tài khoản";
            this.menuAdminManagement.Click += new System.EventHandler(this.menuAdminManagement_Click);
            // 
            // menuViewAccount
            // 
            this.menuViewAccount.Name = "menuViewAccount";
            this.menuViewAccount.Size = new System.Drawing.Size(182, 24);
            this.menuViewAccount.Text = "Xem thông tin tài khoản";
            this.menuViewAccount.Click += new System.EventHandler(this.menuViewAccount_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewTables);
            this.groupBox2.Location = new System.Drawing.Point(429, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 178);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách bàn";
            // 
            // listViewTables
            // 
            this.listViewTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnStt,
            this.clmnTableName,
            this.clmnStatus,
            this.cmlnCapacity});
            this.listViewTables.FullRowSelect = true;
            this.listViewTables.GridLines = true;
            this.listViewTables.HideSelection = false;
            this.listViewTables.Location = new System.Drawing.Point(12, 24);
            this.listViewTables.Name = "listViewTables";
            this.listViewTables.Size = new System.Drawing.Size(347, 141);
            this.listViewTables.TabIndex = 0;
            this.listViewTables.UseCompatibleStateImageBehavior = false;
            this.listViewTables.View = System.Windows.Forms.View.Details;
            // 
            // clmnStt
            // 
            this.clmnStt.Text = "ID";
            this.clmnStt.Width = 50;
            // 
            // clmnTableName
            // 
            this.clmnTableName.Text = "Tên bàn";
            this.clmnTableName.Width = 150;
            // 
            // clmnStatus
            // 
            this.clmnStatus.Text = "Trạng thái";
            this.clmnStatus.Width = 200;
            // 
            // cmlnCapacity
            // 
            this.cmlnCapacity.Text = "Số chỗ";
            this.cmlnCapacity.Width = 120;
            // 
            // listViewBillDetails
            // 
            this.listViewBillDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewBillDetails.FullRowSelect = true;
            this.listViewBillDetails.GridLines = true;
            this.listViewBillDetails.HideSelection = false;
            this.listViewBillDetails.Location = new System.Drawing.Point(6, 24);
            this.listViewBillDetails.Name = "listViewBillDetails";
            this.listViewBillDetails.Size = new System.Drawing.Size(399, 283);
            this.listViewBillDetails.TabIndex = 37;
            this.listViewBillDetails.UseCompatibleStateImageBehavior = false;
            this.listViewBillDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món ăn";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewBillDetails);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 313);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách bàn";
            // 
            // btnCheckoutTable
            // 
            this.btnCheckoutTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckoutTable.Location = new System.Drawing.Point(12, 350);
            this.btnCheckoutTable.Name = "btnCheckoutTable";
            this.btnCheckoutTable.Size = new System.Drawing.Size(106, 23);
            this.btnCheckoutTable.TabIndex = 37;
            this.btnCheckoutTable.Text = "Thanh toán";
            this.btnCheckoutTable.UseVisualStyleBackColor = true;
            this.btnCheckoutTable.Click += new System.EventHandler(this.btnCheckoutTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Chọn món ăn";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(550, 269);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(238, 22);
            this.numericUpDownQuantity.TabIndex = 40;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBill.Location = new System.Drawing.Point(124, 350);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(106, 23);
            this.btnPrintBill.TabIndex = 37;
            this.btnPrintBill.Text = "In hóa đơn";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nhập số lượng";
            // 
            // comboBoxFoods
            // 
            this.comboBoxFoods.FormattingEnabled = true;
            this.comboBoxFoods.Location = new System.Drawing.Point(529, 230);
            this.comboBoxFoods.Name = "comboBoxFoods";
            this.comboBoxFoods.Size = new System.Drawing.Size(259, 24);
            this.comboBoxFoods.TabIndex = 41;
            // 
            // btnAddFoodToBill
            // 
            this.btnAddFoodToBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFoodToBill.Location = new System.Drawing.Point(441, 315);
            this.btnAddFoodToBill.Name = "btnAddFoodToBill";
            this.btnAddFoodToBill.Size = new System.Drawing.Size(106, 23);
            this.btnAddFoodToBill.TabIndex = 37;
            this.btnAddFoodToBill.Text = "Thêm món";
            this.btnAddFoodToBill.UseVisualStyleBackColor = true;
            this.btnAddFoodToBill.Click += new System.EventHandler(this.btnAddFoodToBill_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 399);
            this.Controls.Add(this.comboBoxFoods);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddFoodToBill);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.btnCheckoutTable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdminManagement;
        private System.Windows.Forms.ToolStripMenuItem menuViewAccount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewTables;
        private System.Windows.Forms.ColumnHeader clmnStt;
        private System.Windows.Forms.ColumnHeader clmnTableName;
        private System.Windows.Forms.ColumnHeader clmnStatus;
        private System.Windows.Forms.ColumnHeader cmlnCapacity;
        private System.Windows.Forms.ListView listViewBillDetails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheckoutTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFoods;
        private System.Windows.Forms.Button btnAddFoodToBill;
    }
}