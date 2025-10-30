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
    public partial class CategoryFoodForm : Form
    {
        public CategoryFoodForm()
        {
            InitializeComponent();
        }
        private List<Category> GetCategories()
        {
            var dbContext = new RestaurantContext();
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
        }
        private void ShowCategories()
        {
            tvwCategory.Nodes.Clear();
            var cateMap = new Dictionary<CategoryType, string>()
            {
                [CategoryType.Food] = "Đồ ăn",
                [CategoryType.Drink] = "Thức uống"
            };
            var rootNode = tvwCategory.Nodes.Add("Tất cả");
            var categories = GetCategories();
            foreach (var cateType in cateMap)
            {
                var childNode = rootNode.Nodes.Add(cateType.Key.ToString(), cateType.Value);
                childNode.Tag = cateType.Key;
                foreach (var category in categories)
                {
                    if (category.Type != cateType.Key)
                        continue;
                    var grantChildNode = childNode.Nodes.Add(category.Id.ToString(), category.Name);
                    grantChildNode.Tag = category;
                }
            }
            tvwCategory.ExpandAll();
            tvwCategory.SelectedNode = rootNode;
        }
        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            var dbContext = new RestaurantContext();
            var foods = dbContext.Foods.AsQueryable();
            if (categoryId != null && categoryId > 0)
            {
                foods = foods.Where(x => x.FoodCategoryId == categoryId);
            }
            return foods
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }
        private List<FoodModel> GetFoodByCategoryType(CategoryType cateType)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Foods
                .Where(x => x.Category.Type == cateType)
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                })
                .ToList();

        }
        private void ShowFoodsOnListView(List<FoodModel> foods)
        {
            foreach (var foodItem in foods)
            {
                var item = lvwFood.Items.Add(foodItem.Id.ToString());
                item.SubItems.Add(foodItem.Name);
                item.SubItems.Add(foodItem.Unit);
                item.SubItems.Add(foodItem.Price.ToString("##,###"));
                item.SubItems.Add(foodItem.CategoryName);
                item.SubItems.Add(foodItem.Notes);
            }
        }
        private void ShowFoodForNode(TreeNode node)
        {
            lvwFood.Items.Clear();
            if (node == null)
                return;
            List<FoodModel> foods = new List<FoodModel>();
            if (node.Level == 1)
            {
                var categoryType = (CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }
            else
            {
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.Id);
            }
            ShowFoodsOnListView(foods);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }
        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
        }
        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e?.Node != null)
            {
                ShowFoodForNode(e.Node);
            }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateCategoryForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShowCategories();
            }
        }
        private void tvwCategory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Level < 2 || e.Node.Tag == null)
            {
                return;
            }

            var category = e.Node.Tag as Category;
            var dialog = new UpdateCategoryForm(category?.Id);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }
        private void btnReloadFood_Click(object sender, EventArgs e)
        {
            ShowFoodForNode(tvwCategory.SelectedNode);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwFood?.SelectedItems == null || lvwFood.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem selectedItem = lvwFood.SelectedItems[0];
            if (selectedItem == null || string.IsNullOrWhiteSpace(selectedItem.Text))
            {
                return;
            }
            if (!int.TryParse(selectedItem.Text, out int selectedFoodId))
            {
                MessageBox.Show("ID món ăn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dbContext = new RestaurantContext();
            var selectedFood = dbContext.Foods?.Find(selectedFoodId);
            if (selectedFood != null)
            {
                dbContext.Foods.Remove(selectedFood);
                dbContext.SaveChanges();
                lvwFood.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Không tìm thấy món ăn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateFoodForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodForNode(tvwCategory.SelectedNode);
            }
        }
        private void lvwFood_DoubleClick(object sender, EventArgs e)
        {
            if (lvwFood.SelectedItems.Count == 0)
            {
                return;
            }

            var foodId = int.Parse(lvwFood.SelectedItems[0].Text);
            var dialog = new UpdateFoodForm(foodId);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodForNode(tvwCategory.SelectedNode);
            }
        }
    }
}
