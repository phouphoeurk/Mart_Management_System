namespace Mart_Management_System.Forms
{
    partial class StockAlertsForm
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
            lblAlertType = new Label();
            cbAlertType = new ComboBox();
            btnRefresh = new Button();
            dgvAlerts = new DataGridView();
            colProduct = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colReorder = new DataGridViewTextBoxColumn();
            colExpiry = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();

            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(lblAlertType);
            topPanel.Controls.Add(cbAlertType);
            topPanel.Controls.Add(btnRefresh);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(20, 20);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1060, 60);
            topPanel.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "STOCK ALERTS";

            lblAlertType.AutoSize = true;
            lblAlertType.Font = new Font("Segoe UI", 10F);
            lblAlertType.Location = new Point(230, 22);
            lblAlertType.Name = "lblAlertType";
            lblAlertType.Size = new Size(70, 20);
            lblAlertType.TabIndex = 1;
            lblAlertType.Text = "View:";

            cbAlertType.Font = new Font("Segoe UI", 10F);
            cbAlertType.Location = new Point(275, 18);
            cbAlertType.Name = "cbAlertType";
            cbAlertType.Size = new Size(200, 28);
            cbAlertType.TabIndex = 2;
            cbAlertType.SelectedIndexChanged += cbAlertType_SelectedIndexChanged;

            btnRefresh.BackColor = Color.FromArgb(91, 174, 99);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(900, 16);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 32);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AllowUserToDeleteRows = false;
            dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.BorderStyle = BorderStyle.None;
            dgvAlerts.ColumnHeadersHeight = 40;
            dgvAlerts.Columns.AddRange(new DataGridViewColumn[]
            {
                colProduct,
                colCategory,
                colStock,
                colReorder,
                colExpiry,
                colStatus,
                colAction
            });
            dgvAlerts.Dock = DockStyle.Fill;
            dgvAlerts.Location = new Point(20, 80);
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.ReadOnly = true;
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.Size = new Size(1060, 580);
            dgvAlerts.TabIndex = 1;
            dgvAlerts.CellContentClick += dgvAlerts_CellContentClick;

            colProduct.HeaderText = "Product / Item";
            colProduct.Name = "colProduct";
            colProduct.ReadOnly = true;
            colCategory.HeaderText = "Type / Category";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            colStock.HeaderText = "Stock / Change";
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            colReorder.HeaderText = "Reorder / Reference";
            colReorder.Name = "colReorder";
            colReorder.ReadOnly = true;
            colExpiry.HeaderText = "Expiry / Date";
            colExpiry.Name = "colExpiry";
            colExpiry.ReadOnly = true;
            colStatus.HeaderText = "Status / User";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colAction.HeaderText = "Action";
            colAction.Name = "colAction";
            colAction.Text = "Adjust";
            colAction.UseColumnTextForButtonValue = true;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(dgvAlerts);
            Controls.Add(topPanel);
            Name = "StockAlertsForm";
            Padding = new Padding(20);
            Text = "Stock Alerts";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
            ResumeLayout(false);
            PerformLayout();
            Load += StockAlertsForm_Load;
        }

        private Panel topPanel;
        private Label lblTitle;
        private Label lblAlertType;
        private ComboBox cbAlertType;
        private Button btnRefresh;
        private DataGridView dgvAlerts;
        private DataGridViewTextBoxColumn colProduct;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colReorder;
        private DataGridViewTextBoxColumn colExpiry;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn colAction;
    }
}
