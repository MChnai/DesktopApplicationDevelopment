using _2312805_TranNgocNhuY_lab07.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _2312805_TranNgocNhuY_lab07.Forms
{
    public partial class RoleForm : Form
    {
        private RestaurantContext _context;
        public RoleForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadRoles();
        }
        public RoleForm(List<string> roles)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadRoles(roles);
        }
        private void LoadRoles(List<string> roles)
        {
            lvRoles.Items.Clear(); 

            foreach (var roleName in roles)
            {
                var item = new ListViewItem(roleName);
                lvRoles.Items.Add(item);
            }
        }
        private void LoadRoles()
        {
            lvRoles.Items.Clear();

            var roles = _context.Roles.Select(r => new RoleModel
            {
                Id = r.Id,
                RoleName = r.RoleName,
                Path = r.Path,
                Notes = r.Notes
            }).ToList();

            foreach (var role in roles)
            {
                var item = new ListViewItem(role.Id.ToString());
                item.SubItems.Add(role.RoleName);
                item.SubItems.Add(role.Path);
                item.SubItems.Add(role.Notes);

                lvRoles.Items.Add(item);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newRole = new Role
            {
                RoleName = txtRoleName.Text,
                Path = txtPath.Text,
                Notes = txtNotes.Text
            };

            _context.Roles.Add(newRole); 
            _context.SaveChanges();     
            MessageBox.Show("Thêm vai trò mới thành công!");
            LoadRoles();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count > 0)
            {
                var selectedItem = lvRoles.SelectedItems[0];
                int roleId = int.Parse(selectedItem.Text);

                var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);

                if (role != null)
                {
                    role.RoleName = txtRoleName.Text;
                    role.Path = txtPath.Text;
                    role.Notes = txtNotes.Text;

                    _context.SaveChanges();
                    MessageBox.Show("Cập nhật vai trò thành công!");
                    LoadRoles();
                }
            }
        }
        private void lvRoles_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count > 0)
            {
                var selectedItem = lvRoles.SelectedItems[0];
                int roleId = int.Parse(selectedItem.Text);

                var accounts = _context.RoleAccounts
                    .Where(ra => ra.RoleId == roleId && ra.Actived)
                    .Join(_context.Accounts,
                        ra => ra.AccountName,
                        acc => acc.AccountName,
                        (ra, acc) => new AccountModel
                        {
                            AccountName = acc.AccountName,
                            FullName = acc.FullName,
                            Email = acc.Email,
                            Phone = acc.Tell,
                            DateCreated = acc.DateCreated
                        })
                    .ToList();

                txtRoleName.Text = selectedItem.SubItems[1].Text;
                txtPath.Text = selectedItem.SubItems[2].Text;
                txtNotes.Text = selectedItem.SubItems[3].Text;

                lvAccounts.Items.Clear(); 

                foreach (var account in accounts)
                {
                    var item = new ListViewItem(account.AccountName);
                    item.SubItems.Add(account.FullName);
                    item.SubItems.Add(account.Email);
                    item.SubItems.Add(account.Phone);
                    item.SubItems.Add(account.DateCreated
                        != null ? account.DateCreated.ToString("yyyy-MM-dd")
                        : "N/A");

                    lvAccounts.Items.Add(item);
                }
            }
        }
        private void btnLoadAccountList_Click(object sender, EventArgs e)
        {
            var accounts = _context.RoleAccounts                   
                    .Join(_context.Accounts,
                        ra => ra.AccountName,
                        acc => acc.AccountName,
                        (ra, acc) => new AccountModel
                        {
                            AccountName = acc.AccountName,
                            FullName = acc.FullName,
                            Email = acc.Email,
                            Phone = acc.Tell,
                            DateCreated = acc.DateCreated
                        })
                    .ToList();

            lvAccounts.Items.Clear();

            foreach (var account in accounts)
            {
                var item = new ListViewItem(account.AccountName);
                item.SubItems.Add(account.FullName);
                item.SubItems.Add(account.Email);
                item.SubItems.Add(account.Phone);
                item.SubItems.Add(account.DateCreated
                    != null ? account.DateCreated.ToString("yyyy-MM-dd")
                    : "N/A");

                lvAccounts.Items.Add(item);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNotes.Text = string.Empty;
            txtPath.Text = string.Empty;
            txtRoleName.Text = string.Empty;
        }
    }
}
