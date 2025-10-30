using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;


namespace _2312805_TranNgocNhuY_Lab06.Forms
{
    public partial class FoodForm : Form
    {
        List<Category> listCategory = new List<Category>();
        List<Food> listFood = new List<Food>();
        Food foodCurrent = new Food();
        public FoodForm()
        {
            InitializeComponent();
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnit.Text = string.Empty;
            if(cbbCategory.Items.Count > 0) 
                cbbCategory.SelectedIndex = 0;
        }
        //Load food form
        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }
        private void LoadFoodDataToListView()
        {           
            FoodBL foodBL = new FoodBL();
            listFood = foodBL.GetAll();
            int count = 1;
            lsvFood.Items.Clear();
            foreach (var food in listFood)
            {
                if (food == null)
                    continue;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(food.Name ?? "N/A"); 
                item.SubItems.Add(food.Unit ?? "N/A"); 
                item.SubItems.Add(food.Price.ToString("N0")); 
                var category = listCategory.Find(x => x.ID == food.FoodCategoryID);
                item.SubItems.Add(category?.Name ?? "Unknown Category");
                item.SubItems.Add(food.Notes ?? "No notes");
                lsvFood.Items.Add(item);
                count++;
            }
        }
        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodDataToListView();
            lblStatistic.Text = $"Tổng số món ăn: {listFood.Count}";
        }
        //food list click
        private void lsvFood_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvFood.Items.Count; i++)
            {
                if (lsvFood.Items[i].Selected)
                {
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtUnit.Text = foodCurrent.Unit;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;
                    cbbCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }
        //insert food
        public int InsertFood()
        {
            Food food = new Food();
            food.ID = 0;
            if (string.IsNullOrEmpty(txtName?.Text) || string.IsNullOrEmpty(txtUnit?.Text) || string.IsNullOrEmpty(txtPrice?.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
                return -1;
            }
            else
            {
                food.Name = txtName?.Text ?? string.Empty;
                food.Unit = txtUnit?.Text ?? string.Empty;
                food.Notes = txtNotes?.Text ?? string.Empty;
                int price = 0;
                if (!int.TryParse(txtPrice?.Text, out price))
                {
                    price = 0; 
                }
                food.Price = price;
                int foodCategoryId = 0;
                if (!int.TryParse(cbbCategory?.SelectedValue?.ToString(), out foodCategoryId))
                {
                    MessageBox.Show("Giá trị danh mục không hợp lệ.");
                    return -1;
                }
                food.FoodCategoryID = foodCategoryId;
                FoodBL foodBL = new FoodBL();
                return foodBL.Insert(food);
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thực phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Food food = new Food
                {
                    Name = txtName.Text.Trim(),
                    Unit = txtUnit.Text.Trim(),
                    FoodCategoryID = Convert.ToInt32(cbbCategory.SelectedValue),
                    Price = int.TryParse(txtPrice.Text.Trim(), out int price) ? price : 0,
                    Notes = txtNotes.Text.Trim()
                };
                int result = new FoodBL().Insert(food);
                if (result > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    LoadFoodDataToListView();
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
        //delete food
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (foodCurrent == null || foodCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn món ăn để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá món ăn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = new FoodBL().Delete(foodCurrent.ID);
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá món ăn thành công!");
                        LoadFoodDataToListView();
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
        //update food
        public int UpdateFood()
        {
            if (foodCurrent == null)
            {
                MessageBox.Show("Không có dữ liệu Food hiện hành để cập nhật.");
                return -1;
            }
            Food food = foodCurrent;
            if (string.IsNullOrEmpty(txtName?.Text) || string.IsNullOrEmpty(txtUnit?.Text) || string.IsNullOrEmpty(txtPrice?.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            }
            else
            {
                food.Name = txtName?.Text ?? string.Empty;
                food.Unit = txtUnit?.Text ?? string.Empty;
                food.Notes = txtNotes?.Text ?? string.Empty;
                int price = 0;
                if (!int.TryParse(txtPrice?.Text, out price))
                {
                    price = 0; 
                }
                food.Price = price;
                int foodCategoryId = 0;
                if (!int.TryParse(cbbCategory?.SelectedValue?.ToString(), out foodCategoryId))
                {
                    MessageBox.Show("Giá trị danh mục không hợp lệ.");
                    return -1;
                }
                food.FoodCategoryID = foodCategoryId;
                FoodBL foodBL = new FoodBL();
                return foodBL.Update(food);
            }

            return -1;
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (foodCurrent == null || foodCurrent.ID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn món ăn để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thực phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Food food = new Food
                {
                    ID = foodCurrent.ID,
                    Name = txtName.Text.Trim(),
                    Unit = txtUnit.Text.Trim(),
                    FoodCategoryID = Convert.ToInt32(cbbCategory.SelectedValue),
                    Price = int.TryParse(txtPrice.Text.Trim(), out int price) ? price : 0,
                    Notes = txtNotes.Text.Trim()
                };
                int result = new FoodBL().Update(food);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    LoadFoodDataToListView();
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
