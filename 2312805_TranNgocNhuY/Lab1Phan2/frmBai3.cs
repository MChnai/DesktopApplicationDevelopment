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
	public partial class frmBai3 : Form
	{
		public frmBai3()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TinhToan tt = new TinhToan();
			if (rbtnTongAvaB.Checked)
				txtKetQua.Text = tt.CongHaiSo(Convert.ToInt32(txta.Text), Convert.ToInt32(txtb.Text)).ToString();
			else
				txtKetQua.Text = tt.TongDaySo(Convert.ToInt32(txtn.Text)).ToString();
		}
	}
}
