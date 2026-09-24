using DotNetEnv;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using MartManagementSystem.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart_Management_System.Repositories
{
    public class UserRepository : IUser

    {
        
        
        string? connString = Environment.GetEnvironmentVariable("DB_CONNECTION");
        public void ConnectDB()
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show(
                    "Connecting to database successfully",
                    "Database connecting succuss",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Connecting to database failed",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

            }
            finally
            {
                conn.Close();
            }

        }

        public bool delete(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string sql = "DELETE FROM users WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int deletedUser = 0;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                deletedUser = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete user id : {id} failed" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return deletedUser > 0;
        }

        public User? findByName(string name)
        {
            using SqlConnection conn = new(connString);

            string sql = @"
                            SELECT id, username, password, role, isActive
                            FROM users
                            WHERE username = @name";

            using SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@name", name);

            try
            {
                conn.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2),

                        role = Enum.Parse<UserRole>(
                            reader.GetString(3),
                            ignoreCase: true
                        ),

                        isActive = reader.GetBoolean(4)
                    };
                    return user;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"User does not existing\n{ex.Message}"
                );
            }

            return null;
        }

        public List<User> getAll()
        {
            List<User> users = new List<User>();
            using SqlConnection conn = new SqlConnection(connString);
            string sql = "SELECT id, username, password, role, isActive FROM users";
            using SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User
                    {
                        id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2),
                        role = Enum.Parse<UserRole>(reader.GetString(3)),
                        isActive = reader.GetBoolean(4)
                    };
                    users.Add(user);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Loading users failed\n" + ex.Message);
            }
            return users;
        }

        public User? getById(int id)
        {
            using SqlConnection conn = new SqlConnection(connString);
            string sql = @"SELECT id, username, password,role,isActive FROM users WHERE id = @id";
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                User? user = null;
                if (reader.Read())
                {
                    user = new User
                    {
                        id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2),
                        role = Enum.Parse<UserRole>(reader.GetString(3)),
                        isActive = reader.GetBoolean(4)
                    };
                }
                return user;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loading user id: {id} failed");
            }
            return null;
        }

        public bool save(User user)
        {
            using SqlConnection conn = new SqlConnection(connString);
            string sql = @"INSERT INTO users(username,password,role,isActive) VALUES
            (@username,@password,@role,@isActive)
            ";
            using SqlCommand cmd = new SqlCommand(sql, conn);
            int rows = 0;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@role", user.role.ToString());
                cmd.Parameters.AddWithValue("@isActive", user.isActive);

                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            return rows > 0;
        }

        public bool update(User user)
        {
            using SqlConnection conn = new SqlConnection(connString);
            string sql = @"UPDATE users SET 
                username = @name,
                password = @pw,
                role     = @role,
                isActive = @isActive
                WHERE id = @id;
            ";
            using SqlCommand cmd = new SqlCommand(sql, conn);
            int updated = 0;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@id", user.id);
                cmd.Parameters.AddWithValue("@name", user.username);
                cmd.Parameters.AddWithValue("@pw", user.password);
                cmd.Parameters.AddWithValue("@role", user.role.ToString());
                cmd.Parameters.AddWithValue("@isActive", user.isActive);


                updated = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update user failed\n" + ex.Message);
            }
            return updated > 0;
        }

        public DataTable search(string keyword)
        {
            SqlConnection conn = new SqlConnection(connString);
            string sql = "SELECT id, username, password, role, isActive FROM users WHERE username LIKE @keyword";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
