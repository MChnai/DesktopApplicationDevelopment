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
    public partial class frmAccount : Form
    {
        List<Account> listAccount = new List<Account>();
        Account accountCurrent = new Account();
        public frmAccount()
        {
            InitializeComponent();
        }
        //Exit aplication
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //clear information
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
        //Load account table
        private void LoadAccountDataToListView()
        {
            AccountBL accountBL = new AccountBL();
            listAccount = accountBL.GetAll();
            int count = 1;
            lsvAccount.Items.Clear();
            foreach (var account in listAccount)
            {
                if (account == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(account.AccountName ?? "N/A");
                item.SubItems.Add(account.Password ?? "N/A");
                item.SubItems.Add(account.FullName ?? "N/A");
                item.SubItems.Add(account.Email ?? "N/A");
                item.SubItems.Add(account.Tell ?? "N/A");
                item.SubItems.Add(account.DateCreated.ToString("dd/MM/yyyy"));
                lsvAccount.Items.Add(item);
                count++;
            }
        }
        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadAccountDataToListView();
            lblStatistic.Text = $"Tổng số accounts: {listAccount.Count}";
        }
        //select index change of listview information
        private void lsvAccount_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvAccount.Items.Count; i++)
            {
                if (lsvAccount.Items[i].Selected)
                {
                    accountCurrent = listAccount[i];
                    txtAccountName.Text = accountCurrent.AccountName;
                    txtPassword.Text = accountCurrent.Password;
                    txtFullName.Text = accountCurrent.FullName;
                    txtEmail.Text = accountCurrent.Email;
                    txtPhone.Text = accountCurrent.Tell;
                }
            }
        }
        //Insert Update Delete accounts
        public int InsertAccount()
        {
            Account account = new Account();
            account.AccountName = "";
            if (string.IsNullOrEmpty(txtAccountName?.Text) || string.IsNullOrEmpty(txtPassword?.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
                return -1;
            }
            else
            {
                account.AccountName = txtAccountName?.Text ?? string.Empty;
                account.Password = txtPassword?.Text ?? string.Empty;
                account.FullName = txtFullName?.Text ?? string.Empty;
                account.Email = txtEmail?.Text ?? string.Empty;
                account.Tell = txtPhone?.Text ?? string.Empty;
                account.DateCreated = DateTime.Now;
                AccountBL accountBL = new AccountBL();
                return accountBL.Insert(account);
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAccountName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Account account = new Account
                {
                    AccountName = txtAccountName.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Tell = txtPhone.Text.Trim(),
                    DateCreated = DateTime.Now
                };
                int result = new AccountBL().Insert(account);
                if (result > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    LoadAccountDataToListView();
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
                if (accountCurrent == null || accountCurrent.AccountName == "")
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new AccountBL().Delete(accountCurrent);
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá tài khoản thành công!");
                        LoadAccountDataToListView();
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
        public int UpdateAccount()
        {
            if (accountCurrent == null)
            {
                MessageBox.Show("Không có dữ liệu tài khoản hiện hành để cập nhật.");
                return -1;
            }
            accountCurrent.AccountName = txtAccountName?.Text ?? string.Empty;
            accountCurrent.Password = txtPassword?.Text ?? string.Empty;
            accountCurrent.FullName = txtFullName?.Text ?? string.Empty;
            accountCurrent.Email = txtEmail?.Text ?? string.Empty;
            accountCurrent.Tell = txtPhone?.Text ?? string.Empty;
            return new AccountBL().Update(accountCurrent);
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (accountCurrent == null || accountCurrent.AccountName == "")
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int result = UpdateAccount();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    LoadAccountDataToListView();
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
