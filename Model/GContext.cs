using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Expense_Tracker.Model
{
    public class GContext: DbContext
    {
       public DbSet<Expense> Expenses { get; set; }
       
       public DbSet<Category> Categories { get; set; }

       public DbSet<MonthlyBudget> MonthlyBudgets { get; set;} 
    }
}