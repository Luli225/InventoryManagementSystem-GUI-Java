using DailyExpenseTracker.Models; // To use the User model
using System;
using System.Data;
using System.Data.SqlClient; // For SQL Server interaction
using System.Security.Cryptography; // For password hashing
using System.Text; // For encoding strings to bytes

namespace DailyExpenseTracker.DataAccess
{
    public class UserDataAccess
    {
        private readonly string _connectionString;

        public UserDataAccess()
        {
            _connectionString = DatabaseHelper.GetConnectionString();
        }

        // --- Password Hashing and Verification ---

        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 20; // SHA1
        private const int Iterations = 10000; // Number of iterations for PBKDF2

        
        private string HashPassword(string password, out byte[] salt)
        {
            // Generate a cryptographic random salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                salt = new byte[SaltSize];
                rng.GetBytes(salt);
            }

            // Hash the password and salt with PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hash); // Store hash as Base64 string
            }
        }

        
        public bool VerifyPassword(string password, string saltBase64, string hashedPasswordBase64)
        {
            byte[] salt = Convert.FromBase64String(saltBase64);
            byte[] storedHash = Convert.FromBase64String(hashedPasswordBase64);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] testHash = pbkdf2.GetBytes(HashSize);
                // Compare the two hashes byte by byte
                if (testHash.Length != storedHash.Length) return false;
                for (int i = 0; i < testHash.Length; i++)
                {
                    if (testHash[i] != storedHash[i]) return false;
                }
                return true;
            }
        }

        // --- User CRUD Operations ---

       
        public bool UsernameExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        
        public int RegisterUser(User user, string password)
        {
            if (UsernameExists(user.Username))
            {
                // Username already exists, cannot register
                return -1; // Or throw an exception: throw new ArgumentException("Username already exists.");
            }

            byte[] saltBytes;
            string hashedPassword = HashPassword(password, out saltBytes);
            string saltBase64 = Convert.ToBase64String(saltBytes); // Store salt as Base64 string

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO Users (Username, PasswordHash, Salt, Email, FirstName, LastName, DateCreated)
                    VALUES (@Username, @PasswordHash, @Salt, @Email, @FirstName, @LastName, @DateCreated);
                    SELECT SCOPE_IDENTITY();"; // Returns the ID of the newly inserted row

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@Salt", saltBase64);
                    command.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FirstName", (object)user.FirstName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", (object)user.LastName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                    connection.Open();
                    // ExecuteScalar is used here because we are returning a single value (the new ID)
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1; // Should not happen if insert was successful and SCOPE_IDENTITY() works
                }
            }
        }

        
        public User GetUserByUsername(string username)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT UserID, Username, PasswordHash, Salt, Email, FirstName, LastName, DateCreated FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Salt = reader["Salt"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null,
                                LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                }
            }
            return user;
        }
    }
}