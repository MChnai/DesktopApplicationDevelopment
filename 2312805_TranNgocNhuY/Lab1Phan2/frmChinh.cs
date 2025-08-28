using _2312805_TranNgocNhuY.Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY.Lab2
{
	public partial class frmChinh : Form
	{
		public frmChinh()
		{
			InitializeComponent();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			new Lab1Phan2.frmBai1().ShowDialog();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			new Lab1Phan2.frmBai2().ShowDialog();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			new Lab1Phan2.frmBai3().ShowDialog();
		}
	}
}
