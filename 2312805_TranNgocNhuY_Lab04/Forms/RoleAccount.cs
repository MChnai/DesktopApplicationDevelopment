using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab04.Forms
{
    public partial class RoleAccount : Form
    {
        SQLStuff sqlStuff;
        SqlDataAdapter sqlDataReader;
        public string AccountName { get; set; }
        public RoleAccount()
        {
            InitializeComponent();
        }
        private void RoleAccount_Load(object sender, EventArgs e)
        {
            dtgvRoleAccount.DataSource = new DataTable();
            sqlStuff = new SQLStuff();
            string sqlCommand = "SELECT[dbo].Account.AccountName, [dbo].Account.Password, FullName, Email, Tell, DateCreated, [dbo].RoleAccount.RoleID, Actived, [dbo].RoleAccount.Notes " +
                "FROM[dbo].Account, [dbo].RoleAccount, [dbo].Role " +
                "WHERE[dbo].Account.AccountName = [dbo].RoleAccount.AccountName AND[dbo].Role.ID = [dbo].RoleAccount.RoleID AND [dbo].RoleAccount.AccountName = '" + Name + "'";
            sqlDataReader = sqlStuff.Read_Data_Adapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            sqlDataReader.Fill(dt);
            dtgvRoleAccount.DataSource = dt;
            sqlDataReader.Dispose();
        }
    }
}
