using System;
using Microsoft.Data.SqlClient;
using DotNetEnv;

namespace MartManagementSystem.Data
{
    public class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                // Load variables from .env
                Env.Load();

                // Get DB_CONNECTION from .env
                string? connectionString =
                    Environment.GetEnvironmentVariable("DB_CONNECTION");

                // Validate connection string
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new Exception(
                        "DB_CONNECTION was not found in the .env file."
                    );
                }

                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Cannot create database connection. Error: " + ex.Message,
                    ex
                );
            }
        }
    }
}