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
    public partial class TableForm : Form
    {
        private RestaurantContext _context;
        public TableForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadTables();
        }
        private void LoadTables()
        {
            lvTables.Items.Clear();
            var tables = _context.Tables.ToList();
            foreach (var table in tables)
            {
                var item = new ListViewItem(table.Id.ToString());
                item.SubItems.Add(table.Name ?? "Unknown"); 
                item.SubItems.Add(table.Status.ToString()); 
                item.SubItems.Add(table.Capacity.ToString());

                lvTables.Items.Add(item);
            }
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCapacity.Text = "0";
            txtStatus.Text = "0";
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse(txtStatus.Text, out TableStatus status))
            {
                MessageBox.Show("Trạng thái không hợp lệ. Vui lòng nhập 'Available', 'Reserved', hoặc 'Occupied'.");
                return;
            }
            var table = new Table01
            {
                Name = txtName.Text,
                Status = status, 
                Capacity = int.Parse(txtCapacity.Text)
            };
            _context.Tables.Add(table);
            _context.SaveChanges();
            LoadTables();
            MessageBox.Show("Đã thêm bàn thành công");
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count > 0)
            {
                int id = int.Parse(lvTables.SelectedItems[0].Text);
                var table = _context.Tables.Find(id);

                if (table != null)
                {
                    table.Name = txtName.Text;

                    if (!Enum.TryParse(txtStatus.Text, out TableStatus status))
                    {
                        MessageBox.Show("Trạng thái không hợp lệ. Vui lòng nhập 'Available', 'Reserved', hoặc 'Occupied'.");
                        return;
                    }
                    table.Status = status;

                    table.Capacity = int.Parse(txtCapacity.Text);

                    _context.SaveChanges();
                    LoadTables();
                    MessageBox.Show("Đã cập nhật bàn thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn để cập nhật.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để cập nhật.");
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count > 0)
            {
                int id = int.Parse(lvTables.SelectedItems[0].Text);
                var table = _context.Tables.Find(id);

                _context.Tables.Remove(table);
                _context.SaveChanges();
                LoadTables();
                MessageBox.Show("Đã xóa bàn thành công");
            }
        }
        private void tsmiDeleteTable_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }
        private void tsmiViewBillDetails_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count > 0)
            {
                var billForm = new BillDetailsForm(lvTables.SelectedItems[0].SubItems[1].Text);
                billForm.ShowDialog();
            }
        }
        private void lvTables_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvTables.Items.Count; i++)
            {
                if (lvTables.Items[i].Selected)
                {
                    ListViewItem tableCurrent = lvTables.Items[i];
                    txtName.Text = tableCurrent.SubItems[1].Text;
                    txtStatus.Text = tableCurrent.SubItems[2].Text; 
                    txtCapacity.Text = tableCurrent.SubItems[3].Text;
                }
            }
        }
        private void tsmiViewSalesLog_Click(object sender, EventArgs e)
        {
            string _tableName = lvTables.SelectedItems[0].SubItems[1].Text;
            var table = _context.Tables.FirstOrDefault(t => t.Name == _tableName);
            var salesLogForm = new SalesLogForm(table.Id);
            salesLogForm.ShowDialog();
        }
    }
}
