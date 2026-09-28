namespace Mart_Management_System.Forms
{
    partial class PurchaseOrderForm
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
            lblSupplier = new Label();
            cbSupplier = new ComboBox();
            lblDate = new Label();
            dtpPurchaseDate = new DateTimePicker();
            lblDiscount = new Label();
            numDiscount = new NumericUpDown();
            lblStatus = new Label();
            btnSaveDraft = new Button();
            btnReceive = new Button();
            btnNewOrder = new Button();
            productPanel = new Panel();
            lblProduct = new Label();
            cbProduct = new ComboBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblUnitCost = new Label();
            numUnitCost = new NumericUpDown();
            btnAddLine = new Button();
            btnRemoveLine = new Button();
            dgvPurchaseDetails = new DataGridView();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitCost = new DataGridViewTextBoxColumn();
            colLineSubtotal = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            totalsPanel = new Panel();
            lblSubtotal = new Label();
            lblSubtotalValue = new Label();
            lblTotal = new Label();
            lblTotalValue = new Label();
            topPanel.SuspendLayout();
            productPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUnitCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).BeginInit();
            totalsPanel.SuspendLayout();
            SuspendLayout();

            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(lblSupplier);
            topPanel.Controls.Add(cbSupplier);
            topPanel.Controls.Add(lblDate);
            topPanel.Controls.Add(dtpPurchaseDate);
            topPanel.Controls.Add(lblDiscount);
            topPanel.Controls.Add(numDiscount);
            topPanel.Controls.Add(lblStatus);
            topPanel.Controls.Add(btnSaveDraft);
            topPanel.Controls.Add(btnReceive);
            topPanel.Controls.Add(btnNewOrder);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(20, 20);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1060, 90);
            topPanel.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(0, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PURCHASE ORDER";

            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 10F);
            lblSupplier.Location = new Point(0, 48);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(55, 20);
            lblSupplier.TabIndex = 1;
            lblSupplier.Text = "Supplier:";

            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.Location = new Point(65, 45);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(190, 28);
            cbSupplier.TabIndex = 2;

            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Location = new Point(275, 48);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(35, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "Date:";

            dtpPurchaseDate.Font = new Font("Segoe UI", 10F);
            dtpPurchaseDate.Format = DateTimePickerFormat.Short;
            dtpPurchaseDate.Location = new Point(315, 45);
            dtpPurchaseDate.Name = "dtpPurchaseDate";
            dtpPurchaseDate.Size = new Size(120, 26);
            dtpPurchaseDate.TabIndex = 4;

            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F);
            lblDiscount.Location = new Point(455, 48);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(55, 20);
            lblDiscount.TabIndex = 5;
            lblDiscount.Text = "Discount:";

            numDiscount.DecimalPlaces = 2;
            numDiscount.Font = new Font("Segoe UI", 10F);
            numDiscount.Location = new Point(515, 45);
            numDiscount.Maximum = new decimal(1000000000, 0, 0, false, 2);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(105, 26);
            numDiscount.TabIndex = 6;
            numDiscount.ValueChanged += numDiscount_ValueChanged;

            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Firebrick;
            lblStatus.Location = new Point(640, 49);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(190, 20);
            lblStatus.TabIndex = 7;

            btnSaveDraft.BackColor = Color.FromArgb(91, 174, 99);
            btnSaveDraft.FlatStyle = FlatStyle.Flat;
            btnSaveDraft.FlatAppearance.BorderSize = 0;
            btnSaveDraft.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSaveDraft.ForeColor = Color.White;
            btnSaveDraft.Location = new Point(820, 40);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(105, 34);
            btnSaveDraft.TabIndex = 8;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = false;
            btnSaveDraft.Click += btnSaveDraft_Click;

            btnReceive.BackColor = Color.FromArgb(7, 132, 59);
            btnReceive.Enabled = false;
            btnReceive.FlatStyle = FlatStyle.Flat;
            btnReceive.FlatAppearance.BorderSize = 0;
            btnReceive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReceive.ForeColor = Color.White;
            btnReceive.Location = new Point(820, 5);
            btnReceive.Name = "btnReceive";
            btnReceive.Size = new Size(105, 30);
            btnReceive.TabIndex = 9;
            btnReceive.Text = "Receive";
            btnReceive.UseVisualStyleBackColor = false;
            btnReceive.Click += btnReceive_Click;

            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.Font = new Font("Segoe UI", 9F);
            btnNewOrder.Location = new Point(935, 40);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(105, 34);
            btnNewOrder.TabIndex = 10;
            btnNewOrder.Text = "New Order";
            btnNewOrder.Click += btnNewOrder_Click;

            productPanel.BackColor = Color.White;
            productPanel.Controls.Add(lblProduct);
            productPanel.Controls.Add(cbProduct);
            productPanel.Controls.Add(lblQuantity);
            productPanel.Controls.Add(numQuantity);
            productPanel.Controls.Add(lblUnitCost);
            productPanel.Controls.Add(numUnitCost);
            productPanel.Controls.Add(btnAddLine);
            productPanel.Controls.Add(btnRemoveLine);
            productPanel.Dock = DockStyle.Top;
            productPanel.Location = new Point(20, 110);
            productPanel.Name = "productPanel";
            productPanel.Size = new Size(1060, 70);
            productPanel.TabIndex = 1;

            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 10F);
            lblProduct.Location = new Point(0, 25);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(55, 20);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product:";

            cbProduct.Font = new Font("Segoe UI", 10F);
            cbProduct.Location = new Point(65, 22);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(260, 28);
            cbProduct.TabIndex = 1;
            cbProduct.SelectedIndexChanged += cbProduct_SelectedIndexChanged;

            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F);
            lblQuantity.Location = new Point(345, 25);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(55, 20);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity:";

            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(410, 22);
            numQuantity.Maximum = new decimal(2000000000, 0, 0, false, 0);
            numQuantity.Minimum = 1;
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(90, 26);
            numQuantity.TabIndex = 3;
            numQuantity.Value = 1;

            lblUnitCost.AutoSize = true;
            lblUnitCost.Font = new Font("Segoe UI", 10F);
            lblUnitCost.Location = new Point(520, 25);
            lblUnitCost.Name = "lblUnitCost";
            lblUnitCost.Size = new Size(65, 20);
            lblUnitCost.TabIndex = 4;
            lblUnitCost.Text = "Unit cost:";

            numUnitCost.DecimalPlaces = 2;
            numUnitCost.Font = new Font("Segoe UI", 10F);
            numUnitCost.Location = new Point(595, 22);
            numUnitCost.Maximum = new decimal(1000000000, 0, 0, false, 2);
            numUnitCost.Name = "numUnitCost";
            numUnitCost.Size = new Size(105, 26);
            numUnitCost.TabIndex = 5;

            btnAddLine.BackColor = Color.FromArgb(91, 174, 99);
            btnAddLine.FlatStyle = FlatStyle.Flat;
            btnAddLine.FlatAppearance.BorderSize = 0;
            btnAddLine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddLine.ForeColor = Color.White;
            btnAddLine.Location = new Point(720, 20);
            btnAddLine.Name = "btnAddLine";
            btnAddLine.Size = new Size(105, 30);
            btnAddLine.TabIndex = 6;
            btnAddLine.Text = "Add Product";
            btnAddLine.UseVisualStyleBackColor = false;
            btnAddLine.Click += btnAddLine_Click;

            btnRemoveLine.FlatStyle = FlatStyle.Flat;
            btnRemoveLine.Font = new Font("Segoe UI", 9F);
            btnRemoveLine.Location = new Point(835, 20);
            btnRemoveLine.Name = "btnRemoveLine";
            btnRemoveLine.Size = new Size(105, 30);
            btnRemoveLine.TabIndex = 7;
            btnRemoveLine.Text = "Remove";
            btnRemoveLine.Click += btnRemoveLine_Click;

            dgvPurchaseDetails.AllowUserToAddRows = false;
            dgvPurchaseDetails.AllowUserToDeleteRows = false;
            dgvPurchaseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchaseDetails.BackgroundColor = Color.White;
            dgvPurchaseDetails.BorderStyle = BorderStyle.None;
            dgvPurchaseDetails.ColumnHeadersHeight = 38;
            dgvPurchaseDetails.Columns.AddRange(new DataGridViewColumn[]
            {
                colProductName,
                colQuantity,
                colUnitCost,
                colLineSubtotal,
                colRemove
            });
            dgvPurchaseDetails.Dock = DockStyle.Fill;
            dgvPurchaseDetails.Location = new Point(20, 180);
            dgvPurchaseDetails.Name = "dgvPurchaseDetails";
            dgvPurchaseDetails.ReadOnly = true;
            dgvPurchaseDetails.RowHeadersVisible = false;
            dgvPurchaseDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchaseDetails.Size = new Size(1060, 420);
            dgvPurchaseDetails.TabIndex = 2;
            dgvPurchaseDetails.CellContentClick += dgvPurchaseDetails_CellContentClick;

            colProductName.HeaderText = "Product";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colUnitCost.HeaderText = "Unit Cost";
            colUnitCost.Name = "colUnitCost";
            colUnitCost.ReadOnly = true;
            colLineSubtotal.HeaderText = "Line Total";
            colLineSubtotal.Name = "colLineSubtotal";
            colLineSubtotal.ReadOnly = true;
            colRemove.HeaderText = "Action";
            colRemove.Name = "colRemove";
            colRemove.Text = "Remove";
            colRemove.UseColumnTextForButtonValue = true;

            totalsPanel.BackColor = Color.White;
            totalsPanel.Controls.Add(lblSubtotal);
            totalsPanel.Controls.Add(lblSubtotalValue);
            totalsPanel.Controls.Add(lblTotal);
            totalsPanel.Controls.Add(lblTotalValue);
            totalsPanel.Dock = DockStyle.Bottom;
            totalsPanel.Location = new Point(20, 600);
            totalsPanel.Name = "totalsPanel";
            totalsPanel.Size = new Size(1060, 60);
            totalsPanel.TabIndex = 3;

            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 11F);
            lblSubtotal.Location = new Point(700, 18);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(60, 20);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal:";

            lblSubtotalValue.AutoSize = true;
            lblSubtotalValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtotalValue.Location = new Point(770, 18);
            lblSubtotalValue.Name = "lblSubtotalValue";
            lblSubtotalValue.Size = new Size(70, 20);
            lblSubtotalValue.TabIndex = 1;
            lblSubtotalValue.Text = "$0.00";

            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(91, 174, 99);
            lblTotal.Location = new Point(850, 15);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 25);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total:";

            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(91, 174, 99);
            lblTotalValue.Location = new Point(905, 15);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(80, 25);
            lblTotalValue.TabIndex = 3;
            lblTotalValue.Text = "$0.00";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(dgvPurchaseDetails);
            Controls.Add(totalsPanel);
            Controls.Add(productPanel);
            Controls.Add(topPanel);
            Name = "PurchaseOrderForm";
            Padding = new Padding(20);
            Text = "Purchase Orders";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            productPanel.ResumeLayout(false);
            productPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUnitCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).EndInit();
            totalsPanel.ResumeLayout(false);
            totalsPanel.PerformLayout();
            ResumeLayout(false);
        }

        private Panel topPanel;
        private Label lblTitle;
        private Label lblSupplier;
        private ComboBox cbSupplier;
        private Label lblDate;
        private DateTimePicker dtpPurchaseDate;
        private Label lblDiscount;
        private NumericUpDown numDiscount;
        private Label lblStatus;
        private Button btnSaveDraft;
        private Button btnReceive;
        private Button btnNewOrder;
        private Panel productPanel;
        private Label lblProduct;
        private ComboBox cbProduct;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblUnitCost;
        private NumericUpDown numUnitCost;
        private Button btnAddLine;
        private Button btnRemoveLine;
        private DataGridView dgvPurchaseDetails;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitCost;
        private DataGridViewTextBoxColumn colLineSubtotal;
        private DataGridViewButtonColumn colRemove;
        private Panel totalsPanel;
        private Label lblSubtotal;
        private Label lblSubtotalValue;
        private Label lblTotal;
        private Label lblTotalValue;
    }
}
