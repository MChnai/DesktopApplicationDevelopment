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
	public partial class frmBai3 : Form
	{
		List<string> list = new List<string>();
		public frmBai3()
		{
			InitializeComponent();
		}

		private void btnChonHang_Click(object sender, EventArgs e)
		{
			listBox1.Items.Add(txtTuMoi.Text);
			list.Add(txtNghiaCuaTu.Text);
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtNghia.Text = list[Convert.ToInt32(listBox1.SelectedIndex)];
		}
	}
}
