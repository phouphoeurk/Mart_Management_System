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
            topPanel = new Panel();
            lblTitle = new Label();
            cardsPanel = new Panel();
            card1 = new Panel();
            card2 = new Panel();
            card3 = new Panel();
            card4 = new Panel();
            filterPanel = new Panel();
            lblReport = new Label();
            cbReport = new ComboBox();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnGenerate = new Button();
            chartsPanel = new Panel();
            chart1Panel = new Panel();
            lblChart1Placeholder = new Label();
            dgvReport = new DataGridView();
            colReportLabel = new DataGridViewTextBoxColumn();
            colReportValue = new DataGridViewTextBoxColumn();
            chart2Panel = new Panel();
            lblChart2Placeholder = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            cardsPanel.SuspendLayout();
            card1.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            card4.SuspendLayout();
            filterPanel.SuspendLayout();
            chartsPanel.SuspendLayout();
            chart1Panel.SuspendLayout();
            chart2Panel.SuspendLayout();
            SuspendLayout();

            topPanel.Controls.Add(lblTitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(20, 20);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1060, 50);
            topPanel.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(0, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(117, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REPORTS";

            cardsPanel.Controls.Add(card4);
            cardsPanel.Controls.Add(card3);
            cardsPanel.Controls.Add(card2);
            cardsPanel.Controls.Add(card1);
            cardsPanel.Dock = DockStyle.Top;
            cardsPanel.Location = new Point(20, 70);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.Size = new Size(1060, 130);
            cardsPanel.TabIndex = 1;

            ConfigureCard(card1, new Point(0, 15), new Size(240, 100), "Daily Sales", out lblCard1Title, out lblCard1Value);
            ConfigureCard(card2, new Point(260, 15), new Size(240, 100), "Weekly Sales", out lblCard2Title, out lblCard2Value);
            ConfigureCard(card3, new Point(520, 15), new Size(240, 100), "Monthly Sales", out lblCard3Title, out lblCard3Value);
            ConfigureCard(card4, new Point(780, 15), new Size(260, 100), "Total Revenue", out lblCard4Title, out lblCard4Value);

            filterPanel.Controls.Add(lblReport);
            filterPanel.Controls.Add(cbReport);
            filterPanel.Controls.Add(lblFrom);
            filterPanel.Controls.Add(dtpFrom);
            filterPanel.Controls.Add(lblTo);
            filterPanel.Controls.Add(dtpTo);
            filterPanel.Controls.Add(btnGenerate);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(20, 200);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1060, 60);
            filterPanel.TabIndex = 2;

            lblReport.AutoSize = true;
            lblReport.Font = new Font("Segoe UI", 10F);
            lblReport.Location = new Point(0, 20);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(50, 20);
            lblReport.TabIndex = 0;
            lblReport.Text = "Report:";

            cbReport.Font = new Font("Segoe UI", 10F);
            cbReport.Items.AddRange(new object[]
            {
                "Sales Trend",
                "Revenue by Cashier",
                "Revenue by Payment Method",
                "Top Products",
                "Sales by Category",
                "Supplier Purchase History",
                "Inventory Value"
            });
            cbReport.Location = new Point(60, 17);
            cbReport.Name = "cbReport";
            cbReport.Size = new Size(220, 28);
            cbReport.TabIndex = 1;
            cbReport.SelectedIndexChanged += cbReport_SelectedIndexChanged;

            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.Location = new Point(310, 20);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(35, 20);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "From:";

            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(350, 17);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(115, 26);
            dtpFrom.TabIndex = 3;

            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 10F);
            lblTo.Location = new Point(485, 20);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 20);
            lblTo.TabIndex = 4;
            lblTo.Text = "To:";

            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(515, 17);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(115, 26);
            dtpTo.TabIndex = 5;

            btnGenerate.BackColor = Color.FromArgb(91, 174, 99);
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(655, 15);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(115, 32);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;

            chartsPanel.Controls.Add(chart2Panel);
            chartsPanel.Controls.Add(chart1Panel);
            chartsPanel.Dock = DockStyle.Fill;
            chartsPanel.Location = new Point(20, 260);
            chartsPanel.Name = "chartsPanel";
            chartsPanel.Padding = new Padding(0, 10, 0, 0);
            chartsPanel.Size = new Size(1060, 420);
            chartsPanel.TabIndex = 3;

            chart1Panel.BackColor = Color.White;
            chart1Panel.Controls.Add(dgvReport);
            chart1Panel.Controls.Add(lblChart1Placeholder);
            chart1Panel.Dock = DockStyle.Left;
            chart1Panel.Location = new Point(0, 10);
            chart1Panel.Name = "chart1Panel";
            chart1Panel.Size = new Size(620, 410);
            chart1Panel.TabIndex = 0;

            lblChart1Placeholder.Dock = DockStyle.Fill;
            lblChart1Placeholder.Font = new Font("Segoe UI", 12F);
            lblChart1Placeholder.ForeColor = Color.Gray;
            lblChart1Placeholder.Text = "Select a report to view results";
            lblChart1Placeholder.TextAlign = ContentAlignment.MiddleCenter;
            lblChart1Placeholder.Visible = false;

            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersHeight = 38;
            dgvReport.Columns.AddRange(new DataGridViewColumn[]
            {
                colReportLabel,
                colReportValue
            });
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(620, 410);
            dgvReport.TabIndex = 1;

            colReportLabel.HeaderText = "Report Item";
            colReportLabel.Name = "colReportLabel";
            colReportLabel.ReadOnly = true;
            colReportValue.HeaderText = "Value";
            colReportValue.Name = "colReportValue";
            colReportValue.ReadOnly = true;

            chart2Panel.BackColor = Color.White;
            chart2Panel.Controls.Add(lblChart2Placeholder);
            chart2Panel.Location = new Point(620, 10);
            chart2Panel.Name = "chart2Panel";
            chart2Panel.Size = new Size(420, 400);
            chart2Panel.TabIndex = 1;

            lblChart2Placeholder.Dock = DockStyle.Fill;
            lblChart2Placeholder.Font = new Font("Segoe UI", 12F);
            lblChart2Placeholder.ForeColor = Color.Gray;
            lblChart2Placeholder.Text = "Report summary will appear here";
            lblChart2Placeholder.TextAlign = ContentAlignment.MiddleCenter;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(chartsPanel);
            Controls.Add(filterPanel);
            Controls.Add(cardsPanel);
            Controls.Add(topPanel);
            Name = "ReportsForm";
            Padding = new Padding(20);
            Text = "Reports";
            cardsPanel.ResumeLayout(false);
            card1.ResumeLayout(false);
            card1.PerformLayout();
            card2.ResumeLayout(false);
            card2.PerformLayout();
            card3.ResumeLayout(false);
            card3.PerformLayout();
            card4.ResumeLayout(false);
            card4.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            chartsPanel.ResumeLayout(false);
            chart1Panel.ResumeLayout(false);
            chart1Panel.PerformLayout();
            chart2Panel.ResumeLayout(false);
            chart2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
            Load += ReportsForm_Load;
        }

        private static void ConfigureCard(
            Panel card,
            Point location,
            Size size,
            string title,
            out Label titleLabel,
            out Label valueLabel
        )
        {
            card.BackColor = Color.White;
            card.Location = location;
            card.Size = size;
            card.TabStop = false;

            titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 11F);
            titleLabel.ForeColor = Color.Gray;
            titleLabel.Location = new Point(20, 15);
            titleLabel.Text = title;

            valueLabel = new Label();
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(91, 174, 99);
            valueLabel.Location = new Point(15, 45);
            valueLabel.Text = "$0.00";

            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
        }

        private Panel topPanel;
        private Label lblTitle;
        private Panel cardsPanel;
        private Panel card1;
        private Label lblCard1Title;
        private Label lblCard1Value;
        private Panel card2;
        private Label lblCard2Title;
        private Label lblCard2Value;
        private Panel card3;
        private Label lblCard3Title;
        private Label lblCard3Value;
        private Panel card4;
        private Label lblCard4Title;
        private Label lblCard4Value;
        private Panel filterPanel;
        private Label lblReport;
        private ComboBox cbReport;
        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnGenerate;
        private Panel chartsPanel;
        private Panel chart1Panel;
        private Label lblChart1Placeholder;
        private DataGridView dgvReport;
        private DataGridViewTextBoxColumn colReportLabel;
        private DataGridViewTextBoxColumn colReportValue;
        private Panel chart2Panel;
        private Label lblChart2Placeholder;
    }
}
