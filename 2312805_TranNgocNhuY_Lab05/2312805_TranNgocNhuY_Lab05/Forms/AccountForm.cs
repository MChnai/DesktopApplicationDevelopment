using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab05.Forms
{
    public partial class AccountForm : Form
    {
        SqlConnection conn;
        sqlCommands command;
        DataTable accountTable;
        DataTable RoleTable;
        public AccountForm()
        {
            InitializeComponent();
        }
        private void LoadRole()
        {
            command = new sqlCommands();
            conn = command.Conmection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE [dbo].[GetRoleInfo]";
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            RoleTable = new DataTable();
            adapter.Fill(RoleTable);
            cbbRole.DataSource = RoleTable;
            cbbRole.DisplayMember = "Notes";
            conn.Close();
        }
        private void LoadAccount()
        {
            command = new sqlCommands();
            conn = command.Conmection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE [dbo].[GetAccountInfo]";
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            accountTable = new DataTable();
            adapter.Fill(accountTable);
            dgvAccountList.DataSource = accountTable;
            conn.Close();
        }
        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadAccount();
            LoadRole();
        }
        private void dgvAccountList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccountList.SelectedRows.Count > 0)
            {
                int index = dgvAccountList.SelectedRows.Count;
                DataGridViewRow row = dgvAccountList.SelectedRows[0];

                txtName.Text = row.Cells[0].Value.ToString();
                txtPass.Text = row.Cells[1].Value.ToString();
                txtFullName.Text = row.Cells[2].Value.ToString();
                txtMail.Text = row.Cells[3].Value.ToString();
                txtPhone.Text = row.Cells[4].Value.ToString();
                dtpDate.Text = row.Cells[5].Value.ToString();
                cbbRole.Text = row.Cells[9].Value.ToString();
            }
        }
        private bool CheckAccountName()
        {
            foreach (DataRow row in accountTable.Rows)
                if (row["AccountName"].ToString() == txtName.Text)
                    return false;
            return true;
        }
        private int GetRoleID()
        {
            foreach (DataRow row in RoleTable.Rows)
                if (row["Notes"].ToString() == cbbRole.Text)
                    return Convert.ToInt32(row["ID"].ToString());
            return -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!CheckAccountName())
            {
                MessageBox.Show("This account name has already existed. Please try other account name.");
                return;
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE InsertAccount @AccountName, @Password, @FullName, @Mail, @Tell, @RoleID, @Activated, @RoleNotes";
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = txtPass.Text;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = txtFullName.Text;
            cmd.Parameters.Add("@Mail", SqlDbType.NVarChar, 100).Value = txtMail.Text;
            cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = txtPhone.Text;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = GetRoleID(); 
            cmd.Parameters.AddWithValue("@Activated ", 1);
            cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = cbbRole.Text;

            try
            {
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully adding new acount");
                    this.ResetText();
                    this.LoadAccount();
                }
                else
                {
                    MessageBox.Show("Adding account failed");
                }
                conn.Close();
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckAccountName())
            {
                MessageBox.Show("This account name doesn't exist. Please try other account name.");
                return;
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE UpdateAccount @AccountName, @Password, @FullName, @Mail, @Tell, @RoleID, @RoleNotes";
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = txtPass.Text;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = txtFullName.Text;
            cmd.Parameters.Add("@Mail", SqlDbType.NVarChar, 100).Value = txtMail.Text;
            cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = txtPhone.Text;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = GetRoleID();
            cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = cbbRole.Text;

            try
            {
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully updating new acount");
                    this.ResetText();
                    this.LoadAccount();
                }
                else
                {
                    MessageBox.Show("Updating account failed");
                }
                conn.Close();
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
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (CheckAccountName())
            {
                MessageBox.Show("This account name doesn't exist. Please try other account name.");
                return;
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE UpdateAccount @AccountName, @Password, @FullName, @Mail, @Tell, @RoleID, @RoleNotes";
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = "123456";
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = txtFullName.Text;
            cmd.Parameters.Add("@Mail", SqlDbType.NVarChar, 100).Value = txtMail.Text;
            cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = txtPhone.Text;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = GetRoleID();
            cmd.Parameters.Add("@RoleNotes", SqlDbType.NVarChar).Value = cbbRole.Text;

            try
            {
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully reseting pasword into default (123456)");
                    this.ResetText();
                    this.LoadAccount();
                }
                else
                {
                    MessageBox.Show("Reseting account failed");
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
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            RoleInfo roleinfo = new RoleInfo();
            roleinfo.FormClosed += new FormClosedEventHandler(AccountForm_FormClosed);
            roleinfo.Show(this);
        }
        private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbRole.SelectedIndex;
            cbbRole.SelectedIndex = index;
            this.LoadAccount();
            LoadRole();
        }
        private void xemDanhSáchVaiTròToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleInfo roleInfor = new RoleInfo();
            roleInfor.accountName = txtName.Text;
            roleInfor.role = cbbRole.Text;
            roleInfor.FormClosed += new FormClosedEventHandler(AccountForm_FormClosed);
            roleInfor.Show(this);
        }
        private void xemNhậtKýHoạtĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiaryForm diary = new DiaryForm();
            diary.accountName = txtName.Text;
            diary.Show();
        }
    }
}
