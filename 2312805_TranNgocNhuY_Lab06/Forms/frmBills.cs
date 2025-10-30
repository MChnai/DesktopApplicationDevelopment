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
    public partial class frmBills : Form
    {
        List<Bills> listBills = new List<Bills>();
        Bills billCurrent = new Bills();
        public frmBills()
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
            txtName.Text = "";
            txtTableID.Text = "";
            txtAmount.Text = "0";
            txtDiscount.Text = "0";
            txtTax.Text = "0";
            txtAccount.Text = "";
            cbbStatus.SelectedIndex = 0; 
            dtpCheckoutDate.Value = DateTime.Now;
        }
        //Load bill table
        private void LoadBillsDataToListView()
        {
            BillsBL billsBL = new BillsBL();
            listBills = billsBL.GetAllStatus0();
            listBills = listBills.OrderBy(bill => bill.Name).ToList();
            int count = 1;
            lsvBills.Items.Clear();
            foreach (var bill in listBills)
            {
                if (bill == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(bill.Name ?? "N/A"); 
                item.SubItems.Add(bill.TableID.ToString()); 
                item.SubItems.Add(bill.Amount.ToString("N0")); 
                item.SubItems.Add(bill.Discount.ToString("P0")); 
                item.SubItems.Add(bill.Status ? "Đã thanh toán" : "Chưa thanh toán"); 
                item.SubItems.Add(bill.Tax.ToString("P0")); 
                item.SubItems.Add(bill.CheckoutDate.ToString("dd/MM/yyyy")); 
                item.SubItems.Add(bill.Account ?? "N/A"); 
                lsvBills.Items.Add(item);
                count++;
            }
        }
        private void frmBills_Load(object sender, EventArgs e)
        {
            cbbStatus.Items.Clear();
            cbbStatus.Items.Add("Chưa thanh toán");
            cbbStatus.Items.Add("Đã thanh toán");
            cbbStatus.SelectedIndex = 0;
            LoadBillsDataToListView();
            lblStatistic.Text = $"Tổng số hóa đơn: {listBills.Count}";
        }
        //Insert Update Delete Bills
        public int InsertBill()
        {
            if (string.IsNullOrEmpty(txtName?.Text) || string.IsNullOrEmpty(txtTableID?.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hóa đơn và mã bàn.");
                return -1;
            }
            Bills bill = new Bills
            {
                Name = txtName.Text,
                Account = txtAccount.Text,
                TableID = int.TryParse(txtTableID.Text, out int tableId) ? tableId : 0,
                Amount = int.TryParse(txtAmount.Text, out int amount) ? amount : 0,
                Discount = float.TryParse(txtDiscount.Text, out float discount) ? discount : 0,
                Tax = float.TryParse(txtTax.Text, out float tax) ? tax : 0,
                CheckoutDate = dtpCheckoutDate.Value,
                Status = cbbStatus.SelectedIndex == 1 
            };

            BillsBL billsBL = new BillsBL();
            return billsBL.Insert(bill);
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int result = InsertBill();

                if (result > 0)
                {
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    LoadBillsDataToListView();
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn không thành công. Vui lòng thử lại.");
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
                if (billCurrent == null || billCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new BillsBL().Delete(billCurrent);
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá hóa đơn thành công!");
                        LoadBillsDataToListView();
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
        public int UpdateBill()
        {
            try
            {
                if (billCurrent == null)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để cập nhật.");
                    return -1; 
                }
                billCurrent.Name = txtName.Text ?? string.Empty;
                billCurrent.Account = txtAccount.Text ?? string.Empty;
                billCurrent.TableID = int.TryParse(txtTableID.Text, out int tableId) ? tableId : 0;
                billCurrent.Amount = int.TryParse(txtAmount.Text, out int amount) ? amount : 0;
                billCurrent.Discount = float.TryParse(txtDiscount.Text, out float discount) ? discount : 0;
                billCurrent.Tax = float.TryParse(txtTax.Text, out float tax) ? tax : 0;
                billCurrent.CheckoutDate = dtpCheckoutDate.Value;
                billCurrent.Status = cbbStatus.SelectedIndex == 1;
                BillsBL billsBL = new BillsBL();
                int result = billsBL.Update(billCurrent);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!");
                    LoadBillsDataToListView();
                    return result; 
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn không thành công.");
                    return 0; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; 
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int result = UpdateBill();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    LoadBillsDataToListView();
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
        //selection index change of list bills
        private void lsvBills_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvBills.Items.Count; i++)
            {
                if (lsvBills.Items[i].Selected)
                {
                    billCurrent = listBills[i];
                    txtName.Text = billCurrent.Name;
                    txtTableID.Text = billCurrent.TableID.ToString();
                    txtAmount.Text = billCurrent.Amount.ToString();
                    txtDiscount.Text = billCurrent.Discount.ToString();
                    txtTax.Text = billCurrent.Tax.ToString();
                    txtAccount.Text = billCurrent.Account;
                    dtpCheckoutDate.Value = billCurrent.CheckoutDate;
                    cbbStatus.SelectedIndex = billCurrent.Status ? 1 : 0;
                }
            }
        }
    }
}
