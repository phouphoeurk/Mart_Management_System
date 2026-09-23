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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Loads logo dynamically without corrupting .resx files
            if (System.IO.File.Exists("logo.png"))
            {
                pictureBox1.Image = Image.FromFile("logo.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
