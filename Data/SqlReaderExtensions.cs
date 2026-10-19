using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Data
{
    internal static class SqlReaderExtensions
    {
        public static decimal GetDecimalSafe(this SqlDataReader reader, int ordinal)
        {
            object value = reader.GetValue(ordinal);
            return value is null or DBNull
                ? 0m
                : Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        public static int GetInt32Safe(this SqlDataReader reader, int ordinal)
        {
            object value = reader.GetValue(ordinal);
            return value is null or DBNull
                ? 0
                : Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static string GetStringSafe(this SqlDataReader reader, int ordinal)
        {
            object value = reader.GetValue(ordinal);
            return value is null or DBNull
                ? string.Empty
                : Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
        }
    }
}
