using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly User _currentAdministrator;
        private readonly PurchaseOrderRepository _purchaseOrderRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly ProductRepository _productRepository;
        private readonly List<PurchaseLine> _lines = new();
        private int? _draftPurchaseOrderId;

        public PurchaseOrderForm()
            : this(new User
            {
                FullName = "Designer",
                Username = "designer",
                Role = UserRole.Admin,
                IsActive = true,
                UserId = 1
            })
        {
        }

        public PurchaseOrderForm(User currentAdministrator)
        {
            ArgumentNullException.ThrowIfNull(currentAdministrator);
            _currentAdministrator = currentAdministrator;
            _purchaseOrderRepository = new PurchaseOrderRepository();
            _supplierRepository = new SupplierRepository();
            _productRepository = new ProductRepository();

            InitializeComponent();

            if (currentAdministrator.Role != UserRole.Admin)
            {
                lblStatus.Text = "Administrator access required";
                SetEditingEnabled(false);
            }
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            if (_currentAdministrator.Role != UserRole.Admin)
            {
                return;
            }

            LoadSuppliers();
            LoadProducts();
            ResetOrder();

            if (cbSupplier.Items.Count == 0)
            {
                lblStatus.Text =
                    "Add an active supplier before creating a purchase order.";
            }
            else if (cbProduct.Items.Count == 0)
            {
                lblStatus.Text =
                    "Add an active product before receiving stock.";
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                cbSupplier.Items.Clear();
                foreach (Supplier supplier in _supplierRepository.GetAll()
                    .Where(supplier => supplier.IsActive))
                {
                    cbSupplier.Items.Add(new SupplierOption(supplier));
                }

                if (cbSupplier.Items.Count == 0)
                {
                    lblStatus.Text = "Add an active supplier before creating a purchase order.";
                }
            }
            catch (Exception)
            {
                lblStatus.Text = "Unable to load suppliers.";
            }
        }

        private void LoadProducts()
        {
            try
            {
                cbProduct.Items.Clear();
                foreach (Product product in _productRepository.GetAll(activeOnly: true))
                {
                    cbProduct.Items.Add(new ProductOption(product));
                }

                if (cbProduct.Items.Count == 0)
                {
                    lblStatus.Text = "Add an active product before receiving stock.";
                }
            }
            catch (Exception)
            {
                lblStatus.Text = "Unable to load products.";
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;

            if (cbProduct.SelectedItem is not ProductOption productOption)
            {
                lblStatus.Text = "Select a product.";
                return;
            }

            int quantity = decimal.ToInt32(numQuantity.Value);
            decimal unitCost = numUnitCost.Value;
            if (quantity <= 0)
            {
                lblStatus.Text = "Quantity must be greater than zero.";
                return;
            }

            if (unitCost < 0)
            {
                lblStatus.Text = "Unit cost cannot be negative.";
                return;
            }

            PurchaseLine? existingLine = _lines.FirstOrDefault(
                line => line.Product.ProductId == productOption.Product.ProductId
            );
            if (existingLine is not null)
            {
                existingLine.Quantity += quantity;
                existingLine.UnitCost = unitCost;
            }
            else
            {
                _lines.Add(new PurchaseLine(productOption.Product, quantity, unitCost));
            }

            RefreshLines();
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseDetails.CurrentRow?.Tag is not PurchaseLine line)
            {
                lblStatus.Text = "Select a purchase line to remove.";
                return;
            }

            _lines.Remove(line);
            RefreshLines();
        }

        private void dgvPurchaseDetails_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colRemove.Index)
            {
                return;
            }

            if (dgvPurchaseDetails.Rows[e.RowIndex].Tag is PurchaseLine line)
            {
                _lines.Remove(line);
                RefreshLines();
            }
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SaveDraft();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (_draftPurchaseOrderId is null && !SaveDraft(showSuccess: false))
            {
                return;
            }

            try
            {
                _purchaseOrderRepository.Receive(
                    _draftPurchaseOrderId!.Value,
                    _currentAdministrator.UserId
                );
                MessageBox.Show(
                    $"Purchase order {_draftPurchaseOrderId.Value} was received. Stock was updated.",
                    "Purchase Received",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                ResetOrder();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to receive this purchase order. No stock was changed.",
                    "Purchase Order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ResetOrder();
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedItem is ProductOption option)
            {
                numUnitCost.Value = Math.Min(
                    option.Product.CostPrice,
                    numUnitCost.Maximum
                );
            }
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            RefreshLines();
        }

        private bool SaveDraft(bool showSuccess = true)
        {
            lblStatus.Text = string.Empty;

            if (_draftPurchaseOrderId is not null)
            {
                lblStatus.Text = "This order is already saved. Receive it or start a new order.";
                return true;
            }

            if (cbSupplier.SelectedItem is not SupplierOption supplierOption)
            {
                lblStatus.Text = "Select a supplier.";
                return false;
            }

            if (_lines.Count == 0)
            {
                lblStatus.Text = "Add at least one product to the purchase order.";
                return false;
            }

            decimal subtotal = _lines.Sum(
                line => line.Quantity * line.UnitCost
            );
            decimal discount = numDiscount.Value;
            if (discount < 0 || discount > subtotal)
            {
                lblStatus.Text = "Discount must be between zero and the subtotal.";
                return false;
            }

            PurchaseOrder order = new()
            {
                SupplierId = supplierOption.Supplier.SupplierId,
                CreatedByUserId = _currentAdministrator.UserId,
                PurchaseDate = dtpPurchaseDate.Value,
                Status = PurchaseOrderStatus.Draft,
                Subtotal = subtotal,
                DiscountAmount = discount,
                TotalAmount = subtotal - discount,
                PurchaseOrderDetails = _lines.Select(line => new PurchaseOrderDetail
                {
                    ProductId = line.Product.ProductId,
                    Quantity = line.Quantity,
                    UnitCost = line.UnitCost,
                    LineSubtotal = line.Quantity * line.UnitCost
                }).ToList()
            };

            try
            {
                _draftPurchaseOrderId = _purchaseOrderRepository.CreateDraft(order);
                lblStatus.Text = $"Draft purchase order #{_draftPurchaseOrderId} saved.";
                SetEditingEnabled(false);
                btnNewOrder.Enabled = true;
                btnReceive.Enabled = true;

                if (showSuccess)
                {
                    MessageBox.Show(
                        $"Draft purchase order #{_draftPurchaseOrderId} saved.",
                        "Purchase Order",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                return true;
            }
            catch (Exception)
            {
                _draftPurchaseOrderId = null;
                lblStatus.Text = "Unable to save the purchase order.";
                return false;
            }
        }

        private void ResetOrder()
        {
            _draftPurchaseOrderId = null;
            _lines.Clear();
            numQuantity.Value = 1;
            numUnitCost.Value = 0;
            numDiscount.Value = 0;
            cbSupplier.SelectedIndex = cbSupplier.Items.Count > 0 ? 0 : -1;
            cbProduct.SelectedIndex = cbProduct.Items.Count > 0 ? 0 : -1;
            SetEditingEnabled(_currentAdministrator.Role == UserRole.Admin);
            lblStatus.Text = string.Empty;
            RefreshLines();
        }

        private void SetEditingEnabled(bool enabled)
        {
            cbSupplier.Enabled = enabled;
            cbProduct.Enabled = enabled;
            numQuantity.Enabled = enabled;
            numUnitCost.Enabled = enabled;
            numDiscount.Enabled = enabled;
            btnAddLine.Enabled = enabled;
            btnRemoveLine.Enabled = enabled;
            btnSaveDraft.Enabled = enabled;
            btnNewOrder.Enabled = enabled;
            btnReceive.Enabled = enabled && _draftPurchaseOrderId is not null;
        }

        private void RefreshLines()
        {
            dgvPurchaseDetails.Rows.Clear();
            foreach (PurchaseLine line in _lines)
            {
                int rowIndex = dgvPurchaseDetails.Rows.Add(
                    line.Product.ProductName,
                    line.Quantity,
                    line.UnitCost.ToString("C2"),
                    (line.Quantity * line.UnitCost).ToString("C2"),
                    "Remove"
                );
                dgvPurchaseDetails.Rows[rowIndex].Tag = line;
            }

            decimal subtotal = _lines.Sum(line => line.Quantity * line.UnitCost);
            lblSubtotalValue.Text = subtotal.ToString("C2");
            lblTotalValue.Text = (subtotal - numDiscount.Value).ToString("C2");
        }

        private sealed class SupplierOption
        {
            public SupplierOption(Supplier supplier)
            {
                Supplier = supplier;
            }

            public Supplier Supplier { get; }

            public override string ToString() => Supplier.SupplierName;
        }

        private sealed class ProductOption
        {
            public ProductOption(Product product)
            {
                Product = product;
            }

            public Product Product { get; }

            public override string ToString() =>
                $"{Product.ProductName} (Stock: {Product.StockQuantity})";
        }

        private sealed class PurchaseLine
        {
            public PurchaseLine(Product product, int quantity, decimal unitCost)
            {
                Product = product;
                Quantity = quantity;
                UnitCost = unitCost;
            }

            public Product Product { get; }

            public int Quantity { get; set; }

            public decimal UnitCost { get; set; }
        }
    }
}
