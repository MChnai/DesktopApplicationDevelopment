using BusinessLogic;
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
    public partial class frmPayment : Form
    {
        private BillsBL billsBL;
        private int billId;
        public frmPayment(int billId)
        {
            this.billId = billId;
            billsBL = new BillsBL();
            InitializeComponent();
            LoadBillDetails();
            CalculateFinalTotal();
        }
        private void LoadBillDetails()
        {
            // Lấy chi tiết hóa đơn từ BillsBL
            var billDetails = billsBL.GetBillDetails(billId);

            decimal total = 0;

            foreach (var detail in billDetails)
            {
                var item = new ListViewItem(detail.FoodName);
                item.SubItems.Add(detail.Price.ToString("C")); // Giá
                item.SubItems.Add(detail.Quantity.ToString()); // Số lượng
                item.SubItems.Add(detail.Total.ToString("C")); // Thành tiền
                lvOrder.Items.Add(item);

                total += detail.Total;
            }

            txtTotal.Text = total.ToString("C"); // Hiển thị tổng tiền
        }
        private void CalculateFinalTotal()
        {
            decimal total = 0;
            decimal discount = 0;

            string strTotal = txtTotal.Text.Replace("$", "");
            strTotal = strTotal.Replace(",", "");
            total = Convert.ToDecimal(strTotal);
           //decimal.TryParse(txtTotal.Text.Replace("₫", "").Trim(), out total);
            decimal.TryParse(txtDiscount.Text, out discount);

            decimal finalTotal = total - discount;
            if (finalTotal < 0)
                finalTotal = 0;

            txtFinalTotal.Text = finalTotal.ToString("C");
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text, out discount);

            decimal finalTotal = 0;
            decimal.TryParse(txtFinalTotal.Text, out finalTotal);
            var result = billsBL.PayBill(billId, discount, finalTotal);
            if (result)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }
    }
}
