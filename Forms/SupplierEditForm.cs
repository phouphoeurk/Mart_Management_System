using System.Net.Mail;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Forms
{
    public partial class SupplierEditForm : Form
    {
        private readonly SupplierRepository _supplierRepository;
        private readonly Supplier? _supplier;

        public SupplierEditForm()
            : this(null)
        {
        }

        public SupplierEditForm(Supplier? supplier)
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            _supplierRepository = new SupplierRepository();
            _supplier = supplier;

            if (_supplier is not null)
            {
                Text = "Edit Supplier";
                btnSave.Text = "Update Supplier";
                txtSupplierName.Text = _supplier.SupplierName;
                txtPhone.Text = _supplier.Phone ?? string.Empty;
                txtEmail.Text = _supplier.Email ?? string.Empty;
                txtAddress.Text = _supplier.Address ?? string.Empty;
                chkActive.Checked = _supplier.IsActive;
            }
            else
            {
                Text = "Add Supplier";
                btnSave.Text = "Save Supplier";
                chkActive.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string supplierName = txtSupplierName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(supplierName))
            {
                ShowError("Supplier name is required.");
                txtSupplierName.Focus();
                return;
            }

            if (supplierName.Length > 150)
            {
                ShowError("Supplier name cannot exceed 150 characters.");
                txtSupplierName.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                ShowError("Enter a valid email address.");
                txtEmail.Focus();
                return;
            }

            if (phone.Length > 30)
            {
                ShowError("Phone cannot exceed 30 characters.");
                txtPhone.Focus();
                return;
            }

            if (email.Length > 150)
            {
                ShowError("Email cannot exceed 150 characters.");
                txtEmail.Focus();
                return;
            }

            if (address.Length > 255)
            {
                ShowError("Address cannot exceed 255 characters.");
                txtAddress.Focus();
                return;
            }

            Supplier supplier = _supplier is null
                ? new Supplier()
                : new Supplier
                {
                    SupplierId = _supplier.SupplierId,
                    CreatedAt = _supplier.CreatedAt
                };

            supplier.SupplierName = supplierName;
            supplier.Phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
            supplier.Email = string.IsNullOrWhiteSpace(email) ? null : email;
            supplier.Address = string.IsNullOrWhiteSpace(address) ? null : address;
            supplier.IsActive = chkActive.Checked;

            try
            {
                bool saved = _supplier is null
                    ? _supplierRepository.Create(supplier)
                    : _supplierRepository.Update(supplier);

                if (!saved)
                {
                    ShowError("The supplier could not be saved. Please try again.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                ShowError("Unable to save the supplier. Please try again.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
        }
    }
}
