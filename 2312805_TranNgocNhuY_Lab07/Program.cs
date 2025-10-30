using _2312805_TranNgocNhuY_lab07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_lab07
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var context = new RestaurantContext();

            AccountModel loggedInAccount = null;
            using (var loginForm = new Forms.LoginForm(context))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    loggedInAccount = loginForm.LoggedInAccount;
                }
            }
            if (loggedInAccount == null)
            {
                return;
            }
            Application.Run(new Forms.MainForm(context, loggedInAccount));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Forms.AccountForm());
            //Application.Run(new Forms.BillsForm());
            //Application.Run(new Forms.RoleForm());
            //Application.Run(new Forms.TableForm());
        }
    }
}
