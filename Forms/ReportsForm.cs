using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly DashboardRepository _dashboardRepository;
        private int _printRowIndex;

        public ReportsForm()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
        }

        private string SelectedReport =>
            cbReport.SelectedItem?.ToString() ?? "Sales Trend";

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-29);
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                lblCard1Value.Text = "Error";
                lblCard2Value.Text = "Error";
                lblCard3Value.Text = "Error";
            }

            try
            {
                lblCard4Value.Text = _dashboardRepository.GetAllTimeRevenue()
                    .ToString("C2");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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
                string report = SelectedReport;
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;
                if (fromDate > toDate)
                {
                    (fromDate, toDate) = (toDate, fromDate);
                    dtpFrom.Value = fromDate;
                    dtpTo.Value = toDate;
                }

                List<ReportRow> rows;
                string highlight;

                switch (report)
                {
                    case "Revenue by Cashier":
                        rows = _dashboardRepository.GetRevenueByCashier(
                            fromDate,
                            toDate
                        );
                        highlight =
                            $"Total revenue: {rows.Sum(row => row.Value):C2}";
                        break;

                    case "Revenue by Payment Method":
                        rows = _dashboardRepository.GetRevenueByPaymentMethod(
                            fromDate,
                            toDate
                        );
                        highlight =
                            $"Total revenue: {rows.Sum(row => row.Value):C2}";
                        break;

                    case "Top Products":
                        rows = _dashboardRepository.GetTopProducts(
                            fromDate,
                            toDate
                        );
                        highlight =
                            $"Units sold: {rows.Sum(row => row.Value):0}";
                        break;

                    case "Sales by Category":
                        rows = _dashboardRepository.GetSalesByCategory(
                            fromDate,
                            toDate
                        );
                        highlight =
                            $"Total revenue: {rows.Sum(row => row.Value):C2}";
                        break;

                    case "Sales by Product":
                        rows = _dashboardRepository.GetSalesByProduct(
                            fromDate,
                            toDate
                        );
                        highlight =
                            $"Total revenue: {rows.Sum(row => row.Value):C2}";
                        break;

                    case "Supplier Purchase History":
                        rows = _dashboardRepository.GetSupplierPurchaseHistory();
                        highlight =
                            $"Total received: {rows.Sum(row => row.Value):C2}";
                        break;

                    case "Inventory Value":
                        decimal inventoryValue =
                            _dashboardRepository.GetInventoryValue();
                        rows = new List<ReportRow>
                        {
                            new()
                            {
                                Label = "Current inventory value",
                                Value = inventoryValue,
                                DisplayValue = inventoryValue.ToString("C2")
                            }
                        };
                        highlight =
                            $"Inventory value (active products): {inventoryValue:C2}";
                        break;

                    case "Low Stock Report":
                        rows = _dashboardRepository.GetLowStockReport();
                        highlight =
                            $"Products at or below reorder level: {rows.Count}";
                        break;

                    case "Profit Report":
                        rows = _dashboardRepository.GetProfitReport(
                            fromDate,
                            toDate
                        );
                        ReportRow? grossProfit = rows.FirstOrDefault(
                            row => row.Label == "Gross profit"
                        );
                        highlight =
                            $"Gross profit: {grossProfit?.DisplayValue ?? "—"}";
                        break;

                    default:
                        rows = _dashboardRepository.GetSalesTrend(
                            fromDate,
                            toDate
                        );
                        highlight =
                            $"Total revenue: {rows.Sum(row => row.Value):C2}";
                        break;
                }

                dgvReport.Rows.Clear();
                foreach (ReportRow row in rows)
                {
                    dgvReport.Rows.Add(row.Label, row.DisplayValue);
                }

                lblGridPlaceholder.Visible = rows.Count == 0;
                if (rows.Count == 0)
                {
                    lblGridPlaceholder.Text = "No data for the selected filters.";
                }

                StringBuilder summary = new();
                summary.AppendLine($"Report: {report}");
                summary.AppendLine(
                    $"Range: {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}"
                );
                summary.AppendLine($"Rows: {rows.Count}");
                summary.AppendLine();
                summary.AppendLine(highlight);
                summary.AppendLine();
                summary.AppendLine($"Generated {DateTime.Now:yyyy-MM-dd HH:mm}");
                lblSummary.Text = summary.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                dgvReport.Rows.Clear();
                lblGridPlaceholder.Visible = true;
                lblGridPlaceholder.Text =
                    "Unable to load the selected report. Please try again.";
                lblSummary.Text =
                    "Unable to load the selected report. Please try again.";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }

        private void ExportCsv()
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There are no rows to export. Generate a report first.",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            string safeName = string.Concat(
                SelectedReport.Select(character =>
                    char.IsLetterOrDigit(character) ? character : '_'
                )
            );
            using SaveFileDialog dialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName =
                    $"{safeName}_{dtpFrom.Value:yyyyMMdd}_{dtpTo.Value:yyyyMMdd}.csv"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder content = new();
                content.AppendLine("Report Item,Value");
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    content.AppendLine(
                        $"{EscapeCsv(row.Cells[0].Value?.ToString())},{EscapeCsv(row.Cells[1].Value?.ToString())}"
                    );
                }

                File.WriteAllText(
                    dialog.FileName,
                    content.ToString(),
                    Encoding.UTF8
                );
                MessageBox.Show(
                    $"Exported {dgvReport.Rows.Count} rows to\n{dialog.FileName}",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to write the CSV file.",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static string EscapeCsv(string? value)
        {
            string text = value ?? string.Empty;
            if (
                text.Contains('"')
                || text.Contains(',')
                || text.Contains('\n')
                || text.Contains('\r')
            )
            {
                return $"\"{text.Replace("\"", "\"\"")}\"";
            }

            return text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There are no rows to print. Generate a report first.",
                    "Print",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            try
            {
                _printRowIndex = 0;
                using PrintDocument document = new();
                document.DocumentName = SelectedReport;
                document.PrintPage += Report_PrintPage;
                using PrintPreviewDialog preview = new()
                {
                    Document = document,
                    Width = 900,
                    Height = 700
                };
                preview.ShowDialog(this);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to open the print preview.",
                    "Print",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Report_PrintPage(object sender, PrintPageEventArgs e)
        {
            const float itemWidthRatio = 0.65f;
            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;
            float itemWidth = width * itemWidthRatio;
            float valueWidth = width - itemWidth;
            const float rowHeight = 24f;

            using Font titleFont = new("Segoe UI", 16F, FontStyle.Bold);
            using Font headerFont = new("Segoe UI", 10F, FontStyle.Bold);
            using Font rowFont = new("Segoe UI", 10F);
            using SolidBrush darkBrush = new(Color.FromArgb(30, 30, 30));
            using SolidBrush grayBrush = new(Color.Gray);
            using Pen rulePen = new(Color.FromArgb(210, 214, 218));
            using StringFormat ellipsis = new()
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            Graphics? graphics = e.Graphics;
            if (graphics is null)
            {
                e.HasMorePages = false;
                return;
            }

            float y = top;
            graphics.DrawString("REPORTS", titleFont, darkBrush, left, y);
            y += 40;
            graphics.DrawString(
                $"{SelectedReport}  |  {dtpFrom.Value.Date:yyyy-MM-dd} to {dtpTo.Value.Date:yyyy-MM-dd}",
                rowFont,
                grayBrush,
                left,
                y
            );
            y += 30;

            graphics.DrawString(
                "Report Item",
                headerFont,
                darkBrush,
                new RectangleF(left, y, itemWidth, rowHeight)
            );
            graphics.DrawString(
                "Value",
                headerFont,
                darkBrush,
                new RectangleF(left + itemWidth, y, valueWidth, rowHeight)
            );
            y += rowHeight;
            graphics.DrawLine(
                rulePen,
                left,
                y,
                left + width,
                y
            );
            y += 6;

            while (_printRowIndex < dgvReport.Rows.Count)
            {
                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                DataGridViewRow row = dgvReport.Rows[_printRowIndex];
                graphics.DrawString(
                    row.Cells[0].Value?.ToString() ?? string.Empty,
                    rowFont,
                    darkBrush,
                    new RectangleF(left, y, itemWidth - 8, rowHeight),
                    ellipsis
                );
                graphics.DrawString(
                    row.Cells[1].Value?.ToString() ?? string.Empty,
                    rowFont,
                    darkBrush,
                    new RectangleF(left + itemWidth, y, valueWidth, rowHeight),
                    ellipsis
                );
                y += rowHeight;
                _printRowIndex++;
            }

            if (y + 30 <= e.MarginBounds.Bottom)
            {
                graphics.DrawString(
                    $"Generated {DateTime.Now:yyyy-MM-dd HH:mm}",
                    rowFont,
                    grayBrush,
                    left,
                    y + 8
                );
            }

            e.HasMorePages = false;
        }
    }
}
