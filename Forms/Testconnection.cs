using Mart_Management_System.Data;
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
            //this.Load += Testconnection_Load;
        }

        // ថែមសញ្ញា ? នៅត្រង់ object? sender
        private void Testconnection_Load(object? sender, EventArgs e)
        {
            try
            {
                // ហៅ Connection ពី Class DatabaseConnection ដែលយើងបានរៀបចំជាមួយ .env
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open(); // សាកល្បងបើក Connection ទៅកាន់ SQL Server

                    // បើជោគជ័យ វានឹងលោត Message នេះ
                    MessageBox.Show("Database connection success!",
                                    "Database Setup",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // បើមាន Error (ឧទាហរណ៍ ភ្លេចបើក SQL Server ឬខុស Password) វានឹងលោត Message នេះ
                MessageBox.Show("Database connection failed\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Testconnection_Load_1(object sender, EventArgs e)
        {

        }
    }
}