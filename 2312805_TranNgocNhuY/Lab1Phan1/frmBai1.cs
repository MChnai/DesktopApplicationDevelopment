using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY.Lab1
{
	public partial class frmBai1 : Form
	{
		public frmBai1()
		{
			InitializeComponent();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			txtDonGia.Text = "22000";
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			txtDonGia.Text = "21000";
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			txtDonGia.Text = "20000";
		}

		private void btnTinhTien_Click(object sender, EventArgs e)
		{
			txtThanhTien.Text = Convert.ToString(int.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text));
		}
	}
}
