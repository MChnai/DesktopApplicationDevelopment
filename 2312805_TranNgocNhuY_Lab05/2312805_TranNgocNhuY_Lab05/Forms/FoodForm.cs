using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab05.Forms
{
    public partial class FoodForm : Form
    {
        SqlDataAdapter sqlDataReader;
        sqlCommands sqlCommands;
        private DataTable foodTable;
        public FoodForm()
        {
            InitializeComponent();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void LoadCategory()
        {
            sqlCommands = new sqlCommands();
            string sqlCommand = "SELECT ID, Name FROM [dbo].[Category]";
            sqlDataReader = sqlCommands.Read_Data_Adapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            sqlDataReader.Fill(dt);
            cbbCategory.DataSource = dt;
            cbbCategory.DisplayMember = "Name";
            sqlDataReader.Dispose();
        }
        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1)
                return;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [dbo].[Food] WHERE FoodCategoryID = @ID";
            if(cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                cmd.CommandText = cmd.CommandText.Replace("@ID", rowView["ID"].ToString());
            }
            else
                cmd.CommandText = cmd.CommandText.Replace("@ID", cbbCategory.SelectedValue.ToString());
            sqlDataReader = sqlCommands.Read_Data_Adapter(cmd.CommandText);
            foodTable = new DataTable();
            sqlDataReader.Fill(foodTable);
            dgvFoodList.DataSource = foodTable;
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
        }
        private void tínhSốLượngĐãBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT sum(Quantity) FROM [dbo].[BillDetail] WHERE FoodID = @ID";
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowview = selectedRow.DataBoundItem as DataRowView;
                cmd.CommandText = cmd.CommandText.Replace("@ID", rowview["ID"].ToString());
                string result = sqlCommands.ExecuteScalar(cmd.CommandText);
                MessageBox.Show("Tổng số lượng món: " + rowview["Name"] + " đã bán là : " + result + rowview["Unit"]);
            }
        }
        private void thêmMónĂnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodInfoForm = new FoodInfoForm();
            foodInfoForm.FormClosed += new FormClosedEventHandler(FoodForm_FormClosed);
            foodInfoForm.Show(this);
        }
        private void cậpNhậtMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(FoodForm_FormClosed);

                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }
        private void FoodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = index;
            this.LoadCategory();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;
            string filterExpression = "Name like '%" + txtName.Text + "%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;
            DataView foodView = new DataView(foodTable,
                                             filterExpression,
                                             sortExpression,
                                             rowStateFilter);

            dgvFoodList.DataSource = foodView;
        }
    }
}
