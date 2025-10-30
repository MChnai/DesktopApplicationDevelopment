using _2312805_TranNgocNhuY_lab07.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_lab07.Forms
{
    public partial class BillDetailsForm : Form
    {
        private readonly RestaurantContext _context;
        private readonly int _billId;
        private readonly string _tableId;
        public BillDetailsForm(int billId)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            _billId = billId;
            LoadBillDetails(_billId);
        }
        public BillDetailsForm(string tableId)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            _tableId = tableId;
            this.Size = new System.Drawing.Size(570, 240);
            LoadBills();
        }
        private void LoadBills()
        {
            var table = _context.Tables.FirstOrDefault(t => t.Name == _tableId);

            if (table == null)
            {
                MessageBox.Show("Không tìm thấy bàn.");
                return;
            }
            var bills = _context.Bills
                .Where(b => b.Table01.Name == table.Name)
                .Select(b => new { b.Id, b.Name, b.Amount, b.CheckoutDate })
                .ToList();

            lstBills.DataSource = bills;
            lstBills.DisplayMember = "Name";
            lstBills.ValueMember = "Id";
        }

        private void LoadBillDetails(int billId)
        {
            var billDetails = _context.BillDetails
                .Where(d => d.InvoiceId == billId)
                .Select(d => new
                {
                    d.Id,
                    FoodName = d.Food != null ? d.Food.Name : "Không xác định", 
                    d.Quantity
                }).ToList();

            lvBillDetails.Items.Clear();
            lvBillDetails.Columns.Clear();

            lvBillDetails.Columns.Add("Id", 50);
            lvBillDetails.Columns.Add("Tên món ăn", 150);
            lvBillDetails.Columns.Add("Số lượng", 100);

            foreach (var detail in billDetails)
            {
                var item = new ListViewItem(detail.Id.ToString());
                item.SubItems.Add(detail.FoodName);
                item.SubItems.Add(detail.Quantity.ToString());
                lvBillDetails.Items.Add(item);
            }
        }

        private void lstBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBills.SelectedValue != null)
            {
                if (int.TryParse(lstBills.SelectedValue.ToString(), out int billId))
                {
                    LoadBillDetails(billId);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
