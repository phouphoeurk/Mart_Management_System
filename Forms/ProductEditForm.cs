using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Forms
{
    public partial class ProductEditForm : Form
    {
        private readonly ProductRepository _productRepository;
        private readonly Product? _product;
        private readonly User _currentAdministrator;
        private readonly List<LookupOption> _categoryOptions = new();
        private readonly List<LookupOption> _supplierOptions = new();

        public ProductEditForm()
            : this(null, CreateDesignerAdministrator())
        {
        }

        public ProductEditForm(Product? product)
            : this(product, CreateDesignerAdministrator())
        {
        }

        public ProductEditForm(Product? product, User currentAdministrator)
        {
            ArgumentNullException.ThrowIfNull(currentAdministrator);
            _currentAdministrator = currentAdministrator;
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            _productRepository = new ProductRepository();
            _product = product;
            LoadLookups();

            if (_product is not null)
            {
                Text = "Edit Product";
                btnSave.Text = "Update Product";
                txtProductName.Text = _product.ProductName;
                txtBarcode.Text = _product.Barcode ?? string.Empty;
                numCostPrice.Value = _product.CostPrice;
                numSellingPrice.Value = _product.SellingPrice;
                numStockQuantity.Value = _product.StockQuantity;
                numReorderLevel.Value = _product.ReorderLevel;
                chkActive.Checked = _product.IsActive;
                chkHasExpiry.Checked = _product.ExpiryDate.HasValue;
                if (_product.ExpiryDate.HasValue)
                {
                    dtpExpiry.Value = _product.ExpiryDate.Value;
                }

                SelectLookup(
                    cbCategory,
                    _categoryOptions,
                    _product.CategoryId
                );
                SelectLookup(
                    cbSupplier,
                    _supplierOptions,
                    _product.SupplierId
                );
            }
            else
            {
                Text = "Add Product";
                btnSave.Text = "Save Product";
                chkActive.Checked = true;
                SelectFirstCategory();
            }

            dtpExpiry.Enabled = chkHasExpiry.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string productName = txtProductName.Text.Trim();
            string barcode = txtBarcode.Text.Trim();

            if (string.IsNullOrWhiteSpace(productName))
            {
                ShowError("Product name is required.");
                txtProductName.Focus();
                return;
            }

            if (productName.Length > 150)
            {
                ShowError("Product name cannot exceed 150 characters.");
                txtProductName.Focus();
                return;
            }

            if (barcode.Length > 50)
            {
                ShowError("Barcode cannot exceed 50 characters.");
                txtBarcode.Focus();
                return;
            }

            if (cbCategory.SelectedItem is not LookupOption categoryOption)
            {
                ShowError("Select a category.");
                cbCategory.Focus();
                return;
            }

            Product product = _product is null
                ? new Product()
                : new Product
                {
                    ProductId = _product.ProductId,
                    CreatedAt = _product.CreatedAt
                };

            product.ProductName = productName;
            product.Barcode = string.IsNullOrWhiteSpace(barcode) ? null : barcode;
            product.CategoryId = categoryOption.Id!.Value;
            product.SupplierId = (cbSupplier.SelectedItem as LookupOption)?.Id;
            product.CostPrice = numCostPrice.Value;
            product.SellingPrice = numSellingPrice.Value;
            product.StockQuantity = decimal.ToInt32(numStockQuantity.Value);
            product.ReorderLevel = decimal.ToInt32(numReorderLevel.Value);
            product.ExpiryDate = chkHasExpiry.Checked
                ? dtpExpiry.Value.Date
                : null;
            product.IsActive = chkActive.Checked;

            try
            {
                bool saved = _product is null
                    ? _productRepository.Create(
                        product,
                        _currentAdministrator.UserId,
                        "Initial stock from product editor"
                    )
                    : _productRepository.Update(
                        product,
                        _currentAdministrator.UserId,
                        "Stock updated from product editor"
                    );

                if (!saved)
                {
                    ShowError("The product could not be saved. Please try again.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number is 2601 or 2627)
            {
                ShowError("A product with this barcode already exists.");
            }
            catch (Exception)
            {
                ShowError("Unable to save the product. Please try again.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkHasExpiry_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpiry.Enabled = chkHasExpiry.Checked;
        }

        private void LoadLookups()
        {
            try
            {
                List<Category> categories = new CategoryRepository().GetAll();
                foreach (Category category in categories.Where(
                    category => category.IsActive
                        || category.CategoryId == _product?.CategoryId
                ))
                {
                    _categoryOptions.Add(
                        new LookupOption(category.CategoryId, category.CategoryName)
                    );
                }

                List<Supplier> suppliers = new SupplierRepository().GetAll();
                _supplierOptions.Add(new LookupOption(null, "No Supplier"));
                foreach (Supplier supplier in suppliers.Where(
                    supplier => supplier.IsActive
                        || supplier.SupplierId == _product?.SupplierId
                ))
                {
                    _supplierOptions.Add(
                        new LookupOption(supplier.SupplierId, supplier.SupplierName)
                    );
                }

                cbCategory.Items.Clear();
                cbCategory.Items.AddRange(_categoryOptions.Cast<object>().ToArray());
                cbSupplier.Items.Clear();
                cbSupplier.Items.AddRange(_supplierOptions.Cast<object>().ToArray());
            }
            catch (Exception)
            {
                ShowError("Unable to load categories and suppliers.");
            }
        }

        private void SelectFirstCategory()
        {
            if (_categoryOptions.Count > 0)
            {
                cbCategory.SelectedIndex = 0;
            }
        }

        private void SelectLookup(
            ComboBox comboBox,
            IEnumerable<LookupOption> options,
            int? id
        )
        {
            LookupOption? option = options.FirstOrDefault(
                candidate => candidate.Id == id
            );
            comboBox.SelectedItem = option;
        }

        private static User CreateDesignerAdministrator()
        {
            return new User
            {
                UserId = 1,
                FullName = "Designer",
                Username = "designer",
                Role = UserRole.Admin,
                IsActive = true
            };
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
        }

        private sealed class LookupOption
        {
            public LookupOption(int? id, string name)
            {
                Id = id;
                Name = name;
            }

            public int? Id { get; }

            public string Name { get; }

            public override string ToString() => Name;
        }
    }
}
