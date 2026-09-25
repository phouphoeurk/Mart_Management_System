namespace Mart_Management_System.Forms
{
    partial class MainForm
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
            panelHeader = new Panel();
            lblAdmin = new Label();
            lblLogo = new Label();
            panelSidebar = new Panel();
            butLogout = new Button();
            butSettings = new Button();
            btnUsers = new Button();
            btnReports = new Button();
            btnSalesHistory = new Button();
            btnSuppliers = new Button();
            btnSales = new Button();
            btnCategories = new Button();
            btnProducts = new Button();
            btnDashboard = new Button();
            mainContentPanel = new Panel();
            panelHeader.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(255, 255, 255);
            panelHeader.Controls.Add(lblAdmin);
            panelHeader.Controls.Add(lblLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1366, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblAdmin
            // 
            lblAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdmin.AutoSize = true;
            lblAdmin.Cursor = Cursors.Hand;
            lblAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAdmin.ForeColor = Color.FromArgb(102, 102, 102);
            lblAdmin.Location = new Point(1170, 20);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(170, 21);
            lblAdmin.TabIndex = 1;
            lblAdmin.Text = "👤 ADMIN | LOGOUT";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(91, 174, 99);
            lblLogo.Location = new Point(20, 15);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(330, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "MART MANAGEMENT SYSTEM";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(255, 255, 255);
            panelSidebar.Controls.Add(butLogout);
            panelSidebar.Controls.Add(butSettings);
            panelSidebar.Controls.Add(btnUsers);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnSalesHistory);
            panelSidebar.Controls.Add(btnSuppliers);
            panelSidebar.Controls.Add(btnSales);
            panelSidebar.Controls.Add(btnCategories);
            panelSidebar.Controls.Add(btnProducts);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 60);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 708);
            panelSidebar.TabIndex = 1;
            // 
            // butLogout
            // 
            butLogout.FlatAppearance.BorderSize = 0;
            butLogout.FlatStyle = FlatStyle.Flat;
            butLogout.Font = new Font("Segoe UI", 12F);
            butLogout.Location = new Point(0, 655);
            butLogout.Name = "butLogout";
            butLogout.Size = new Size(220, 50);
            butLogout.TabIndex = 9;
            butLogout.Text = " 🚪 Logout";
            butLogout.TextAlign = ContentAlignment.MiddleLeft;
            butLogout.UseVisualStyleBackColor = true;
            butLogout.Click += butLogout_Click;
            // 
            // butSettings
            // 
            butSettings.Dock = DockStyle.Top;
            butSettings.FlatAppearance.BorderSize = 0;
            butSettings.FlatStyle = FlatStyle.Flat;
            butSettings.Font = new Font("Segoe UI", 12F);
            butSettings.Location = new Point(0, 400);
            butSettings.Name = "butSettings";
            butSettings.Size = new Size(220, 50);
            butSettings.TabIndex = 8;
            butSettings.Text = " ⚙️ Settings";
            butSettings.TextAlign = ContentAlignment.MiddleLeft;
            butSettings.UseVisualStyleBackColor = true;
            butSettings.Click += butSettings_Click;
            // 
            // btnUsers
            // 
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 12F);
            btnUsers.Location = new Point(0, 350);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(220, 50);
            btnUsers.TabIndex = 7;
            btnUsers.Text = "  👥 Users";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 12F);
            btnReports.Location = new Point(0, 300);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(220, 50);
            btnReports.TabIndex = 6;
            btnReports.Text = " 📈 Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnSalesHistory
            // 
            btnSalesHistory.Dock = DockStyle.Top;
            btnSalesHistory.FlatAppearance.BorderSize = 0;
            btnSalesHistory.FlatStyle = FlatStyle.Flat;
            btnSalesHistory.Font = new Font("Segoe UI", 12F);
            btnSalesHistory.Location = new Point(0, 250);
            btnSalesHistory.Name = "btnSalesHistory";
            btnSalesHistory.Size = new Size(220, 50);
            btnSalesHistory.TabIndex = 5;
            btnSalesHistory.Text = " 📜 Sales History";
            btnSalesHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnSalesHistory.UseVisualStyleBackColor = true;
            btnSalesHistory.Click += btnSalesHistory_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Dock = DockStyle.Top;
            btnSuppliers.FlatAppearance.BorderSize = 0;
            btnSuppliers.FlatStyle = FlatStyle.Flat;
            btnSuppliers.Font = new Font("Segoe UI", 12F);
            btnSuppliers.Location = new Point(0, 200);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(220, 50);
            btnSuppliers.TabIndex = 4;
            btnSuppliers.Text = "  🏢 Suppliers";
            btnSuppliers.TextAlign = ContentAlignment.MiddleLeft;
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnSales
            // 
            btnSales.Dock = DockStyle.Top;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 12F);
            btnSales.Location = new Point(0, 150);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(220, 50);
            btnSales.TabIndex = 3;
            btnSales.Text = "  \U0001f6d2 Sales / POS";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnCategories
            // 
            btnCategories.Dock = DockStyle.Top;
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI", 12F);
            btnCategories.Location = new Point(0, 100);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(220, 50);
            btnCategories.TabIndex = 2;
            btnCategories.Text = "  📁 Categories";
            btnCategories.TextAlign = ContentAlignment.MiddleLeft;
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnProducts
            // 
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 12F);
            btnProducts.Location = new Point(0, 50);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(220, 50);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "  📦 Products";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 12F);
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(220, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "  📊 Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.FromArgb(238, 241, 244);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(220, 60);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1146, 708);
            mainContentPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 768);
            Controls.Add(mainContentPanel);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mart Management System";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Panel mainContentPanel;
        private Button btnSuppliers;
        private Button btnSalesHistory;
        private Button btnReports;
        private Button btnUsers;
        private Button butSettings;
        private Button butLogout;
    }
}