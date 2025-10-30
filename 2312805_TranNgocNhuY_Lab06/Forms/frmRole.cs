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
    public partial class frmRole : Form
    {
        List<Role> listRole = new List<Role>();
        Role roleCurrent = new Role();
        public frmRole()
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
            txtRoleName.Text = "";
            txtPath.Text = "";
            txtNotes.Text = "";
        }
        //Load role table
        private void LoadRoleDataToListView()
        {
            RoleBL roleBL = new RoleBL();
            listRole = roleBL.GetAll();
            int count = 1;
            lsvRole.Items.Clear();
            foreach (var role in listRole)
            {
                if (role == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(role.RoleName ?? "N/A");
                item.SubItems.Add(role.Path ?? "N/A");    
                item.SubItems.Add(role.Notes ?? "No notes"); 
                lsvRole.Items.Add(item);
                count++;
            }
        }
        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadRoleDataToListView();
            lblStatistic.Text = $"Tổng số vai trò: {listRole.Count}";
        }
        //select index change
        private void lsvRole_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvRole.Items.Count; i++)
            {
                if (lsvRole.Items[i].Selected)
                {
                    roleCurrent = listRole[i];
                    txtRoleName.Text = roleCurrent.RoleName;
                    txtPath.Text = roleCurrent.Path;
                    txtNotes.Text = roleCurrent.Notes;
                }
            }
        }
        //Insert Update Delete role
        public int InsertRole()
        {
            Role role = new Role();
            role.ID = 0;
            if (string.IsNullOrEmpty(txtRoleName?.Text) || string.IsNullOrEmpty(txtPath?.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
                return -1;
            }
            role.RoleName = txtRoleName?.Text ?? string.Empty;
            role.Path = txtPath?.Text ?? string.Empty;
            role.Notes = txtNotes?.Text ?? string.Empty;
            RoleBL roleBL = new RoleBL();
            return roleBL.Insert(role);

        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRoleName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên Role.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Role role = new Role
                {
                    RoleName = txtRoleName.Text.Trim(),
                    Path = txtPath.Text.Trim(),
                    Notes = txtNotes.Text.Trim()
                };
                int result = new RoleBL().Insert(role);

                if (result > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    LoadRoleDataToListView();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (roleCurrent == null || roleCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn Role để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá Role này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new RoleBL().Delete(roleCurrent);
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá Role thành công!");
                        LoadRoleDataToListView();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int UpdateRole()
        {
            if (roleCurrent == null)
            {
                MessageBox.Show("Không có dữ liệu Role hiện hành để cập nhật.");
                return -1;
            }
            Role role = roleCurrent;
            if (string.IsNullOrEmpty(txtRoleName?.Text) || string.IsNullOrEmpty(txtPath?.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
                return -1;
            }
                role.RoleName = txtRoleName?.Text ?? string.Empty;
                role.Path = txtPath?.Text ?? string.Empty;
                role.Notes = txtNotes?.Text ?? string.Empty;
                RoleBL roleBL = new RoleBL();
                return roleBL.Update(role);          
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (roleCurrent == null || roleCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn Role để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Role role = new Role
                {
                    ID = roleCurrent.ID,
                    RoleName = txtRoleName.Text.Trim(),
                    Path = txtPath.Text.Trim(),
                    Notes = txtNotes.Text.Trim()
                };
                int result = new RoleBL().Update(role);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    LoadRoleDataToListView();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
