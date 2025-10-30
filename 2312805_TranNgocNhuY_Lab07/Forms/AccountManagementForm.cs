using _2312805_TranNgocNhuY_lab07.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_lab07.Forms
{
    public partial class AccountManagementForm : Form
    {
        private RestaurantContext _context;
        public AccountManagementForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadRoles();
            LoadAccounts();
        }
        public AccountManagementForm(RestaurantContext context)
        {
            InitializeComponent();
            _context = context;

            LoadAccounts();
        }
        private void LoadAccounts()
        {
            listViewAccounts.Items.Clear();

            List<AccountModel> accounts = _context.Accounts
                    .Select(acc => new AccountModel
                    {
                        AccountName = acc.AccountName,
                        FullName = acc.FullName,
                        Email = acc.Email,
                        Phone = acc.Tell,
                        Password = acc.Password,
                        DateCreated = acc.DateCreated
                    })
                    .ToList();
            foreach (var account in accounts)
            {
                var item = new ListViewItem(account.AccountName);
                item.SubItems.Add(account.FullName ?? "");
                item.SubItems.Add(account.Email ?? "");
                item.SubItems.Add(account.Phone ?? "");
                item.SubItems.Add(account.Password ?? "");
                item.SubItems.Add(account.DateCreated.ToString("dd/MM/yyyy") ?? "");

                listViewAccounts.Items.Add(item);
            }       
        }
        private void LoadRoles()
        {
            comboRole.Items.Clear();

            var roles = _context.Roles.Select(r => new RoleModel
            {
                Id = r.Id,
                RoleName = r.RoleName,
                Path = r.Path,
                Notes = r.Notes
            }).ToList();

            foreach (var role in roles)
            {
                comboRole.Items.Add(role.RoleName);
            }
        }
        private string getRoleName(string accountName)
        {
            string roleName = _context.RoleAccounts
                                        .Where(ur => ur.AccountName == accountName) 
                                        .Select(ur => ur.Role.RoleName) 
                                        .FirstOrDefault(); 
            return roleName;
        }
        private int getRoleID(string role)
        {
            int roleID = Convert.ToInt32(_context.Roles
                                        .Where(ur => ur.RoleName == role)
                                        .Select(ur => ur.Id)
                                        .FirstOrDefault());
            return roleID;
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = "123456";
            if (comboRole.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn vai trò hợp lệ.");
                return;
            }

            int roleId = getRoleID(comboRole.Text);
            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được để trống.");
                return;
            }

            var newAccount = new Account
            {
                AccountName = accountName,
                FullName = fullName,
                Email = email,
                Tell = phone,
                Password = password,
                DateCreated = DateTime.Now
            };

            _context.Accounts.Add(newAccount);
            _context.RoleAccounts.Add(new RoleAccount
            {
                AccountName = accountName,
                RoleId = roleId,
                Actived = true,
                Notes = comboRole.Text
            });

            _context.SaveChanges();
            MessageBox.Show("Thêm tài khoản mới thành công!");
            DialogResult = DialogResult.OK;
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountName == txtAccountName.Text);
            var roleAccount = _context.RoleAccounts.FirstOrDefault(a => a.AccountName == txtAccountName.Text);

            if (account != null)
            {
                account.FullName = txtFullName.Text.Trim();
                account.Email = txtEmail.Text.Trim();
                account.Tell = txtPhone.Text.Trim();
                _context.SaveChanges();
                MessageBox.Show("Cập nhật thông tin tài khoản thành công! (Lưu ý cập nhật tên tài khoản và vai trò)");
                LoadAccounts();
            }
        }
        private void listViewAccounts_Click(object sender, EventArgs e)
        {
            if (listViewAccounts.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewAccounts.SelectedItems[0];
                txtAccountName.Text = item.SubItems[0].Text;
                txtFullName.Text = item.SubItems[1].Text;
                txtEmail.Text = item.SubItems[2].Text;
                txtPhone.Text = item.SubItems[3].Text;
                comboRole.Text = getRoleName(item.SubItems[0].Text);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            comboRole.Text = string.Empty;
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (listViewAccounts.SelectedItems.Count > 0)
            {
                var selectedAccount = listViewAccounts.SelectedItems[0].Text;
                var account = _context.Accounts.FirstOrDefault(a => a.AccountName == selectedAccount);
                var accountRole = _context.RoleAccounts.FirstOrDefault(a => a.AccountName == selectedAccount);

                if (account != null)
                {
                    _context.RoleAccounts.Remove(accountRole);
                    _context.SaveChanges();
                    _context.Accounts.Remove(account);
                    _context.SaveChanges();
                    LoadAccounts();
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một tài khoản để xóa!");
            }
        }
        private void AccountManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
