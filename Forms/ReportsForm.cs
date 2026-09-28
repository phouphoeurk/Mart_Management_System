using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly DashboardRepository _dashboardRepository;

        public ReportsForm()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            cbReport.SelectedIndex = 0;
            LoadTotals();
            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void cbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                GenerateReport();
            }
        }

        private void LoadTotals()
        {
            try
            {
                ReportTotals totals = _dashboardRepository.GetPeriodTotals();
                lblCard1Value.Text = totals.DailySales.ToString("C2");
                lblCard2Value.Text = totals.WeeklySales.ToString("C2");
                lblCard3Value.Text = totals.MonthlySales.ToString("C2");
                lblCard4Value.Text = _dashboardRepository.GetAllTimeRevenue()
                    .ToString("C2");
            }
            catch (Exception)
            {
                lblCard1Value.Text = "Error";
                lblCard2Value.Text = "Error";
                lblCard3Value.Text = "Error";
                lblCard4Value.Text = "Error";
            }
        }

        private void GenerateReport()
        {
            if (!IsHandleCreated)
            {
                return;
            }

            try
            {
                string report = cbReport.SelectedItem?.ToString()
                    ?? "Sales Trend";
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;
                List<ReportRow> rows;
                decimal inventoryValue = _dashboardRepository.GetInventoryValue();

                rows = report switch
                {
                    "Revenue by Cashier" =>
                        _dashboardRepository.GetRevenueByCashier(fromDate, toDate),
                    "Revenue by Payment Method" =>
                        _dashboardRepository.GetRevenueByPaymentMethod(
                            fromDate,
                            toDate
                        ),
                    "Top Products" =>
                        _dashboardRepository.GetTopProducts(fromDate, toDate),
                    "Sales by Category" =>
                        _dashboardRepository.GetSalesByCategory(fromDate, toDate),
                    "Supplier Purchase History" =>
                        _dashboardRepository.GetSupplierPurchaseHistory(),
                    "Inventory Value" => new List<ReportRow>
                    {
                        new ReportRow
                        {
                            Label = "Current inventory value",
                            Value = inventoryValue,
                            DisplayValue = inventoryValue.ToString("C2")
                        }
                    },
                    _ => _dashboardRepository.GetSalesTrend(fromDate, toDate)
                };

                dgvReport.Rows.Clear();
                foreach (ReportRow row in rows)
                {
                    dgvReport.Rows.Add(row.Label, row.DisplayValue);
                }

                lblChart2Placeholder.Text =
                    $"📦 Inventory value: {inventoryValue:C2}\n" +
                    $"Rows returned: {rows.Count}\n" +
                    $"Range: {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}";
                lblChart1Placeholder.Visible = false;
            }
            catch (Exception)
            {
                dgvReport.Rows.Clear();
                lblChart2Placeholder.Text =
                    "Unable to load the selected report. Please try again.";
            }
        }
    }
}
