namespace _2312805_TranNgocNhuY.Lab1
{
	partial class frmBai2
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
			this.lblDanhSachHannghoa = new System.Windows.Forms.Panel();
			this.btnChonHang = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnTinhTien = new System.Windows.Forms.Button();
			this.btnBoHang = new System.Windows.Forms.Button();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.lblThanhTIen = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblDanhSachHannghoa.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblDanhSachHannghoa
			// 
			this.lblDanhSachHannghoa.Controls.Add(this.btnChonHang);
			this.lblDanhSachHannghoa.Controls.Add(this.listBox1);
			this.lblDanhSachHannghoa.Controls.Add(this.label1);
			this.lblDanhSachHannghoa.Location = new System.Drawing.Point(33, 52);
			this.lblDanhSachHannghoa.Name = "lblDanhSachHannghoa";
			this.lblDanhSachHannghoa.Size = new System.Drawing.Size(339, 347);
			this.lblDanhSachHannghoa.TabIndex = 0;
			// 
			// btnChonHang
			// 
			this.btnChonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChonHang.Location = new System.Drawing.Point(220, 83);
			this.btnChonHang.Name = "btnChonHang";
			this.btnChonHang.Size = new System.Drawing.Size(102, 23);
			this.btnChonHang.TabIndex = 3;
			this.btnChonHang.Text = "chọn hàng >";
			this.btnChonHang.UseVisualStyleBackColor = true;
			this.btnChonHang.Click += new System.EventHandler(this.btnChonHang_Click);
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Items.AddRange(new object[] {
            "Chuột",
            "Bàn phím",
            "Máy in",
            "USB Kingmax"});
			this.listBox1.Location = new System.Drawing.Point(21, 51);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(183, 84);
			this.listBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(97, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Danh sách hàng hóa";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnTinhTien);
			this.panel1.Controls.Add(this.btnBoHang);
			this.panel1.Controls.Add(this.listBox2);
			this.panel1.Controls.Add(this.lblThanhTIen);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(378, 52);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(355, 347);
			this.panel1.TabIndex = 0;
			// 
			// btnTinhTien
			// 
			this.btnTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTinhTien.Location = new System.Drawing.Point(195, 186);
			this.btnTinhTien.Name = "btnTinhTien";
			this.btnTinhTien.Size = new System.Drawing.Size(102, 23);
			this.btnTinhTien.TabIndex = 3;
			this.btnTinhTien.Text = "Tính tiền";
			this.btnTinhTien.UseVisualStyleBackColor = true;
			this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
			// 
			// btnBoHang
			// 
			this.btnBoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBoHang.Location = new System.Drawing.Point(24, 83);
			this.btnBoHang.Name = "btnBoHang";
			this.btnBoHang.Size = new System.Drawing.Size(102, 23);
			this.btnBoHang.TabIndex = 3;
			this.btnBoHang.Text = "< bỏ hàng";
			this.btnBoHang.UseVisualStyleBackColor = true;
			this.btnBoHang.Click += new System.EventHandler(this.btnBoHang_Click);
			// 
			// listBox2
			// 
			this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 16;
			this.listBox2.Items.AddRange(new object[] {
            ""});
			this.listBox2.Location = new System.Drawing.Point(155, 51);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(183, 84);
			this.listBox2.TabIndex = 2;
			// 
			// lblThanhTIen
			// 
			this.lblThanhTIen.AutoSize = true;
			this.lblThanhTIen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblThanhTIen.ForeColor = System.Drawing.Color.Blue;
			this.lblThanhTIen.Location = new System.Drawing.Point(187, 248);
			this.lblThanhTIen.Name = "lblThanhTIen";
			this.lblThanhTIen.Size = new System.Drawing.Size(54, 16);
			this.lblThanhTIen.TabIndex = 0;
			this.lblThanhTIen.Text = "0 đồng";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(30, 248);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(151, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tổng tiền thanh toán:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(97, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(190, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Các mặt hàng khách hàng mua";
			// 
			// frmBai2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblDanhSachHannghoa);
			this.Name = "frmBai2";
			this.Text = "Mua bán hàng";
			this.lblDanhSachHannghoa.ResumeLayout(false);
			this.lblDanhSachHannghoa.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel lblDanhSachHannghoa;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnChonHang;
		private System.Windows.Forms.Button btnTinhTien;
		private System.Windows.Forms.Button btnBoHang;
		private System.Windows.Forms.Label lblThanhTIen;
		private System.Windows.Forms.Label label3;
	}
}