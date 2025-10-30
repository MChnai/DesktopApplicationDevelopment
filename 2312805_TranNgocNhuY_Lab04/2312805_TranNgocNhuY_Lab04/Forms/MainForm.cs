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
    public partial class MainForm : Form
    {
        SQLStuff sqlStuff;
        SqlDataAdapter sqlDataReader;
        DataTable Table;
        public MainForm()
        {
            InitializeComponent();
        }
        //Main form Load
        private void Load_Data()
        {
            dtgvTables.DataSource = new DataTable();
            sqlStuff = new SQLStuff();
            string sqlCommand = "SELECT ID,Name,Status,Capacity FROM Table01";
            sqlDataReader = sqlStuff.Read_Data_Adapter(sqlCommand);
            Table = new DataTable();
            sqlDataReader.Fill(Table);
            dtgvTables.DataSource = Table;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        //selection index change
        private void dtgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvTables.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgvTables.SelectedRows[0];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtStatus.Text = row.Cells[2].Value.ToString();
                txtCapacity.Text = row.Cells[3].Value.ToString();
            }
        }
        //button save table information
        private int GetID()
        {
            int value = 1;
            foreach (DataRow row in Table.Rows)
            {
                int id = Convert.ToInt32(row["ID"].ToString());
                if (id == value)
                    value++;
            }
            return value;
        }
        private void Add_Table()
        {
            sqlStuff = new SQLStuff();
            SqlCommand cmd = new SqlCommand();
            if (txtName.Text == string.Empty ||
                txtStatus.Text == string.Empty ||
                txtCapacity.Text == string.Empty)
            {
                MessageBox.Show("Please enter enough information for new table");
                return;
            }
            cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Table01] ON INSERT INTO Table01 (ID, Name, Status, Capacity) VALUES (@ID, @Name, @Status, @Capacity)";
            cmd.Parameters.AddWithValue("@ID", GetID());
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
            sqlStuff.Execute(cmd);
            Load_Data();
            MessageBox.Show("Add new table completed");
        }
        private void Update_Table()
        {
            sqlStuff = new SQLStuff();
            SqlCommand cmd = new SqlCommand();
            DataGridViewRow row = dtgvTables.SelectedRows[0];
            if (txtName.Text == string.Empty ||
                txtStatus.Text == string.Empty ||
                txtCapacity.Text == string.Empty)
            {
                MessageBox.Show("Please enter enough information for new table");
                return;
            }
            cmd.CommandText = "UPDATE Table01 SET Name=@Name, Status=@Status, Capacity=@Capacity WHERE ID = @id";
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
            cmd.Parameters.AddWithValue("@id", row.Cells[0].Value.ToString());
            sqlStuff.Execute(cmd);
            Load_Data();
            MessageBox.Show("Update table information completed");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
                Add_Table();
            else
                Update_Table();
        }
        //button clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtCapacity.Text = string.Empty;
            txtName.Text = string.Empty;    
            txtStatus.Text = string.Empty;
        }
        //Delete table
        private void Delete_Table()
        {
            if (dtgvTables.SelectedRows.Count != -1)
            {
                sqlStuff = new SQLStuff();
                SqlCommand cmd = new SqlCommand();
                DataGridViewRow row = dtgvTables.SelectedRows[0];
                cmd.CommandText = "DELETE  FROM [dbo].[Table01] WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(row.Cells[0].Value));
                sqlStuff.Execute(cmd);
                Load_Data();
                MessageBox.Show("Remove table completed");
            }
        }
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            Delete_Table();
        }
        //view bills detail
        private void tsmDanhMuc_Click(object sender, EventArgs e)
        {
            if (dtgvTables.SelectedRows.Count > 0)
            {
                string maBan = dtgvTables.SelectedRows[0].Cells[0].Value.ToString();

                InvoiceList frm = new InvoiceList(maBan);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để xem danh mục hóa đơn!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Bills diary
        private void tsmNhatKy_Click(object sender, EventArgs e)
        {
            if (dtgvTables.SelectedRows.Count > 0)
            {
                string maBan = dtgvTables.SelectedRows[0].Cells[0].Value.ToString();

                Dairy frm = new Dairy(maBan);
                frm.ShowDialog();
            }
        }
    }
}
