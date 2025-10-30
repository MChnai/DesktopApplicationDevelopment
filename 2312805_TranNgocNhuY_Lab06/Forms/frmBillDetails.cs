using BusinessLogic;
using DataAccess;
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
    public partial class frmBillDetails : Form
    {
        List<BillDetails> listBillDetails = new List<BillDetails>();
        List<Bills> listBills = new List<Bills>();
        List<Food> listFood = new List<Food>();
        BillDetails billDetailsCurrent = new BillDetails();
        public frmBillDetails()
        {
            InitializeComponent();
        }
        //Exit button
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Clear button
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "0";
            if (cbbInvoice.Items.Count > 0)
                cbbInvoice.SelectedIndex = 0;
            if (cbbFood.Items.Count > 0)
                cbbFood.SelectedIndex = 0;
        }
        //Load Bill Detail Table
        private void LoadInvoices()
        {            
            BillsBL billsBL = new BillsBL();
            listBills = billsBL.GetAllStatus0();
            cbbInvoice.DataSource = listBills;
            cbbInvoice.ValueMember = "ID";
            cbbInvoice.DisplayMember = "Name";
        }
        private void LoadBillDetailsToListView()
        {
            BillDetailsBL billDetailsBL = new BillDetailsBL();
            listBillDetails = billDetailsBL.GetAll();
            int count = 1;
            lsvBillDetails.Items.Clear();
            foreach (var detail in listBillDetails)
            {
                if (detail == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                var bill = listBills.Find(x => x.ID == detail.InvoiceID);
                item.SubItems.Add(bill?.Name ?? "Unknown Invoice");

                var food = listFood.Find(x => x.ID == detail.FoodID);
                item.SubItems.Add(food?.Name ?? "Unknown Food");

                item.SubItems.Add(detail.Quantity.ToString());
                lsvBillDetails.Items.Add(item);
                count++;
            }
        }
        private void LoadFood()
        {
            FoodBL foodBL = new FoodBL();
            listFood = foodBL.GetAll();
            cbbFood.DataSource = listFood;
            cbbFood.ValueMember = "ID";
            cbbFood.DisplayMember = "Name";
        }
        private void frmBillDetails_Load(object sender, EventArgs e)
        {
            LoadInvoices();
            LoadFood();
            LoadBillDetailsToListView();
            lblStatistic.Text = $"Tổng số hóa đơn: {listBillDetails.Count}";
        }
        //selection index change
        private void lsvBillDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvBillDetails.Items.Count; i++)
            {
                if (lsvBillDetails.Items[i].Selected)
                {
                    billDetailsCurrent = listBillDetails[i];
                    cbbInvoice.SelectedIndex = listBills.FindIndex(x => x.ID == billDetailsCurrent.InvoiceID);
                    cbbFood.SelectedIndex = listFood.FindIndex(x => x.ID == billDetailsCurrent.FoodID);
                    txtQuantity.Text = billDetailsCurrent.Quantity.ToString();
                }
            }
        }
        //Insert Update Delete Bill Detail
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Vui lòng nhập số lượng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BillDetails detail = new BillDetails
                {
                    InvoiceID = Convert.ToInt32(cbbInvoice.SelectedValue),
                    FoodID = Convert.ToInt32(cbbFood.SelectedValue),
                    Quantity = int.TryParse(txtQuantity.Text.Trim(), out int quantity) ? quantity : 0
                };
                int result = new BillDetailsBL().Insert(detail);
                if (result > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    LoadBillDetailsToListView();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (billDetailsCurrent == null || billDetailsCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá chi tiết này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new BillDetailsBL().Delete(billDetailsCurrent);
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá chi tiết thành công!");
                        LoadBillDetailsToListView();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (billDetailsCurrent == null || billDetailsCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BillDetails detail = new BillDetails
                {
                    ID = billDetailsCurrent.ID,
                    InvoiceID = Convert.ToInt32(cbbInvoice.SelectedValue),
                    FoodID = Convert.ToInt32(cbbFood.SelectedValue),
                    Quantity = int.TryParse(txtQuantity.Text.Trim(), out int quantity) ? quantity : 0
                };
                int result = new BillDetailsBL().Update(detail);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    LoadBillDetailsToListView();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }   
}
