using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312805_TranNgocNhuY_Lab06.Forms
{
    public partial class frmMain : Form
    {
        private TableBL tableBL;
        private Account loggedInUser;
        private BillsBL billsBL;
        private int tableId;
        public frmMain(Account account)
        {
            InitializeComponent();
            tableBL = new TableBL();
            billsBL = new BillsBL();
            LoadTables();
            tableId = GetDefaultTableId();

            loggedInUser = account;
            LoadBills(tableId);
        }
        private void LoadTables()
        {
            var tables = tableBL.GetAll(); 
            lvTables.Items.Clear();

            foreach (var table in tables)
            {
                string TableID = table.ID.ToString();
                string status = table.Status == 1 ? "Đang sử dụng" : "Trống";
                string tableName = table.Name ?? "Không tên";

                var item = new ListViewItem(new[] { tableName, status , TableID});
                lvTables.Items.Add(item);
            }
        }
        private int GetDefaultTableId()
        {
            var tables = tableBL.GetAll();
            return tables.Count > 0 ? tables[0].ID : -1; 
        }
        private void LoadBills(int tableId)
        {
            lvBills.Items.Clear();

            var bills = billsBL.GetAllStatus0();
            foreach (var bill in bills)
            {
                var item = new ListViewItem(bill.ID.ToString());
                item.SubItems.Add(bill.Name);
                item.SubItems.Add(bill.CheckoutDate.ToString("yyyy/MM/dd"));
                item.SubItems.Add(bill.Amount.ToString("C")); 
                item.Tag = bill.ID; 
                lvBills.Items.Add(item);
            }
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count > 0)
            {
                frmOder orderForm = new frmOder(loggedInUser);
                int selectedBillId = GetSelectedBillId();
                orderForm.TableID = Convert.ToInt32(lvTables.SelectedItems[0].SubItems[2].Text);
                orderForm.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
                orderForm.Show();
            }
        }
        private int GetSelectedBillId()
        {
            if (lvBills.SelectedItems.Count > 0)
            {
                return Convert.ToInt32(lvBills.SelectedItems[0].Tag); 
            }

            return -1; 
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            int selectedBillId = GetSelectedBillId();

            if (selectedBillId > 0)
            {
                var paymentForm = new frmPayment(selectedBillId);
                paymentForm.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
                paymentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnTableManager_Click(object sender, EventArgs e)
        {
            var tableManagerForm = new TableManagerForm();
            tableManagerForm.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
            tableManagerForm.ShowDialog();
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportForm = new frmReport();
            reportForm.ShowDialog();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.LoadTables();
            this.LoadBills(tableId);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lvBills.SelectedItems.Count > 0)
            {
                frmOder orderForm = new frmOder(loggedInUser, Convert.ToInt32(lvBills.SelectedItems[0].SubItems[0].Text));
                int selectedBillId = GetSelectedBillId();
                orderForm.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
                orderForm.Show();
            }
        }
    }
}
