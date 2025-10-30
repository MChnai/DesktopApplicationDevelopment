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
    public partial class frmRoleAccount : Form
    {
        List<Role> listRole = new List<Role>();
        List<RoleAccount> listRoleAccount = new List<RoleAccount>();
        RoleAccount currentRoleAccount = new RoleAccount();
        public frmRoleAccount()
        {
            InitializeComponent();
        }
        //Exit button
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Clear button
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = "";
            chkActivatedYes.Checked = false;
            txtNotes.Text = "";
            if (cbbRole.Items.Count > 0)
                cbbRole.SelectedIndex = 0;
        }
        //Load role account table
        private void LoadRoles()
        {
            RoleBL roleBL = new RoleBL();
            listRole = roleBL.GetAll();
            cbbRole.DataSource = listRole;
            cbbRole.ValueMember = "ID";
            cbbRole.DisplayMember = "RoleName";
        }
        private void LoadRoleAccountDataToListView()
        {
            RoleAccountBL roleAccountBL = new RoleAccountBL();
            listRoleAccount = roleAccountBL.GetAll();
            int count = 1;
            lsvRoleAccount.Items.Clear();

            foreach (var roleAccount in listRoleAccount)
            {
                if (roleAccount == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(roleAccount.AccountName ?? "N/A");
                var role = listRole.Find(x => x.ID == roleAccount.RoleID);
                item.SubItems.Add(role?.RoleName ?? "Unknown Role");
                item.SubItems.Add(roleAccount.Actived ? "Hoạt động" : "Không hoạt động"); 
                item.SubItems.Add(roleAccount.Notes ?? "No notes");
                lsvRoleAccount.Items.Add(item);
                count++;
            }
        }
        private void frmRoleAccount_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadRoleAccountDataToListView();
            lblStatistic.Text = $"Tổng số vai trò tài khoản: {listRoleAccount.Count}";
        }
        //select index change
        private void lsvRoleAccount_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvRoleAccount.Items.Count; i++)
            {
                if (lsvRoleAccount.Items[i].Selected)
                {
                    currentRoleAccount = listRoleAccount[i];
                    txtAccountName.Text = currentRoleAccount.AccountName;
                    if (currentRoleAccount.Actived)
                        chkActivatedYes.Checked = currentRoleAccount.Actived;
                    else
                        chkActivatedNo.Checked = true;
                    cbbRole.SelectedIndex = listRole.FindIndex(x => x.ID == currentRoleAccount.RoleID);
                    txtNotes.Text = currentRoleAccount.Notes;
                }
            }
        }
        //Insert update delete role account
        public int InsertRoleAccount()
        {
            RoleAccount roleAccount = new RoleAccount();

            if (string.IsNullOrEmpty(txtAccountName?.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản.");
                return -1;
            }

            roleAccount.AccountName = txtAccountName?.Text ?? string.Empty;
            roleAccount.Actived = chkActivatedYes?.Checked ?? false;
            roleAccount.Notes = txtNotes?.Text ?? string.Empty;

            if (cbbRole?.SelectedValue != null && int.TryParse(cbbRole.SelectedValue.ToString(), out int roleId))
                roleAccount.RoleID = roleId;
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò hợp lệ.");
                return -1;
            }

            RoleAccountBL roleAccountBL = new RoleAccountBL();
            return roleAccountBL.Insert(roleAccount);
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (InsertRoleAccount() > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!");
                LoadRoleAccountDataToListView();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công.");
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (currentRoleAccount == null || string.IsNullOrEmpty(currentRoleAccount.AccountName))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xoá.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RoleAccountBL roleAccountBL = new RoleAccountBL();
                if (roleAccountBL.Delete(currentRoleAccount) > 0)
                {
                    MessageBox.Show("Xoá thành công!");
                    LoadRoleAccountDataToListView();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công.");
                }
            }
        }
        public int UpdateRoleAccount()
        {
            if (currentRoleAccount == null)
            {
                MessageBox.Show("Không có tài khoản hiện hành để cập nhật.");
                return -1;
            }

            currentRoleAccount.AccountName = txtAccountName?.Text ?? string.Empty;
            currentRoleAccount.Actived = chkActivatedYes?.Checked ?? false;
            currentRoleAccount.Notes = txtNotes?.Text ?? string.Empty;

            if (cbbRole?.SelectedValue != null && int.TryParse(cbbRole.SelectedValue.ToString(), out int roleId))
                currentRoleAccount.RoleID = roleId;
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò hợp lệ.");
                return -1;
            }

            RoleAccountBL roleAccountBL = new RoleAccountBL();
            return roleAccountBL.Update(currentRoleAccount);
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateRoleAccount() > 0)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadRoleAccountDataToListView();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
      
    }
}
