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
    public partial class Dairy : Form
    {
        public string MaBan;
        SQLStuff SQLStuff;
        SqlConnection conn;
        public Dairy()
        {
            InitializeComponent();
        }
        public Dairy(string maBan)
        {
            InitializeComponent();
            this.MaBan = maBan;
        }

        private void Dairy_Load(object sender, EventArgs e)
        {
            SQLStuff = new SQLStuff();
            conn = SQLStuff.Conmection();
            string query = @"SELECT a.ID,a.CheckoutDate,a.Account,a.Discount,a.Tax,SUM(a.Amount * b.Quantity) AS TongTien" +
                    " FROM Bills a, BillDetail b" +
                    " WHERE a.ID=b.InvoiceID AND a.TableID=@MaBan" +
                    " GROUP BY a.ID, a.CheckoutDate, a.Account, a.Discount, a.Tax" +
                    " ORDER BY a.CheckoutDate DESC";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaBan", MaBan);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhatKy.DataSource = dt;

            // 🔹 Tính tổng cộng
            double tongHoaDon = dt.Rows.Count;
            double tongTien = 0, tongThue = 0, tongGiamGia = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongTien += Convert.ToDouble(row[5]);
                tongThue += Convert.ToDouble(row[4]);
                tongGiamGia += Convert.ToDouble(row[3]);
            }

            lblThongKe.Text = $"Số HĐ: {tongHoaDon} \n Tổng tiền: {tongTien:#,##0}đ \n Tổng thuế: {tongThue}% \n Tổng giảm giá: {tongGiamGia}%";
        }
    }
}
