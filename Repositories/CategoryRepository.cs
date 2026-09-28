using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class CategoryRepository
    {
        public List<Category> GetAll(string? keyword = null)
        {
            const string sql = """
                SELECT CategoryId, CategoryName, Description, IsActive, CreatedAt
                FROM dbo.Categories
                WHERE @keyword IS NULL
                   OR CategoryName LIKE @keyword
                   OR Description LIKE @keyword
                ORDER BY CategoryName;
                """;

            List<Category> categories = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@keyword", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(keyword)
                    ? DBNull.Value
                    : $"%{keyword.Trim()}%";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(MapCategory(reader));
            }

            return categories;
        }

        public Category? GetById(int categoryId)
        {
            const string sql = """
                SELECT CategoryId, CategoryName, Description, IsActive, CreatedAt
                FROM dbo.Categories
                WHERE CategoryId = @categoryId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            return reader.Read() ? MapCategory(reader) : null;
        }

        public bool Create(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);
            ValidateCategory(category);

            const string sql = """
                INSERT INTO dbo.Categories
                    (CategoryName, Description, IsActive, CreatedAt)
                VALUES
                    (@categoryName, @description, @isActive, SYSUTCDATETIME());
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddParameters(command, category);

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        public bool Update(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);
            ValidateCategory(category);

            const string sql = """
                UPDATE dbo.Categories
                SET CategoryName = @categoryName,
                    Description = @description,
                    IsActive = @isActive
                WHERE CategoryId = @categoryId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddParameters(command, category);
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value = category.CategoryId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        public bool SetActive(int categoryId, bool isActive)
        {
            const string sql = """
                UPDATE dbo.Categories
                SET IsActive = @isActive
                WHERE CategoryId = @categoryId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = isActive;
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        private static void AddParameters(SqlCommand command, Category category)
        {
            command.Parameters.Add("@categoryName", SqlDbType.NVarChar, 100).Value =
                category.CategoryName.Trim();
            command.Parameters.Add("@description", SqlDbType.NVarChar, 255).Value =
                (object?)category.Description ?? DBNull.Value;
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = category.IsActive;
        }

        private static void ValidateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new ArgumentException("Category name is required.");
            }

            if (category.CategoryName.Trim().Length > 100)
            {
                throw new ArgumentException("Category name cannot exceed 100 characters.");
            }

            if (category.Description?.Length > 255)
            {
                throw new ArgumentException(
                    "Description cannot exceed 255 characters."
                );
            }
        }

        private static Category MapCategory(SqlDataReader reader)
        {
            return new Category
            {
                CategoryId = reader.GetInt32(0),
                CategoryName = reader.GetString(1),
                Description = reader.IsDBNull(2)
                    ? null
                    : reader.GetString(2),
                IsActive = reader.GetBoolean(3),
                CreatedAt = reader.GetDateTime(4)
            };
        }
    }
}
