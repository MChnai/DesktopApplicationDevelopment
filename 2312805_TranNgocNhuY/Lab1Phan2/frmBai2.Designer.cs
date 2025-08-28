namespace _2312805_TranNgocNhuY.Lab1Phan2
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxTenHang = new System.Windows.Forms.ComboBox();
			this.txtDonGia = new System.Windows.Forms.TextBox();
			this.txtSoLuong = new System.Windows.Forms.TextBox();
			this.grxHinhThuc = new System.Windows.Forms.GroupBox();
			this.rbtnChuyenKhoan = new System.Windows.Forms.RadioButton();
			this.rbtnTienMat = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtThanhTien = new System.Windows.Forms.Label();
			this.btnTinhTien = new System.Windows.Forms.Button();
			this.grxHinhThuc.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(46, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên hàng:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(46, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Đơn giá:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(46, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Số lượng:";
			// 
			// cbxTenHang
			// 
			this.cbxTenHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxTenHang.FormattingEnabled = true;
			this.cbxTenHang.Items.AddRange(new object[] {
            "Chuột",
            "Bàn phím",
            "Máy in"});
			this.cbxTenHang.Location = new System.Drawing.Point(134, 26);
			this.cbxTenHang.Name = "cbxTenHang";
			this.cbxTenHang.Size = new System.Drawing.Size(181, 24);
			this.cbxTenHang.TabIndex = 1;
			this.cbxTenHang.SelectedIndexChanged += new System.EventHandler(this.cbxTenHang_SelectedIndexChanged);
			// 
			// txtDonGia
			// 
			this.txtDonGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDonGia.Location = new System.Drawing.Point(134, 57);
			this.txtDonGia.Name = "txtDonGia";
			this.txtDonGia.Size = new System.Drawing.Size(181, 22);
			this.txtDonGia.TabIndex = 2;
			// 
			// txtSoLuong
			// 
			this.txtSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSoLuong.Location = new System.Drawing.Point(134, 92);
			this.txtSoLuong.Name = "txtSoLuong";
			this.txtSoLuong.Size = new System.Drawing.Size(181, 22);
			this.txtSoLuong.TabIndex = 2;
			// 
			// grxHinhThuc
			// 
			this.grxHinhThuc.Controls.Add(this.rbtnTienMat);
			this.grxHinhThuc.Controls.Add(this.rbtnChuyenKhoan);
			this.grxHinhThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grxHinhThuc.Location = new System.Drawing.Point(134, 131);
			this.grxHinhThuc.Name = "grxHinhThuc";
			this.grxHinhThuc.Size = new System.Drawing.Size(181, 100);
			this.grxHinhThuc.TabIndex = 3;
			this.grxHinhThuc.TabStop = false;
			this.grxHinhThuc.Text = "Hình thức thanh toán";
			// 
			// rbtnChuyenKhoan
			// 
			this.rbtnChuyenKhoan.AutoSize = true;
			this.rbtnChuyenKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtnChuyenKhoan.Location = new System.Drawing.Point(6, 28);
			this.rbtnChuyenKhoan.Name = "rbtnChuyenKhoan";
			this.rbtnChuyenKhoan.Size = new System.Drawing.Size(102, 20);
			this.rbtnChuyenKhoan.TabIndex = 0;
			this.rbtnChuyenKhoan.TabStop = true;
			this.rbtnChuyenKhoan.Text = "Chuyển khản";
			this.rbtnChuyenKhoan.UseVisualStyleBackColor = true;
			// 
			// rbtnTienMat
			// 
			this.rbtnTienMat.AutoSize = true;
			this.rbtnTienMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtnTienMat.Location = new System.Drawing.Point(7, 63);
			this.rbtnTienMat.Name = "rbtnTienMat";
			this.rbtnTienMat.Size = new System.Drawing.Size(77, 20);
			this.rbtnTienMat.TabIndex = 0;
			this.rbtnTienMat.TabStop = true;
			this.rbtnTienMat.Text = "Tiền mặt";
			this.rbtnTienMat.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(46, 271);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(115, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Số tiền thanh toán:";
			// 
			// txtThanhTien
			// 
			this.txtThanhTien.AutoSize = true;
			this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtThanhTien.Location = new System.Drawing.Point(164, 271);
			this.txtThanhTien.Name = "txtThanhTien";
			this.txtThanhTien.Size = new System.Drawing.Size(14, 16);
			this.txtThanhTien.TabIndex = 0;
			this.txtThanhTien.Text = "0";
			// 
			// btnTinhTien
			// 
			this.btnTinhTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnTinhTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTinhTien.Location = new System.Drawing.Point(240, 237);
			this.btnTinhTien.Name = "btnTinhTien";
			this.btnTinhTien.Size = new System.Drawing.Size(75, 23);
			this.btnTinhTien.TabIndex = 4;
			this.btnTinhTien.Text = "Tính tiền";
			this.btnTinhTien.UseVisualStyleBackColor = false;
			this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
			// 
			// frmBai2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 369);
			this.Controls.Add(this.btnTinhTien);
			this.Controls.Add(this.grxHinhThuc);
			this.Controls.Add(this.txtSoLuong);
			this.Controls.Add(this.txtDonGia);
			this.Controls.Add(this.cbxTenHang);
			this.Controls.Add(this.txtThanhTien);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmBai2";
			this.Text = "Bài 2";
			this.grxHinhThuc.ResumeLayout(false);
			this.grxHinhThuc.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxTenHang;
		private System.Windows.Forms.TextBox txtDonGia;
		private System.Windows.Forms.TextBox txtSoLuong;
		private System.Windows.Forms.GroupBox grxHinhThuc;
		private System.Windows.Forms.RadioButton rbtnTienMat;
		private System.Windows.Forms.RadioButton rbtnChuyenKhoan;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label txtThanhTien;
		private System.Windows.Forms.Button btnTinhTien;
	}
}