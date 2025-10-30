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
    public partial class FoodForm : Form
    {
        SQLStuff sqlStuff;
        SqlDataAdapter sqlDataReader;
        public string ID { get; set; }
        public FoodForm()
        {
            InitializeComponent();
        }
        //load food category
        public void LoadForm()
        {
            dtgrvFood.DataSource = new DataTable();
            sqlStuff = new SQLStuff();
            string sqlCommand = "SELECT * FROM Food WHERE FoodCategoryID = " + ID;
            sqlDataReader = sqlStuff.Read_Data_Adapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            sqlDataReader.Fill(dt);
            dtgrvFood.DataSource = dt;
            sqlDataReader.Dispose();
            dtgrvFood.Columns[0].ReadOnly = true;
        }
        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        //button delete food from category
        private void Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Food WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);
            sqlStuff.Execute(cmd);
            LoadForm();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgrvFood.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgrvFood.SelectedRows[0];
                object IdValue = selectedRow.Cells[0].Value;
                int value = Convert.ToInt32(IdValue);
                Delete(value);
            }
        }
        //button save (update food or add new food)
        private bool CheckInformation(DataGridViewRow row)
        {
            if (row.Cells[1].Value == null ||
                row.Cells[2].Value == null ||
                row.Cells[3].Value == null ||
                row.Cells[4].Value == null ||
                row.Cells[5].Value == null )
                return false;
            return true;
        }
        private void Add_New_Food(SqlCommand cmd)
        {
            sqlStuff.Execute(cmd);
            LoadForm();
        }
        private void Update(SqlCommand cmd)
        {
            sqlStuff.Execute(cmd);
            LoadForm();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtgrvFood.SelectedRows.Count > 0)
            {
                sqlStuff = new SQLStuff();
                SqlCommand cmd = new SqlCommand();
                DataGridViewRow row = dtgrvFood.SelectedRows[0];
                int index = dtgrvFood.SelectedRows[0].Index + 1;
                if (!CheckInformation(row))
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin trước khi lưu");
                    return;
                }
                if(row.Cells[0].Value.ToString() == string.Empty)
                {
                    cmd.CommandText = "INSERT INTO Food ([Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (@Name, @Unit, @FoodCategoryID, @Price, @Notes)";
                    cmd.Parameters.AddWithValue("@Name", Convert.ToString(row.Cells[1].Value));
                    cmd.Parameters.AddWithValue("@Unit", Convert.ToString(row.Cells[2].Value));
                    cmd.Parameters.AddWithValue("@FoodCategoryID", Convert.ToInt32(row.Cells[3].Value));
                    cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(row.Cells[4].Value));
                    cmd.Parameters.AddWithValue("@Notes", Convert.ToString(row.Cells[5].Value));
                    Add_New_Food(cmd);
                }
                else
                {
                    cmd.CommandText = "UPDATE Food SET Name = @Name, Unit = @Unit, FoodCategoryID = @FoodCategoryID, Price = @Price, Notes = @Notes WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@Name", Convert.ToString(row.Cells[1].Value));
                    cmd.Parameters.AddWithValue("@Unit", Convert.ToString(row.Cells[2].Value));
                    cmd.Parameters.AddWithValue("@FoodCategoryID", Convert.ToInt32(row.Cells[3].Value));
                    cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(row.Cells[4].Value));
                    cmd.Parameters.AddWithValue("@Notes", Convert.ToString(row.Cells[5].Value));
                    Update(cmd);
                }         
            }
        }
    }
}
