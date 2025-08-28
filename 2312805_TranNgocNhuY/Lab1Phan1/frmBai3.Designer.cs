namespace _2312805_TranNgocNhuY.Lab1
{
	partial class frmBai3
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTuMoi = new System.Windows.Forms.TextBox();
			this.txtNghiaCuaTu = new System.Windows.Forms.TextBox();
			this.btnChonHang = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNghia = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(66, 218);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(268, 180);
			this.listBox1.TabIndex = 4;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(51, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Từ mới:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(51, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Ngĩa của từ:";
			// 
			// txtTuMoi
			// 
			this.txtTuMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTuMoi.Location = new System.Drawing.Point(143, 26);
			this.txtTuMoi.Name = "txtTuMoi";
			this.txtTuMoi.Size = new System.Drawing.Size(191, 22);
			this.txtTuMoi.TabIndex = 5;
			// 
			// txtNghiaCuaTu
			// 
			this.txtNghiaCuaTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNghiaCuaTu.Location = new System.Drawing.Point(143, 73);
			this.txtNghiaCuaTu.Name = "txtNghiaCuaTu";
			this.txtNghiaCuaTu.Size = new System.Drawing.Size(191, 22);
			this.txtNghiaCuaTu.TabIndex = 5;
			// 
			// btnChonHang
			// 
			this.btnChonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChonHang.Location = new System.Drawing.Point(232, 142);
			this.btnChonHang.Name = "btnChonHang";
			this.btnChonHang.Size = new System.Drawing.Size(102, 23);
			this.btnChonHang.TabIndex = 7;
			this.btnChonHang.Text = "Thêm từ mới";
			this.btnChonHang.UseVisualStyleBackColor = true;
			this.btnChonHang.Click += new System.EventHandler(this.btnChonHang_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(140, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "DANH SÁCH TỪ MỚI";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(512, 188);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "NGHĨA CỦA TỪ";
			// 
			// txtNghia
			// 
			this.txtNghia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNghia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNghia.Location = new System.Drawing.Point(438, 218);
			this.txtNghia.Multiline = true;
			this.txtNghia.Name = "txtNghia";
			this.txtNghia.ReadOnly = true;
			this.txtNghia.Size = new System.Drawing.Size(262, 180);
			this.txtNghia.TabIndex = 5;
			// 
			// frmBai3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnChonHang);
			this.Controls.Add(this.txtNghiaCuaTu);
			this.Controls.Add(this.txtNghia);
			this.Controls.Add(this.txtTuMoi);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "frmBai3";
			this.Text = "Từ điển Anh Việt";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTuMoi;
		private System.Windows.Forms.TextBox txtNghiaCuaTu;
		private System.Windows.Forms.Button btnChonHang;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNghia;
	}
}