namespace Mart_Management_System.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip = new ToolTip();
            components.Add(toolTip);
            dashboardLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            lblTitle = new Label();
            btnRefresh = new Button();
            cardsLayout = new TableLayoutPanel();
            cardRevenue = new Panel();
            cardSales = new Panel();
            cardProducts = new Panel();
            cardLowStock = new Panel();
            cardExpiry = new Panel();
            cardTopProduct = new Panel();
            lblTopProductQuantity = new Label();
            lblChartTitle = new Label();
            chartPanel = new Panel();
            footerLayout = new TableLayoutPanel();
            lblMessage = new Label();
            lblLastUpdated = new Label();
            dashboardLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            cardsLayout.SuspendLayout();
            SuspendLayout();

            dashboardLayout.BackColor = Color.FromArgb(238, 241, 244);
            dashboardLayout.ColumnCount = 1;
            dashboardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            dashboardLayout.Controls.Add(headerLayout, 0, 0);
            dashboardLayout.Controls.Add(cardsLayout, 0, 1);
            dashboardLayout.Controls.Add(lblChartTitle, 0, 2);
            dashboardLayout.Controls.Add(chartPanel, 0, 3);
            dashboardLayout.Controls.Add(footerLayout, 0, 4);
            dashboardLayout.Dock = DockStyle.Fill;
            dashboardLayout.Margin = new Padding(0);
            dashboardLayout.Name = "dashboardLayout";
            dashboardLayout.RowCount = 5;
            dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 190F));
            dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            dashboardLayout.Size = new Size(1100, 700);
            dashboardLayout.TabIndex = 0;

            headerLayout.ColumnCount = 2;
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            headerLayout.Controls.Add(lblTitle, 0, 0);
            headerLayout.Controls.Add(btnRefresh, 1, 0);
            headerLayout.Dock = DockStyle.Fill;
            headerLayout.Margin = new Padding(0);
            headerLayout.Name = "headerLayout";
            headerLayout.Padding = new Padding(20, 0, 20, 0);
            headerLayout.RowCount = 1;
            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headerLayout.Size = new Size(1100, 64);
            headerLayout.TabIndex = 0;

            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(900, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DASHBOARD";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            btnRefresh.BackColor = Color.FromArgb(91, 174, 99);
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Margin = new Padding(0, 13, 0, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(160, 38);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // Six equal-width columns so the cards stay side by side and scale
            // with the form instead of being pinned to fixed offsets.
            cardsLayout.ColumnCount = 6;
            cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            cardsLayout.Controls.Add(cardRevenue, 0, 0);
            cardsLayout.Controls.Add(cardSales, 1, 0);
            cardsLayout.Controls.Add(cardProducts, 2, 0);
            cardsLayout.Controls.Add(cardLowStock, 3, 0);
            cardsLayout.Controls.Add(cardExpiry, 4, 0);
            cardsLayout.Controls.Add(cardTopProduct, 5, 0);
            cardsLayout.Dock = DockStyle.Fill;
            cardsLayout.Margin = new Padding(0);
            cardsLayout.Name = "cardsLayout";
            cardsLayout.Padding = new Padding(20, 0, 20, 0);
            cardsLayout.RowCount = 1;
            cardsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cardsLayout.Size = new Size(1100, 190);
            cardsLayout.TabIndex = 1;

            ConfigureCard(cardRevenue, "Today's Revenue", out lblRevenueTitle, out lblRevenueValue, out _);
            ConfigureCard(cardSales, "Today's Sales", out lblSalesTitle, out lblSalesValue, out _);
            ConfigureCard(cardProducts, "Active Products", out lblProductsTitle, out lblProductsValue, out _);
            ConfigureCard(cardLowStock, "Low Stock", out lblLowStockTitle, out lblLowStockValue, out _);
            ConfigureCard(cardExpiry, "Expiring Soon", out lblExpiryTitle, out lblExpiryValue, out _);
            ConfigureCard(cardTopProduct, "Top Seller", out lblTopProductTitle, out lblTopProductValue, out TableLayoutPanel topProductLayout);

            // The final card carries no trailing gap so the row stays balanced.
            cardTopProduct.Margin = new Padding(0, 10, 0, 10);
            lblTopProductValue.AutoEllipsis = true;
            lblTopProductValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            lblTopProductQuantity.AutoSize = false;
            lblTopProductQuantity.Dock = DockStyle.Fill;
            lblTopProductQuantity.Font = new Font("Segoe UI", 8.5F);
            lblTopProductQuantity.ForeColor = Color.Gray;
            lblTopProductQuantity.Name = "lblTopProductQuantity";
            lblTopProductQuantity.TabIndex = 2;
            lblTopProductQuantity.Text = "No completed sales yet";
            lblTopProductQuantity.TextAlign = ContentAlignment.MiddleLeft;
            topProductLayout.Controls.Add(lblTopProductQuantity, 0, 2);

            lblChartTitle.AutoSize = false;
            lblChartTitle.Dock = DockStyle.Fill;
            lblChartTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblChartTitle.Margin = new Padding(0);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Padding = new Padding(20, 0, 0, 0);
            lblChartTitle.Size = new Size(1100, 32);
            lblChartTitle.TabIndex = 2;
            lblChartTitle.Text = "SALES REVENUE \u2014 LAST 7 DAYS";
            lblChartTitle.TextAlign = ContentAlignment.MiddleLeft;

            chartPanel.BackColor = Color.White;
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Margin = new Padding(20, 0, 20, 8);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(1060, 336);
            chartPanel.TabIndex = 3;
            chartPanel.Paint += ChartPanel_Paint;

            footerLayout.ColumnCount = 1;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            footerLayout.Controls.Add(lblMessage, 0, 0);
            footerLayout.Controls.Add(lblLastUpdated, 0, 1);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.Padding = new Padding(20, 0, 20, 0);
            footerLayout.RowCount = 2;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            footerLayout.Size = new Size(1100, 60);
            footerLayout.TabIndex = 4;

            lblMessage.AutoSize = false;
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(1060, 30);
            lblMessage.TabIndex = 0;
            lblMessage.Text = string.Empty;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            lblLastUpdated.AutoSize = false;
            lblLastUpdated.Dock = DockStyle.Fill;
            lblLastUpdated.ForeColor = Color.Gray;
            lblLastUpdated.Name = "lblLastUpdated";
            lblLastUpdated.Size = new Size(1060, 30);
            lblLastUpdated.TabIndex = 1;
            lblLastUpdated.Text = string.Empty;
            lblLastUpdated.TextAlign = ContentAlignment.MiddleLeft;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(dashboardLayout);
            MinimumSize = new Size(700, 500);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            dashboardLayout.ResumeLayout(false);
            dashboardLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            cardsLayout.ResumeLayout(false);
            cardsLayout.PerformLayout();
            chartPanel.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            footerLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
            Load += DashboardForm_Load;
        }

        private static void ConfigureCard(
            Panel card,
            string title,
            out Label titleLabel,
            out Label valueLabel,
            out TableLayoutPanel cardLayout
        )
        {
            card.BackColor = Color.White;
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 10, 8, 10);
            card.Padding = new Padding(0);
            card.TabStop = false;

            titleLabel = new Label();
            titleLabel.AutoSize = false;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 9F);
            titleLabel.ForeColor = Color.Gray;
            titleLabel.Name = "lblTitle";
            titleLabel.Text = title;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            valueLabel = new Label();
            valueLabel.AutoSize = false;
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(91, 174, 99);
            valueLabel.Name = "lblValue";
            valueLabel.Text = "$0.00";
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            cardLayout = new TableLayoutPanel();
            cardLayout.ColumnCount = 1;
            cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            cardLayout.Dock = DockStyle.Fill;
            cardLayout.Margin = new Padding(0);
            cardLayout.Padding = new Padding(14, 12, 14, 12);
            cardLayout.RowCount = 3;
            cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));

            cardLayout.Controls.Add(titleLabel, 0, 0);
            cardLayout.Controls.Add(valueLabel, 0, 1);

            card.SuspendLayout();
            card.Controls.Add(cardLayout);
            card.ResumeLayout(false);
        }

        private TableLayoutPanel dashboardLayout;
        private TableLayoutPanel headerLayout;
        private TableLayoutPanel cardsLayout;
        private TableLayoutPanel footerLayout;
        private Label lblTitle;
        private ToolTip toolTip;
        private Button btnRefresh;
        private Label lblChartTitle;
        private Panel chartPanel;
        private Panel cardRevenue;
        private Label lblRevenueTitle;
        private Label lblRevenueValue;
        private Panel cardSales;
        private Label lblSalesTitle;
        private Label lblSalesValue;
        private Panel cardProducts;
        private Label lblProductsTitle;
        private Label lblProductsValue;
        private Panel cardLowStock;
        private Label lblLowStockTitle;
        private Label lblLowStockValue;
        private Panel cardExpiry;
        private Label lblExpiryTitle;
        private Label lblExpiryValue;
        private Panel cardTopProduct;
        private Label lblTopProductTitle;
        private Label lblTopProductValue;
        private Label lblTopProductQuantity;
        private Label lblMessage;
        private Label lblLastUpdated;
    }
}
