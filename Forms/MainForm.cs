using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mart_Management_System.Forms
{
    public partial class MainForm : Form
    {
        // ប្រើសញ្ញា ? ដើម្បីបញ្ជាក់ថាវាអាចមានតម្លៃ null (ដោះស្រាយ Warning)
        private Button? currentActiveButton;
        private Form? currentChildForm;

        public MainForm()
        {
            InitializeComponent();
            // បើក Dashboard មុនគេពេលកម្មវិធីដើរ
            OpenChildForm(new DashboardForm(), btnDashboard);
        }

        private void OpenChildForm(Form childForm, Button senderButton)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            HighlightActiveButton(senderButton);

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void HighlightActiveButton(Button clickedButton)
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.White;
                currentActiveButton.ForeColor = Color.FromArgb(17, 17, 17); // ពណ៌អក្សរធម្មតា
            }

            currentActiveButton = clickedButton;
            currentActiveButton.BackColor = Color.FromArgb(91, 174, 99); // ពណ៌បៃតង
            currentActiveButton.ForeColor = Color.White;
        }

        // --- Events ---
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // កែពី senderButton មក sender វិញ
            OpenChildForm(new DashboardForm(), (Button)sender);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            // កែពី senderButton មក sender វិញ
            OpenChildForm(new ProductForm(), (Button)sender);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            // ហៅ CategoryForm មកបង្ហាញ និងប្តូរពណ៌ប៊ូតុង
            OpenChildForm(new CategoryForm(), (Button)sender);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SupplierForm(), (Button)sender);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            // ហៅ SalesForm (POS) មកបង្ហាញ
            OpenChildForm(new SalesForm(), (Button)sender);
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            // ហៅ SalesHistoryForm មកបង្ហាញ
            OpenChildForm(new SalesHistoryForm(), (Button)sender);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // ហៅ ReportsForm មកបង្ហាញ
            OpenChildForm(new ReportsForm(), (Button)sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // ហៅ UserManagementForm មកបង្ហាញ
            OpenChildForm(new UserManagementForm(), (Button)sender);
        }
    }
}