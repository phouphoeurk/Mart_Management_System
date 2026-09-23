using MartManagementSystem.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Mart_Management_System.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("ការតភ្ជាប់ Database ទទួលបានជោគជ័យ! (Connection Successful!)", "Database Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ការតភ្ជាប់បរាជ័យ (Connection Failed): \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";

            // បន្ថែមបន្ទាត់កូដនេះ ដើម្បីភ្ជាប់ Event ឱ្យដំណើរការកូដភ្ជាប់ Database
            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
        }


    }
}
