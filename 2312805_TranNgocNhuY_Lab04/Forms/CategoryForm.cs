using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab04.Forms
{
    public partial class CategoryForm : Form
    {
        SQLStuff sqlStuff;
        SqlDataReader sqlDataReader;
        public CategoryForm()
        {
            InitializeComponent();
        }
        //button Load category List
        private void btnGet_Click(object sender, EventArgs e)
        {
            sqlStuff = new SQLStuff();
            sqlDataReader = sqlStuff.Read("SELECT * FROM Category");
            Display(sqlDataReader);
            sqlDataReader.Close();
        }
        private void Display(SqlDataReader reader)
        {
            lvCategory.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
                lvCategory.Items.Add(item);
            }
        }
        //button add new category
        private bool CheckInformation()
        {
            if (txtName.Text == string.Empty || txtType.Text == string.Empty)
                return false;
            return true;
        }
        private void Clear()
        {
            txtID.ResetText();
            txtName.ResetText();
            txtType.ResetText();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInformation())
            {
                MessageBox.Show("Your informaiton isn't enough. Please enter all needed information above!!!");
                return;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Category ([Name], [Type]) VALUES (@Name, @Type)";
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Type", txtType.Text);
            sqlStuff.Execute(cmd);
            MessageBox.Show("Thêm món ăn thành công");
            btnGet.PerformClick();
            Clear();
        }
        //button update category
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!CheckInformation())
            {
                MessageBox.Show("Your informaiton isn't enough. Please enter all needed information above!!!");
                return;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Category SET Name = @Name, Type = @Type WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Type", txtType.Text);
            sqlStuff.Execute(cmd);
            btnGet.PerformClick();
            MessageBox.Show("Cập nhật thông tin món ăn thành công");
            Clear();
        }
        //Select index change in list view category
        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvCategory.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtType.Text = item.SubItems[2].Text;
            }
        }
        //button delete category
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Can't find category ID to delete!!!");
                return;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Category WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            sqlStuff.Execute(cmd);
            btnGet.PerformClick();
            MessageBox.Show("Xóa món ăn thành công");
            Clear();
        }
        //context menu script delete
        private void ctmsDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
                btnDelete.PerformClick();
        }
        //context menu scipt view food category
        private void ctmsView_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty)
            {
                Forms.FoodForm foodForm = new FoodForm();
                foodForm.ID = txtType.Text;
                foodForm.ShowDialog();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtType.Text = string.Empty;
        }
    }
}
