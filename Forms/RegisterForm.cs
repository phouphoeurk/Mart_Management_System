using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mart_Management_System.Forms
{
    using BCrypt.Net;
    using Mart_Management_System.Enums;
    using Mart_Management_System.Models;
    using Mart_Management_System.Repositories;

    public partial class RegisterForm : Form
    {
        private UserRepository userRepo;

        public RegisterForm()
        {
            InitializeComponent();
            userRepo = new UserRepository();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            string hashedPassword = BCrypt.HashPassword(password);
            User? user = new User();
            user.username = username;
            user.password = hashedPassword;
            user.role = UserRole.Cashier;
            user.isActive = true;
            user.createdAt = DateTime.Now;

            lblUsernameError.Text = string.Empty;
            lblPasswordError.Text = string.Empty;
            lblConfirmPasswordError.Text = string.Empty;

            if (string.IsNullOrEmpty(username))
            {
                lblUsernameError.Text = "Please enter a username.";

                MessageBox.Show(
                    "Please enter a username.",
                    "Register Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblPasswordError.Text = "Please enter a password.";

                MessageBox.Show(
                    "Please enter a password.",
                    "Register Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirm))
            {
                lblConfirmPasswordError.Text = "Please confirm your password.";

                MessageBox.Show(
                    "Please confirm your password.",
                    "Register Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtConfirmPassword.Focus();
                return;
            }

            if (password != confirm)
            {
                lblConfirmPasswordError.Text = "Passwords do not match.";

                MessageBox.Show(
                    "Password does not match",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (userRepo.save(user))
            {
                MessageBox.Show(
                    "Register success",
                    "Registeration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                //go next page
            }
            else
            {
                MessageBox.Show(
                    "Register failed",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        

        private void lnkGoToLogin_Click(
            object sender,
            LinkLabelLinkClickedEventArgs e
        )
        {
            this.Close();

            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
