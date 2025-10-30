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
    public partial class LoginForm : Form
    {
        private readonly RestaurantContext _context;
        public AccountModel LoggedInAccount { get; private set; }
        public LoginForm(RestaurantContext context)
        {
            InitializeComponent();
            this._context = context;
        }
        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            return inputPassword == storedPassword; 
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được để trống.");
                return;
            }
            var account = _context.Accounts
                .FirstOrDefault(a => a.AccountName == accountName);

            if (account == null || !VerifyPassword(password, account.Password))
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.");
                return;
            }
            LoggedInAccount = new AccountModel
            {
                AccountName = account.AccountName,
                FullName = account.FullName,
                Email = account.Email,
                Phone = account.Tell,
                Password = account.Password,
                DateCreated = account.DateCreated
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
