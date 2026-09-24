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

    public partial class LoginForm : Form
    {
        private UserRepository userRepo;
        public LoginForm()
        {
            InitializeComponent();
            userRepo = new UserRepository();
            userRepo.ConnectDB();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
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
        }
    }
}
