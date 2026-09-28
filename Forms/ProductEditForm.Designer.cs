namespace Mart_Management_System.Forms
{
    partial class ProductEditForm
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
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            lblCategory = new Label();
            cbCategory = new ComboBox();
            lblSupplier = new Label();
            cbSupplier = new ComboBox();
            lblCostPrice = new Label();
            numCostPrice = new NumericUpDown();
            lblSellingPrice = new Label();
            numSellingPrice = new NumericUpDown();
            lblStockQuantity = new Label();
            numStockQuantity = new NumericUpDown();
            lblReorderLevel = new Label();
            numReorderLevel = new NumericUpDown();
            chkHasExpiry = new CheckBox();
            lblExpiryDate = new Label();
            dtpExpiry = new DateTimePicker();
            chkActive = new CheckBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCostPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSellingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).BeginInit();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(24, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product";

            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 10F);
            lblProductName.Location = new Point(25, 65);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(90, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product name:";

            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(25, 90);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(440, 28);
            txtProductName.TabIndex = 2;

            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 10F);
            lblBarcode.Location = new Point(25, 130);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(60, 20);
            lblBarcode.TabIndex = 3;
            lblBarcode.Text = "Barcode:";

            txtBarcode.Font = new Font("Segoe UI", 10F);
            txtBarcode.Location = new Point(25, 155);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(440, 28);
            txtBarcode.TabIndex = 4;

            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.Location = new Point(25, 195);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(60, 20);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category:";

            cbCategory.Font = new Font("Segoe UI", 10F);
            cbCategory.Location = new Point(25, 220);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(440, 28);
            cbCategory.TabIndex = 6;

            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 10F);
            lblSupplier.Location = new Point(25, 260);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(60, 20);
            lblSupplier.TabIndex = 7;
            lblSupplier.Text = "Supplier:";

            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.Location = new Point(25, 285);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(440, 28);
            cbSupplier.TabIndex = 8;

            lblCostPrice.AutoSize = true;
            lblCostPrice.Font = new Font("Segoe UI", 10F);
            lblCostPrice.Location = new Point(25, 325);
            lblCostPrice.Name = "lblCostPrice";
            lblCostPrice.Size = new Size(70, 20);
            lblCostPrice.TabIndex = 9;
            lblCostPrice.Text = "Cost price:";

            numCostPrice.DecimalPlaces = 2;
            numCostPrice.Font = new Font("Segoe UI", 10F);
            numCostPrice.Location = new Point(25, 350);
            numCostPrice.Maximum = new decimal(1000000000, 0, 0, false, 2);
            numCostPrice.Name = "numCostPrice";
            numCostPrice.Size = new Size(130, 26);
            numCostPrice.TabIndex = 10;

            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Font = new Font("Segoe UI", 10F);
            lblSellingPrice.Location = new Point(190, 325);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(85, 20);
            lblSellingPrice.TabIndex = 11;
            lblSellingPrice.Text = "Selling price:";

            numSellingPrice.DecimalPlaces = 2;
            numSellingPrice.Font = new Font("Segoe UI", 10F);
            numSellingPrice.Location = new Point(190, 350);
            numSellingPrice.Maximum = new decimal(1000000000, 0, 0, false, 2);
            numSellingPrice.Name = "numSellingPrice";
            numSellingPrice.Size = new Size(130, 26);
            numSellingPrice.TabIndex = 12;

            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Font = new Font("Segoe UI", 10F);
            lblStockQuantity.Location = new Point(350, 325);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(75, 20);
            lblStockQuantity.TabIndex = 13;
            lblStockQuantity.Text = "Stock quantity:";

            numStockQuantity.Font = new Font("Segoe UI", 10F);
            numStockQuantity.Location = new Point(350, 350);
            numStockQuantity.Maximum = new decimal(2000000000, 0, 0, false, 0);
            numStockQuantity.Name = "numStockQuantity";
            numStockQuantity.Size = new Size(115, 26);
            numStockQuantity.TabIndex = 14;

            lblReorderLevel.AutoSize = true;
            lblReorderLevel.Font = new Font("Segoe UI", 10F);
            lblReorderLevel.Location = new Point(25, 395);
            lblReorderLevel.Name = "lblReorderLevel";
            lblReorderLevel.Size = new Size(80, 20);
            lblReorderLevel.TabIndex = 15;
            lblReorderLevel.Text = "Reorder level:";

            numReorderLevel.Font = new Font("Segoe UI", 10F);
            numReorderLevel.Location = new Point(25, 420);
            numReorderLevel.Maximum = new decimal(2000000000, 0, 0, false, 0);
            numReorderLevel.Name = "numReorderLevel";
            numReorderLevel.Size = new Size(130, 26);
            numReorderLevel.TabIndex = 16;

            chkHasExpiry.AutoSize = true;
            chkHasExpiry.Font = new Font("Segoe UI", 10F);
            chkHasExpiry.Location = new Point(190, 395);
            chkHasExpiry.Name = "chkHasExpiry";
            chkHasExpiry.Size = new Size(105, 25);
            chkHasExpiry.TabIndex = 17;
            chkHasExpiry.Text = "Has expiry date";
            chkHasExpiry.CheckedChanged += chkHasExpiry_CheckedChanged;

            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Font = new Font("Segoe UI", 10F);
            lblExpiryDate.Location = new Point(190, 430);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(70, 20);
            lblExpiryDate.TabIndex = 18;
            lblExpiryDate.Text = "Expiry date:";

            dtpExpiry.Enabled = false;
            dtpExpiry.Font = new Font("Segoe UI", 10F);
            dtpExpiry.Format = DateTimePickerFormat.Short;
            dtpExpiry.Location = new Point(280, 426);
            dtpExpiry.Name = "dtpExpiry";
            dtpExpiry.Size = new Size(120, 26);
            dtpExpiry.TabIndex = 19;

            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(25, 475);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(110, 25);
            chkActive.TabIndex = 20;
            chkActive.Text = "Active product";

            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(25, 510);
            lblError.Name = "lblError";
            lblError.Size = new Size(440, 20);
            lblError.TabIndex = 21;

            btnSave.BackColor = Color.FromArgb(91, 174, 99);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(250, 555);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 36);
            btnSave.TabIndex = 22;
            btnSave.Text = "Save Product";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(370, 555);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 36);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            CancelButton = btnCancel;
            ClientSize = new Size(510, 620);
            Controls.Add(lblTitle);
            Controls.Add(lblProductName);
            Controls.Add(txtProductName);
            Controls.Add(lblBarcode);
            Controls.Add(txtBarcode);
            Controls.Add(lblCategory);
            Controls.Add(cbCategory);
            Controls.Add(lblSupplier);
            Controls.Add(cbSupplier);
            Controls.Add(lblCostPrice);
            Controls.Add(numCostPrice);
            Controls.Add(lblSellingPrice);
            Controls.Add(numSellingPrice);
            Controls.Add(lblStockQuantity);
            Controls.Add(numStockQuantity);
            Controls.Add(lblReorderLevel);
            Controls.Add(numReorderLevel);
            Controls.Add(chkHasExpiry);
            Controls.Add(lblExpiryDate);
            Controls.Add(dtpExpiry);
            Controls.Add(chkActive);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product";
            ((System.ComponentModel.ISupportInitialize)numCostPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSellingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblBarcode;
        private TextBox txtBarcode;
        private Label lblCategory;
        private ComboBox cbCategory;
        private Label lblSupplier;
        private ComboBox cbSupplier;
        private Label lblCostPrice;
        private NumericUpDown numCostPrice;
        private Label lblSellingPrice;
        private NumericUpDown numSellingPrice;
        private Label lblStockQuantity;
        private NumericUpDown numStockQuantity;
        private Label lblReorderLevel;
        private NumericUpDown numReorderLevel;
        private CheckBox chkHasExpiry;
        private Label lblExpiryDate;
        private DateTimePicker dtpExpiry;
        private CheckBox chkActive;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}
