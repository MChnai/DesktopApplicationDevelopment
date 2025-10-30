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
    public partial class TableManagerForm : Form
    {
        private TableBL tableBL;
        public TableManagerForm()
        {
            tableBL = new TableBL();
            InitializeComponent();
            LoadTables();
        }
        private void LoadTables()
        {
            lvTables.Items.Clear();
            var tables = tableBL.GetAll();

            foreach (var table in tables)
            {
                string statusText = table.Status == 1 ? "Đang sử dụng" : "Trống";

                var item = new ListViewItem(table.Name);
                item.SubItems.Add(statusText);
                item.Tag = table.ID;
                lvTables.Items.Add(item);
            }
        }
        private string InputBox(string prompt, string title, string defaultValue = "")
        {
            Form inputForm = new Form
            {
                Width = 400,
                Height = 200,
                Text = title
            };

            Label lblPrompt = new Label { Text = prompt, Left = 10, Top = 20, Width = 360 };
            TextBox txtInput = new TextBox { Left = 10, Top = 50, Width = 360, Text = defaultValue };
            Button btnOk = new Button { Text = "OK", Left = 290, Top = 90, Width = 80 };

            inputForm.Controls.Add(lblPrompt);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOk);

            btnOk.Click += (s, e) => { inputForm.DialogResult = DialogResult.OK; inputForm.Close(); };
            inputForm.AcceptButton = btnOk;

            return inputForm.ShowDialog() == DialogResult.OK ? txtInput.Text : string.Empty;
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string tableName = InputBox("Nhập tên bàn mới:", "Thêm bàn");
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                Table newTable = new Table
                {
                    Name = tableName,
                    Status = 0 
                };

                if (tableBL.Insert(newTable) > 0) 
                {
                    MessageBox.Show("Thêm bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTables();
                }
                else
                {
                    MessageBox.Show("Thêm bàn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(lvTables.SelectedItems[0].Tag);
            string currentName = lvTables.SelectedItems[0].Text;
            string newName = InputBox("Sửa tên bàn:", "Sửa bàn", currentName);
            if (!string.IsNullOrWhiteSpace(newName))
            {
                if (tableBL.Update(new Table { ID = tableId, Name = newName, Status = 0 }) > 0) // Kiểm tra số dòng bị ảnh hưởng
                {
                    MessageBox.Show("Sửa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTables();
                }
                else
                {
                    MessageBox.Show("Sửa bàn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(lvTables.SelectedItems[0].Tag);
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                if (tableBL.Delete(tableId) > 0) 
                {
                    MessageBox.Show("Xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTables(); 
                }
                else
                {
                    MessageBox.Show("Xóa bàn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSplitTable_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn để tách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(lvTables.SelectedItems[0].Tag);
            string currentTableName = lvTables.SelectedItems[0].Text;
            string input = InputBox($"Nhập số lượng bàn cần tách từ bàn {currentTableName}:", "Tách bàn");
            if (!int.TryParse(input, out int numberOfTables) || numberOfTables <= 0)
            {
                MessageBox.Show("Số lượng bàn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 1; i <= numberOfTables; i++)
            {
                Table newTable = new Table
                {
                    Name = $"{currentTableName} - {i}",
                    Status = 0
                };

                if (tableBL.Insert(newTable) <= 0)
                {
                    MessageBox.Show($"Không thể tạo bàn {newTable.Name}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Tách bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTables();
        }
        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count < 2)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 2 bàn để gộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<int> tableIds = new List<int>();
            string mergedTableName = "Bàn gộp";
            foreach (ListViewItem item in lvTables.SelectedItems)
            {
                tableIds.Add(Convert.ToInt32(item.Tag));
                mergedTableName += $" + {item.Text}";
            }
            string input = InputBox("Nhập tên cho bàn mới sau khi gộp:", "Gộp bàn", mergedTableName);
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Tên bàn mới không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (int tableId in tableIds)
            {
                if (tableBL.Delete(tableId) <= 0) // Sử dụng tableId thay vì đối tượng Table
                {
                    MessageBox.Show("Không thể xóa một trong các bàn cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Table newTable = new Table
            {
                Name = input,
                Status = 0
            };

            if (tableBL.Insert(newTable) > 0)
            {
                MessageBox.Show("Gộp bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTables(); 
            }
            else
            {
                MessageBox.Show("Không thể tạo bàn mới sau khi gộp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
