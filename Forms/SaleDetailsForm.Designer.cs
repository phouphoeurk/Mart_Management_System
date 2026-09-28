namespace Mart_Management_System.Forms
{
    partial class SaleDetailsForm
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
            lblTitle = new Label();
            lblSaleId = new Label();
            lblCashier = new Label();
            lblDate = new Label();
            lblPayment = new Label();
            lblStatus = new Label();
            lblTotal = new Label();
            dgvDetails = new DataGridView();
            colProduct = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colDiscount = new DataGridViewTextBoxColumn();
            colLineTotal = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(24, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SALE DETAILS";

            lblSaleId.AutoSize = true;
            lblSaleId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSaleId.Location = new Point(25, 65);
            lblSaleId.Name = "lblSaleId";
            lblSaleId.Size = new Size(90, 20);
            lblSaleId.TabIndex = 1;
            lblSaleId.Text = "Sale ID:";

            lblCashier.AutoSize = true;
            lblCashier.Font = new Font("Segoe UI", 10F);
            lblCashier.Location = new Point(150, 65);
            lblCashier.Name = "lblCashier";
            lblCashier.Size = new Size(100, 20);
            lblCashier.TabIndex = 2;
            lblCashier.Text = "Cashier:";

            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Location = new Point(300, 65);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(150, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "Date:";

            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("Segoe UI", 10F);
            lblPayment.Location = new Point(500, 65);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(100, 20);
            lblPayment.TabIndex = 4;
            lblPayment.Text = "Payment:";

            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(25, 95);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 20);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";

            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(91, 174, 99);
            lblTotal.Location = new Point(400, 92);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 25);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total:";

            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.BorderStyle = BorderStyle.None;
            dgvDetails.ColumnHeadersHeight = 38;
            dgvDetails.Columns.AddRange(new DataGridViewColumn[]
            {
                colProduct,
                colQuantity,
                colUnitPrice,
                colDiscount,
                colLineTotal
            });
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.Dock = DockStyle.None;
            dgvDetails.Location = new Point(25, 135);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(850, 350);
            dgvDetails.TabIndex = 7;

            colProduct.HeaderText = "Product";
            colProduct.Name = "colProduct";
            colProduct.ReadOnly = true;
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            colDiscount.HeaderText = "Discount";
            colDiscount.Name = "colDiscount";
            colDiscount.ReadOnly = true;
            colLineTotal.HeaderText = "Line Total";
            colLineTotal.Name = "colLineTotal";
            colLineTotal.ReadOnly = true;

            btnClose.DialogResult = DialogResult.OK;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Location = new Point(770, 505);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(105, 36);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(900, 570);
            Controls.Add(lblTitle);
            Controls.Add(lblSaleId);
            Controls.Add(lblCashier);
            Controls.Add(lblDate);
            Controls.Add(lblPayment);
            Controls.Add(lblStatus);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetails);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaleDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sale Details";
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSaleId;
        private Label lblCashier;
        private Label lblDate;
        private Label lblPayment;
        private Label lblStatus;
        private Label lblTotal;
        private DataGridView dgvDetails;
        private DataGridViewTextBoxColumn colProduct;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colDiscount;
        private DataGridViewTextBoxColumn colLineTotal;
        private Button btnClose;
    }
}
