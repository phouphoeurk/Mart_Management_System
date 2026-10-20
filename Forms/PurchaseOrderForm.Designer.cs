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
            mainLayout = new TableLayoutPanel();
            topPanel = new TableLayoutPanel();
            lblTitle = new Label();
            lblStatus = new Label();
            buttonsFlow = new FlowLayoutPanel();
            btnSaveDraft = new Button();
            btnReceive = new Button();
            btnNewOrder = new Button();
            fieldsFlow = new FlowLayoutPanel();
            lblSupplier = new Label();
            cbSupplier = new ComboBox();
            lblDate = new Label();
            dtpPurchaseDate = new DateTimePicker();
            lblDiscount = new Label();
            numDiscount = new NumericUpDown();
            productPanel = new FlowLayoutPanel();
            lblProduct = new Label();
            cbProduct = new ComboBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblUnitCost = new Label();
            numUnitCost = new NumericUpDown();
            btnAddLine = new Button();
            btnRemoveLine = new Button();
            bodyLayout = new TableLayoutPanel();
            dgvPurchaseDetails = new DataGridView();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitCost = new DataGridViewTextBoxColumn();
            colLineSubtotal = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            pastPanel = new Panel();
            dgvPastOrders = new DataGridView();
            colPastId = new DataGridViewTextBoxColumn();
            colPastDate = new DataGridViewTextBoxColumn();
            colPastSupplier = new DataGridViewTextBoxColumn();
            colPastTotal = new DataGridViewTextBoxColumn();
            colPastStatus = new DataGridViewTextBoxColumn();
            lblPastTitle = new Label();
            totalsPanel = new Panel();
            totalsLayout = new TableLayoutPanel();
            lblSubtotal = new Label();
            lblSubtotalValue = new Label();
            lblTotal = new Label();
            lblTotalValue = new Label();
            mainLayout.SuspendLayout();
            topPanel.SuspendLayout();
            buttonsFlow.SuspendLayout();
            fieldsFlow.SuspendLayout();
            productPanel.SuspendLayout();
            bodyLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).BeginInit();
            pastPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPastOrders).BeginInit();
            totalsPanel.SuspendLayout();
            totalsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUnitCost).BeginInit();
            SuspendLayout();

            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F)
            );
            mainLayout.Controls.Add(topPanel, 0, 0);
            mainLayout.Controls.Add(productPanel, 0, 1);
            mainLayout.Controls.Add(bodyLayout, 0, 2);
            mainLayout.Controls.Add(totalsPanel, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Margin = new Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            mainLayout.Size = new Size(1060, 660);
            mainLayout.TabIndex = 0;

            topPanel.BackColor = Color.White;
            topPanel.ColumnCount = 3;
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            topPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 370F)
            );
            topPanel.Controls.Add(lblTitle, 0, 0);
            topPanel.Controls.Add(lblStatus, 1, 0);
            topPanel.Controls.Add(buttonsFlow, 2, 0);
            topPanel.Dock = DockStyle.Fill;
            topPanel.Margin = new Padding(0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(14, 4, 12, 4);
            topPanel.RowCount = 2;
            topPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            topPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topPanel.Size = new Size(1060, 96);
            topPanel.TabIndex = 0;

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 44);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PURCHASE ORDER";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            lblStatus.AutoEllipsis = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.ForeColor = Color.Firebrick;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(480, 44);
            lblStatus.TabIndex = 1;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            buttonsFlow.Dock = DockStyle.Fill;
            buttonsFlow.Name = "buttonsFlow";
            buttonsFlow.Padding = new Padding(0, 6, 0, 0);
            buttonsFlow.Size = new Size(370, 44);
            buttonsFlow.TabIndex = 2;
            buttonsFlow.WrapContents = false;

            btnSaveDraft.BackColor = Color.FromArgb(91, 174, 99);
            btnSaveDraft.FlatStyle = FlatStyle.Flat;
            btnSaveDraft.FlatAppearance.BorderSize = 0;
            btnSaveDraft.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSaveDraft.ForeColor = Color.White;
            btnSaveDraft.Margin = new Padding(0, 4, 8, 0);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(105, 32);
            btnSaveDraft.TabIndex = 0;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = false;
            btnSaveDraft.Click += btnSaveDraft_Click;

            btnReceive.BackColor = Color.FromArgb(7, 132, 59);
            btnReceive.Enabled = false;
            btnReceive.FlatStyle = FlatStyle.Flat;
            btnReceive.FlatAppearance.BorderSize = 0;
            btnReceive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReceive.ForeColor = Color.White;
            btnReceive.Margin = new Padding(0, 4, 8, 0);
            btnReceive.Name = "btnReceive";
            btnReceive.Size = new Size(105, 32);
            btnReceive.TabIndex = 1;
            btnReceive.Text = "Receive";
            btnReceive.UseVisualStyleBackColor = false;
            btnReceive.Click += btnReceive_Click;

            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.Font = new Font("Segoe UI", 9F);
            btnNewOrder.Margin = new Padding(0, 4, 0, 0);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(105, 32);
            btnNewOrder.TabIndex = 2;
            btnNewOrder.Text = "New Order";
            btnNewOrder.Click += btnNewOrder_Click;

            buttonsFlow.Controls.Add(btnSaveDraft);
            buttonsFlow.Controls.Add(btnReceive);
            buttonsFlow.Controls.Add(btnNewOrder);

            fieldsFlow.Dock = DockStyle.Fill;
            fieldsFlow.Name = "fieldsFlow";
            fieldsFlow.Padding = new Padding(0, 8, 0, 0);
            fieldsFlow.Size = new Size(1034, 44);
            fieldsFlow.TabIndex = 3;
            fieldsFlow.WrapContents = false;

            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 10F);
            lblSupplier.Margin = new Padding(0, 7, 6, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Text = "Supplier:";

            cbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.Margin = new Padding(0, 3, 20, 0);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(210, 28);

            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Margin = new Padding(0, 7, 6, 0);
            lblDate.Name = "lblDate";
            lblDate.Text = "Date:";

            dtpPurchaseDate.Font = new Font("Segoe UI", 10F);
            dtpPurchaseDate.Format = DateTimePickerFormat.Short;
            dtpPurchaseDate.Margin = new Padding(0, 4, 20, 0);
            dtpPurchaseDate.Name = "dtpPurchaseDate";
            dtpPurchaseDate.Size = new Size(125, 26);

            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F);
            lblDiscount.Margin = new Padding(0, 7, 6, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Text = "Discount:";

            numDiscount.DecimalPlaces = 2;
            numDiscount.Font = new Font("Segoe UI", 10F);
            numDiscount.Margin = new Padding(0, 4, 0, 0);
            numDiscount.Maximum = new decimal(1000000000, 0, 0, false, 2);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(115, 26);
            numDiscount.ValueChanged += numDiscount_ValueChanged;

            fieldsFlow.Controls.Add(lblSupplier);
            fieldsFlow.Controls.Add(cbSupplier);
            fieldsFlow.Controls.Add(lblDate);
            fieldsFlow.Controls.Add(dtpPurchaseDate);
            fieldsFlow.Controls.Add(lblDiscount);
            fieldsFlow.Controls.Add(numDiscount);

            topPanel.Controls.Add(fieldsFlow, 0, 1);
            topPanel.SetColumnSpan(fieldsFlow, 3);

            productPanel.BackColor = Color.White;
            productPanel.Dock = DockStyle.Fill;
            productPanel.Name = "productPanel";
            productPanel.Padding = new Padding(14, 12, 14, 8);
            productPanel.Size = new Size(1060, 60);
            productPanel.TabIndex = 1;
            productPanel.WrapContents = false;

            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 10F);
            lblProduct.Margin = new Padding(0, 7, 6, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Text = "Product:";

            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduct.Font = new Font("Segoe UI", 10F);
            cbProduct.Margin = new Padding(0, 3, 20, 0);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(280, 28);
            cbProduct.SelectedIndexChanged += cbProduct_SelectedIndexChanged;

            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F);
            lblQuantity.Margin = new Padding(0, 7, 6, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Text = "Quantity:";

            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Margin = new Padding(0, 4, 20, 0);
            numQuantity.Maximum = new decimal(2000000000, 0, 0, false, 0);
            numQuantity.Minimum = 1;
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(90, 26);
            numQuantity.Value = 1;

            lblUnitCost.AutoSize = true;
            lblUnitCost.Font = new Font("Segoe UI", 10F);
            lblUnitCost.Margin = new Padding(0, 7, 6, 0);
            lblUnitCost.Name = "lblUnitCost";
            lblUnitCost.Text = "Unit cost:";

            numUnitCost.DecimalPlaces = 2;
            numUnitCost.Font = new Font("Segoe UI", 10F);
            numUnitCost.Margin = new Padding(0, 4, 20, 0);
            numUnitCost.Maximum = new decimal(1000000000, 0, 0, false, 2);
            numUnitCost.Name = "numUnitCost";
            numUnitCost.Size = new Size(115, 26);

            btnAddLine.BackColor = Color.FromArgb(91, 174, 99);
            btnAddLine.FlatStyle = FlatStyle.Flat;
            btnAddLine.FlatAppearance.BorderSize = 0;
            btnAddLine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddLine.ForeColor = Color.White;
            btnAddLine.Margin = new Padding(0, 2, 8, 0);
            btnAddLine.Name = "btnAddLine";
            btnAddLine.Size = new Size(115, 32);
            btnAddLine.Text = "Add Product";
            btnAddLine.UseVisualStyleBackColor = false;
            btnAddLine.Click += btnAddLine_Click;

            btnRemoveLine.FlatStyle = FlatStyle.Flat;
            btnRemoveLine.Font = new Font("Segoe UI", 9F);
            btnRemoveLine.Margin = new Padding(0, 2, 0, 0);
            btnRemoveLine.Name = "btnRemoveLine";
            btnRemoveLine.Size = new Size(100, 32);
            btnRemoveLine.Text = "Remove";
            btnRemoveLine.Click += btnRemoveLine_Click;

            productPanel.Controls.Add(lblProduct);
            productPanel.Controls.Add(cbProduct);
            productPanel.Controls.Add(lblQuantity);
            productPanel.Controls.Add(numQuantity);
            productPanel.Controls.Add(lblUnitCost);
            productPanel.Controls.Add(numUnitCost);
            productPanel.Controls.Add(btnAddLine);
            productPanel.Controls.Add(btnRemoveLine);

            bodyLayout.ColumnCount = 2;
            bodyLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 70F)
            );
            bodyLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 30F)
            );
            bodyLayout.Controls.Add(dgvPurchaseDetails, 0, 0);
            bodyLayout.Controls.Add(pastPanel, 1, 0);
            bodyLayout.Dock = DockStyle.Fill;
            bodyLayout.Margin = new Padding(0);
            bodyLayout.Name = "bodyLayout";
            bodyLayout.RowCount = 1;
            bodyLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            bodyLayout.Size = new Size(1060, 440);
            bodyLayout.TabIndex = 2;

            dgvPurchaseDetails.AllowUserToAddRows = false;
            dgvPurchaseDetails.AllowUserToDeleteRows = false;
            dgvPurchaseDetails.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchaseDetails.BackgroundColor = Color.White;
            dgvPurchaseDetails.BorderStyle = BorderStyle.None;
            dgvPurchaseDetails.ColumnHeadersHeight = 38;
            dgvPurchaseDetails.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colProductName,
                    colQuantity,
                    colUnitCost,
                    colLineSubtotal,
                    colRemove
                }
            );
            dgvPurchaseDetails.Dock = DockStyle.Fill;
            dgvPurchaseDetails.Margin = new Padding(0, 8, 8, 0);
            dgvPurchaseDetails.Name = "dgvPurchaseDetails";
            dgvPurchaseDetails.ReadOnly = true;
            dgvPurchaseDetails.RowHeadersVisible = false;
            dgvPurchaseDetails.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPurchaseDetails.Size = new Size(734, 432);
            dgvPurchaseDetails.TabIndex = 0;
            dgvPurchaseDetails.CellContentClick +=
                dgvPurchaseDetails_CellContentClick;

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

            pastPanel.BackColor = Color.White;
            pastPanel.Controls.Add(dgvPastOrders);
            pastPanel.Controls.Add(lblPastTitle);
            pastPanel.Dock = DockStyle.Fill;
            pastPanel.Margin = new Padding(10, 8, 0, 0);
            pastPanel.Name = "pastPanel";
            pastPanel.Size = new Size(316, 432);
            pastPanel.TabIndex = 1;

            dgvPastOrders.AllowUserToAddRows = false;
            dgvPastOrders.AllowUserToDeleteRows = false;
            dgvPastOrders.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvPastOrders.BackgroundColor = Color.White;
            dgvPastOrders.BorderStyle = BorderStyle.None;
            dgvPastOrders.ColumnHeadersHeight = 34;
            dgvPastOrders.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colPastId,
                    colPastDate,
                    colPastSupplier,
                    colPastTotal,
                    colPastStatus
                }
            );
            dgvPastOrders.Dock = DockStyle.Fill;
            dgvPastOrders.Location = new Point(0, 40);
            dgvPastOrders.Margin = new Padding(0);
            dgvPastOrders.Name = "dgvPastOrders";
            dgvPastOrders.ReadOnly = true;
            dgvPastOrders.RowHeadersVisible = false;
            dgvPastOrders.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPastOrders.Size = new Size(316, 392);
            dgvPastOrders.TabIndex = 1;

            colPastId.FillWeight = 14F;
            colPastId.HeaderText = "#";
            colPastId.Name = "colPastId";
            colPastId.ReadOnly = true;
            colPastDate.FillWeight = 24F;
            colPastDate.HeaderText = "Date";
            colPastDate.Name = "colPastDate";
            colPastDate.ReadOnly = true;
            colPastSupplier.FillWeight = 34F;
            colPastSupplier.HeaderText = "Supplier";
            colPastSupplier.Name = "colPastSupplier";
            colPastSupplier.ReadOnly = true;
            colPastTotal.FillWeight = 16F;
            colPastTotal.HeaderText = "Total";
            colPastTotal.Name = "colPastTotal";
            colPastTotal.ReadOnly = true;
            colPastStatus.FillWeight = 12F;
            colPastStatus.HeaderText = "Status";
            colPastStatus.Name = "colPastStatus";
            colPastStatus.ReadOnly = true;

            lblPastTitle.Dock = DockStyle.Top;
            lblPastTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPastTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblPastTitle.Location = new Point(0, 0);
            lblPastTitle.Name = "lblPastTitle";
            lblPastTitle.Padding = new Padding(12, 0, 0, 0);
            lblPastTitle.Size = new Size(316, 40);
            lblPastTitle.TabIndex = 0;
            lblPastTitle.Text = "RECENT ORDERS";
            lblPastTitle.TextAlign = ContentAlignment.MiddleLeft;

            totalsPanel.BackColor = Color.White;
            totalsPanel.Controls.Add(totalsLayout);
            totalsPanel.Dock = DockStyle.Fill;
            totalsPanel.Margin = new Padding(0, 8, 0, 0);
            totalsPanel.Name = "totalsPanel";
            totalsPanel.Size = new Size(1060, 64);
            totalsPanel.TabIndex = 3;

            totalsLayout.ColumnCount = 5;
            totalsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F)
            );
            totalsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 130F)
            );
            totalsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 130F)
            );
            totalsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 80F)
            );
            totalsLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 150F)
            );
            totalsLayout.Controls.Add(lblSubtotal, 1, 0);
            totalsLayout.Controls.Add(lblSubtotalValue, 2, 0);
            totalsLayout.Controls.Add(lblTotal, 3, 0);
            totalsLayout.Controls.Add(lblTotalValue, 4, 0);
            totalsLayout.Dock = DockStyle.Fill;
            totalsLayout.Margin = new Padding(0);
            totalsLayout.Name = "totalsLayout";
            totalsLayout.RowCount = 1;
            totalsLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            totalsLayout.Size = new Size(1060, 64);
            totalsLayout.TabIndex = 0;

            lblSubtotal.Dock = DockStyle.Fill;
            lblSubtotal.Font = new Font("Segoe UI", 11F);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(130, 64);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal:";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;

            lblSubtotalValue.AutoEllipsis = true;
            lblSubtotalValue.Dock = DockStyle.Fill;
            lblSubtotalValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtotalValue.Name = "lblSubtotalValue";
            lblSubtotalValue.Size = new Size(130, 64);
            lblSubtotalValue.TabIndex = 1;
            lblSubtotalValue.Text = "$0.00";
            lblSubtotalValue.TextAlign = ContentAlignment.MiddleLeft;

            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(91, 174, 99);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(80, 64);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total:";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;

            lblTotalValue.AutoEllipsis = true;
            lblTotalValue.Dock = DockStyle.Fill;
            lblTotalValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(91, 174, 99);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(150, 64);
            lblTotalValue.TabIndex = 3;
            lblTotalValue.Text = "$0.00";
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(1100, 700);
            Controls.Add(mainLayout);
            MinimumSize = new Size(940, 620);
            Name = "PurchaseOrderForm";
            Padding = new Padding(20);
            Text = "Purchase Orders";

            mainLayout.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            buttonsFlow.ResumeLayout(false);
            fieldsFlow.ResumeLayout(false);
            fieldsFlow.PerformLayout();
            productPanel.ResumeLayout(false);
            productPanel.PerformLayout();
            bodyLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).EndInit();
            pastPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPastOrders).EndInit();
            totalsPanel.ResumeLayout(false);
            totalsLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUnitCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
            Load += PurchaseOrderForm_Load;
        }

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel topPanel;
        private FlowLayoutPanel buttonsFlow;
        private FlowLayoutPanel fieldsFlow;
        private FlowLayoutPanel productPanel;
        private TableLayoutPanel bodyLayout;
        private TableLayoutPanel totalsLayout;
        private Panel pastPanel;
        private Panel totalsPanel;
        private Label lblTitle;
        private Label lblStatus;
        private Label lblSupplier;
        private Label lblDate;
        private Label lblDiscount;
        private Label lblProduct;
        private Label lblQuantity;
        private Label lblUnitCost;
        private Label lblPastTitle;
        private Label lblSubtotal;
        private Label lblSubtotalValue;
        private Label lblTotal;
        private Label lblTotalValue;
        private ComboBox cbSupplier;
        private ComboBox cbProduct;
        private DateTimePicker dtpPurchaseDate;
        private NumericUpDown numDiscount;
        private NumericUpDown numQuantity;
        private NumericUpDown numUnitCost;
        private Button btnSaveDraft;
        private Button btnReceive;
        private Button btnNewOrder;
        private Button btnAddLine;
        private Button btnRemoveLine;
        private DataGridView dgvPurchaseDetails;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitCost;
        private DataGridViewTextBoxColumn colLineSubtotal;
        private DataGridViewButtonColumn colRemove;
        private DataGridView dgvPastOrders;
        private DataGridViewTextBoxColumn colPastId;
        private DataGridViewTextBoxColumn colPastDate;
        private DataGridViewTextBoxColumn colPastSupplier;
        private DataGridViewTextBoxColumn colPastTotal;
        private DataGridViewTextBoxColumn colPastStatus;
    }
}
