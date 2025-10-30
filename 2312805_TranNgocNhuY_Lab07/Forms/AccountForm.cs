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
    public partial class AccountForm : Form
    {
        private RestaurantContext _context;
        public AccountForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadAccounts();
            LoadRole();
        }
        private void LoadRole()
        {
            cbbRole.Items.Clear();
            List<RoleModel> listRole = _context.Roles
                .Select(role => new RoleModel
                {
                    RoleName = role.RoleName,
                }).ToList();
            cbbRole.Items.Add("All");
            foreach (RoleModel role in listRole) 
                cbbRole.Items.Add(role.RoleName);
        }
        private void LoadAccounts(List<AccountModel> accounts = null)
        {
            lvwAccount.Items.Clear();

            if (accounts == null)
            {
                accounts = _context.Accounts
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
            }
            foreach (var account in accounts)
            {
                var item = new ListViewItem(account.AccountName);
                item.SubItems.Add(account.FullName ?? "");
                item.SubItems.Add(account.Email ?? "");
                item.SubItems.Add(account.Phone ?? "");
                item.SubItems.Add(account.Password ?? "");
                item.SubItems.Add(account.DateCreated.ToString("dd/MM/yyyy") ?? "");

                lvwAccount.Items.Add(item);
            }
        }
        private void btnAccountManagement_Click(object sender, EventArgs e)
        {
            using (var addAccountForm = new AccountManagementForm())
            {
                if (addAccountForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAccounts();
                }
            }
        }
        private void Find()
        {
            string userName = txtSearchUserName.Text;
            var query = _context.Accounts.AsQueryable();
            if (!string.IsNullOrEmpty(cbbRole.Text) && cbbRole.SelectedIndex != 0)
            {
                query = query.Join(_context.RoleAccounts,
                    acc => acc.AccountName,
                    roleAcc => roleAcc.AccountName,
                    (acc, roleAcc) => new { acc, roleAcc })
                    .Where(x => x.roleAcc.Role != null && x.roleAcc.Role.RoleName == cbbRole.Text)
                    .Select(x => x.acc);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                query = query.Where(acc => acc.FullName != null && acc.FullName.Contains(userName));
            }
            var accountModels = query.Select(acc => new AccountModel
            {
                AccountName = acc.AccountName,
                FullName = acc.FullName,
                Email = acc.Email,
                Phone = acc.Tell,
                Password = acc.Password,
                DateCreated = acc.DateCreated
            }).ToList();
            LoadAccounts(accountModels);
        }
        private void txtRoleName_TextChanged(object sender, EventArgs e)
        {
            Find();
        }
        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Find();
        }
        private void btnPassManagement_Click(object sender, EventArgs e)
        {
            if (lvwAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để thay đổi mật khẩu.");
                return;
            }

            string accountName = lvwAccount.SelectedItems[0].Text;
            var changePasswordForm = new ChangePasswordForm(accountName);
            if (changePasswordForm.ShowDialog() == DialogResult.OK)
            {
                LoadAccounts();
            }
        }
        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.");
                return;
            }

            string accountName = lvwAccount.SelectedItems[0].Text;

            var account = _context.Accounts.FirstOrDefault(a => a.AccountName == accountName);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
                MessageBox.Show("Tài khoản đã bị xóa.");
                LoadAccounts();
            }
        }
        private void xemDanhSáchVaiTròToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem vai trò.");
                return;
            }

            string accountName = lvwAccount.SelectedItems[0].Text;

            var roles = _context.RoleAccounts
                .Where(ra => ra.AccountName == accountName && ra.Role != null)
                .Select(ra => ra.RoleId)
                .ToList();
            List<string> result = new List<string>();
            foreach (var role in roles)
            {
                string value = role.ToString();
                result.Add(value);
            }

            var roleForm = new RoleAccountForm(result);
            roleForm.ShowDialog();
        }
    }
}
