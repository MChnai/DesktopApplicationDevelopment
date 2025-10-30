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
    public partial class CategoryInfoForm : Form
    {
        SqlConnection sqlConnection;
        public CategoryInfoForm()
        {
            InitializeComponent();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if(txtName.Text == string.Empty ||
                nudType.Text == string.Empty)
            {
                MessageBox.Show("Please enter enogh information!!!");
                return;
            }
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "EXECUTE InsertCategory @id OUTPUT, @name, @Type";
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = txtName.Text;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 100).Value = nudType.Text;

            try
            {
                sqlConnection.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    // Now this should successfully retrieve the new ID
                    string CategoryID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Successfully adding new category. Category_ID = " + CategoryID, "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Adding category failed");
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
        private void CategoryInfoForm_Load(object sender, EventArgs e)
        {
            sqlCommands cmd = new sqlCommands();
            sqlConnection = cmd.Conmection();
        }
    }
}
