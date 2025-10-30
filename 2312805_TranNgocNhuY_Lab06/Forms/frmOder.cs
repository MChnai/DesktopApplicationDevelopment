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
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;

namespace _2312805_TranNgocNhuY_Lab06.Forms
{
    public partial class frmOder : Form
    {
        private FoodBL foodBL;
        private BillDetailsBL billDetailsBL;
        private BillsBL billsBL; 
        private Account loggedInUser;
        private List<string> foods = new List<string>();
        private int billID {  get; set; }
        public int TableID {  get; set; }
        public frmOder(Account account)
        {
            InitializeComponent();
            foodBL = new FoodBL();
            billDetailsBL = new BillDetailsBL();
            LoadFoodMenu();
            billsBL = new BillsBL(); 
            billID = 0;
            loggedInUser = account;
        }
        public frmOder(Account account, int billID)
        {
            InitializeComponent();
            foodBL = new FoodBL();
            billDetailsBL = new BillDetailsBL();
            LoadFoodMenu();
            billsBL = new BillsBL(); 
            loggedInUser = account;
            this.billID = billID;
            LoadBill();
        }
        private void LoadBill()
        {
            foods = foodBL.GetFoodByID(billID);
            lvOrder.Items.Clear();
            foreach (string food in foods)
            {
                ListViewItem item = new ListViewItem();
                string[] list = food.Split(',');
                item.Text = list[0];
                item.SubItems.Add(list[1]);
                item.SubItems.Add(list[2]);
                lvOrder.Items.Add(item);
            }
        }
        private void LoadFoodMenu()
        {
            var foods = foodBL.GetAll();
            lsvFood.Items.Clear();
            foreach (var food in foods)
            {
                ListViewItem item = new ListViewItem();
                item.Text = food.Name;
                item.SubItems.Add(food.Price.ToString());
                item.SubItems.Add(food.Notes);
                lsvFood.Items.Add(item);
            }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (lsvFood.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvFood.SelectedItems[0];
                string foodName = item.Text ?? "Không xác định";
                decimal price = item.SubItems[1].Text != null ? Convert.ToDecimal(item.SubItems[1].Text) : 0;
                decimal quantity = nudQuantity.Value.ToString() != null ? Convert.ToDecimal(nudQuantity.Value.ToString()) : 0;
                lvOrder.Items.Add(new ListViewItem(new[] { foodName, price.ToString("C"), quantity.ToString()}));
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            if (lvOrder.SelectedItems.Count > 0)
            {
                if(billID != 0)
                {
                    int ID = 0;
                    int index = 0;
                    foreach(string food in foods)
                    {
                        string[] list = food.Split(',');
                        if (list[0] == lvOrder.SelectedItems[0].Text)
                        {
                            food.Remove(index);
                            ID = Convert.ToInt32(list[4]);
                        }
                        index++;
                    }
                    BillDetails bill = new BillDetails();
                    bill.ID = ID;
                    billDetailsBL.Delete(bill);
                }
                foreach (ListViewItem item in lvOrder.SelectedItems)
                {
                    lvOrder.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (lvOrder.Items.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào trong đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal amount = 0;
            foreach (ListViewItem item in lvOrder.Items)
            {
                string strTotal = item.SubItems[1].Text.Replace("$", "");
                strTotal = strTotal.Replace(",", "");
                amount += Convert.ToDecimal(strTotal);
            }
            if(billID == 0)
            {
                Bills bill = new Bills
                {
                    Name = "Hóa đơn của " + loggedInUser.FullName,
                    Account = loggedInUser.AccountName,
                    Date =  DateTime.Now,
                    TableID = TableID,
                    Amount = Convert.ToInt32(amount),
                    Total = 0
                };
                int invoice = billsBL.Insert(bill);
                foreach (ListViewItem item in lvOrder.Items)
                {
                    string foodName = item.SubItems[0].Text;
                    decimal price = decimal.Parse(item.SubItems[1].Text, System.Globalization.NumberStyles.Currency);
                    var food = foodBL.GetByName(foodName);
                    if (food != null)
                    {
                        BillDetails billDetail = new BillDetails
                        {
                            InvoiceID = invoice,
                            FoodID = food.ID,
                            Quantity = Convert.ToInt32(item.SubItems[2].Text),
                            ID = bill.ID,
                        };
                        billDetailsBL.Insert(billDetail);
                    }
                }

                MessageBox.Show("Đã tạo đơn hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                for (int i  = foods.Count() + 1; i <= lvOrder.Items.Count; i++)
                {
                    ListViewItem item = lvOrder.Items[i - 1];
                    string foodName = item.SubItems[0].Text;
                    decimal price = decimal.Parse(item.SubItems[1].Text, System.Globalization.NumberStyles.Currency);
                    var food = foodBL.GetByName(foodName);
                    if (food != null)
                    {
                        BillDetails billDetail = new BillDetails
                        {
                            InvoiceID = billID,
                            FoodID = food.ID,
                            Quantity = Convert.ToInt32(item.SubItems[2].Text),
                            ID = billID,
                        };
                        billDetailsBL.Insert(billDetail);
                    }
                }

                MessageBox.Show("Đã lưu thông tin hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
