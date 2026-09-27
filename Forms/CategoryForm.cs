using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryForm()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using CategoryEditForm form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void dgvCategories_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
            if (row.Tag is not Category category)
            {
                return;
            }

            if (e.ColumnIndex == colEdit.Index)
            {
                using CategoryEditForm form = new(category);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                ToggleCategory(category);
            }
        }

        private void LoadCategories()
        {
            try
            {
                List<Category> categories = _categoryRepository.GetAll(txtSearch.Text);
                dgvCategories.Rows.Clear();

                foreach (Category category in categories)
                {
                    int rowIndex = dgvCategories.Rows.Add(
                        category.CategoryId,
                        category.CategoryName,
                        category.Description ?? string.Empty,
                        category.IsActive ? "Active" : "Inactive",
                        "Edit",
                        category.IsActive ? "Deactivate" : "Activate"
                    );
                    dgvCategories.Rows[rowIndex].Tag = category;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load categories. Please try again.",
                    "Category Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ToggleCategory(Category category)
        {
            string action = category.IsActive ? "deactivate" : "activate";
            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to {action} '{category.CategoryName}'?",
                "Confirm Category Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_categoryRepository.SetActive(category.CategoryId, !category.IsActive))
                {
                    LoadCategories();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to change the category status. Please try again.",
                    "Category Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
