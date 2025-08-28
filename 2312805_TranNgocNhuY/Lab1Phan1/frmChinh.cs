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
	public partial class frmChinh : Form
	{
		public frmChinh()
		{
			InitializeComponent();
		}

		private void tsmBai1_Click(object sender, EventArgs e)
		{
			new frmBai1().ShowDialog();
		}

		private void tsmBai2_Click(object sender, EventArgs e)
		{
			new frmBai2().ShowDialog();
		}

		private void tsmBai3_Click(object sender, EventArgs e)
		{
			new frmBai3().ShowDialog();
		}

		private void bài4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new frmBai4().ShowDialog();
		}
	}
}
