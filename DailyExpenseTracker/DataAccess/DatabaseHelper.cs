using System.Configuration;

namespace DailyExpenseTracker.DataAccess
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString(string name = "DefaultConnection")
        {
            // Check if the connection string exists
            if (ConfigurationManager.ConnectionStrings[name] == null)
            {
                
                throw new ConfigurationErrorsException($"Connection string '{name}' not found in App.config.");
            }
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        
         
    }
}