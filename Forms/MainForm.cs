using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.UI;
#if DEBUG
using System.Diagnostics;
using Mart_Management_System.Diagnostics;
#endif

namespace Mart_Management_System.Forms
{
    public partial class MainForm : Form
    {
        private static readonly Color SidebarBackColor = Color.FromArgb(
            30,
            30,
            30
        );
        private static readonly Color SidebarInactiveColor = Color.FromArgb(
            211,
            211,
            211
        );
        private readonly User _currentUser;
        private Button? _currentActiveButton;
        private Form? _currentChildForm;

        // Kept for the Visual Studio designer. Runtime authentication always
        // uses the constructor that receives the authenticated user.
        public MainForm()
            : this(new User
            {
                FullName = "Designer",
                Username = "designer",
                Role = UserRole.Admin,
                IsActive = true
            })
        {
        }

        public MainForm(User currentUser)
        {
            ArgumentNullException.ThrowIfNull(currentUser);
            _currentUser = currentUser;

            InitializeComponent();
            ConfigureSidebarMenu();
            UiTheme.Apply(this);
            ApplyRoleVisibility();

            lblAdmin.Text =
                $"{DisplayName(_currentUser)} | {_currentUser.Role} | Logout";

            if (_currentUser.Role == UserRole.Admin)
            {
                OpenChildForm(() => new DashboardForm(), btnDashboard);
            }
            else
            {
                OpenChildForm(() => new SalesForm(), btnSales);
            }
        }

        private void ConfigureSidebarMenu()
        {
            panelSidebar.Controls.Clear();

            // Dock.Top is laid out in reverse child order. Adding the menu
            // items from bottom to top makes the visual order explicit and
            // prevents a newly inserted item from covering another one.
            panelSidebar.Controls.Add(butLogout);
            panelSidebar.Controls.Add(butSettings);
            panelSidebar.Controls.Add(btnUsers);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnSalesHistory);
            panelSidebar.Controls.Add(btnSuppliers);
            panelSidebar.Controls.Add(btnStockAlerts);
            panelSidebar.Controls.Add(btnPurchases);
            panelSidebar.Controls.Add(btnSales);
            panelSidebar.Controls.Add(btnCategories);
            panelSidebar.Controls.Add(btnProducts);
            panelSidebar.Controls.Add(btnDashboard);

            ConfigureSidebarButton(btnDashboard, "  📊 Dashboard", 0);
            ConfigureSidebarButton(btnProducts, "  📦 Products", 1);
            ConfigureSidebarButton(btnCategories, "  📁 Categories", 2);
            ConfigureSidebarButton(btnSales, "  \U0001f6d2 Sales / POS", 3);
            ConfigureSidebarButton(btnPurchases, "  🧾 Purchases", 4);
            // U+26A0 without the emoji variation selector inherits the
            // sidebar text color, keeping the warning icon high-contrast.
            ConfigureSidebarButton(btnStockAlerts, "  ⚠ Stock Alerts", 5);
            ConfigureSidebarButton(btnSuppliers, "  🏢 Suppliers", 6);
            ConfigureSidebarButton(btnSalesHistory, "  📜 Sales History", 7);
            ConfigureSidebarButton(btnReports, "  📈 Reports", 8);
            ConfigureSidebarButton(btnUsers, "  👥 Users", 9);
            ConfigureSidebarButton(butSettings, "  ⚙️ Settings", 10);

            butLogout.Dock = DockStyle.Bottom;
            butLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            butLogout.AutoSize = false;
            butLogout.BackColor = SidebarBackColor;
            butLogout.FlatAppearance.BorderSize = 0;
            butLogout.FlatStyle = FlatStyle.Flat;
            butLogout.Font = new Font("Segoe UI", 12F);
            butLogout.ForeColor = SidebarInactiveColor;
            butLogout.Size = new Size(220, 50);
            butLogout.TabIndex = 11;
            butLogout.Text = "  🚪 Logout";
            butLogout.TextAlign = ContentAlignment.MiddleLeft;
            butLogout.UseVisualStyleBackColor = false;
        }

