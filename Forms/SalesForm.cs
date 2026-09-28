using System.Globalization;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class SalesForm : Form
    {
        private readonly User _currentUser;
        private readonly ProductRepository _productRepository;
        private readonly SalesRepository _salesRepository;
        private readonly List<CartLine> _cart = new();

        public SalesForm()
            : this(new User
            {
                UserId = 1,
                FullName = "Designer",
                Username = "designer",
                Role = UserRole.Cashier,
                IsActive = true
            })
        {
        }

        public SalesForm(User currentUser)
        {
            ArgumentNullException.ThrowIfNull(currentUser);
            _currentUser = currentUser;
            _productRepository = new ProductRepository();
            _salesRepository = new SalesRepository();

            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            ResetSale();
        }

        private void txtSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dgvProducts_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colProdAdd.Index)
            {
                return;
            }

            if (dgvProducts.Rows[e.RowIndex].Tag is Product product)
            {
                AddProductToCart(product);
            }
        }

        private void dgvCart_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colCartRemove.Index)
            {
                return;
            }

            if (dgvCart.Rows[e.RowIndex].Tag is CartLine line)
            {
                _cart.Remove(line);
                RefreshCart();
            }
        }

        private void dgvCart_CellEndEdit(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colCartQty.Index)
            {
                return;
            }

            DataGridViewRow row = dgvCart.Rows[e.RowIndex];
            if (row.Tag is not CartLine line)
            {
                return;
            }

            if (!int.TryParse(
                row.Cells[colCartQty.Index].Value?.ToString(),
                out int quantity
            ) || quantity <= 0)
            {
                ShowSaleError("Quantity must be a whole number greater than zero.");
                RefreshCart();
                return;
            }

            if (quantity > line.Product.StockQuantity)
            {
                ShowSaleError(
                    $"Only {line.Product.StockQuantity} units are available."
                );
                RefreshCart();
                return;
            }

            line.Quantity = quantity;
            RefreshCart();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetSale();
            LoadProducts();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!TryBuildSale(out Sale? sale, out string errorMessage))
            {
                ShowSaleError(errorMessage);
                return;
            }

            try
            {
                int saleId = _salesRepository.CreateCompletedSale(sale!);
                MessageBox.Show(
                    $"Sale completed successfully.\nSale ID: {saleId}",
                    "Payment Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                ResetSale();
                LoadProducts();
            }
            catch (Exception)
            {
                ShowSaleError(
                    "The sale could not be completed. No stock or sale data was changed."
                );
                LoadProducts();
            }
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCash = IsCashPayment();
            txtCashReceived.Enabled = isCash;
            if (!isCash)
            {
                txtCashReceived.Clear();
            }

            UpdateTotals();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void LoadProducts()
        {
            try
            {
                List<Product> products = _productRepository.GetAll(
                    txtSearchBarcode.Text,
                    activeOnly: true
                );
                dgvProducts.Rows.Clear();
                foreach (Product product in products)
                {
                    int rowIndex = dgvProducts.Rows.Add(
                        product.ProductId,
                        product.ProductName,
                        product.SellingPrice.ToString("C2"),
                        product.StockQuantity,
                        "Add"
                    );
                    dgvProducts.Rows[rowIndex].Tag = product;
                }
            }
            catch (Exception)
            {
                ShowSaleError("Unable to load products for the POS.");
            }
        }

        private void AddProductToCart(Product product)
        {
            if (product.StockQuantity <= 0)
            {
                ShowSaleError("This product is out of stock.");
                return;
            }

            CartLine? line = _cart.FirstOrDefault(
                candidate => candidate.Product.ProductId == product.ProductId
            );
            if (line is null)
            {
                _cart.Add(new CartLine(product, 1, product.SellingPrice));
            }
            else if (line.Quantity >= product.StockQuantity)
            {
                ShowSaleError(
                    $"Only {product.StockQuantity} units are available."
                );
                return;
            }
            else
            {
                line.Quantity++;
            }

            RefreshCart();
        }

        private void RefreshCart()
        {
            dgvCart.Rows.Clear();
            foreach (CartLine line in _cart)
            {
                int rowIndex = dgvCart.Rows.Add(
                    line.Product.ProductId,
                    line.Product.ProductName,
                    line.UnitPrice.ToString("C2"),
                    line.Quantity,
                    (line.UnitPrice * line.Quantity).ToString("C2"),
                    "X"
                );
                dgvCart.Rows[rowIndex].Tag = line;
            }

            UpdateTotals();
        }

        private void ResetSale()
        {
            _cart.Clear();
            dgvCart.Rows.Clear();
            txtDiscount.Text = "0.00";
            txtCashReceived.Clear();
            if (cbPaymentMethod.Items.Count > 0)
            {
                cbPaymentMethod.SelectedIndex = 0;
            }

            UpdateTotals();
        }

        private bool TryBuildSale(out Sale? sale, out string errorMessage)
        {
            sale = null;
            errorMessage = string.Empty;

            if (_cart.Count == 0)
            {
                errorMessage = "Add at least one product to the cart.";
                return false;
            }

            if (!TryReadDecimal(txtDiscount.Text, out decimal discount))
            {
                errorMessage = "Enter a valid discount.";
                return false;
            }

            decimal subtotal = _cart.Sum(
                line => line.Quantity * line.UnitPrice
            );
            if (discount < 0 || discount > subtotal)
            {
                errorMessage = "Discount must be between zero and the subtotal.";
                return false;
            }

            decimal total = subtotal - discount;
            PaymentMethod paymentMethod = IsCashPayment()
                ? PaymentMethod.Cash
                : PaymentMethod.QRCode;
            decimal? amountReceived = null;
            decimal? changeAmount = null;

            if (paymentMethod == PaymentMethod.Cash)
            {
                if (!TryReadDecimal(txtCashReceived.Text, out decimal received))
                {
                    errorMessage = "Enter the cash received.";
                    return false;
                }

                if (received < total)
                {
                    errorMessage = "Cash received must cover the total amount.";
                    return false;
                }

                amountReceived = received;
                changeAmount = received - total;
            }

            sale = new Sale
            {
                CashierUserId = _currentUser.UserId,
                SaleDate = DateTime.Now,
                Subtotal = subtotal,
                DiscountAmount = discount,
                TotalAmount = total,
                PaymentMethod = paymentMethod,
                AmountReceived = amountReceived,
                ChangeAmount = changeAmount,
                Status = SaleStatus.Completed,
                SaleDetails = _cart.Select(line => new SaleDetail
                {
                    ProductId = line.Product.ProductId,
                    Quantity = line.Quantity,
                    UnitPrice = line.UnitPrice,
                    DiscountAmount = 0,
                    LineSubtotal = line.Quantity * line.UnitPrice
                }).ToList()
            };

            return true;
        }

        private void UpdateTotals()
        {
            decimal subtotal = _cart.Sum(
                line => line.Quantity * line.UnitPrice
            );
            lblSubtotalValue.Text = subtotal.ToString("C2");

            if (!TryReadDecimal(txtDiscount.Text, out decimal discount)
                || discount < 0
                || discount > subtotal)
            {
                lblTotalValue.Text = "Invalid discount";
                lblChangeValue.Text = "$0.00";
                return;
            }

            decimal total = subtotal - discount;
            lblTotalValue.Text = total.ToString("C2");

            if (IsCashPayment()
                && TryReadDecimal(txtCashReceived.Text, out decimal received))
            {
                lblChangeValue.Text = (received - total).ToString("C2");
            }
            else
            {
                lblChangeValue.Text = "$0.00";
            }
        }

        private bool IsCashPayment()
        {
            return cbPaymentMethod.SelectedItem?.ToString() == "Cash";
        }

        private static bool TryReadDecimal(string text, out decimal value)
        {
            return decimal.TryParse(
                text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out value
            );
        }

        private static void ShowSaleError(string message)
        {
            MessageBox.Show(
                message,
                "Sales / POS",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private sealed class CartLine
        {
            public CartLine(Product product, int quantity, decimal unitPrice)
            {
                Product = product;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }

            public Product Product { get; }

            public int Quantity { get; set; }

            public decimal UnitPrice { get; }
        }
    }
}
