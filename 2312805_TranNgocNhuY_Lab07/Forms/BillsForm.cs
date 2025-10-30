using _2312805_TranNgocNhuY_lab07.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_lab07.Forms
{
    public partial class BillsForm : Form
    {
        private readonly RestaurantContext _context;
        public BillsForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadBills();
        }
        private void LoadBills(DateTime? fromDate = null, DateTime? toDate = null)
        {
            lvBills.Items.Clear(); 
            lvBills.Columns.Clear(); 

            lvBills.Columns.Add("Id", 50);
            lvBills.Columns.Add("Tên hóa đơn", 150);
            lvBills.Columns.Add("Tên bàn", 100);
            lvBills.Columns.Add("Tổng tiền", 100);
            lvBills.Columns.Add("Giảm giá", 100);
            lvBills.Columns.Add("Thực thu", 100);
            lvBills.Columns.Add("Ngày thanh toán", 150);
            lvBills.Columns.Add("Nhân viên", 120);
            lvBills.Columns.Add("Trạng thái", 100);

            var query = _context.Bills.AsQueryable();

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(b => b.CheckoutDate >= fromDate && b.CheckoutDate <= toDate);
            }
            var bills = query
                .Include(b => b.Table01)
                .Select(b => new
                {
                    b.Id,
                    b.Name,
                    TableName = b.Table01 != null ? b.Table01.Name : "Không xác định",
                    TotalAmount = b.Amount,
                    DiscountAmount = b.Discount, 
                    ActualAmount = b.Amount - b.Discount,
                    b.CheckoutDate,
                    AccountName = b.Account ?? "Không xác định",
                    b.Status
                }).ToList();
            foreach (var bill in bills)
            {
                var item = new ListViewItem(bill.Id.ToString());
                item.SubItems.Add(bill.Name ?? "");
                item.SubItems.Add(bill.TableName);
                item.SubItems.Add(bill.TotalAmount.ToString("N0"));
                item.SubItems.Add(bill.DiscountAmount.ToString("N0"));
                item.SubItems.Add(bill.ActualAmount.ToString("N0"));
                item.SubItems.Add(bill.CheckoutDate.ToString("dd/MM/yyyy HH:mm") ?? "");
                item.SubItems.Add(bill.AccountName);
                item.SubItems.Add(bill.Status ? "Đã thanh toán" : "Chưa thanh toán");
                item.Tag = bill.Id;

                lvBills.Items.Add(item);
            }

            var totalAmount = bills.Sum(b => b.TotalAmount);
            var totalDiscount = bills.Sum(b => b.DiscountAmount);
            var actualAmount = bills.Sum(b => b.ActualAmount);

            txtTotal.Text = totalAmount.ToString("N0");
            txtDiscount.Text = totalDiscount.ToString("N0");
            txtFinalAmount.Text = actualAmount.ToString("N0");
        }
        private void btnexecute_Click(object sender, EventArgs e)
        {
            var fromDate = dtpFromDate.Value.Date;
            var toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1); // Đến cuối ngày
            LoadBills(fromDate, toDate);
        }
        private void lvBills_DoubleClick(object sender, EventArgs e)
        {
            if (lvBills.SelectedItems.Count > 0)
            {
                var selectedItem = lvBills.SelectedItems[0];
                if (selectedItem.Tag is int)
                {
                    var billDetailsForm = new BillDetailsForm(Convert.ToInt32(selectedItem.Tag));
                    billDetailsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ID hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
