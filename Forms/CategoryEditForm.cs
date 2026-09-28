using Mart_Management_System.Models;
using Mart_Management_System.Repositories;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Forms
{
    public partial class CategoryEditForm : Form
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly Category? _category;

        public CategoryEditForm()
            : this(null)
        {
        }

        public CategoryEditForm(Category? category)
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            _categoryRepository = new CategoryRepository();
            _category = category;

            if (_category is not null)
            {
                Text = "Edit Category";
                btnSave.Text = "Update Category";
                txtCategoryName.Text = _category.CategoryName;
                txtDescription.Text = _category.Description ?? string.Empty;
                chkActive.Checked = _category.IsActive;
            }
            else
            {
                Text = "Add Category";
                btnSave.Text = "Save Category";
                chkActive.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string categoryName = txtCategoryName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ShowError("Category name is required.");
                txtCategoryName.Focus();
                return;
            }

            if (categoryName.Length > 100)
            {
                ShowError("Category name cannot exceed 100 characters.");
                txtCategoryName.Focus();
                return;
            }

            if (description.Length > 255)
            {
                ShowError("Description cannot exceed 255 characters.");
                txtDescription.Focus();
                return;
            }

            Category category = _category is null
                ? new Category()
                : new Category
                {
                    CategoryId = _category.CategoryId,
                    CreatedAt = _category.CreatedAt
                };

            category.CategoryName = categoryName;
            category.Description = string.IsNullOrWhiteSpace(description)
                ? null
                : description;
            category.IsActive = chkActive.Checked;

            try
            {
                bool saved = _category is null
                    ? _categoryRepository.Create(category)
                    : _categoryRepository.Update(category);

                if (!saved)
                {
                    ShowError("The category could not be saved. Please try again.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number is 2601 or 2627)
            {
                ShowError("A category with this name already exists.");
            }
            catch (Exception)
            {
                ShowError("Unable to save the category. Please try again.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
        }
    }
}
