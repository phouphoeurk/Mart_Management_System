using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
#if DEBUG
using System.Data;
using System.Diagnostics;
using Mart_Management_System.Diagnostics;
#endif

namespace Mart_Management_System.Data
{
    public static class DatabaseConnection
    {
        private static readonly Lazy<IConfiguration> AppConfiguration =
            new(CreateConfiguration);

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new(GetConnectionString());
#if DEBUG
            long startTimestamp = Stopwatch.GetTimestamp();
            connection.StateChange += (_, eventArgs) =>
            {
                if (eventArgs.CurrentState == ConnectionState.Open)
                {
                    PerfTimer.Log("SqlConnection.Open", startTimestamp);
                }
            };
#endif
            return connection;
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
