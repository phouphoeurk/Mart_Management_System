using System;
using System.Windows.Forms;

namespace Mart_Management_System.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // លាក់លេខសម្ងាត់ជាមុន (Hide password by default)
            textBox2.UseSystemPasswordChar = true;
        }

        // Event សម្រាប់បង្ហាញ ឬលាក់ Password ពេលចុច Checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false; // បង្ហាញ Password ជាអក្សរ
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;  // លាក់ Password ជាសញ្ញា ***
            }
        }

        // Event សម្រាប់ចូលទៅកាន់ Main Dashboard ពេលចុចប៊ូតុង Login
        private void button1_Click(object sender, EventArgs e)
        {
            // នៅវគ្គក្រោយ យើងនឹងសរសេរកូដឆែក Username/Password ជាមួយ SQL នៅទីនេះ
            // តែពេលនេះ យើងឱ្យវាបើក Form1 (Dashboard) សិន ដើម្បី Test UI
            Testconnection  mainForm = new Testconnection();
            mainForm.Show();
            this.Hide(); // លាក់ផ្ទាំង Login នេះ
        }
    }
}