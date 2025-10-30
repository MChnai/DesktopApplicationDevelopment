using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab06.Forms
{
    public partial class frmPhanQuyen : Form
    {
        List<Role> listRoles = new List<Role>();
        List<RoleAccount> listRoleAccounts = new List<RoleAccount>();
        RoleAccount currentRoleAccount = new RoleAccount();
        public frmPhanQuyen()
        {
            InitializeComponent();
        }
        //Exit button
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Load roles table
        private void LoadRoles()
        {
            RoleBL roleBL = new RoleBL();
            listRoles = roleBL.GetAll();
            cmbRoles.DataSource = listRoles;
            cmbRoles.ValueMember = "ID";
            cmbRoles.DisplayMember = "RoleName";
        }
        private void LoadRoleAccountsToListView()
        {
            RoleAccountBL roleAccountBL = new RoleAccountBL();
            listRoleAccounts = roleAccountBL.GetAll();

            int count = 1;
            lsvUsers.Items.Clear();
            foreach (var roleAccount in listRoleAccounts)
            {
                if (roleAccount == null) continue;

                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(roleAccount.AccountName); 
                item.SubItems.Add(listRoles.Find(r => r.ID == roleAccount.RoleID)?.RoleName ?? "Unknown"); 
                item.SubItems.Add(roleAccount.Notes ?? "Unknown");

                lsvUsers.Items.Add(item);
                count++;
            }
            lblStatistic.Text = $"Tổng số tài khoản: {listRoleAccounts.Count}";
        }
        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadRoleAccountsToListView();
        }
        //clear button
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = "";
            chkActive.Checked = false;
            if (cmbRoles.Items.Count > 0)
                cmbRoles.SelectedIndex = 0;
        }
        //select index change
        private void lsvUsers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvUsers.Items.Count; i++)
            {
                if (lsvUsers.Items[i].Selected)
                {
                    currentRoleAccount = listRoleAccounts[i];
                    txtAccountName.Text = currentRoleAccount.AccountName;
                    chkActive.Checked = currentRoleAccount.Actived;
                    cmbRoles.SelectedIndex = listRoles.FindIndex(r => r.ID == currentRoleAccount.RoleID);
                }
            }
        }
        //Insert update delete button
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAccountName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbRoles.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một vai trò hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int roleId = cmbRoles.SelectedValue as int? ?? -1;
                if (roleId == -1)
                {
                    MessageBox.Show("Vai trò không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AccountBL accountBL = new AccountBL();
                RoleAccount roleAccount = new RoleAccount
                {
                    AccountName = txtAccountName.Text.Trim(),
                    RoleID = roleId,
                    Actived = chkActive.Checked
                };
                roleAccount.Notes = txtNote.Text;

                RoleAccountBL roleAccountBL = new RoleAccountBL();
                int result = roleAccountBL.Insert(roleAccount);

                if (result > 0)
                {
                    MessageBox.Show("Thêm quyền thành công!");
                    LoadRoleAccountsToListView();
                }
                else
                {
                    MessageBox.Show("Thêm quyền thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRoleAccount == null || string.IsNullOrWhiteSpace(txtAccountName.Text))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbRoles.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một vai trò hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int roleId = cmbRoles.SelectedValue as int? ?? -1;
                if (roleId == -1)
                {
                    MessageBox.Show("Vai trò không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                currentRoleAccount.AccountName = txtAccountName.Text.Trim();
                currentRoleAccount.RoleID = roleId;
                currentRoleAccount.Actived = chkActive.Checked;
                RoleAccountBL roleAccountBL = new RoleAccountBL();
                int result = roleAccountBL.Update(currentRoleAccount);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật quyền thành công!");
                    LoadRoleAccountsToListView();
                }
                else
                {
                    MessageBox.Show("Cập nhật quyền thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRoleAccount == null)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RoleAccountBL roleAccountBL = new RoleAccountBL();
                int result = roleAccountBL.Delete(currentRoleAccount);

                if (result > 0)
                {
                    MessageBox.Show("Xóa quyền thành công!");
                    LoadRoleAccountsToListView();
                }
                else
                {
                    MessageBox.Show("Xóa quyền thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        //Assign role for account
        private void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbRoles.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                RoleAccount roleAccount = new RoleAccount
                {
                    AccountName = txtAccountName.Text.Trim(),
                    RoleID = (int)cmbRoles.SelectedValue,
                    Actived = chkActive.Checked
                };
                RoleAccountBL roleAccountBL = new RoleAccountBL();
                int result = roleAccountBL.AssignRole(roleAccount.AccountName, roleAccount.RoleID, roleAccount.Actived);
                if (result > 0)
                {
                    MessageBox.Show("Gán quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Gán quyền thất bại! Tài khoản có thể chưa tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //select index change of role combo box
        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Role role in listRoles)
                if (role.RoleName == cmbRoles.Text)
                    txtNote.Text = role.Notes;
        }
    }
}
