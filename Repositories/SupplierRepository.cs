using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class SupplierRepository
    {
        public List<Supplier> GetAll(string? keyword = null)
        {
            const string sql = """
                SELECT SupplierId, SupplierName, Phone, Email, Address,
                       IsActive, CreatedAt
                FROM dbo.Suppliers
                WHERE @keyword IS NULL
                   OR SupplierName LIKE @keyword
                   OR Phone LIKE @keyword
                ORDER BY SupplierName;
                """;

            List<Supplier> suppliers = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@keyword", SqlDbType.NVarChar, 150).Value =
                string.IsNullOrWhiteSpace(keyword)
                    ? DBNull.Value
                    : $"%{keyword.Trim()}%";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                suppliers.Add(MapSupplier(reader));
            }

            return suppliers;
        }

        public Supplier? GetById(int supplierId)
        {
            const string sql = """
                SELECT SupplierId, SupplierName, Phone, Email, Address,
                       IsActive, CreatedAt
                FROM dbo.Suppliers
                WHERE SupplierId = @supplierId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@supplierId", SqlDbType.Int).Value = supplierId;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            return reader.Read() ? MapSupplier(reader) : null;
        }

        public bool Create(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);
            ValidateSupplier(supplier);

            const string sql = """
                INSERT INTO dbo.Suppliers
                    (SupplierName, Phone, Email, Address, IsActive, CreatedAt)
                VALUES
                    (@supplierName, @phone, @email, @address, @isActive,
                     SYSUTCDATETIME());
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddParameters(command, supplier);

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        public bool Update(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);
            ValidateSupplier(supplier);

            const string sql = """
                UPDATE dbo.Suppliers
                SET SupplierName = @supplierName,
                    Phone = @phone,
                    Email = @email,
                    Address = @address,
                    IsActive = @isActive
                WHERE SupplierId = @supplierId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddParameters(command, supplier);
            command.Parameters.Add("@supplierId", SqlDbType.Int).Value = supplier.SupplierId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        public bool SetActive(int supplierId, bool isActive)
        {
            const string sql = """
                UPDATE dbo.Suppliers
                SET IsActive = @isActive
                WHERE SupplierId = @supplierId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = isActive;
            command.Parameters.Add("@supplierId", SqlDbType.Int).Value = supplierId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        private static void AddParameters(SqlCommand command, Supplier supplier)
        {
            command.Parameters.Add("@supplierName", SqlDbType.NVarChar, 150).Value =
                supplier.SupplierName.Trim();
            command.Parameters.Add("@phone", SqlDbType.NVarChar, 30).Value =
                (object?)supplier.Phone ?? DBNull.Value;
            command.Parameters.Add("@email", SqlDbType.NVarChar, 150).Value =
                (object?)supplier.Email ?? DBNull.Value;
            command.Parameters.Add("@address", SqlDbType.NVarChar, 255).Value =
                (object?)supplier.Address ?? DBNull.Value;
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = supplier.IsActive;
        }

        private static void ValidateSupplier(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
            {
                throw new ArgumentException("Supplier name is required.");
            }

            if (supplier.SupplierName.Trim().Length > 150)
            {
                throw new ArgumentException(
                    "Supplier name cannot exceed 150 characters."
                );
            }

            if (supplier.Phone?.Length > 30)
            {
                throw new ArgumentException("Phone cannot exceed 30 characters.");
            }

            if (supplier.Email?.Length > 150)
            {
                throw new ArgumentException("Email cannot exceed 150 characters.");
            }

            if (supplier.Address?.Length > 255)
            {
                throw new ArgumentException(
                    "Address cannot exceed 255 characters."
                );
            }
        }

        private static Supplier MapSupplier(SqlDataReader reader)
        {
            return new Supplier
            {
                SupplierId = reader.GetInt32(0),
                SupplierName = reader.GetString(1),
                Phone = reader.IsDBNull(2) ? null : reader.GetString(2),
                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                Address = reader.IsDBNull(4) ? null : reader.GetString(4),
                IsActive = reader.GetBoolean(5),
                CreatedAt = reader.GetDateTime(6)
            };
        }
    }
}
