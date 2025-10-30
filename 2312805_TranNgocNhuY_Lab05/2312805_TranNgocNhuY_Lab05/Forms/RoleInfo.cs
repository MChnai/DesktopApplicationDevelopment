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
    public partial class RoleInfo : Form
    {
        DataTable RoleTable;
        SqlConnection conn;
        SqlDataAdapter sqlDataReader;
        sqlCommands commands;
        public string accountName;
        public string role;
        public RoleInfo()
        {
            InitializeComponent();
        }
        private bool checkInfo()
        {
            if (txtName.Text == string.Empty ||
               txtPath.Text == string.Empty ||
               txtNote.Text == string.Empty)
                return false;
            return true;
        }
        private int CreateID()
        {
            int id = 1;
            foreach (DataRow row in RoleTable.Rows)
                if (row["ID"].ToString() == id.ToString())
                    id++;
            return id;
        }
        private void loadRoleTable()
        {
            dgvRoleList.DataSource = new DataTable();
            string sqlCommand = "SELECT * FROM Role";
            sqlDataReader = commands.Read_Data_Adapter(sqlCommand);
            RoleTable = new DataTable("Role");
            sqlDataReader.Fill(RoleTable);
            dgvRoleList.DataSource = RoleTable;
            sqlDataReader.Dispose();
        }
        private void RoleCheck()
        {
            foreach (DataGridViewRow dgvr in dgvRoleList.Rows)
            {
                if (dgvr.Cells[1].Value is null)
                    return;
                if (dgvr.Cells[3].Value.ToString() == role)
                    dgvr.Cells[4].Value = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!checkInfo())
            {
                MessageBox.Show("Please enter enough information!!!");
                return;
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET IDENTITY_INSERT [dbo].[Table01] OFF " +
                "SET IDENTITY_INSERT [dbo].[Role] ON " + 
                "EXECUTE InsertRole @ID, @Name, @Path, @Notes";
            txtID.Text = CreateID().ToString();
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = CreateID();
            cmd.Parameters.Add("Name", SqlDbType.NVarChar, 100).Value = txtName.Text;
            cmd.Parameters.Add("@Path", SqlDbType.NVarChar, 100).Value = txtPath.Text;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 100).Value = txtNote.Text;

            try
            {
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully adding new role");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Adding role failed");
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
        private void RoleInfo_Load(object sender, EventArgs e)
        {
            commands = new sqlCommands();
            conn = commands.Conmection();
            loadRoleTable();
            txtaccountName.Text = this.accountName;

            commands = new sqlCommands();
            conn = commands.Conmection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE [dbo].[GetRoleInfo]";
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            RoleTable = new DataTable();
            adapter.Fill(RoleTable);
            conn.Close();

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Chọn";
            checkColumn.ReadOnly = true;
            dgvRoleList.Columns.Insert(4, checkColumn);
            RoleCheck();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkInfo())
            {
                MessageBox.Show("Please enter enough information!!!");
                return;
            }
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Cannot update role without a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE UpdateRole @ID, @Name, @Path, @Notes";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txtID.Text; 
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = txtName.Text;
            cmd.Parameters.Add("@Path", SqlDbType.NVarChar, 100).Value = txtPath.Text;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 100).Value = txtNote.Text;

            try
            {
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully updating role");
                    this.ResetText();               
                }
                else
                {
                    MessageBox.Show("Updating role failed. Role ID may not exist.");
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
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void dgvRoleList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoleList.SelectedRows.Count > 0)
            {
                int index = dgvRoleList.SelectedRows.Count;
                DataGridViewRow row = dgvRoleList.SelectedRows[0];

                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPath.Text = row.Cells[2].Value.ToString();
                txtNote.Text = row.Cells[3].Value.ToString();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
