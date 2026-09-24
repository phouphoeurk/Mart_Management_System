using Mart_Management_System.Data; // ត្រូវប្រាកដថាប្រើឈ្មោះ Namespace ត្រឹមត្រូវតាម Project របស់អ្នក
using Microsoft.Data.SqlClient;
using System;

namespace Mart_Management_System.Repositories
{
    public class DashboardRepository
    {
        // Method សម្រាប់រាប់ចំនួនផលិតផលសរុប
        public int GetTotalProducts()
        {
            int count = 0;
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE Status = 1"; // រាប់តែទំនិញដែល Active
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    count = (int)cmd.ExecuteScalar(); // ExecuteScalar ប្រើសម្រាប់ទាញយកតម្លៃតែមួយ
                }
            }
            return count;
        }

        // Method សម្រាប់បូកចំណូលសរុបថ្ងៃនេះ
        public decimal GetTodayRevenue()
        {
            decimal revenue = 0;
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // បូក TotalAmount ដែលមាន SaleDate ស្មើនឹងថ្ងៃនេះ (GETDATE)
                string query = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Sales WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    revenue = (decimal)cmd.ExecuteScalar();
                }
            }
            return revenue;
        }
    }
}