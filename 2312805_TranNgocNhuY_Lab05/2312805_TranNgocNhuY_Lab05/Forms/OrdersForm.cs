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
using System.Xml.Linq;

namespace _2312805_TranNgocNhuY_Lab05.Forms
{
    public partial class OrdersForm : Form
    {
        SqlConnection conn;
        public OrdersForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE GetOdersByDate @StartDate, @EndDate";
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dtpStartDate.Text;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dtpEndDate.Text;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ordersTable = new DataTable();
            adapter.Fill(ordersTable);
            dgvBillList.DataSource = ordersTable;
            conn.Close();

            //total sale
            int totalAmount = ordersTable.Rows.Count;
            if (totalAmount > 0)
            {
                totalAmount = ordersTable.AsEnumerable()
                                    .Sum(row => row.Field<int>("Amount"));
            }
            txtSale.Text = totalAmount.ToString() + " VND";
        }
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            sqlCommands cmd = new sqlCommands();
            conn = cmd.Conmection();
        }
    }
}
