using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Expense_Tracker.Model
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        public int CategoryExpenseLimit { get; set; }
        public int CategoryMonth { get; set; }
        public int CategoryYear { get; set; }
        
    }
}