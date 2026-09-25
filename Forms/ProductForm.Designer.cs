namespace Mart_Management_System.Forms
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            topPanel = new Panel();
            btnAddProduct = new Button();
            lblTitle = new Label();
            searchPanel = new Panel();
            cbCategoryFilter = new ComboBox();
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colSupplier = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            topPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(btnAddProduct);
            topPanel.Controls.Add(lblTitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(49, 55);
            topPanel.Margin = new Padding(7, 8, 7, 8);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(2573, 137);
            topPanel.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduct.BackColor = Color.FromArgb(91, 174, 99);
            btnAddProduct.Cursor = Cursors.Hand;
            btnAddProduct.FlatAppearance.BorderSize = 0;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(2185, 14);
            btnAddProduct.Margin = new Padding(7, 8, 7, 8);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(389, 109);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(0, 14);
            lblTitle.Margin = new Padding(7, 0, 7, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(764, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PRODUCT MANAGEMENT";
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(cbCategoryFilter);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(49, 192);
            searchPanel.Margin = new Padding(7, 8, 7, 8);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(2573, 137);
            searchPanel.TabIndex = 1;
            searchPanel.Paint += searchPanel_Paint;
            // 
            // cbCategoryFilter
            // 
            cbCategoryFilter.Font = new Font("Segoe UI", 11F);
            cbCategoryFilter.FormattingEnabled = true;
            cbCategoryFilter.Items.AddRange(new object[] { "All Categories", "Drinks", "Snacks", "Food" });
            cbCategoryFilter.Location = new Point(680, 27);
            cbCategoryFilter.Margin = new Padding(7, 8, 7, 8);
            cbCategoryFilter.Name = "cbCategoryFilter";
            cbCategoryFilter.Size = new Size(480, 58);
            cbCategoryFilter.TabIndex = 1;
            cbCategoryFilter.Text = "Filter by Category...";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(0, 27);
            txtSearch.Margin = new Padding(7, 8, 7, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "  Search products by name or barcode...";
            txtSearch.Size = new Size(626, 61);
            txtSearch.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 241, 244);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(238, 241, 244);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colID, colName, colCategory, colSupplier, colPrice, colStock, colStatus, colEdit, colDelete });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(234, 245, 236);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.Location = new Point(49, 329);
            dgvProducts.Margin = new Padding(7, 8, 7, 8);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 102;
            dgvProducts.RowTemplate.Height = 35;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(2573, 1529);
            dgvProducts.TabIndex = 2;
            // 
            // colID
            // 
            colID.FillWeight = 50F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 12;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colName
            // 
            colName.FillWeight = 150F;
            colName.HeaderText = "Product Name";
            colName.MinimumWidth = 12;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Category";
            colCategory.MinimumWidth = 12;
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colSupplier
            // 
            colSupplier.HeaderText = "Supplier";
            colSupplier.MinimumWidth = 12;
            colSupplier.Name = "colSupplier";
            colSupplier.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 12;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 12;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 12;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colEdit
            // 
            colEdit.FillWeight = 60F;
            colEdit.HeaderText = "Action";
            colEdit.MinimumWidth = 12;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.FillWeight = 60F;
            colDelete.HeaderText = "";
            colDelete.MinimumWidth = 12;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(2671, 1913);
            Controls.Add(dgvProducts);
            Controls.Add(searchPanel);
            Controls.Add(topPanel);
            Margin = new Padding(7, 8, 7, 8);
            Name = "ProductForm";
            Padding = new Padding(49, 55, 49, 55);
            Text = "ProductForm";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}