using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierForm()
        {
            InitializeComponent();
            _supplierRepository = new SupplierRepository();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using SupplierEditForm form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadSuppliers();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void dgvSuppliers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
            if (row.Tag is not Supplier supplier)
            {
                return;
            }

            if (e.ColumnIndex == colEdit.Index)
            {
                using SupplierEditForm form = new(supplier);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSuppliers();
                }
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                ToggleSupplier(supplier);
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                List<Supplier> suppliers = _supplierRepository.GetAll(txtSearch.Text);
                dgvSuppliers.Rows.Clear();

                foreach (Supplier supplier in suppliers)
                {
                    int rowIndex = dgvSuppliers.Rows.Add(
                        supplier.SupplierId,
                        supplier.SupplierName,
                        supplier.Phone ?? string.Empty,
                        supplier.Email ?? string.Empty,
                        supplier.Address ?? string.Empty,
                        supplier.IsActive ? "Active" : "Inactive",
                        "Edit",
                        supplier.IsActive ? "Deactivate" : "Activate"
                    );
                    dgvSuppliers.Rows[rowIndex].Tag = supplier;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load suppliers. Please try again.",
                    "Supplier Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ToggleSupplier(Supplier supplier)
        {
            string action = supplier.IsActive ? "deactivate" : "activate";
            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to {action} '{supplier.SupplierName}'?",
                "Confirm Supplier Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_supplierRepository.SetActive(supplier.SupplierId, !supplier.IsActive))
                {
                    LoadSuppliers();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to change the supplier status. Please try again.",
                    "Supplier Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
