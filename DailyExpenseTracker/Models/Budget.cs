using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Models
{
    public class Budget
    {
        public int BudgetID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public DateTime MonthYear { get; set; }
        public decimal BudgetAmount { get; set; }
        public string CategoryName { get; set; } // Not mapped to DB directly, for display
    }
}
