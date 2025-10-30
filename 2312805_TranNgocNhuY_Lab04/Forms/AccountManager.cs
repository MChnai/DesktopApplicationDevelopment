using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2312805_TranNgocNhuY_Lab04.Forms
{
    public partial class AccountManager : Form
    {
        SqlConnection conn;
        SQLStuff command;
        DataTable accountTable;
        DataTable result;
        DataTable RoleTable;
        public AccountManager()
        {
            InitializeComponent();
        }
        //load account list
        private void LoadRole()
        {
            command = new SQLStuff();
            conn = command.Conmection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE [dbo].[GetRoleInfo]";
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            RoleTable = new DataTable();
            adapter.Fill(RoleTable);

            foreach(DataRow row in RoleTable.Rows)
            {
                string note = row["Notes"].ToString();
                cboGroup.Items.Add(note);
            }

            cboGroup.Items.Insert(0, "All");
            conn.Close();
        }
        private void LoadAccount()
        {
            command = new SQLStuff();
            conn = command.Conmection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE [dbo].[GetAccountInfo]";
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            accountTable = new DataTable();
            adapter.Fill(accountTable);
            dtgvAccount.DataSource = accountTable;
            conn.Close();
            result = new DataTable();
            result = accountTable;
        }
        private void AccountManager_Load(object sender, EventArgs e)
        {
            LoadAccount();
            LoadRole();
        }
        //button add new account
        private string GetRoleName()
        {
            DataGridViewRow dgvrow = dtgvAccount.SelectedRows[0];
            foreach (DataRow row in RoleTable.Rows)
                if (row["ID"].ToString() == Convert.ToString(dgvrow.Cells[6].Value))
                    return row["Notes"].ToString();
            return string.Empty;
        }
        private bool CheckIDAccount(string id, string accountName)
        {
            foreach (DataRow row in accountTable.Rows)
                if (row[0].ToString() == accountName && row[6].ToString() == id)
                    return false;
            return true;
        }
        private void Add_New_Account()
        {
            if (dtgvAccount.SelectedRows.Count != -1)
            {
                command = new SQLStuff();
                SqlCommand cmd = new SqlCommand();
                DataGridViewRow row = dtgvAccount.SelectedRows[0];
                if (row.Cells[0].Value == null ||
                    row.Cells[1].Value == null ||
                    row.Cells[2].Value == null ||
                    row.Cells[4].Value == null ||
                    row.Cells[3].Value == null)
                {
                    MessageBox.Show("Please enter enough information for new account (AccountName, Password, FullName, Email, Tell)");
                    return;
                }
                if (!CheckIDAccount(row.Cells[6].Value.ToString(), row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Đã tồn tại vai trò cho account");
                    return;
                }
                cmd.CommandText = "EXECUTE InsertAccount @AccountName, @Password, @FullName, @Mail, @Tell, @RoleID, @Activated, @RoleNotes";
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[0].Value);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[1].Value);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[2].Value);
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[3].Value);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[4].Value);
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                cmd.Parameters.AddWithValue("@Activated ", 1);
                cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = GetRoleName();

                command.Execute(cmd);
                LoadAccount();
                MessageBox.Show("Add new account completed");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_New_Account();
        }
        //button update account information
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dtgvAccount.SelectedRows.Count != -1)
            {
                command = new SQLStuff();
                SqlCommand cmd = new SqlCommand();
                DataGridViewRow row = dtgvAccount.SelectedRows[0];
                if (row.Cells[0].Value == null ||
                    row.Cells[1].Value == null ||
                    row.Cells[2].Value == null ||
                    row.Cells[4].Value == null ||
                    row.Cells[3].Value == null)
                {
                    MessageBox.Show("Please enter enough information for new account (AccountName, Password, FullName, Email, Tell)");
                    return;
                }
                cmd.CommandText = "EXECUTE UpdateAccountLab04 @AccountName, @Password, @FullName, @Mail, @Tell, @Activated, @RoleID, @RoleNotes";
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[0].Value);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[1].Value);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[2].Value);
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[3].Value);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[4].Value);
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                if (row.Cells[8].Value.ToString() == "True")
                    cmd.Parameters.AddWithValue("@Activated", 1);
                else
                    cmd.Parameters.AddWithValue("@Activated", 0);
                cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = GetRoleName();

                command.Execute(cmd);
                LoadAccount();
                MessageBox.Show("Insert account information completed");
            }
        }
        //button reset password for account
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (dtgvAccount.SelectedRows.Count != -1)
            {
                command = new SQLStuff();
                SqlCommand cmd = new SqlCommand();
                DataGridViewRow row = dtgvAccount.SelectedRows[0];
                if (row.Cells[0].Value == null ||
                    row.Cells[1].Value == null ||
                    row.Cells[2].Value == null ||
                    row.Cells[4].Value == null ||
                    row.Cells[3].Value == null)
                {
                    MessageBox.Show("Please enter enough information for new account (AccountName, Password, FullName, Email, Tell)");
                    return;
                }
                cmd.CommandText = "EXECUTE UpdateAccountLab04 @AccountName, @Password, @FullName, @Mail, @Tell, @Activated, @RoleID, @RoleNotes";
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[0].Value);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = "123456";
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[2].Value);
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[3].Value);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[4].Value);
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                if (row.Cells[8].Value.ToString() == "True")
                    cmd.Parameters.AddWithValue("@Activated", 1);
                else
                    cmd.Parameters.AddWithValue("@Activated", 0);
                cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = GetRoleName();

                command.Execute(cmd);
                LoadAccount();
                MessageBox.Show("Update account information completed");
            }
        }
        //filter by role of accounts
        private DataTable CreateAccountTable(DataTable dtAccount)
        {
            dtAccount.Columns.Add("AccountName", typeof(string)); 
            dtAccount.Columns.Add("Password", typeof(string));    
            dtAccount.Columns.Add("FullName", typeof(string));   
            dtAccount.Columns.Add("Email", typeof(string));     
            dtAccount.Columns.Add("Tell", typeof(string));       
            dtAccount.Columns.Add("DateCreated", typeof(DateTime)); 

            dtAccount.Columns.Add("RoleID", typeof(int));         
            dtAccount.Columns.Add("Actived", typeof(bool));       
            dtAccount.Columns.Add("Notes", typeof(string));
            return dtAccount;
        }
        private void CopydataRow(ref DataRow dr1, DataRow dr2)
        {
            foreach (DataColumn column in dr1.Table.Columns)
            {
                string columnName = column.ColumnName;
                if (dr1.Table.Columns.Contains(columnName))
                    dr1[columnName] = dr2[columnName];
            }
        }
        private void filterByRole(string role)
        {
            DataTable dt = new DataTable();
            dt = CreateAccountTable(dt);
            DataRow dr;

            foreach (DataRow row in accountTable.Rows)
            {
                if (row["Notes"].ToString() == role)
                {
                    dr = dt.NewRow();
                    CopydataRow(ref dr, row);
                    dt.Rows.Add(dr);
                }
                result = dt;
                dtgvAccount.DataSource = dt;
            }
        }
        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = cboGroup.SelectedItem.ToString();
            if (cboGroup.SelectedIndex == 0)
                LoadAccount();
            else
            {
                filterByRole(role);
                if (rbtnOn.Checked)
                    rbtnOn_CheckedChanged(null, null);
                else if (rbtnOff.Checked)
                    rbtnOff_CheckedChanged(null, null);
            }
        }
        private void rbtnOn_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = CreateAccountTable(dt);
            DataRow dr;

            foreach (DataRow row in result.Rows)
            {
                if (row["Actived"].ToString() == "True")
                {
                    dr = dt.NewRow();
                    CopydataRow(ref dr, row);
                    dt.Rows.Add(dr);
                }
            }
            dtgvAccount.DataSource = dt;
        }
        private void rbtnOff_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = CreateAccountTable(dt);
            DataRow dr;

            foreach (DataRow row in result.Rows)
            {
                if (row["Actived"].ToString() == "False")
                {
                    dr = dt.NewRow();
                    CopydataRow(ref dr, row);
                    dt.Rows.Add(dr);
                }
            }
            dtgvAccount.DataSource = dt;
        }
        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            dtgvAccount.DataSource = result;
        }
        //context menu script update account
        private void xóaTàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvAccount.SelectedRows.Count != -1)
            {
                command = new SQLStuff();
                SqlCommand cmd = new SqlCommand();
                DataGridViewRow row = dtgvAccount.SelectedRows[0];
                if (row.Cells[0].Value == null ||
                    row.Cells[1].Value == null ||
                    row.Cells[2].Value == null ||
                    row.Cells[4].Value == null ||
                    row.Cells[3].Value == null)
                {
                    MessageBox.Show("Please enter enough information for new account (AccountName, Password, FullName, Email, Tell)");
                    return;
                }
                cmd.CommandText = "EXECUTE UpdateAccountLab04 @AccountName, @Password, @FullName, @Mail, @Tell, @Activated, @RoleID, @RoleNotes";
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[0].Value);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[1].Value);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[2].Value);
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar, 100).Value = Convert.ToString(row.Cells[3].Value);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = Convert.ToString(row.Cells[4].Value);
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                cmd.Parameters.AddWithValue("@Activated", 0);
                cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = GetRoleName();

                command.Execute(cmd);
                LoadAccount();
                MessageBox.Show("Update account information completed");
            }
        }
        //context menu script view role list
        private void xemDanhSáchVaiTròToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvAccount.SelectedRows.Count != -1)
            {
                DataGridViewRow row = dtgvAccount.SelectedRows[0];
                Forms.RoleAccount roleAccount = new Forms.RoleAccount();
                roleAccount.Name = Convert.ToString(row.Cells[0].Value);
                roleAccount.ShowDialog();
            }
        }
    }
}
