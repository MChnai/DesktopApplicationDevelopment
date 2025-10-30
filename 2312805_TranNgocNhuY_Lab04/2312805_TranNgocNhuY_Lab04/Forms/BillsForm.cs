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
    public partial class BillsForm : Form
    {
        SQLStuff sqlStuff;
        SqlDataReader sqlDataReader;
        DataTable dt;
        public BillsForm()
        {
            InitializeComponent();
        }
        private void Display(SqlDataReader reader)
        {
            lvBill.Items.Clear();
            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("CheckoutDate", typeof(DateTime));
            dt.Columns.Add("Total", typeof(decimal));
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Amount"].ToString());
                item.SubItems.Add(reader["Discount"].ToString());
                item.SubItems.Add(reader["CheckoutDate"].ToString());
                item.SubItems.Add(reader["Total"].ToString());
                lvBill.Items.Add(item);

                DataRow row = dt.NewRow();
                row["ID"] = sqlDataReader["ID"];
                row["Amount"] = sqlDataReader["Amount"];
                row["Discount"] = sqlDataReader["Discount"];
                row["CheckoutDate"] = sqlDataReader["CheckoutDate"];
                row["Total"] = sqlDataReader["Total"];
                dt.Rows.Add(row);
            }
        }
        private void btnexecute_Click(object sender, EventArgs e)
        {
            sqlStuff = new SQLStuff();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ID,Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account,(Amount - Discount + Tax) AS Total " +
                "FROM Bills " +
                "WHERE CheckoutDate >= '@From' AND CheckoutDate <= '@To'";
            cmd.CommandText = cmd.CommandText.Replace("@From", dtpFrom.Text);
            cmd.CommandText = cmd.CommandText.Replace("@To", dtpTo.Text);
            sqlDataReader = sqlStuff.Read(cmd.CommandText);
            dt = new DataTable();
            Display(sqlDataReader);
            sqlDataReader.Close();

            //Amount
            decimal total = 0, discount = 0, final = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Amount"]);
                discount += Convert.ToDecimal(row["Discount"]);
                final += Convert.ToDecimal(row["Total"]);
            }
            txtTotal.Text = total.ToString();
            txtDiscount.Text = discount.ToString();
            txtFinalAmount.Text = final.ToString();
        }
        private void lvBill_DoubleClick(object sender, EventArgs e)
        {
            if (lvBill.SelectedItems.Count > 0)
            {
                ListViewItem item = lvBill.SelectedItems[0];
                BillDetailsForm detailsForm = new BillDetailsForm();
                detailsForm.ID = item.SubItems[0].Text;
                detailsForm.ShowDialog();
            }
        }
    }
}
