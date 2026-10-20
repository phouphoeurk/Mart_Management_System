using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Globalization;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;
using Mart_Management_System.UI;

namespace Mart_Management_System.Forms
{
    public partial class DashboardForm : Form
    {
        private enum DashboardRange
        {
            Day = 0,
            Week = 1,
            Month = 2
        }

        private enum TrendGranularity
        {
            Hour,
            Day
        }

        private readonly record struct TrendSlot(
            string Key,
            string XLabel,
            decimal Value
        );

        private sealed class KpiCard
        {
            public required RoundedPanel Card { get; init; }

            public required Label Value { get; init; }

            public required Label Delta { get; init; }
        }

        private readonly DashboardRepository _dashboardRepository;
        private readonly List<KpiCard> _kpiCards = new();
        private List<ReportRow> _trend = new();
        private TrendGranularity _granularity = TrendGranularity.Day;
        private DashboardRange _range = DashboardRange.Week;
        private System.Windows.Forms.Timer? _fadeTimer;

        private WidgetListPanel _widgetTopProducts = null!;
        private WidgetListPanel _widgetPayments = null!;
        private WidgetListPanel _widgetRecentSales = null!;
        private WidgetListPanel _widgetLowStock = null!;

        private static readonly Color DeltaUpColor = Color.FromArgb(38, 139, 70);
        private static readonly Color DeltaDownColor = Color.FromArgb(200, 60, 60);

        public DashboardForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _dashboardRepository = new DashboardRepository();

            toggleRange.SetItems("1 Day", "1 Week", "1 Month");
            toggleRange.SelectedIndexChanged += toggleRange_SelectedIndexChanged;
            toggleRange.SelectedIndex = (int)DashboardRange.Week;

            BuildKpiCards();
            BuildWidgets();

            chartPanel.Resize += (_, _) => chartPanel.Invalidate();

            _fadeTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _fadeTimer.Tick += FadeTimer_Tick;
        }

        private void DashboardForm_Load(object? sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void toggleRange_SelectedIndexChanged(object? sender, EventArgs e)
        {
            DashboardRange range = (DashboardRange)toggleRange.SelectedIndex;
            if (range == _range)
            {
                return;
            }

            _range = range;
            LoadDashboard();
        }

        private void BuildKpiCards()
        {
            AddKpiCard(0, "Revenue", "Revenue");
            AddKpiCard(1, "Sales", "Sales");
            AddKpiCard(2, "Top Seller", "Top Seller");
            AddKpiCard(3, "Active Products", "Active Products");
            AddKpiCard(4, "Low Stock", "Low Stock");
            AddKpiCard(5, "Expiring Soon", "Expiring Soon");
        }

        private void AddKpiCard(int column, string title, string tooltip)
        {
            RoundedPanel card = new()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 4, 0, 4),
                Padding = new Padding(14, 8, 14, 6),
                HoverEffect = true
            };

            Label titleLabel = new()
            {
                Dock = DockStyle.Top,
                Height = 22,
                Text = title,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label valueLabel = new()
            {
                Dock = DockStyle.Fill,
                Text = "—",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = UiTheme.ActiveGreen,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };

            Label deltaLabel = new()
            {
                Dock = DockStyle.Bottom,
                Height = 22,
                Text = string.Empty,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };

            // Dock pass runs last-added first: title, then delta, value fills.
            card.Controls.Add(valueLabel);
            card.Controls.Add(deltaLabel);
            card.Controls.Add(titleLabel);

            cardsLayout.Controls.Add(card, column, 0);
            toolTip.SetToolTip(card, tooltip);
            _kpiCards.Add(new KpiCard
            {
                Card = card,
                Value = valueLabel,
                Delta = deltaLabel
            });
        }

