﻿using _2312805_TranNgocNhuY_lab07.Models;
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
    public partial class UpdateCategoryForm : Form
    {
        private RestaurantContext _dbContext;
        private int _categoryId;

        public UpdateCategoryForm()
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
        }
        public UpdateCategoryForm(int? categoryId = null)
        {
            InitializeComponent();

            _dbContext = new RestaurantContext();
            _categoryId = categoryId ?? 0;
        }
        private Category GetCategoryById(int categoryId)
        {
            return categoryId > 0 ? _dbContext.Categories.Find(categoryId) : null;
        }
        private void ShowCategory()
        {
            var category = GetCategoryById(_categoryId);
            if (category == null)
                return;
            txtCategoryId.Text = category.Id.ToString();
            txtCategoryName.Text = category.Name;
            cbbCategoryType.SelectedIndex = (int)category.Type - 1;
        }
        private Category GetUpdatedCategory()
        {
            var category = new Category()
            {
                Name = txtCategoryName.Text.Trim(),
                Type = (CategoryType)cbbCategoryType.SelectedIndex + 1
            };
            if (_categoryId > 0)
            {
                category.Id = _categoryId;
            }

            return category;
        }
        private bool ValidateUserInput()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhám thức ăn không được để trống", "Thông báo");
                return false;
            }
            if (cbbCategoryType.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại nhóm thức ăn", "Thông báo");
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                var newCategory = GetUpdatedCategory();
                var oldCategory = GetCategoryById(_categoryId);
                if (oldCategory == null)
                {
                    _dbContext.Categories.Add(newCategory);
                }
                else
                {
                    oldCategory.Name = newCategory.Name;
                    oldCategory.Type = newCategory.Type;
                }
                _dbContext.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }
        private void UpdateCategoryForm_Load(object sender, EventArgs e)
        {
            ShowCategory();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
