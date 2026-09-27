using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class StockAdjustmentForm : Form
    {
        private readonly Product _product;
        private readonly User _currentUser;
        private readonly InventoryRepository _inventoryRepository;

        public StockAdjustmentForm()
            : this(
                new Product { ProductId = 1, ProductName = "Designer product" },
                new User { UserId = 1, Username = "designer" }
            )
        {
        }

        public StockAdjustmentForm(Product product, User currentUser)
        {
            ArgumentNullException.ThrowIfNull(product);
            ArgumentNullException.ThrowIfNull(currentUser);

            _product = product;
            _currentUser = currentUser;
            _inventoryRepository = new InventoryRepository();

            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);
            lblProduct.Text = $"Product: {product.ProductName}";
            lblCurrentStock.Text = $"Current stock: {product.StockQuantity}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            int delta = decimal.ToInt32(numQuantity.Value);
            if (delta == 0)
            {
                ShowError("Adjustment cannot be zero.");
                return;
            }

            try
            {
                _inventoryRepository.AdjustStock(
                    _product.ProductId,
                    delta,
                    _currentUser.UserId,
                    string.IsNullOrWhiteSpace(txtNotes.Text)
                        ? "Manual stock adjustment"
                        : txtNotes.Text.Trim()
                );
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                ShowError(
                    "Unable to adjust stock. The stock quantity may become negative."
                );
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
