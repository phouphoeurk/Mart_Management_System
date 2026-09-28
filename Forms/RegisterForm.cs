using System.Runtime.InteropServices;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserRepository _userRepository;

        public RegisterForm()
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            SetTextBoxPadding(txtFullName, 10, 10);
            SetTextBoxPadding(txtUsername, 10, 10);
            SetTextBoxPadding(txtPassword, 10, 10);
            SetTextBoxPadding(txtConfirmPassword, 10, 10);

            ClearErrors();
            _userRepository = new UserRepository();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ClearErrors();

            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                lblFullNameError.Text = "Please enter your full name.";
                txtFullName.Focus();
                return;
            }

            if (fullName.Length > 150)
            {
                lblFullNameError.Text = "Full name cannot exceed 150 characters.";
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                lblUsernameError.Text = "Please enter a username.";
                txtUsername.Focus();
                return;
            }

            if (username.Length > 50)
            {
                lblUsernameError.Text = "Username cannot exceed 50 characters.";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblPasswordError.Text = "Please enter a password.";
                txtPassword.Focus();
                return;
            }

            if (password.Length < 8)
            {
                lblPasswordError.Text = "Password must be at least 8 characters.";
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                lblConfirmPasswordError.Text = "Please confirm your password.";
                txtConfirmPassword.Focus();
                return;
            }

            if (!string.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                lblConfirmPasswordError.Text = "Passwords do not match.";
                txtConfirmPassword.Focus();
                return;
            }

            User user = new()
            {
                FullName = fullName,
                Username = username,
                PasswordHash = global::BCrypt.Net.BCrypt.HashPassword(password),
                Role = UserRole.Cashier,
                // Self-registered accounts stay inactive until an administrator
                // approves them from User Management, so the public form can
                // never create a usable account on its own.
                IsActive = false
            };

            try
            {
                if (!_userRepository.Create(user))
                {
                    lblUsernameError.Text = "The account could not be created.";
                    return;
                }
            }
            catch (SqlException ex) when (ex.Number is 2601 or 2627)
            {
                lblUsernameError.Text = "That username is already taken.";
                txtUsername.Focus();
                return;
            }
            catch (ArgumentException)
            {
                lblUsernameError.Text = "The account could not be created.";
                return;
            }
            catch (Exception)
            {
                lblUsernameError.Text = "Unable to create the account. Please try again.";
                return;
            }

            MessageBox.Show(
                "Your account has been created and is waiting for admin approval. "
                    + "You will be able to sign in once an administrator activates it.",
                "Registration Received",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = checkBox1.Checked;
            txtPassword.UseSystemPasswordChar = !showPassword;
            txtConfirmPassword.UseSystemPasswordChar = !showPassword;
        }

        private void lnkGoToLogin_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e
        )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ClearErrors()
        {
            lblFullNameError.Text = string.Empty;
            lblUsernameError.Text = string.Empty;
            lblPasswordError.Text = string.Empty;
            lblConfirmPasswordError.Text = string.Empty;
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(
            IntPtr hWnd,
            int message,
            int wParam,
            int lParam
        );

        private const int EM_SETMARGINS = 0xD3;
        private const int EC_LEFTMARGIN = 0x0001;
        private const int EC_RIGHTMARGIN = 0x0002;

        private void SetTextBoxPadding(TextBox textBox, int left, int right)
        {
            SendMessage(
                textBox.Handle,
                EM_SETMARGINS,
                EC_LEFTMARGIN | EC_RIGHTMARGIN,
                (right << 16) | left
            );
        }
    }
}
