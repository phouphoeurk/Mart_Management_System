namespace Mart_Management_System.Forms
{
    partial class SupplierForm
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
            btnAddSupplier = new Button();
            lblTitle = new Label();
            searchPanel = new Panel();
            txtSearch = new TextBox();
            dgvSuppliers = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            topPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(btnAddSupplier);
            topPanel.Controls.Add(lblTitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(49, 55);
            topPanel.Margin = new Padding(7, 8, 7, 8);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(2573, 137);
            topPanel.TabIndex = 0;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddSupplier.BackColor = Color.FromArgb(91, 174, 99);
            btnAddSupplier.Cursor = Cursors.Hand;
            btnAddSupplier.FlatAppearance.BorderSize = 0;
            btnAddSupplier.FlatStyle = FlatStyle.Flat;
            btnAddSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddSupplier.ForeColor = Color.White;
            btnAddSupplier.Location = new Point(2160, 14);
            btnAddSupplier.Margin = new Padding(7, 8, 7, 8);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(413, 109);
            btnAddSupplier.TabIndex = 1;
            btnAddSupplier.Text = "+ Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(0, 14);
            lblTitle.Margin = new Padding(7, 0, 7, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(757, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SUPPLIER MANAGEMENT";
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(49, 192);
            searchPanel.Margin = new Padding(7, 8, 7, 8);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(2573, 137);
            searchPanel.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(0, 27);
            txtSearch.Margin = new Padding(7, 8, 7, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "  Search suppliers by name or phone...";
            txtSearch.Size = new Size(771, 61);
            txtSearch.TabIndex = 0;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.BorderStyle = BorderStyle.None;
            dgvSuppliers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 241, 244);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(238, 241, 244);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSuppliers.ColumnHeadersHeight = 40;
            dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] { colID, colName, colPhone, colEmail, colAddress, colStatus, colEdit, colDelete });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(234, 245, 236);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSuppliers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSuppliers.Dock = DockStyle.Fill;
            dgvSuppliers.EnableHeadersVisualStyles = false;
            dgvSuppliers.Location = new Point(49, 329);
            dgvSuppliers.Margin = new Padding(7, 8, 7, 8);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.ReadOnly = true;
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.RowHeadersWidth = 102;
            dgvSuppliers.RowTemplate.Height = 35;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.Size = new Size(2573, 1529);
            dgvSuppliers.TabIndex = 2;
            dgvSuppliers.CellContentClick += dgvSuppliers_CellContentClick;
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
            colName.HeaderText = "Supplier Name";
            colName.MinimumWidth = 12;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "Phone";
            colPhone.MinimumWidth = 12;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.FillWeight = 120F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 12;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.FillWeight = 150F;
            colAddress.HeaderText = "Address";
            colAddress.MinimumWidth = 12;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 80F;
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
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(2671, 1913);
            Controls.Add(dgvSuppliers);
            Controls.Add(searchPanel);
            Controls.Add(topPanel);
            Margin = new Padding(7, 8, 7, 8);
            Name = "SupplierForm";
            Padding = new Padding(49, 55, 49, 55);
            Text = "SupplierForm";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}