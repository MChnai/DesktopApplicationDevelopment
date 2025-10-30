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
    public partial class frmTable : Form
    {
        List<Table> listTable = new List<Table>();
        Table tableCurrent = new Table();
        public frmTable()
        {
            InitializeComponent();
        }
        //Exit button
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //clear button
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCapacity.Text = "0";
            if (cbbStatus.Items.Count > 0)
            {
                cbbStatus.SelectedIndex = 0; 
            }
        }
        //Load table table
        private void LoadTableDataToListView()
        {
            TableBL tableBL = new TableBL();
            listTable = tableBL.GetAll();
            int count = 1;
            lsvTable.Items.Clear();
            foreach (var table in listTable)
            {
                if (table == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(table.Name ?? "N/A"); 
                item.SubItems.Add(GetStatusText(table.Status)); 
                item.SubItems.Add(table.Capacity.ToString());
                lsvTable.Items.Add(item);

                count++;
            }
        }
        private string GetStatusText(int status)
        {
            switch (status)
            {
                case 0:
                    return "Trống";
                case 1:
                    return "Đang sử dụng";
                case 2:
                    return "Đã đặt trước";
                default:
                    return "Không xác định";
            }
        }
        private void frmTable_Load(object sender, EventArgs e)
        {
            cbbStatus.Items.Clear();
            cbbStatus.Items.Add("1 - Trống");
            cbbStatus.Items.Add("2 - Đang sử dụng");
            cbbStatus.Items.Add("3 - Đã đặt trước");
            cbbStatus.SelectedIndex = 0;
            LoadTableDataToListView();
        }
        //select index change
        private void lsvTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvTable.Items.Count; i++)
            {
                if (lsvTable.Items[i].Selected)
                {
                    tableCurrent = listTable[i];
                    txtName.Text = tableCurrent.Name;
                    cbbStatus.SelectedIndex = tableCurrent.Status; // Chọn trạng thái tương ứng
                    txtCapacity.Text = tableCurrent.Capacity.ToString();
                }
            }
        }
        //Insert update delete table
        public int InsertTable()
        {
            Table table = new Table();
            table.ID = 0;
            if (string.IsNullOrEmpty(txtName?.Text) || string.IsNullOrEmpty(txtCapacity?.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại.");
                return -1;
            }
            table.Name = txtName?.Text ?? string.Empty;
            table.Status = cbbStatus.SelectedIndex; 
            if (!int.TryParse(txtCapacity?.Text, out int capacity))
            {
                capacity = 0; 
            }
            table.Capacity = capacity;
            TableBL tableBL = new TableBL();
            return tableBL.Insert(table);
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int result = InsertTable();

                if (result > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    LoadTableDataToListView();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int UpdateTable()
        {
            if (tableCurrent == null || tableCurrent.ID <= 0)
            {
                MessageBox.Show("Vui lòng chọn bàn để cập nhật.");
                return -1;
            }
            tableCurrent.Name = txtName?.Text ?? string.Empty;
            tableCurrent.Status = cbbStatus.SelectedIndex;

            if (!int.TryParse(txtCapacity?.Text, out int capacity))
            {
                capacity = 0;
            }
            tableCurrent.Capacity = capacity;
            TableBL tableBL = new TableBL();
            return tableBL.Update(tableCurrent);
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int result = UpdateTable();

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    LoadTableDataToListView();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableCurrent == null || tableCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn để xóa.");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new TableBL().Delete(tableCurrent.ID);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!");
                        LoadTableDataToListView();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công. Vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
