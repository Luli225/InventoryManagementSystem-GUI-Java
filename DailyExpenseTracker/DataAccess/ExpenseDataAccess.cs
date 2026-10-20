using DailyExpenseTracker.Models; // For Expense and Category models
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq; // For potential List operations if needed

namespace DailyExpenseTracker.DataAccess
{
    public class ExpenseDataAccess
    {
        private readonly string _connectionString;

        public ExpenseDataAccess()
        {
            _connectionString = DatabaseHelper.GetConnectionString();
        }

        
        public int AddExpense(Expense expense)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO Expenses (UserID, CategoryID, ExpenseDate, Amount, Description, DateRecorded)
                    VALUES (@UserID, @CategoryID, @ExpenseDate, @Amount, @Description, GETDATE());
                    SELECT SCOPE_IDENTITY();"; // Use GETDATE() for DateRecorded

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", expense.UserID);
                    command.Parameters.AddWithValue("@CategoryID", expense.CategoryID);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Description", (object)expense.Description ?? DBNull.Value);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0; // Indicates failure
        }

        
        public bool UpdateExpense(Expense expense)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE Expenses
                    SET CategoryID = @CategoryID,
                        ExpenseDate = @ExpenseDate,
                        Amount = @Amount,
                        Description = @Description
                        -- DateRecorded could be updated too if desired: , DateRecorded = GETDATE()
                    WHERE ExpenseID = @ExpenseID AND UserID = @UserID;"; // Ensure user owns the expense

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", expense.CategoryID);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Description", (object)expense.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ExpenseID", expense.ExpenseID);
                    command.Parameters.AddWithValue("@UserID", expense.UserID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        
        public bool DeleteExpense(int expenseId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Expenses WHERE ExpenseID = @ExpenseID AND UserID = @UserID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExpenseID", expenseId);
                    command.Parameters.AddWithValue("@UserID", userId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        
        public List<Expense> GetExpenses(int userId, DateTime? startDate, DateTime? endDate, int? categoryId)
        {
            List<Expense> expenses = new List<Expense>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Base query with JOIN to get CategoryName
                string query = @"
                    SELECT e.ExpenseID, e.UserID, e.CategoryID, c.CategoryName,
                           e.ExpenseDate, e.Amount, e.Description, e.DateRecorded
                    FROM Expenses e
                    JOIN Categories c ON e.CategoryID = c.CategoryID
                    WHERE e.UserID = @UserID";

                // Dynamically add conditions for filters
                if (startDate.HasValue)
                {
                    query += " AND e.ExpenseDate >= @StartDate";
                }
                if (endDate.HasValue)
                {
                    query += " AND e.ExpenseDate <= @EndDate";
                }
                if (categoryId.HasValue && categoryId.Value > 0) // Assuming 0 means "all categories"
                {
                    query += " AND e.CategoryID = @CategoryIDFilter";
                }
                query += " ORDER BY e.ExpenseDate DESC, e.ExpenseID DESC;"; // Or your preferred order

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    if (startDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.Value.Date); // Use .Date to ignore time part
                    }
                    if (endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@EndDate", endDate.Value.Date);
                    }
                    if (categoryId.HasValue && categoryId.Value > 0)
                    {
                        command.Parameters.AddWithValue("@CategoryIDFilter", categoryId.Value);
                    }

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(new Expense
                            {
                                ExpenseID = Convert.ToInt32(reader["ExpenseID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["CategoryName"].ToString(), // From the JOIN
                                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                                Amount = Convert.ToDecimal(reader["Amount"]),
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                DateRecorded = Convert.ToDateTime(reader["DateRecorded"])
                            });
                        }
                    }
                }
            }
            return expenses;
        }

        
        public Expense GetExpenseById(int expenseId, int userId)
        {
            Expense expense = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT e.ExpenseID, e.UserID, e.CategoryID, c.CategoryName,
                           e.ExpenseDate, e.Amount, e.Description, e.DateRecorded
                    FROM Expenses e
                    JOIN Categories c ON e.CategoryID = c.CategoryID
                    WHERE e.ExpenseID = @ExpenseID AND e.UserID = @UserID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExpenseID", expenseId);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            expense = new Expense
                            {
                                ExpenseID = Convert.ToInt32(reader["ExpenseID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["CategoryName"].ToString(),
                                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                                Amount = Convert.ToDecimal(reader["Amount"]),
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                DateRecorded = Convert.ToDateTime(reader["DateRecorded"])
                            };
                        }
                    }
                }
            }
            return expense;
        }

        
        public decimal GetTotalExpenses(int userId, DateTime startDate, DateTime endDate, int? categoryId)
        {
            decimal total = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT ISNULL(SUM(e.Amount), 0)
                    FROM Expenses e
                    WHERE e.UserID = @UserID
                      AND e.ExpenseDate >= @StartDate
                      AND e.ExpenseDate <= @EndDate";

                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query += " AND e.CategoryID = @CategoryIDFilter";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
                    command.Parameters.AddWithValue("@EndDate", endDate.Date);
                    if (categoryId.HasValue && categoryId.Value > 0)
                    {
                        command.Parameters.AddWithValue("@CategoryIDFilter", categoryId.Value);
                    }

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        total = Convert.ToDecimal(result);
                    }
                }
            }
            return total;
        }
    }
}