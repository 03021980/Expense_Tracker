using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;   
using System.Linq;
using System.Web;

namespace Expense_Tracker.Model
{
    public class Expense
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public string ExpenseTitle { get; set; }
        public string ExpenseDescription { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public int ExpenseAmount { get; set; }
        public int ExpenseCategory { get; set; }
    }
}