using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expense_Tracker.Model
{
    public class MonthlyBudget
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public int Month { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public int MonthExpenseLimit { get; set; }
    }
}