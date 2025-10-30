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

namespace _2312805_TranNgocNhuY_Lab05.Forms
{
    public partial class FoodInfoForm : Form
    {
        SqlDataAdapter sqlDataAdapter;
        sqlCommands sqlcommand;
        SqlConnection sqlConnection;
        public FoodInfoForm()
        {
            InitializeComponent();
        }
        private void ResetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCategoryName.ResetText();
            dudPrice.ResetText();
        }
        private void IniValues()
        {
            sqlcommand = new sqlCommands();
            sqlConnection = sqlcommand.Conmection();
            string command = "SELECT ID, Name FROM [dbo].[Category]";
            sqlDataAdapter = sqlcommand.Read_Data_Adapter(command);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Category");
            cbbCategoryName.DataSource = dataSet.Tables["Category"];
            cbbCategoryName.DisplayMember = "Name";
            cbbCategoryName.ValueMember = "ID";
        }
        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            IniValues();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "EXECUTE InsertFood @id OUTPUT, @name, @unit, @foodCategoryID, @price, @notes";
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output; 
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = txtName.Text;
            cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100).Value = txtUnit.Text;
            cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int).Value = cbbCategoryName.SelectedValue;
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = dudPrice.Text;
            cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000).Value = txtNotes.Text;

            try
            {
                sqlConnection.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    // Now this should successfully retrieve the new ID
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Successfully adding new food. Food_ID = " + foodID, "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Adding food failed");
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL_Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                dudPrice.Text = rowView["Price"].ToString();

                cbbCategoryName.SelectedIndex = -1;
                for (int index = 0; index < cbbCategoryName.Items.Count; index++)
                {
                    DataRowView cat = cbbCategoryName.Items[index] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCategoryName.SelectedIndex = index;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);
                cmd.Parameters["@id"].Value = int.Parse(txtID.Text);
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryID"].Value = cbbCategoryName.SelectedValue;
                cmd.Parameters["@price"].Value = dudPrice.Text; 
                cmd.Parameters["@notes"].Value = txtNotes.Text;
                sqlConnection.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully updating food", "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Updating food failed");
                }  
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryInfoForm categoryInfoForm = new CategoryInfoForm();
            categoryInfoForm.FormClosed += new FormClosedEventHandler(FoodInfoForm_FormClosed);
            categoryInfoForm.Show(this);
        }
        private void FoodInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategoryName.SelectedIndex;
            cbbCategoryName.SelectedIndex = index;
            this.IniValues();
        }
    }
}
