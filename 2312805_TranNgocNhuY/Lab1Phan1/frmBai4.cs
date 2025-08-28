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
	public partial class frmBai4 : Form
	{
		public frmBai4()
		{
			InitializeComponent();
		}

		private void frmBai4_Load(object sender, EventArgs e)
		{
			Random random = new Random();
			for(int i = 10;  i > 0; i--)
			{
				int num =random.Next(1, 100);
				listBox1.Items.Add(num);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			foreach(int num in listBox1.Items)
			{
				if (num.ToString() == txtNum.Text)
				{
					txtKetQua.Text = "Tìm thấy";
					return;
				}
			}
			txtKetQua.Text = "Không tìm thấy";
		}
	}
}
