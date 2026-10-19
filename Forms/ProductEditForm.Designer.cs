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
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(27, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(119, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 10F);
            lblProductName.Location = new Point(29, 87);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(122, 23);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product name:";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(29, 120);
            txtProductName.Margin = new Padding(3, 4, 3, 4);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(502, 30);
            txtProductName.TabIndex = 2;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 10F);
            lblBarcode.Location = new Point(29, 173);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(76, 23);
            lblBarcode.TabIndex = 3;
            lblBarcode.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 10F);
            txtBarcode.Location = new Point(29, 207);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(502, 30);
            txtBarcode.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.Location = new Point(29, 260);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(83, 23);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category:";
            // 
            // cbCategory
            // 
            cbCategory.Font = new Font("Segoe UI", 10F);
            cbCategory.Location = new Point(29, 293);
            cbCategory.Margin = new Padding(3, 4, 3, 4);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(502, 31);
            cbCategory.TabIndex = 6;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 10F);
            lblSupplier.Location = new Point(29, 347);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(76, 23);
            lblSupplier.TabIndex = 7;
            lblSupplier.Text = "Supplier:";
            // 
            // cbSupplier
            // 
            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.Location = new Point(29, 380);
            cbSupplier.Margin = new Padding(3, 4, 3, 4);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(502, 31);
            cbSupplier.TabIndex = 8;
            cbSupplier.SelectedIndexChanged += cbSupplier_SelectedIndexChanged;
            // 
            // lblCostPrice
            // 
            lblCostPrice.AutoSize = true;
            lblCostPrice.Font = new Font("Segoe UI", 10F);
            lblCostPrice.Location = new Point(29, 433);
            lblCostPrice.Name = "lblCostPrice";
            lblCostPrice.Size = new Size(90, 23);
            lblCostPrice.TabIndex = 9;
            lblCostPrice.Text = "Cost price:";
            // 
            // numCostPrice
            // 
            numCostPrice.DecimalPlaces = 2;
            numCostPrice.Font = new Font("Segoe UI", 10F);
            numCostPrice.Location = new Point(29, 467);
            numCostPrice.Margin = new Padding(3, 4, 3, 4);
            numCostPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 131072 });
            numCostPrice.Name = "numCostPrice";
            numCostPrice.Size = new Size(149, 30);
            numCostPrice.TabIndex = 10;
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Font = new Font("Segoe UI", 10F);
            lblSellingPrice.Location = new Point(217, 433);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(106, 23);
            lblSellingPrice.TabIndex = 11;
            lblSellingPrice.Text = "Selling price:";
            // 
            // numSellingPrice
            // 
            numSellingPrice.DecimalPlaces = 2;
            numSellingPrice.Font = new Font("Segoe UI", 10F);
            numSellingPrice.Location = new Point(217, 467);
            numSellingPrice.Margin = new Padding(3, 4, 3, 4);
            numSellingPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 131072 });
            numSellingPrice.Name = "numSellingPrice";
            numSellingPrice.Size = new Size(149, 30);
            numSellingPrice.TabIndex = 12;
            // 
            // lblStockQuantity
            // 
            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Font = new Font("Segoe UI", 10F);
            lblStockQuantity.Location = new Point(400, 433);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(122, 23);
            lblStockQuantity.TabIndex = 13;
            lblStockQuantity.Text = "Stock quantity:";
            // 
            // numStockQuantity
            // 
            numStockQuantity.Font = new Font("Segoe UI", 10F);
            numStockQuantity.Location = new Point(400, 467);
            numStockQuantity.Margin = new Padding(3, 4, 3, 4);
            numStockQuantity.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numStockQuantity.Name = "numStockQuantity";
            numStockQuantity.Size = new Size(131, 30);
            numStockQuantity.TabIndex = 14;
            // 
            // lblReorderLevel
            // 
            lblReorderLevel.AutoSize = true;
            lblReorderLevel.Font = new Font("Segoe UI", 10F);
            lblReorderLevel.Location = new Point(29, 527);
            lblReorderLevel.Name = "lblReorderLevel";
            lblReorderLevel.Size = new Size(113, 23);
            lblReorderLevel.TabIndex = 15;
            lblReorderLevel.Text = "Reorder level:";
            // 
            // numReorderLevel
            // 
            numReorderLevel.Font = new Font("Segoe UI", 10F);
            numReorderLevel.Location = new Point(29, 560);
            numReorderLevel.Margin = new Padding(3, 4, 3, 4);
            numReorderLevel.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numReorderLevel.Name = "numReorderLevel";
            numReorderLevel.Size = new Size(149, 30);
            numReorderLevel.TabIndex = 16;
            // 
            // chkHasExpiry
            // 
            chkHasExpiry.AutoSize = true;
            chkHasExpiry.Font = new Font("Segoe UI", 10F);
            chkHasExpiry.Location = new Point(217, 527);
            chkHasExpiry.Margin = new Padding(3, 4, 3, 4);
            chkHasExpiry.Name = "chkHasExpiry";
            chkHasExpiry.Size = new Size(149, 27);
            chkHasExpiry.TabIndex = 17;
            chkHasExpiry.Text = "Has expiry date";
            chkHasExpiry.CheckedChanged += chkHasExpiry_CheckedChanged;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Font = new Font("Segoe UI", 10F);
            lblExpiryDate.Location = new Point(217, 573);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(98, 23);
            lblExpiryDate.TabIndex = 18;
            lblExpiryDate.Text = "Expiry date:";
            // 
            // dtpExpiry
            // 
            dtpExpiry.Enabled = false;
            dtpExpiry.Font = new Font("Segoe UI", 10F);
            dtpExpiry.Format = DateTimePickerFormat.Short;
            dtpExpiry.Location = new Point(320, 568);
            dtpExpiry.Margin = new Padding(3, 4, 3, 4);
            dtpExpiry.Name = "dtpExpiry";
            dtpExpiry.Size = new Size(137, 30);
            dtpExpiry.TabIndex = 19;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(29, 633);
            chkActive.Margin = new Padding(3, 4, 3, 4);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(143, 27);
            chkActive.TabIndex = 20;
            chkActive.Text = "Active product";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(29, 680);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 21;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(91, 174, 99);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(286, 740);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 48);
            btnSave.TabIndex = 22;
            btnSave.Text = "Save Product";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(423, 740);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 48);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // ProductEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            CancelButton = btnCancel;
            ClientSize = new Size(583, 827);
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
            Margin = new Padding(3, 4, 3, 4);
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
