using Mart_Management_System.UI;

namespace Mart_Management_System.Forms
{
    partial class ReportsForm
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
            mainLayout = new TableLayoutPanel();
            lblTitle = new Label();
            cardsLayout = new TableLayoutPanel();
            card1 = new RoundedPanel();
            card2 = new RoundedPanel();
            card3 = new RoundedPanel();
            card4 = new RoundedPanel();
            filterFlow = new FlowLayoutPanel();
            lblReport = new Label();
            cbReport = new ComboBox();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnGenerate = new Button();
            btnExport = new Button();
            btnPrint = new Button();
            bodyLayout = new TableLayoutPanel();
            gridPanel = new Panel();
            lblGridPlaceholder = new Label();
            dgvReport = new DataGridView();
            colReportLabel = new DataGridViewTextBoxColumn();
            colReportValue = new DataGridViewTextBoxColumn();
            summaryPanel = new Panel();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            mainLayout.SuspendLayout();
            cardsLayout.SuspendLayout();
            card1.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            card4.SuspendLayout();
            filterFlow.SuspendLayout();
            bodyLayout.SuspendLayout();
            gridPanel.SuspendLayout();
            summaryPanel.SuspendLayout();
            SuspendLayout();

            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F)
            );
            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(cardsLayout, 0, 1);
            mainLayout.Controls.Add(filterFlow, 0, 2);
            mainLayout.Controls.Add(bodyLayout, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Margin = new Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1060, 660);
            mainLayout.TabIndex = 0;

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1060, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REPORTS";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            cardsLayout.ColumnCount = 4;
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F)
            );
            cardsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F)
            );
            cardsLayout.Controls.Add(card1, 0, 0);
            cardsLayout.Controls.Add(card2, 1, 0);
            cardsLayout.Controls.Add(card3, 2, 0);
            cardsLayout.Controls.Add(card4, 3, 0);
            cardsLayout.Dock = DockStyle.Fill;
            cardsLayout.Margin = new Padding(0);
            cardsLayout.Name = "cardsLayout";
            cardsLayout.RowCount = 1;
            cardsLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            cardsLayout.Size = new Size(1060, 130);
            cardsLayout.TabIndex = 1;

            ConfigureCard(card1, "Daily Sales", out lblCard1Title, out lblCard1Value);
            ConfigureCard(card2, "Weekly Sales", out lblCard2Title, out lblCard2Value);
            ConfigureCard(card3, "Monthly Sales", out lblCard3Title, out lblCard3Value);
            ConfigureCard(card4, "Total Revenue", out lblCard4Title, out lblCard4Value);

            filterFlow.Controls.Add(lblReport);
            filterFlow.Controls.Add(cbReport);
            filterFlow.Controls.Add(lblFrom);
            filterFlow.Controls.Add(dtpFrom);
            filterFlow.Controls.Add(lblTo);
            filterFlow.Controls.Add(dtpTo);
            filterFlow.Controls.Add(btnGenerate);
            filterFlow.Controls.Add(btnExport);
            filterFlow.Controls.Add(btnPrint);
            filterFlow.Dock = DockStyle.Fill;
            filterFlow.Name = "filterFlow";
            filterFlow.Padding = new Padding(0, 10, 0, 0);
            filterFlow.Size = new Size(1060, 60);
            filterFlow.TabIndex = 2;
            filterFlow.WrapContents = false;

            lblReport.AutoSize = true;
            lblReport.Font = new Font("Segoe UI", 10F);
            lblReport.Margin = new Padding(0, 7, 6, 0);
            lblReport.Name = "lblReport";
            lblReport.Text = "Report:";

            cbReport.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReport.Font = new Font("Segoe UI", 10F);
            cbReport.Margin = new Padding(0, 4, 18, 0);
            cbReport.Name = "cbReport";
            cbReport.Size = new Size(265, 28);
            cbReport.Items.AddRange(
                new object[]
                {
                    "Sales Trend",
                    "Revenue by Cashier",
                    "Revenue by Payment Method",
                    "Top Products",
                    "Sales by Category",
                    "Sales by Product",
                    "Supplier Purchase History",
                    "Inventory Value",
                    "Low Stock Report",
                    "Profit Report"
                }
            );
            cbReport.SelectedIndexChanged += cbReport_SelectedIndexChanged;

            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.Margin = new Padding(0, 7, 6, 0);
            lblFrom.Name = "lblFrom";
            lblFrom.Text = "From:";

            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Margin = new Padding(0, 4, 16, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(115, 26);

            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 10F);
            lblTo.Margin = new Padding(0, 7, 6, 0);
            lblTo.Name = "lblTo";
            lblTo.Text = "To:";

            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Margin = new Padding(0, 4, 16, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(115, 26);

            btnGenerate.BackColor = Color.FromArgb(91, 174, 99);
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Margin = new Padding(0, 3, 8, 0);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(110, 32);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;

            btnExport.BackColor = Color.White;
            btnExport.FlatAppearance.BorderColor = Color.FromArgb(91, 174, 99);
            btnExport.FlatAppearance.BorderSize = 1;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.FromArgb(91, 174, 99);
            btnExport.Margin = new Padding(0, 3, 8, 0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(110, 32);
            btnExport.TabIndex = 7;
            btnExport.Text = "Export CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;

            btnPrint.BackColor = Color.White;
            btnPrint.FlatAppearance.BorderColor = Color.FromArgb(91, 174, 99);
            btnPrint.FlatAppearance.BorderSize = 1;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrint.ForeColor = Color.FromArgb(91, 174, 99);
            btnPrint.Margin = new Padding(0, 3, 0, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(90, 32);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;

            bodyLayout.ColumnCount = 2;
            bodyLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 68F)
            );
            bodyLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 32F)
            );
            bodyLayout.Controls.Add(gridPanel, 0, 0);
            bodyLayout.Controls.Add(summaryPanel, 1, 0);
            bodyLayout.Dock = DockStyle.Fill;
            bodyLayout.Margin = new Padding(0);
            bodyLayout.Name = "bodyLayout";
            bodyLayout.RowCount = 1;
            bodyLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            bodyLayout.Size = new Size(1060, 420);
            bodyLayout.TabIndex = 3;

            gridPanel.BackColor = Color.White;
            gridPanel.Controls.Add(lblGridPlaceholder);
            gridPanel.Controls.Add(dgvReport);
            gridPanel.Dock = DockStyle.Fill;
            gridPanel.Margin = new Padding(0, 8, 6, 0);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(714, 412);
            gridPanel.TabIndex = 0;

            // Added first so it paints over the grid when the result is empty.
            lblGridPlaceholder.Dock = DockStyle.Fill;
            lblGridPlaceholder.Font = new Font("Segoe UI", 11F);
            lblGridPlaceholder.ForeColor = Color.Gray;
            lblGridPlaceholder.Name = "lblGridPlaceholder";
            lblGridPlaceholder.Size = new Size(714, 412);
            lblGridPlaceholder.TabIndex = 0;
            lblGridPlaceholder.Text = "No data for the selected filters.";
            lblGridPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            lblGridPlaceholder.Visible = false;

            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersHeight = 38;
            dgvReport.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colReportLabel,
                    colReportValue
                }
            );
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Margin = new Padding(0);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(714, 412);
            dgvReport.TabIndex = 1;

            colReportLabel.HeaderText = "Report Item";
            colReportLabel.Name = "colReportLabel";
            colReportLabel.ReadOnly = true;
            colReportValue.HeaderText = "Value";
            colReportValue.Name = "colReportValue";
            colReportValue.ReadOnly = true;

            summaryPanel.BackColor = Color.White;
            summaryPanel.Controls.Add(lblSummary);
            summaryPanel.Dock = DockStyle.Fill;
            summaryPanel.Margin = new Padding(6, 8, 0, 0);
            summaryPanel.Name = "summaryPanel";
            summaryPanel.Size = new Size(328, 412);
            summaryPanel.TabIndex = 1;

            lblSummary.Dock = DockStyle.Fill;
            lblSummary.Font = new Font("Segoe UI", 10.5F);
            lblSummary.ForeColor = Color.FromArgb(70, 70, 70);
            lblSummary.Name = "lblSummary";
            lblSummary.Padding = new Padding(16, 14, 12, 12);
            lblSummary.Size = new Size(328, 412);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Report summary will appear here.";
            lblSummary.TextAlign = ContentAlignment.TopLeft;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(mainLayout);
            MinimumSize = new Size(1050, 620);
            Name = "ReportsForm";
            Padding = new Padding(20);
            Text = "Reports";

            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            mainLayout.ResumeLayout(false);
            cardsLayout.ResumeLayout(false);
            card1.ResumeLayout(false);
            card1.PerformLayout();
            card2.ResumeLayout(false);
            card2.PerformLayout();
            card3.ResumeLayout(false);
            card3.PerformLayout();
            card4.ResumeLayout(false);
            card4.PerformLayout();
            filterFlow.ResumeLayout(false);
            filterFlow.PerformLayout();
            bodyLayout.ResumeLayout(false);
            gridPanel.ResumeLayout(false);
            gridPanel.PerformLayout();
            summaryPanel.ResumeLayout(false);
            summaryPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
            Load += ReportsForm_Load;
        }

        private static void ConfigureCard(
            RoundedPanel card,
            string title,
            out Label titleLabel,
            out Label valueLabel
        )
        {
            card.BackColor = Color.White;
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 4, 10, 4);
            card.Padding = new Padding(14, 8, 14, 6);
            card.TabStop = false;

            titleLabel = new Label();
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 28;
            titleLabel.Font = new Font("Segoe UI", 10F);
            titleLabel.ForeColor = Color.Gray;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Text = title;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            valueLabel = new Label();
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(91, 174, 99);
            valueLabel.BackColor = Color.Transparent;
            valueLabel.AutoEllipsis = true;
            valueLabel.Text = "$0.00";
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            // Dock pass runs last-added first: title, then value fills.
            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
        }

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel cardsLayout;
        private TableLayoutPanel bodyLayout;
        private FlowLayoutPanel filterFlow;
        private Panel gridPanel;
        private Panel summaryPanel;
        private Label lblTitle;
        private Label lblGridPlaceholder;
        private Label lblSummary;
        private Label lblReport;
        private Label lblFrom;
        private Label lblTo;
        private Label lblCard1Title;
        private Label lblCard1Value;
        private Label lblCard2Title;
        private Label lblCard2Value;
        private Label lblCard3Title;
        private Label lblCard3Value;
        private Label lblCard4Title;
        private Label lblCard4Value;
        private ComboBox cbReport;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnGenerate;
        private Button btnExport;
        private Button btnPrint;
        private DataGridView dgvReport;
        private DataGridViewTextBoxColumn colReportLabel;
        private DataGridViewTextBoxColumn colReportValue;
        private RoundedPanel card1;
        private RoundedPanel card2;
        private RoundedPanel card3;
        private RoundedPanel card4;
    }
}
