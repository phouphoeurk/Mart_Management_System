using System.Runtime.InteropServices;
using BCrypt.Net;
using Mart_Management_System.Models;
using Mart_Management_System.Services;

namespace Mart_Management_System.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authenticationService;

        public LoginForm()
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            SetTextBoxPadding(txtUsername, 10, 10);
            SetTextBoxPadding(txtPassword, 10, 10);
            txtPassword.UseSystemPasswordChar = true;

            // User accounts are created by an administrator.
            registerLink.Visible = false;
            label4.Visible = false;

            _authenticationService = new AuthenticationService(
                new Mart_Management_System.Repositories.UserRepository()
            );
        }

        private void cbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShowPW.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowValidationMessage("Please enter your username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowValidationMessage("Please enter your password.");
                txtPassword.Focus();
                return;
            }

            try
            {
                User? user = _authenticationService.Authenticate(
                    username,
                    password,
                    out string errorMessage
                );

                if (user is null)
                {
                    bool isInactive =
                        errorMessage.StartsWith(
                            "This account is inactive",
                            StringComparison.Ordinal
                        );

                    MessageBox.Show(
                        errorMessage,
                        isInactive ? "Account Disabled" : "Login Failed",
                        MessageBoxButtons.OK,
                        isInactive ? MessageBoxIcon.Warning : MessageBoxIcon.Error
                    );
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                Hide();
                using MainForm mainForm = new(user);
                mainForm.ShowDialog(this);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to sign in right now. Please try again or contact an administrator.",
                    "Sign-In Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ShowValidationMessage(string message)
        {
            MessageBox.Show(
                message,
                "Login Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
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
