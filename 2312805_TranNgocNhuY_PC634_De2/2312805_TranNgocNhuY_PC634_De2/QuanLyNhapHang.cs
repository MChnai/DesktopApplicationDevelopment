using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_PC634
{
	public partial class QuanLyNhapHang : Form
	{
		public string Name {  get; set; }
		public QuanLyNhapHang()
		{
			InitializeComponent();
		}

		private void QuanLyNhapHang_Load(object sender, EventArgs e)
		{
			cbxName.Text = Name;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			QuanLyNhaCungCap form = new QuanLyNhaCungCap();
			form.ShowDialog();
			this.Close();
		}
	}
}
