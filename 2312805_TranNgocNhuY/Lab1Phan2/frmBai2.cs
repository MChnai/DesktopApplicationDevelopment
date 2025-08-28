using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY.Lab1Phan2
{
	public partial class frmBai2 : Form
	{
		public frmBai2()
		{
			InitializeComponent();
		}

		private void cbxTenHang_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch(cbxTenHang.Text)
			{
				case "Chuột":
					txtDonGia.Text = "100000";
					break;
				case "Máy in":
					txtDonGia.Text = "2000000";
					break;
				case "Bàn phím":
					txtDonGia.Text = "150000";
					break;
			}
		}

		private void btnTinhTien_Click(object sender, EventArgs e)
		{
			if (rbtnChuyenKhoan.Checked)
				txtThanhTien.Text = (Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtDonGia.Text) * 0.95).ToString();
			else
				txtThanhTien.Text = (Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtDonGia.Text)).ToString();
		}
	}
}
