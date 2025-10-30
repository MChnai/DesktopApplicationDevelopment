using _2312805_TranNgocNhuY_Lab06.Forms;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab06
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Account loggedInUser = new Account();

            //using (var loginForm = new frmLogin())
            //{
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
            //        loggedInUser = loginForm.LoggedInAccount;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            //if (loggedInUser == null)
            //{
            //    MessageBox.Show("Lỗi: Không thể xác định tài khoản người dùng.");
            //    return;
            //}
            //var mainForm = new frmMain(loggedInUser);
            //Application.Run(mainForm);

            //Application.Run(new Forms.FoodForm());
            //Application.Run(new Forms.frmAccount());
            //Application.Run(new Forms.frmBills());
            //Application.Run(new Forms.frmCategory());
            //Application.Run(new Forms.frmRole());
        }
    }
}
