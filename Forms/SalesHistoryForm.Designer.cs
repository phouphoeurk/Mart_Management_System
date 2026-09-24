namespace Mart_Management_System.Forms
{
    partial class SalesHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbCashier = new System.Windows.Forms.ComboBox();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSalesHistory = new System.Windows.Forms.DataGridView();
            this.colSaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(20, 20);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1060, 50);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SALES HISTORY";
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.lblDateFrom);
            this.filterPanel.Controls.Add(this.dtpDateFrom);
            this.filterPanel.Controls.Add(this.lblDateTo);
            this.filterPanel.Controls.Add(this.dtpDateTo);
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.cbCashier);
            this.filterPanel.Controls.Add(this.cbPaymentMethod);
            this.filterPanel.Controls.Add(this.btnSearch);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(20, 70);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1060, 60);
            this.filterPanel.TabIndex = 1;
            // 
            // Controls inside filterPanel
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDateFrom.Location = new System.Drawing.Point(0, 15);
            this.lblDateFrom.Text = "From:";

            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(45, 12);
            this.dtpDateFrom.Size = new System.Drawing.Size(110, 25);

            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDateTo.Location = new System.Drawing.Point(165, 15);
            this.lblDateTo.Text = "To:";

            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(195, 12);
            this.dtpDateTo.Size = new System.Drawing.Size(110, 25);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(320, 12);
            this.txtSearch.PlaceholderText = "  Search Sale ID...";
            this.txtSearch.Size = new System.Drawing.Size(150, 25);

            this.cbCashier.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCashier.Items.AddRange(new object[] { "All Cashiers" });
            this.cbCashier.Location = new System.Drawing.Point(480, 12);
            this.cbCashier.Size = new System.Drawing.Size(150, 25);
            this.cbCashier.Text = "All Cashiers";

            this.cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPaymentMethod.Items.AddRange(new object[] { "All Payments", "Cash", "QR Code" });
            this.cbPaymentMethod.Location = new System.Drawing.Point(640, 12);
            this.cbPaymentMethod.Size = new System.Drawing.Size(150, 25);
            this.cbPaymentMethod.Text = "All Payments";

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(174)))), ((int)(((byte)(99)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(800, 10);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "Filter";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // dgvSalesHistory
            // 
            this.dgvSalesHistory.AllowUserToAddRows = false;
            this.dgvSalesHistory.AllowUserToDeleteRows = false;
            this.dgvSalesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvSalesHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesHistory.ColumnHeadersHeight = 40;
            this.dgvSalesHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSaleID,
            this.colDate,
            this.colCashier,
            this.colPayment,
            this.colTotal,
            this.colStatus,
            this.colAction});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgvSalesHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesHistory.EnableHeadersVisualStyles = false;
            this.dgvSalesHistory.Location = new System.Drawing.Point(20, 130);
            this.dgvSalesHistory.Name = "dgvSalesHistory";
            this.dgvSalesHistory.ReadOnly = true;
            this.dgvSalesHistory.RowHeadersVisible = false;
            this.dgvSalesHistory.RowTemplate.Height = 35;
            this.dgvSalesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesHistory.Size = new System.Drawing.Size(1060, 550);
            this.dgvSalesHistory.TabIndex = 2;
            // 
            // Columns
            // 
            this.colSaleID.FillWeight = 80F;
            this.colSaleID.HeaderText = "Sale ID";
            this.colSaleID.Name = "colSaleID";
            this.colSaleID.ReadOnly = true;

            this.colDate.FillWeight = 120F;
            this.colDate.HeaderText = "Date & Time";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;

            this.colCashier.FillWeight = 120F;
            this.colCashier.HeaderText = "Cashier";
            this.colCashier.Name = "colCashier";
            this.colCashier.ReadOnly = true;

            this.colPayment.FillWeight = 100F;
            this.colPayment.HeaderText = "Payment";
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;

            this.colTotal.FillWeight = 100F;
            this.colTotal.HeaderText = "Total ($)";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;

            this.colStatus.FillWeight = 80F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;

            this.colAction.FillWeight = 80F;
            this.colAction.HeaderText = "Action";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Text = "View";
            this.colAction.UseColumnTextForButtonValue = true;
            // 
            // SalesHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.dgvSalesHistory);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "SalesHistoryForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "SalesHistoryForm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbCashier;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSalesHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
    }
}