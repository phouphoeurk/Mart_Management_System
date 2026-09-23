using System;
using Microsoft.Data.SqlClient;

namespace MartManagementSystem.Data
{
    public class DatabaseConnection
    {
        // កែប្រែ Server=ITACHI\SQLEXPRESS
        private static readonly string connectionString = @"Server=ITACHI\SQLEXPRESS;Database=MartManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to Database. Error: " + ex.Message);
            }
        }
    }
}