        private static string DisplayName(User user)
        {
            return string.IsNullOrWhiteSpace(user.FullName)
                ? user.Username
                : user.FullName;
        }

        private static void ConfigureSidebarButton(
            Button button,
            string text,
            int tabIndex
        )
        {
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button.AutoSize = false;
            button.BackColor = SidebarBackColor;
            button.Dock = DockStyle.Top;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 12F);
            button.ForeColor = SidebarInactiveColor;
            button.Padding = new Padding(0);
            button.Size = new Size(220, 50);
            button.TabIndex = tabIndex;
            button.Text = text;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.UseVisualStyleBackColor = false;
        }

        private void ApplyRoleVisibility()
        {
            bool isAdmin = _currentUser.Role == UserRole.Admin;

            btnDashboard.Visible = isAdmin;
            btnProducts.Visible = isAdmin;
            btnCategories.Visible = isAdmin;
            btnSuppliers.Visible = isAdmin;
            btnStockAlerts.Visible = isAdmin;
            btnPurchases.Visible = isAdmin;
            btnReports.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
            butSettings.Visible = isAdmin;

            btnSales.Visible = true;
            btnSalesHistory.Visible = true;
            butLogout.Visible = true;
        }

        private bool CanOpen(Button button)
        {
            if (_currentUser.Role == UserRole.Admin)
            {
                return true;
            }

            return button == btnSales || button == btnSalesHistory;
        }

        private void OpenChildForm(Func<Form> formFactory, Button senderButton)
        {
            if (!CanOpen(senderButton))
            {
                return;
            }

#if DEBUG
            long startTimestamp = Stopwatch.GetTimestamp();
#endif

            if (_currentChildForm is not null)
            {
                _currentChildForm.Close();
                _currentChildForm.Dispose();
            }

            HighlightActiveButton(senderButton);

            Form childForm = formFactory();
#if DEBUG
            string tag = childForm.GetType().Name;
            PerfTimer.Log($"nav:{tag}:construct", startTimestamp);
#endif

            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            mainContentPanel.SuspendLayout();
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(childForm);
            mainContentPanel.ResumeLayout();

            UiTheme.Apply(childForm);

#if DEBUG
            long showStart = Stopwatch.GetTimestamp();
#endif
            childForm.Show();
#if DEBUG
            PerfTimer.Log($"nav:{tag}:show(load+layout)", showStart);

            childForm.Paint += (_, _) =>
            {
                PerfTimer.Log($"nav:{tag}:click-to-first-paint", startTimestamp);
            };

            PerfTimer.Log($"nav:{tag}:total-handler", startTimestamp);
#endif
        }

        private void HighlightActiveButton(Button clickedButton)
        {
            if (_currentActiveButton is not null)
            {
                UiTheme.SetActive(_currentActiveButton, isActive: false);
                _currentActiveButton.ForeColor = SidebarInactiveColor;
            }

            _currentActiveButton = clickedButton;
            UiTheme.SetActive(
                _currentActiveButton,
                isActive: true,
                UiTheme.ActiveGreen
            );
            _currentActiveButton.ForeColor = Color.White;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new DashboardForm(), (Button)sender);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new ProductForm(_currentUser), (Button)sender);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new CategoryForm(), (Button)sender);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new SupplierForm(), (Button)sender);
        }

        private void btnStockAlerts_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                () => new StockAlertsForm(_currentUser),
                (Button)sender
            );
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                () => new PurchaseOrderForm(_currentUser),
                (Button)sender
            );
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new SalesForm(_currentUser), (Button)sender);
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                () => new SalesHistoryForm(_currentUser),
                (Button)sender
            );
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new ReportsForm(), (Button)sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                () => new UserManagementForm(_currentUser),
                (Button)sender
            );
        }

        private void butSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(() => new Settings(_currentUser), (Button)sender);
        }

        private void butLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            Hide();
            using LoginForm loginForm = new();
            loginForm.ShowDialog(this);
            Close();
        }
    }
}
