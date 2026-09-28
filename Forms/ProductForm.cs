using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class ProductForm : Form
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly User _currentAdministrator;

        public ProductForm()
            : this(new User
            {
                UserId = 1,
                FullName = "Designer",
                Username = "designer",
                Role = UserRole.Admin,
                IsActive = true
            })
        {
        }

        public ProductForm(User currentAdministrator)
        {
            ArgumentNullException.ThrowIfNull(currentAdministrator);
            _currentAdministrator = currentAdministrator;
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();

            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadCategoryFilter();
            LoadProducts();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using ProductEditForm form = new(null, _currentAdministrator);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cbCategoryFilter_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            LoadProducts();
        }

        private void dgvProducts_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            if (row.Tag is not Product product)
            {
                return;
            }

            if (e.ColumnIndex == colEdit.Index)
            {
                using ProductEditForm form = new(
                    product,
                    _currentAdministrator
                );
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                ToggleProduct(product);
            }
        }

        private void LoadCategoryFilter()
        {
            try
            {
                cbCategoryFilter.Items.Clear();
                cbCategoryFilter.Items.Add("All Categories");

                foreach (Category category in _categoryRepository.GetAll()
                    .Where(category => category.IsActive))
                {
                    cbCategoryFilter.Items.Add(
                        new CategoryFilterOption(
                            category.CategoryId,
                            category.CategoryName
                        )
                    );
                }

                cbCategoryFilter.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load product categories.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadProducts()
        {
            try
            {
                int? categoryId = (cbCategoryFilter.SelectedItem as CategoryFilterOption)?.Id;
                List<Product> products = _productRepository.GetAll(
                    txtSearch.Text,
                    categoryId
                );

                dgvProducts.Rows.Clear();
                foreach (Product product in products)
                {
                    int rowIndex = dgvProducts.Rows.Add(
                        product.ProductId,
                        product.ProductName,
                        product.CategoryName,
                        product.SupplierName ?? "No Supplier",
                        product.SellingPrice.ToString("C2"),
                        product.StockQuantity,
                        product.IsActive ? "Active" : "Inactive",
                        "Edit",
                        product.IsActive ? "Deactivate" : "Activate"
                    );
                    dgvProducts.Rows[rowIndex].Tag = product;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load products. Please try again.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ToggleProduct(Product product)
        {
            string action = product.IsActive ? "deactivate" : "activate";
            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to {action} '{product.ProductName}'?",
                "Confirm Product Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_productRepository.SetActive(product.ProductId, !product.IsActive))
                {
                    LoadProducts();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to change the product status. Please try again.",
                    "Product Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private sealed class CategoryFilterOption
        {
            public CategoryFilterOption(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; }

            public string Name { get; }

            public override string ToString() => Name;
        }
    }
}