        private void BuildWidgets()
        {
            _widgetTopProducts = new WidgetListPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 4, 4, 4)
            };
            _widgetPayments = new WidgetListPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(4, 4, 0, 4)
            };
            _widgetRecentSales = new WidgetListPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 4, 4, 0)
            };
            _widgetLowStock = new WidgetListPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(4, 4, 0, 0)
            };

            widgetsLayout.Controls.Add(_widgetTopProducts, 0, 0);
            widgetsLayout.Controls.Add(_widgetPayments, 1, 0);
            widgetsLayout.Controls.Add(_widgetRecentSales, 0, 1);
            widgetsLayout.Controls.Add(_widgetLowStock, 1, 1);

            _widgetTopProducts.SetContent(
                "Top Products",
                Array.Empty<WidgetRow>()
            );
            _widgetPayments.SetContent(
                "Payment Mix",
                Array.Empty<WidgetRow>()
            );
            _widgetRecentSales.SetContent(
                "Recent Sales",
                Array.Empty<WidgetRow>()
            );
            _widgetLowStock.SetContent(
                "Low Stock",
                Array.Empty<WidgetRow>()
            );
        }

        private void LoadDashboard()
        {
            try
            {
                UseWaitCursor = true;
                lblMessage.Text = string.Empty;

                (
                    DateTime from,
                    DateTime to,
                    DateTime prevFrom,
                    DateTime prevTo,
                    string compareText,
                    string periodText
                ) = GetRangeBounds(_range);

                DashboardSnapshot snapshot =
                    _dashboardRepository.GetDashboardSnapshot(
                        from,
                        to,
                        prevFrom,
                        prevTo,
                        _range == DashboardRange.Day,
                        5,
                        5,
                        5
                    );

                LoadSummaryCards(snapshot.Summary);
                LoadRangeCards(
                    snapshot.Current,
                    snapshot.Previous,
                    compareText,
                    periodText
                );

                _granularity = _range == DashboardRange.Day
                    ? TrendGranularity.Hour
                    : TrendGranularity.Day;
                _trend = snapshot.Trend;

                lblChartTitle.Text = ChartTitleFor(_range);

                LoadTopProductsWidget(snapshot.TopProducts);
                LoadPaymentsWidget(snapshot.PaymentMix);
                LoadRecentSalesWidget(snapshot.RecentSales);
                LoadLowStockWidget(snapshot.LowStock);

                lblLastUpdated.Text = $"Updated {DateTime.Now:yyyy-MM-dd HH:mm}";
                chartPanel.Invalidate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                _trend = new List<ReportRow>();
                lblMessage.Text = "Unable to load dashboard data.";
                chartPanel.Invalidate();
            }
            finally
            {
                UseWaitCursor = false;
            }

            StartFade();
        }

        private void LoadSummaryCards(DashboardSummary summary)
        {
            SetCard(
                3,
                summary.ActiveProducts.ToString("N0"),
                ("in catalog now", Color.Gray),
                "Products currently enabled in the catalog."
            );
            SetCard(
                4,
                summary.LowStockCount.ToString("N0"),
                ("at or below reorder level", Color.Gray),
                "Products with stock at or below the reorder level."
            );
            SetCard(
                5,
                summary.ExpiringSoonCount.ToString("N0"),
                ("within the next 30 days", Color.Gray),
                "Products expiring within the next 30 days."
            );
        }

        private void LoadRangeCards(
            RangeSummary current,
            RangeSummary previous,
            string compareText,
            string periodText
        )
        {
            SetCard(
                0,
                current.Revenue.ToString("C2"),
                BuildDelta(current.Revenue, previous.Revenue, compareText),
                $"Completed sales revenue for {periodText}."
            );
            SetCard(
                1,
                current.SalesCount.ToString("N0"),
                BuildDelta(current.SalesCount, previous.SalesCount, compareText),
                $"Completed sales count for {periodText}."
            );
            SetCard(
                2,
                current.TopSellingProduct,
                BuildTopSellerDelta(current, previous, compareText),
                current.TopSellingQuantity > 0
                    ? $"{current.TopSellingQuantity:0} units sold for {periodText}."
                    : "No completed sales in this period."
            );
        }

        private void LoadTopProductsWidget(List<ReportRow> topProducts)
        {
            decimal topMax = topProducts.Count > 0
                ? Math.Max(1m, topProducts[0].Value)
                : 1m;
            _widgetTopProducts.SetContent(
                "Top Products",
                topProducts.Select(
                    row => new WidgetRow
                    {
                        LeftText = row.Label,
                        RightText = $"{row.Value:0} u",
                        BarFraction = (float)(row.Value / topMax)
                    }
                ),
                "No sales in this period"
            );
            toolTip.SetToolTip(
                _widgetTopProducts,
                "Top selling products for the selected period."
            );
        }

        private void LoadPaymentsWidget(List<ReportRow> payments)
        {
            decimal paymentTotal = payments.Sum(row => row.Value);
            _widgetPayments.SetContent(
                "Payment Mix",
                payments.Select(
                    row => new WidgetRow
                    {
                        LeftText = row.Label,
                        RightText = row.Value.ToString("C2"),
                        BarFraction = paymentTotal > 0
                            ? (float?)(row.Value / paymentTotal)
                            : null
                    }
                ),
                "No completed sales in this period"
            );
            toolTip.SetToolTip(
                _widgetPayments,
                "Revenue split by payment method."
            );
        }

        private void LoadRecentSalesWidget(List<SaleSummary> recent)
        {
            _widgetRecentSales.SetContent(
                "Recent Sales",
                recent.Select(
                    sale => new WidgetRow
                    {
                        LeftText =
                            $"{sale.SaleDate:MM-dd HH:mm}  {sale.CashierName}",
                        RightText = sale.TotalAmount.ToString("C2"),
                        RightColor = sale.Status.Equals(
                            "Completed",
                            StringComparison.OrdinalIgnoreCase
                        )
                            ? DeltaUpColor
                            : Color.Gray
                    }
                ),
                "No sales yet"
            );
            toolTip.SetToolTip(
                _widgetRecentSales,
                "Most recent sales on record."
            );
        }

        private void LoadLowStockWidget(List<ReportRow> lowStock)
        {
            _widgetLowStock.SetContent(
                "Low Stock",
                lowStock.Select(
                    row => new WidgetRow
                    {
                        LeftText = row.Label,
                        RightText = row.DisplayValue
                    }
                ),
                "All products above reorder level"
            );
            toolTip.SetToolTip(
                _widgetLowStock,
                "Products at or below their reorder level."
            );
        }

        private void SetCard(
            int index,
            string value,
            (string Text, Color Color) delta,
            string tooltip
        )
        {
            KpiCard card = _kpiCards[index];
            card.Value.Text = value;
            card.Delta.Text = delta.Text;
            card.Delta.ForeColor = delta.Color;
            toolTip.SetToolTip(card.Card, tooltip);
        }

        private static (string Text, Color Color) BuildDelta(
            decimal current,
            decimal previous,
            string compareText
        )
        {
            if (previous == 0)
            {
                return current == 0
                    ? ($"no change vs {compareText}", Color.Gray)
                    : ($"new vs {compareText}", DeltaUpColor);
            }

            decimal percent = ((current - previous) / previous) * 100m;
            if (percent == 0)
            {
                return ($"no change vs {compareText}", Color.Gray);
            }

            string arrow = percent > 0 ? "\u25B2" : "\u25BC";
            Color color = percent > 0 ? DeltaUpColor : DeltaDownColor;
            return ($"{arrow} {Math.Abs(percent):0.#}% vs {compareText}", color);
        }

        private static (string Text, Color Color) BuildTopSellerDelta(
            RangeSummary current,
            RangeSummary previous,
            string compareText
        )
        {
            if (current.TopSellingQuantity <= 0)
            {
                return ("no sales in period", Color.Gray);
            }

            if (previous.TopSellingQuantity <= 0)
            {
                return (
                    $"new \u2014 {current.TopSellingQuantity:0} units",
                    DeltaUpColor
                );
            }

            decimal percent =
                ((current.TopSellingQuantity - previous.TopSellingQuantity)
                    / previous.TopSellingQuantity)
                * 100m;
            if (percent == 0)
            {
                return (
                    $"level \u2014 {current.TopSellingQuantity:0} units",
                    Color.Gray
                );
            }

            string arrow = percent > 0 ? "\u25B2" : "\u25BC";
            Color color = percent > 0 ? DeltaUpColor : DeltaDownColor;
            return (
                $"{arrow} {Math.Abs(percent):0.#}% \u2014 {current.TopSellingQuantity:0} units vs {compareText}",
                color
            );
        }

        private static (
            DateTime From,
            DateTime To,
            DateTime PrevFrom,
            DateTime PrevTo,
            string CompareText,
            string PeriodText
        )
            GetRangeBounds(DashboardRange range)
        {
            DateTime today = DateTime.Today;
            return range switch
            {
                DashboardRange.Day => (
                    today,
                    today,
                    today.AddDays(-1),
                    today.AddDays(-1),
                    "yesterday",
                    "today"
                ),
                DashboardRange.Month => (
                    today.AddDays(-29),
                    today,
                    today.AddDays(-59),
                    today.AddDays(-30),
                    "the previous 30 days",
                    "the last 30 days"
                ),
                _ => (
                    today.AddDays(-6),
                    today,
                    today.AddDays(-13),
                    today.AddDays(-7),
                    "the previous 7 days",
                    "the last 7 days"
                )
            };
        }

        private static string ChartTitleFor(DashboardRange range)
        {
            return range switch
            {
                DashboardRange.Day => "SALES REVENUE \u2014 TODAY (HOURLY)",
                DashboardRange.Month => "SALES REVENUE \u2014 LAST 30 DAYS",
                _ => "SALES REVENUE \u2014 LAST 7 DAYS"
            };
        }

        private List<TrendSlot> BuildSlots()
        {
            DateTime today = DateTime.Today;

            if (_granularity == TrendGranularity.Hour)
            {
                List<TrendSlot> hourSlots = new(24);
                for (int hour = 0; hour < 24; hour++)
                {
                    string key = hour.ToString("00", CultureInfo.InvariantCulture);
                    decimal value =
                        _trend.FirstOrDefault(row => row.Label == key)?.Value ?? 0;
                    hourSlots.Add(
                        new TrendSlot(
                            key,
                            hour % 3 == 0 ? key : string.Empty,
                            value
                        )
                    );
                }

                return hourSlots;
            }

            int days = _range == DashboardRange.Month ? 30 : 7;
            List<TrendSlot> daySlots = new(days);
            for (int offset = days - 1; offset >= 0; offset--)
            {
                DateTime date = today.AddDays(-offset);
                string key = date.ToString(
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture
                );
                decimal value =
                    _trend.FirstOrDefault(row => row.Label == key)?.Value ?? 0;
                string xLabel = days == 7
                    ? date.ToString("ddd", CultureInfo.CurrentCulture)
                    : offset % 5 == 0
                        ? date.ToString("MM-dd", CultureInfo.InvariantCulture)
                        : string.Empty;
                daySlots.Add(new TrendSlot(key, xLabel, value));
            }

            return daySlots;
        }

        private void ChartPanel_Paint(object? sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Color.White);

            List<TrendSlot> slots = BuildSlots();

            const int leftMargin = 64;
            const int rightMargin = 16;
            const int topMargin = 26;
            const int bottomMargin = 44;
            int chartWidth = Math.Max(
                60,
                chartPanel.Width - leftMargin - rightMargin
            );
            int chartHeight = Math.Max(
                60,
                chartPanel.Height - topMargin - bottomMargin
            );
            int chartBottom = topMargin + chartHeight;

            decimal maximum = slots.Count == 0
                ? 0
                : slots.Max(slot => slot.Value);
            (decimal scaleMaximum, decimal[] ticks) = GetNiceTicks(maximum);

            using Font axisFont = new("Segoe UI", 8F);
            using Font valueFont = new("Segoe UI", 8F, FontStyle.Bold);
            using SolidBrush axisBrush = new(Color.FromArgb(110, 110, 110));
            using SolidBrush valueBrush = new(Color.FromArgb(70, 70, 70));
            using SolidBrush barBrush = new(UiTheme.ActiveGreen);
            using SolidBrush emptyBarBrush = new(Color.FromArgb(232, 232, 232));
            using Pen gridPen = new(Color.FromArgb(228, 231, 235));

            for (int index = 0; index < ticks.Length; index++)
            {
                decimal tick = ticks[index];
                int y = scaleMaximum <= 0
                    ? chartBottom
                    : chartBottom
                        - (int)(chartHeight * (double)(tick / scaleMaximum));
                graphics.DrawLine(gridPen, leftMargin, y, leftMargin + chartWidth, y);

                string tickLabel = "$" + tick.ToString("0.##", CultureInfo.CurrentCulture);
                SizeF labelSize = graphics.MeasureString(tickLabel, axisFont);
                graphics.DrawString(
                    tickLabel,
                    axisFont,
                    axisBrush,
                    leftMargin - 8 - labelSize.Width,
                    y - (labelSize.Height / 2)
                );
            }

            int slotWidth = Math.Max(4, chartWidth / Math.Max(1, slots.Count));
            int gap = slots.Count > 14 ? 6 : 26;
            int barWidth = Math.Max(3, slotWidth - gap);

            for (int index = 0; index < slots.Count; index++)
            {
                TrendSlot slot = slots[index];
                int barHeight = slot.Value <= 0
                    ? 0
                    : Math.Max(
                        4,
                        (int)(chartHeight * (double)(slot.Value / scaleMaximum))
                    );
                int x = leftMargin + (index * slotWidth)
                    + ((slotWidth - barWidth) / 2);
                int y = chartBottom - barHeight;

                graphics.FillRectangle(
                    slot.Value > 0 ? barBrush : emptyBarBrush,
                    x,
                    y,
                    barWidth,
                    slot.Value > 0 ? barHeight : 3
                );

                if (slot.XLabel.Length > 0)
                {
                    graphics.DrawString(
                        slot.XLabel,
                        axisFont,
                        axisBrush,
                        new RectangleF(
                            leftMargin + (index * slotWidth),
                            chartBottom + 8,
                            slotWidth,
                            20
                        ),
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center
                        }
                    );
                }

                if (slot.Value > 0 && slotWidth >= 28)
                {
                    string barLabel = slot.Value.ToString(
                        "C2",
                        CultureInfo.CurrentCulture
                    );
                    graphics.DrawString(
                        barLabel,
                        valueFont,
                        valueBrush,
                        new RectangleF(
                            x - (slotWidth - barWidth),
                            Math.Max(2, y - 18),
                            slotWidth,
                            16
                        ),
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center
                        }
                    );
                }
            }

            if (slots.Count == 0 || slots.All(slot => slot.Value == 0))
            {
                graphics.DrawString(
                    "No sales data available",
                    valueFont,
                    axisBrush,
                    new RectangleF(leftMargin, topMargin, chartWidth, chartHeight),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                );
            }
        }

        private static (decimal ScaleMaximum, decimal[] Ticks) GetNiceTicks(
            decimal maximum
        )
        {
            if (maximum <= 0)
            {
                return (10m, new[] { 0m, 2.5m, 5m, 7.5m, 10m });
            }

            decimal rawStep = maximum / 4m;
            decimal magnitude = (decimal)Math.Pow(
                10,
                Math.Floor(Math.Log10((double)rawStep))
            );
            decimal normalized = rawStep / magnitude;
            decimal step = normalized switch
            {
                <= 1m => 1m,
                <= 2m => 2m,
                <= 2.5m => 2.5m,
                <= 5m => 5m,
                _ => 10m
            } * magnitude;

            int intervals = Math.Max(
                1,
                (int)Math.Ceiling((double)(maximum / step))
            );
            intervals = Math.Min(intervals, 8);
            decimal scaleMaximum = step * intervals;
            decimal[] ticks = new decimal[intervals + 1];
            for (int index = 0; index <= intervals; index++)
            {
                ticks[index] = step * index;
            }

            return (scaleMaximum, ticks);
        }

        private void middlePanel_Resize(object? sender, EventArgs e)
        {
            fadeOverlay.Bounds = middlePanel.ClientRectangle;
        }

        private void StartFade()
        {
            if (_fadeTimer is null)
            {
                return;
            }

            _fadeTimer.Stop();
            fadeOverlay.BringToFront();
            fadeOverlay.BackColor = Color.FromArgb(150, 238, 241, 244);
            fadeOverlay.Visible = true;
            _fadeTimer.Start();
        }

        private void FadeTimer_Tick(object? sender, EventArgs e)
        {
            int alpha = fadeOverlay.BackColor.A - 12;
            if (alpha <= 0)
            {
                fadeOverlay.Visible = false;
                _fadeTimer?.Stop();
                return;
            }

            fadeOverlay.BackColor = Color.FromArgb(alpha, 238, 241, 244);
        }
    }
}
