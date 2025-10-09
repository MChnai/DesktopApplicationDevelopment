using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2312805_TranNgocNhuY_PC634
{
	public partial class QuanLyNhaCungCap : Form
	{
		ProducerManagement producers;
		public QuanLyNhaCungCap()
		{
			InitializeComponent();
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			txtID.Text = string.Empty;
			txtName.Text = string.Empty;
			mtxtPhone.Text = string.Empty;
			mtxtPhone.Mask = "___________";
			txtAddress.Text = string.Empty;
			btnExport.Text = string.Empty;
		}
		private void dtgvProducers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			DataGridViewRow row = dtgvProducers.Rows[index];
			txtID.Text  = row.Cells[0].Value.ToString();
			txtName.Text = row.Cells[1].Value.ToString();
			txtAddress.Text = row.Cells[2].Value.ToString();
			mtxtPhone.Mask = string.Empty;
			mtxtPhone.Text = row.Cells[3].Value.ToString();
			btnExport.Text = row.Cells[4].Value.ToString();
		}
		private void QuanLyNhaCungCap_Load(object sender, EventArgs e)
		{
			producers = new ProducerManagement();
			producers.Read_TXT("Text.txt");
			Display(producers.list);
		}
		private void Display(List<Producer> list)
		{
			dtgvProducers.DataSource = null;
			dtgvProducers.DataSource = list;
		}
		private Producer Get_ID(Producer producer)
		{
			int ID = 1;
			foreach(Producer pro in producers.list)
			{
				if (pro.ID == ID)
					ID++;
			}
			producer.ID = ID;
			return producer;
		}
		private void Add_New_Producer()
		{
			Producer producer = new Producer();
			producer.Name = txtName.Text;
			producer.Address = txtAddress.Text;
			producer.PhoneNum = mtxtPhone.Text;
			producer.Description = btnExport.Text;
			producer = Get_ID(producer);
			producers.Add(producer);
			producers.Save_To_File("Z:\\2312805_TranNgocNhuY_PC634\\2312805_TranNgocNhuY_PC634\\Text.txt");
			Display(producers.list);
		}
		private void Update_Producer()
		{
			foreach(Producer producer in producers.list)
				if(producer.ID == Convert.ToInt32(txtID.Text))
				{
					producer.Name = txtName.Text;
					producer.Address = txtAddress.Text;
					producer.PhoneNum = mtxtPhone.Text;
					producer.Description = btnExport.Text;
					Display(producers.list);
					producers.Save_To_File("Z:\\2312805_TranNgocNhuY_PC634\\2312805_TranNgocNhuY_PC634\\Text.txt");
					return;
				}
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			if(txtID.Text == string.Empty)
				Add_New_Producer();
			else
				Update_Producer();
		}
		private void mtxtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
			mtxtPhone.Mask = string.Empty;
		}
		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			if(rbtnName.Checked)
			{
				Display(producers.Find_Name(txtSearch.Text));
			}
			else
			{
				Display(producers.Find_Phone(txtSearch.Text));
			}
		}
		private void s_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML FILES (*.xml)| *.xml";
			saveFileDialog.Title = "Export XML";
			saveFileDialog.FileName = "ExportXMl";
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				XElement root = new XElement("Root");
				List<string> list = new List<string>();
				list.Add("ID");
				list.Add("Name");
				list.Add("Address");
				list.Add("Phone");
				list.Add("Description");
				foreach(Producer producer in producers.list)
				{
					XElement data = new XElement("Data");
					data.Add(new XElement(list[0], producer.ID));
					data.Add(new XElement(list[1], producer.Name));
					data.Add(new XElement(list[2], producer.Address));
					data.Add(new XElement(list[3], producer.PhoneNum));
					data.Add(new XElement(list[4], producer.Description));
					root.Add(data);
				}
				XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
				doc.Save(saveFileDialog.FileName);
				MessageBox.Show("Export file XML complete!!!");
			}
		}
		private void dtgvProducers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			DataGridViewRow row = dtgvProducers.Rows[index];
			QuanLyNhapHang form = new QuanLyNhapHang();
			form.Name = row.Cells[1].Value.ToString();
			form.ShowDialog();
			this.Close();
		}
	}
}
