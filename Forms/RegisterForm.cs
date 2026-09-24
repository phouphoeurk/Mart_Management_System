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
            if (string.IsNullOrEmpty(username))
            {
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
    }
}
