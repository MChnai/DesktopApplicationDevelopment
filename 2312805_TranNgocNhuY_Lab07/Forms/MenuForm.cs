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
    public partial class MenuForm : Form
    {
        private RestaurantContext _context;
        public MenuForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            ShowCategories();
        }
        private List<Category> GetCategories()
        {
            var dbContext = new RestaurantContext();
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
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
        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            var menuItems = new List<string>();

            foreach (ListViewItem item in lvwFood.Items)
            {
                var name = item.Text;
                var unit = item.SubItems[1].Text;
                var category = item.SubItems[2].Text;
                var price = item.SubItems[3].Text;
                var notes = item.SubItems[4].Text;

                menuItems.Add($"Tên món: {name}, Đơn vị: {unit}, Nhóm: {category}, Giá: {price}, Ghi chú: {notes}");
            }
            var menuContent = string.Join(Environment.NewLine, menuItems);
            MessageBox.Show(menuContent, "Thực đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e?.Node != null)
            {
                ShowFoodForNode(e.Node);
            }
        }
    }
}
