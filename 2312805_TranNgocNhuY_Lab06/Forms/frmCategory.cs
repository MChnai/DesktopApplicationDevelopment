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
    public partial class frmCategory : Form
    {
        List<Category> listCategory = new List<Category>();
        Category categoryCurrent = new Category();
        public frmCategory()
        {
            InitializeComponent();
        }
        //Exit button
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Load category table
        private void LoadCategoryDataToListView()
        {
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();
            int count = 1;
            lsvCategory.Items.Clear();
            cbbType.Items.Clear();
            foreach (var category in listCategory)
            {
                if (category == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(category.Name ?? "N/A"); 
                item.SubItems.Add(category.Type.ToString()); 
                lsvCategory.Items.Add(item);
                if (!cbbType.Items.Contains(category.Type.ToString()))
                    cbbType.Items.Add(category.Type.ToString());
                count++;
            }

            lblStatistic.Text = $"Tổng số danh mục: {listCategory.Count}";
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadCategoryDataToListView();
        }
        //select index change
        private void lsvCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvCategory.Items.Count; i++)
            {
                if (lsvCategory.Items[i].Selected)
                {
                    categoryCurrent = listCategory[i];
                    txtName.Text = categoryCurrent.Name;
                    cbbType.Text = categoryCurrent.Type.ToString();
                }
            }
        }
        //clear button
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            if (cbbType.Items.Count > 0)
                cbbType.SelectedIndex = 0;
        }
        //Insert Update Delete category
        private int InsertCategory()
        {
            if (string.IsNullOrEmpty(txtName?.Text))
            {
                MessageBox.Show("Chưa nhập tên danh mục, vui lòng nhập lại.");
                return -1;
            }

            Category category = new Category
            {
                Name = txtName.Text.Trim(),
                Type = cbbType.SelectedIndex
            };

            CategoryBL categoryBL = new CategoryBL();
            int result = categoryBL.Insert(category);

            if (result > 0)
            {
                MessageBox.Show("Thêm danh mục thành công!");
            }
            else
            {
                MessageBox.Show("Thêm danh mục không thành công. Vui lòng thử lại.");
            }

            return result;
        }
        private int UpdateCategory()
        {
            if (categoryCurrent == null || categoryCurrent.ID <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            categoryCurrent.Name = txtName.Text.Trim();
            categoryCurrent.Type = Convert.ToInt32(cbbType.Text);

            CategoryBL categoryBL = new CategoryBL();
            int result = categoryBL.Update(categoryCurrent);

            if (result > 0)
            {
                MessageBox.Show("Cập nhật danh mục thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục không thành công. Vui lòng thử lại.");
            }

            return result;
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int result = InsertCategory();

                if (result > 0)
                {
                    MessageBox.Show("Thêm danh mục thành công!");
                    LoadCategoryDataToListView();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục không thành công. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int result = UpdateCategory();

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật danh mục thành công!");
                    LoadCategoryDataToListView();
                }
                else
                {
                    MessageBox.Show("Cập nhật danh mục không thành công. Vui lòng thử lại.");
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
                if (categoryCurrent == null || categoryCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new CategoryBL().Delete(categoryCurrent.ID);

                    if (result > 0)
                    {
                        MessageBox.Show("Xoá danh mục thành công!");
                        LoadCategoryDataToListView();
                    }
                    else
                    {
                        MessageBox.Show("Xoá danh mục không thành công. Vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
