using Mart_Management_System.UI;

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

            _fadeTimer?.Dispose();
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
            toggleRange = new SegmentedToggle();
            btnRefresh = new Button();
            middlePanel = new BufferedPanel();
            fadeOverlay = new BufferedPanel();
            contentLayout = new TableLayoutPanel();
            chartCard = new RoundedPanel();
            chartPanel = new BufferedPanel();
            lblChartTitle = new Label();
            widgetsLayout = new TableLayoutPanel();
            cardsLayout = new TableLayoutPanel();
            footerLayout = new TableLayoutPanel();
            lblMessage = new Label();
            lblLastUpdated = new Label();
            dashboardLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            middlePanel.SuspendLayout();
            contentLayout.SuspendLayout();
            chartCard.SuspendLayout();
            widgetsLayout.SuspendLayout();
            cardsLayout.SuspendLayout();
            footerLayout.SuspendLayout();
            SuspendLayout();

            dashboardLayout.BackColor = Color.FromArgb(238, 241, 244);
            dashboardLayout.ColumnCount = 1;
            dashboardLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F)
            );
            dashboardLayout.Controls.Add(headerLayout, 0, 0);
            dashboardLayout.Controls.Add(middlePanel, 0, 1);
            dashboardLayout.Controls.Add(footerLayout, 0, 2);
            dashboardLayout.Dock = DockStyle.Fill;
            dashboardLayout.Margin = new Padding(0);
            dashboardLayout.Name = "dashboardLayout";
            dashboardLayout.RowCount = 3;
            dashboardLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 64F)
            );
            dashboardLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            dashboardLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 54F)
            );
            dashboardLayout.Size = new Size(1100, 700);
            dashboardLayout.TabIndex = 0;

            headerLayout.ColumnCount = 3;
            headerLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F)
            );
            headerLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 250F)
            );
            headerLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 140F)
            );
            headerLayout.Controls.Add(lblTitle, 0, 0);
            headerLayout.Controls.Add(toggleRange, 1, 0);
            headerLayout.Controls.Add(btnRefresh, 2, 0);
            headerLayout.Dock = DockStyle.Fill;
            headerLayout.Margin = new Padding(0);
            headerLayout.Name = "headerLayout";
            headerLayout.Padding = new Padding(20, 0, 20, 0);
            headerLayout.RowCount = 1;
            headerLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            headerLayout.Size = new Size(1100, 64);
            headerLayout.TabIndex = 0;

            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(670, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DASHBOARD";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            toggleRange.Dock = DockStyle.Fill;
            toggleRange.Margin = new Padding(12, 15, 0, 15);
            toggleRange.Name = "toggleRange";
            toggleRange.TabIndex = 1;

            btnRefresh.BackColor = Color.FromArgb(91, 174, 99);
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Margin = new Padding(12, 13, 0, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 38);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            middlePanel.BackColor = Color.FromArgb(238, 241, 244);
            middlePanel.Controls.Add(fadeOverlay);
            middlePanel.Controls.Add(contentLayout);
            middlePanel.Controls.Add(cardsLayout);
            middlePanel.Dock = DockStyle.Fill;
            middlePanel.Margin = new Padding(0);
            middlePanel.Name = "middlePanel";
            middlePanel.Size = new Size(1100, 582);
            middlePanel.TabIndex = 1;
            middlePanel.Resize += middlePanel_Resize;

            // Added first so it sits at the front of the z-order; Dock.None keeps
            // it out of the dock pass and its bounds are set on resize.
            fadeOverlay.BackColor = Color.FromArgb(
                0,
                238,
                241,
                244
            );
            fadeOverlay.Dock = DockStyle.None;
            fadeOverlay.Location = new Point(0, 0);
            fadeOverlay.Margin = new Padding(0);
            fadeOverlay.Name = "fadeOverlay";
            fadeOverlay.Size = new Size(1100, 582);
            fadeOverlay.TabIndex = 0;
            fadeOverlay.Visible = false;

            contentLayout.BackColor = Color.FromArgb(238, 241, 244);
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 56F)
            );
            contentLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 44F)
            );
            contentLayout.Controls.Add(chartCard, 0, 0);
            contentLayout.Controls.Add(widgetsLayout, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.Padding = new Padding(20, 0, 20, 4);
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            contentLayout.Size = new Size(1100, 430);
            contentLayout.TabIndex = 1;

            chartCard.BackColor = Color.White;
            chartCard.Controls.Add(chartPanel);
            chartCard.Controls.Add(lblChartTitle);
            chartCard.Dock = DockStyle.Fill;
            chartCard.Margin = new Padding(0, 0, 5, 0);
            chartCard.Name = "chartCard";
            chartCard.Padding = new Padding(4, 4, 4, 4);
            chartCard.Size = new Size(600, 426);
            chartCard.TabIndex = 0;

            chartPanel.BackColor = Color.White;
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(0, 40);
            chartPanel.Margin = new Padding(0);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(600, 386);
            chartPanel.TabIndex = 1;
            chartPanel.Paint += ChartPanel_Paint;

            lblChartTitle.AutoSize = false;
            lblChartTitle.Dock = DockStyle.Top;
            lblChartTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblChartTitle.Location = new Point(0, 0);
            lblChartTitle.Margin = new Padding(0);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Padding = new Padding(14, 0, 0, 0);
            lblChartTitle.Size = new Size(600, 40);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "SALES REVENUE \u2014 LAST 7 DAYS";
            lblChartTitle.TextAlign = ContentAlignment.MiddleLeft;

            widgetsLayout.BackColor = Color.FromArgb(238, 241, 244);
            widgetsLayout.ColumnCount = 2;
            widgetsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F)
            );
            widgetsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F)
            );
            widgetsLayout.Dock = DockStyle.Fill;
            widgetsLayout.Margin = new Padding(5, 0, 0, 0);
            widgetsLayout.Name = "widgetsLayout";
            widgetsLayout.RowCount = 2;
            widgetsLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F)
            );
            widgetsLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F)
            );
            widgetsLayout.Size = new Size(479, 426);
            widgetsLayout.TabIndex = 1;

            // Dock pass runs last-added first, so the top strip is claimed first.
            cardsLayout.BackColor = Color.FromArgb(238, 241, 244);
            cardsLayout.ColumnCount = 6;
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 16.666666F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 16.666666F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 16.666666F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 16.666666F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 16.666666F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 16.666666F)
            );
            cardsLayout.Dock = DockStyle.Top;
            cardsLayout.Margin = new Padding(0);
            cardsLayout.Name = "cardsLayout";
            cardsLayout.Padding = new Padding(20, 0, 20, 0);
            cardsLayout.RowCount = 1;
            cardsLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            cardsLayout.Size = new Size(1100, 152);
            cardsLayout.TabIndex = 2;

            footerLayout.ColumnCount = 1;
            footerLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F)
            );
            footerLayout.Controls.Add(lblMessage, 0, 0);
            footerLayout.Controls.Add(lblLastUpdated, 0, 1);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.Padding = new Padding(20, 0, 20, 0);
            footerLayout.RowCount = 2;
            footerLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F)
            );
            footerLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F)
            );
            footerLayout.Size = new Size(1100, 54);
            footerLayout.TabIndex = 2;

            lblMessage.AutoSize = false;
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(1060, 27);
            lblMessage.TabIndex = 0;
            lblMessage.Text = string.Empty;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            lblLastUpdated.AutoSize = false;
            lblLastUpdated.Dock = DockStyle.Fill;
            lblLastUpdated.ForeColor = Color.Gray;
            lblLastUpdated.Name = "lblLastUpdated";
            lblLastUpdated.Size = new Size(1060, 27);
            lblLastUpdated.TabIndex = 1;
            lblLastUpdated.Text = string.Empty;
            lblLastUpdated.TextAlign = ContentAlignment.MiddleLeft;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(dashboardLayout);
            MinimumSize = new Size(860, 540);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            dashboardLayout.ResumeLayout(false);
            dashboardLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            middlePanel.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            chartCard.ResumeLayout(false);
            widgetsLayout.ResumeLayout(false);
            cardsLayout.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            footerLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
            Load += DashboardForm_Load;
        }

        private TableLayoutPanel dashboardLayout;
        private TableLayoutPanel headerLayout;
        private TableLayoutPanel contentLayout;
        private TableLayoutPanel widgetsLayout;
        private TableLayoutPanel cardsLayout;
        private TableLayoutPanel footerLayout;
        private Label lblTitle;
        private Label lblChartTitle;
        private Label lblMessage;
        private Label lblLastUpdated;
        private ToolTip toolTip;
        private Button btnRefresh;
        private SegmentedToggle toggleRange;
        private BufferedPanel middlePanel;
        private BufferedPanel fadeOverlay;
        private BufferedPanel chartPanel;
        private RoundedPanel chartCard;
    }
}
