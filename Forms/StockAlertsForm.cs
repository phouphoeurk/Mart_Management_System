using System.Diagnostics;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class StockAlertsForm : Form
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly User _currentUser;
        private StockAlertSnapshot? _snapshot;

        public StockAlertsForm()
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

        public StockAlertsForm(User currentUser)
        {
            ArgumentNullException.ThrowIfNull(currentUser);
            _currentUser = currentUser;
            _inventoryRepository = new InventoryRepository();

            InitializeComponent();

            if (currentUser.Role != UserRole.Admin)
            {
                cbAlertType.Enabled = false;
                btnRefresh.Enabled = false;
            }
        }

        private void StockAlertsForm_Load(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Admin)
            {
                return;
            }

            cbAlertType.Items.Clear();
            cbAlertType.Items.AddRange(new object[]
            {
                "Low Stock",
                "Out of Stock",
                "Expiring Soon",
                "Expired",
                "Inventory History"
            });

            RefreshAlerts();
            cbAlertType.SelectedIndex = 0;
            RenderAlerts();
        }

        private void cbAlertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                RenderAlerts();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAlerts();
        }

        private void dgvAlerts_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colAction.Index)
            {
                return;
            }

            if (dgvAlerts.Rows[e.RowIndex].Tag is not Product product)
            {
                return;
            }

            using StockAdjustmentForm form = new(product, _currentUser);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                RefreshAlerts();
            }
        }

        private void RefreshAlerts()
        {
            try
            {
                _snapshot = _inventoryRepository.GetStockAlertSnapshot();
                RenderAlerts();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show(
                    "Unable to load stock alerts.",
                    "Stock Alerts",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void RenderAlerts()
        {
            string alertType = cbAlertType.SelectedItem?.ToString()
                ?? "Low Stock";
            dgvAlerts.Rows.Clear();

            if (alertType == "Inventory History")
            {
                RenderHistory();
                return;
            }

            List<Product> products = alertType switch
            {
                "Out of Stock" => _snapshot?.OutOfStock ?? new List<Product>(),
                "Expiring Soon" => _snapshot?.ExpiringSoon ?? new List<Product>(),
                "Expired" => _snapshot?.Expired ?? new List<Product>(),
                _ => _snapshot?.LowStock ?? new List<Product>()
            };

            foreach (Product product in products)
            {
                int rowIndex = dgvAlerts.Rows.Add(
                    product.ProductName,
                    product.CategoryName,
                    product.StockQuantity,
                    product.ReorderLevel,
                    product.ExpiryDate?.ToString("yyyy-MM-dd") ?? "-",
                    GetStatus(alertType, product),
                    "Adjust"
                );
                dgvAlerts.Rows[rowIndex].Tag = product;
            }
        }

        private void RenderHistory()
        {
            foreach (
                InventoryTransaction transaction in _snapshot?.RecentHistory
                    ?? new List<InventoryTransaction>()
            )
            {
                string reference = transaction.SaleId.HasValue
                    ? $"Sale #{transaction.SaleId.Value}"
                    : transaction.PurchaseOrderId.HasValue
                        ? $"PO #{transaction.PurchaseOrderId.Value}"
                        : "Manual";

                int rowIndex = dgvAlerts.Rows.Add(
                    transaction.ProductName,
                    transaction.TransactionType.ToString(),
                    transaction.QuantityChange,
                    reference,
                    transaction.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                    transaction.UserName,
                    transaction.Notes ?? string.Empty
                );
                dgvAlerts.Rows[rowIndex].Tag = transaction;
            }
        }

        private static string GetStatus(string alertType, Product product)
        {
            if (alertType == "Out of Stock")
            {
                return "Out of stock";
            }

            if (alertType == "Expired")
            {
                return "Expired";
            }

            if (alertType == "Expiring Soon" && product.ExpiryDate.HasValue)
            {
                int days = (product.ExpiryDate.Value.Date - DateTime.Today).Days;
                return days == 0 ? "Expires today" : $"Expires in {days} days";
            }

            return "Low stock";
        }
    }
}
