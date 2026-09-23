using MartManagementSystem.Data;
using Microsoft.Data.SqlClient;
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
    public partial class Testconnection : Form
    {
        public Testconnection()
        {
            InitializeComponent();

            // ភ្ជាប់ Event នេះដើម្បីឱ្យកូដ Testconnection_Load ដំណើរការពេល Form បើក
            this.Load += Testconnection_Load;
        }

        // ថែមសញ្ញា ? នៅត្រង់ object? sender
        private void Testconnection_Load(object? sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    MessageBox.Show("ការតភ្ជាប់ Database ទទួលបានជោគជ័យ! (Connection Successful!)",
                                    "Database Setup",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ការតភ្ជាប់បរាជ័យ (Connection Failed): \n\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}