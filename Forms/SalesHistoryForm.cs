using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class SalesHistoryForm : Form
    {
        private readonly SalesRepository _salesRepository;
        private readonly UserRepository _userRepository;
        private User? _currentUser;

        public SalesHistoryForm()
        {
            InitializeComponent();
            _salesRepository = new SalesRepository();
            _userRepository = new UserRepository();
        }

        public SalesHistoryForm(User currentUser)
            : this()
        {
            _currentUser = currentUser;
        }

        public User? CurrentUser => _currentUser;

        private void SalesHistoryForm_Load(object sender, EventArgs e)
        {
            dtpDateFrom.Value = DateTime.Today;
            dtpDateTo.Value = DateTime.Today;
            LoadCashierFilter();
            LoadSales();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void dgvSalesHistory_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colAction.Index)
            {
                return;
            }

            if (dgvSalesHistory.Rows[e.RowIndex].Tag is not SaleSummary summary)
            {
                return;
            }

            if (_currentUser?.Role == UserRole.Cashier
                && summary.CashierUserId != _currentUser.UserId)
            {
                MessageBox.Show(
                    "You can only view your own sales.",
                    "Sales History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                Sale? sale = _salesRepository.GetSale(summary.SaleId);
                if (sale is null)
                {
                    MessageBox.Show(
                        "The selected sale could not be found.",
                        "Sales History",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                using SaleDetailsForm form = new(sale);
                form.ShowDialog(this);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the sale details.",
                    "Sales History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadCashierFilter()
        {
            try
            {
                cbCashier.Items.Clear();
                if (_currentUser?.Role == UserRole.Cashier)
                {
                    cbCashier.Items.Add(
                        new CashierOption(_currentUser.UserId, _currentUser.Username)
                    );
                    cbCashier.SelectedIndex = 0;
                    cbCashier.Enabled = false;
                    return;
                }

                cbCashier.Items.Add(new CashierOption(null, "All Cashiers"));
                foreach (User user in _userRepository.GetAll()
                    .Where(user => user.Role == UserRole.Cashier || user.Role == UserRole.Admin)
                    .OrderBy(user => user.FullName))
                {
                    cbCashier.Items.Add(
                        new CashierOption(user.UserId, user.FullName)
                    );
                }

                cbCashier.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the cashier filter.",
                    "Sales History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadSales()
        {
            try
            {
                List<SaleSummary> sales = _salesRepository.GetHistory(
                    CreateFilter()
                );
                dgvSalesHistory.Rows.Clear();

                foreach (SaleSummary sale in sales)
                {
                    int rowIndex = dgvSalesHistory.Rows.Add(
                        sale.SaleId,
                        sale.SaleDate.ToString("yyyy-MM-dd HH:mm"),
                        sale.CashierName,
                        sale.PaymentMethod,
                        sale.TotalAmount.ToString("C2"),
                        sale.Status,
                        "View"
                    );
                    dgvSalesHistory.Rows[rowIndex].Tag = sale;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load sales history.",
                    "Sales History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private SaleHistoryFilter CreateFilter()
        {
            string payment = cbPaymentMethod.SelectedItem?.ToString()
                ?? "All Payments";
            string status = cbStatus.SelectedItem?.ToString() ?? "All Statuses";
            int? cashierUserId = (cbCashier.SelectedItem as CashierOption)?.UserId;

            if (_currentUser?.Role == UserRole.Cashier)
            {
                cashierUserId = _currentUser.UserId;
            }

            return new SaleHistoryFilter
            {
                FromDate = dtpDateFrom.Value.Date,
                ToDate = dtpDateTo.Value.Date,
                CashierUserId = cashierUserId,
                PaymentMethod = payment == "All Payments" ? null : payment,
                Status = status == "All Statuses" ? null : status,
                Keyword = string.IsNullOrWhiteSpace(txtSearch.Text)
                    ? null
                    : txtSearch.Text.Trim()
            };
        }

        private sealed class CashierOption
        {
            public CashierOption(int? userId, string name)
            {
                UserId = userId;
                Name = name;
            }

            public int? UserId { get; }

            public string Name { get; }

            public override string ToString() => Name;
        }
    }
}
