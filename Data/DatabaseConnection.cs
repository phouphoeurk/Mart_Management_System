using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Mart_Management_System.Data
{
    public static class DatabaseConnection
    {
        private static readonly Lazy<IConfiguration> AppConfiguration =
            new(CreateConfiguration);

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static string GetConnectionString()
        {
            string? connectionString =
                AppConfiguration.Value.GetConnectionString("MartDb");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "The MartDb connection string is missing from appsettings.json."
                );
            }

            return connectionString;
        }

        private static IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile(
                    "appsettings.Development.json",
                    optional: true,
                    reloadOnChange: false
                )
                .Build();
        }
    }
}
