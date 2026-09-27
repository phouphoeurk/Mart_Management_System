using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly User? _user;
        private readonly bool _isNewUser;

        public UserEditForm()
            : this(
                new User
                {
                    FullName = "Designer",
                    Username = "designer",
                    Role = UserRole.Admin,
                    IsActive = true
                },
                null
            )
        {
        }

        public UserEditForm(User currentAdministrator, User? user)
        {
            if (currentAdministrator.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException(
                    "Only administrators can manage user accounts."
                );
            }

            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            _userRepository = new UserRepository();
            _user = user;
            _isNewUser = user is null;

            if (_user is not null)
            {
                Text = "Edit User";
                btnSave.Text = "Update User";
                txtFullName.Text = _user.FullName;
                txtUsername.Text = _user.Username;
                cbRole.SelectedItem = _user.Role.ToString();
                chkActive.Checked = _user.IsActive;
            }
            else
            {
                Text = "Add User";
                btnSave.Text = "Save User";
                cbRole.SelectedItem = UserRole.Cashier.ToString();
                chkActive.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ShowError("Full name is required.");
                txtFullName.Focus();
                return;
            }

            if (fullName.Length > 150)
            {
                ShowError("Full name cannot exceed 150 characters.");
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError("Username is required.");
                txtUsername.Focus();
                return;
            }

            if (username.Length > 50)
            {
                ShowError("Username cannot exceed 50 characters.");
                txtUsername.Focus();
                return;
            }

            if (_isNewUser || !string.IsNullOrEmpty(password))
            {
                if (password.Length < 8)
                {
                    ShowError("Password must contain at least 8 characters.");
                    txtPassword.Focus();
                    return;
                }

                if (password != confirmPassword)
                {
                    ShowError("Passwords do not match.");
                    txtConfirmPassword.Focus();
                    return;
                }
            }

            if (cbRole.SelectedItem is not string roleText
                || !Enum.TryParse(roleText, out UserRole role))
            {
                ShowError("Select a valid role.");
                cbRole.Focus();
                return;
            }

            User user = _user is null
                ? new User()
                : new User
                {
                    UserId = _user.UserId,
                    CreatedAt = _user.CreatedAt,
                    UpdatedAt = _user.UpdatedAt
                };

            user.FullName = fullName;
            user.Username = username;
            user.Role = role;
            user.IsActive = chkActive.Checked;

            try
            {
                bool saved;
                if (_isNewUser)
                {
                    user.PasswordHash = global::BCrypt.Net.BCrypt.HashPassword(password);
                    saved = _userRepository.Create(user);
                }
                else
                {
                    string? passwordHash = string.IsNullOrEmpty(password)
                        ? null
                        : global::BCrypt.Net.BCrypt.HashPassword(password);
                    saved = _userRepository.Update(user, passwordHash);
                }

                if (!saved)
                {
                    ShowError("The user account could not be saved.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number is 2601 or 2627)
            {
                ShowError("A user with this username already exists.");
            }
            catch (Exception)
            {
                ShowError("Unable to save the user account. Please try again.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = chkShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !showPassword;
            txtConfirmPassword.UseSystemPasswordChar = !showPassword;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
        }
    }
}
