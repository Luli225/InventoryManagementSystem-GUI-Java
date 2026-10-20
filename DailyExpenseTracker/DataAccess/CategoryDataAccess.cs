using DailyExpenseTracker.Models; // To use the Category model
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DailyExpenseTracker.DataAccess
{
    public class CategoryDataAccess
    {
        private readonly string _connectionString;

        public CategoryDataAccess()
        {
            _connectionString = DatabaseHelper.GetConnectionString();
        }

        
        public int AddCategory(Category category)
        {
            // Check for duplicate category name for the same user
            if (CategoryNameExistsForUser(category.UserID, category.CategoryName))
            {
                return -1; // Indicates duplicate
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO Categories (UserID, CategoryName)
                    VALUES (@UserID, @CategoryName);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", category.UserID);
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                   

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0; 
        }

        
        public bool UpdateCategory(Category category)
        {
            // Check if the new category name already exists for this user, excluding the current category being edited
            string checkQuery = "SELECT COUNT(1) FROM Categories WHERE UserID = @UserID AND CategoryName = @CategoryName AND CategoryID != @CategoryID";
            using (SqlConnection conCheck = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conCheck))
                {
                    cmdCheck.Parameters.AddWithValue("@UserID", category.UserID);
                    cmdCheck.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmdCheck.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    conCheck.Open();
                    if ((int)cmdCheck.ExecuteScalar() > 0)
                    {
                        return false; // Duplicate name found for this user
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE Categories
                    SET CategoryName = @CategoryName
                    WHERE CategoryID = @CategoryID AND UserID = @UserID;"; // Ensure user owns the category

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    command.Parameters.AddWithValue("@UserID", category.UserID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        
        public bool DeleteCategory(int categoryId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                
                string checkUsageQuery = @"
                    SELECT CASE WHEN EXISTS (SELECT 1 FROM Expenses WHERE CategoryID = @CategoryID AND UserID = @UserID)
                                  OR EXISTS (SELECT 1 FROM Budgets WHERE CategoryID = @CategoryID AND UserID = @UserID)
                           THEN 1 ELSE 0 END";
                using (SqlCommand checkCmd = new SqlCommand(checkUsageQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                    checkCmd.Parameters.AddWithValue("@UserID", userId); // Ensure we only check user's own items
                    connection.Open();
                    if ((int)checkCmd.ExecuteScalar() == 1)
                    {
                        
                        connection.Close(); 
                        return false; 
                    }
                    connection.Close(); // Close before reopening for delete, or reuse connection if logic allows
                }


                // If not in use, proceed with deletion
                string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID AND UserID = @UserID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.Parameters.AddWithValue("@UserID", userId);

                    connection.Open(); // Re-open connection or ensure it's open
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        
        public List<Category> GetCategoriesByUserId(int userId)
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT CategoryID, UserID, CategoryName FROM Categories WHERE UserID = @UserID ORDER BY CategoryName ASC;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                CategoryName = reader["CategoryName"].ToString()
                                // Populate other fields if any
                            });
                        }
                    }
                }
            }
            return categories;
        }

       
        public bool CategoryNameExistsForUser(int userId, string categoryName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM Categories WHERE UserID = @UserID AND CategoryName = @CategoryName;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        
        public Category GetCategoryById(int categoryId, int userId)
        {
            Category category = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT CategoryID, UserID, CategoryName FROM Categories WHERE CategoryID = @CategoryID AND UserID = @UserID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                CategoryName = reader["CategoryName"].ToString()
                            };
                        }
                    }
                }
            }
            return category;
        }
    }
}