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
    public partial class AccountDetailsForm : Form
    {
        private AccountModel _loggedInAccount;
        public AccountDetailsForm(AccountModel loggedInAccount)
        {
            InitializeComponent();
            _loggedInAccount = loggedInAccount;

            LoadAccountDetails();
        }
        private void LoadAccountDetails()
        {
            txtAccountName.Text = _loggedInAccount.AccountName;
            txtFullName.Text = _loggedInAccount.FullName;
            txtEmail.Text = _loggedInAccount.Email;
            txtPhone.Text = _loggedInAccount.Phone;
            txtDateCreated.Text = _loggedInAccount.DateCreated.ToString("dd/MM/yyyy");
        }
    }
}
