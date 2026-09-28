using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class UserRepository : IUser
    {
        public User? FindByUsername(string username)
        {
            const string sql = """
                SELECT UserId, FullName, Username, PasswordHash, Role,
                       IsActive, CreatedAt, UpdatedAt
                FROM dbo.Users
                WHERE Username = @username;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            return reader.Read()
                ? MapUser(reader, includePasswordHash: true)
                : null;
        }

        public User? GetById(int userId)
        {
            const string sql = """
                SELECT UserId, FullName, Username, Role, IsActive,
                       CreatedAt, UpdatedAt
                FROM dbo.Users
                WHERE UserId = @userId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            return reader.Read()
                ? MapUser(reader, includePasswordHash: false)
                : null;
        }

        public List<User> GetAll()
        {
            const string sql = """
                SELECT UserId, FullName, Username, Role, IsActive,
                       CreatedAt, UpdatedAt
                FROM dbo.Users
                ORDER BY Username;
                """;

            List<User> users = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(MapUser(reader, includePasswordHash: false));
            }

            return users;
        }

        public DataTable Search(string keyword)
        {
            const string sql = """
                SELECT UserId, FullName, Username, Role, IsActive,
                       CreatedAt, UpdatedAt
                FROM dbo.Users
                WHERE Username LIKE @keyword
                   OR FullName LIKE @keyword
                ORDER BY Username;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();

            DataTable results = new();
            connection.Open();
            using SqlDataAdapter adapter = new(sql, connection);
            adapter.SelectCommand.Parameters.Add(
                "@keyword",
                SqlDbType.NVarChar,
                150
            ).Value = $"%{keyword.Trim()}%";
            adapter.Fill(results);
            return results;
        }

        public bool Create(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            ValidateUser(user);

            const string sql = """
                INSERT INTO dbo.Users
                    (FullName, Username, PasswordHash, Role, IsActive,
                     CreatedAt, UpdatedAt)
                VALUES
                    (@fullName, @username, @passwordHash, @role, @isActive,
                     SYSUTCDATETIME(), SYSUTCDATETIME());
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddUserParameters(command, user, user.PasswordHash);

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        public bool Update(User user, string? passwordHash = null)
        {
            ArgumentNullException.ThrowIfNull(user);
            ValidateUser(user);

            const string sql = """
                UPDATE dbo.Users
                SET FullName = @fullName,
                    Username = @username,
                    PasswordHash = CASE
                        WHEN @passwordHash IS NULL THEN PasswordHash
                        ELSE @passwordHash
                    END,
                    Role = @role,
                    IsActive = @isActive,
                    UpdatedAt = SYSUTCDATETIME()
                WHERE UserId = @userId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddUserParameters(command, user, passwordHash);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = user.UserId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        public bool SetActive(int userId, bool isActive)
        {
            const string sql = """
                UPDATE dbo.Users
                SET IsActive = @isActive,
                    UpdatedAt = SYSUTCDATETIME()
                WHERE UserId = @userId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = isActive;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        private static void AddUserParameters(
            SqlCommand command,
            User user,
            string? passwordHash
        )
        {
            command.Parameters.Add("@fullName", SqlDbType.NVarChar, 150).Value =
                user.FullName.Trim();
            command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value =
                user.Username.Trim();
            command.Parameters.Add("@passwordHash", SqlDbType.NVarChar, 255).Value =
                (object?)passwordHash ?? DBNull.Value;
            command.Parameters.Add("@role", SqlDbType.NVarChar, 20).Value =
                user.Role.ToString();
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = user.IsActive;
        }

        private static void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                throw new ArgumentException("Full name is required.", nameof(user));
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new ArgumentException("Username is required.", nameof(user));
            }
        }

        private static User MapUser(
            SqlDataReader reader,
            bool includePasswordHash
        )
        {
            int passwordColumn = includePasswordHash ? 3 : -1;
            int roleColumn = includePasswordHash ? 4 : 3;
            int activeColumn = includePasswordHash ? 5 : 4;
            int createdColumn = includePasswordHash ? 6 : 5;
            int updatedColumn = includePasswordHash ? 7 : 6;

            string roleText = reader.GetString(roleColumn);
            if (!Enum.TryParse(roleText, ignoreCase: true, out UserRole role))
            {
                throw new InvalidOperationException(
                    $"Unsupported user role '{roleText}'."
                );
            }

            return new User
            {
                UserId = reader.GetInt32(0),
                FullName = reader.GetString(1),
                Username = reader.GetString(2),
                PasswordHash = includePasswordHash
                    ? reader.GetString(passwordColumn)
                    : string.Empty,
                Role = role,
                IsActive = reader.GetBoolean(activeColumn),
                CreatedAt = reader.GetDateTime(createdColumn),
                UpdatedAt = reader.GetDateTime(updatedColumn)
            };
        }
    }
}
