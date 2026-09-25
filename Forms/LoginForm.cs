using Mart_Management_System.Models;
using Mart_Management_System.Repositories;
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
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices;

    public partial class LoginForm : Form
    {
        private UserRepository userRepo;
        public LoginForm()
        {
            InitializeComponent();
            SetTextBoxPadding(txtUsername, 10, 10);
            SetTextBoxPadding(txtPassword, 10, 10);
            txtPassword.UseSystemPasswordChar = true;
            userRepo = new UserRepository();
        }

        private void cbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPW.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; 
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;  
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
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
            User? user = userRepo.findByName(username);
            if (user != null)
            {
                bool isAutenticated = BCrypt.Verify(password, user.password);
                if (isAutenticated)
                {
                    //DashbaordForm dashboard = new DashbaordForm();
                    MessageBox.Show(
                            "Login success",
                            "success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                    //dashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid username or password",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }

            }
            else
            {
                MessageBox.Show(
                          "You do not have any account.\nPlease sign up first",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information
                 );

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (RegisterForm form = new RegisterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Show Page
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(
                IntPtr hWnd,
                int Msg,
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