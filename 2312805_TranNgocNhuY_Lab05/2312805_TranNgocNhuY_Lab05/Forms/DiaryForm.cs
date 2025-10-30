using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2312805_TranNgocNhuY_Lab05.Forms
{
    public partial class DiaryForm : Form
    {
        DataTable RoleTable;
        SqlConnection conn;
        SqlDataAdapter sqlDataReader;
        sqlCommands command;
        public string accountName;
        public DiaryForm()
        {
            InitializeComponent();
        }
        private void loadDate()
        {
            command = new sqlCommands();
            conn = command.Conmection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE [dbo].[GetBillDetailsAndAccount] @Name";
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = accountName;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            RoleTable = new DataTable();
            adapter.Fill(RoleTable);
            lbxDate.DataSource = RoleTable;
            lbxDate.DisplayMember = "CheckoutDate";
            conn.Close();
        }
        private void DiaryForm_Load(object sender, EventArgs e)
        {
            loadDate();

            lblAmount.Text = RoleTable.Rows.Count.ToString();
            int totalAmount = RoleTable.Rows.Count;
            if (totalAmount > 0)
            {
                totalAmount = RoleTable.AsEnumerable()
                                    .Sum(row => row.Field<int>("Amount"));
            }
            lblSale.Text = totalAmount.ToString() + " VND";
        }
        private void LoadByDate(DateTime date)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE GetBillDetails @Date, @AccountName";
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = accountName;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            RoleTable = new DataTable();
            adapter.Fill(RoleTable);
            dgvBill.DataSource = RoleTable;
            conn.Close();
        }
        private void lbxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = lbxDate.SelectedItem as DataRowView;
            string dateString = selectedRow["CheckoutDate"].ToString();
            LoadByDate(Convert.ToDateTime(dateString));
        }
    }
}
