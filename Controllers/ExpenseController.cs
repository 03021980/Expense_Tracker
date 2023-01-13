using Expense_Tracker.Model;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace Expense_Tracker.Controllers
{
    public class ExpenseController: Controller
    {
        readonly
        GContext gContext = new GContext();
        [Route("Expense")]
        public ActionResult AddExpense()
        {
            return View();
        }

        [Route("AddExpense")]
        [HttpPost]
        public ActionResult AddExpense(Expense e)
        {
            gContext.Expenses.Add(e);
            
            int a = gContext.SaveChanges();
            if (a > 0)
            {
                TempData["InsertMessage"] = "<script>alert('Expense Inserted')</script>";
                return RedirectToAction("ViewExpense");

            }
            else
            {
                TempData["InsertMessage"] = "<script>alert('Expense Not Inserted')</script>";
            }
            return View();
        }

        [Route("ExpenseEdit")]
        public ActionResult EditExpense(int id)
        {
            var row = gContext.Expenses.Where(model=>model.ID == id).FirstOrDefault();
            return View(row);
        }

        [Route("SaveExpense")]
        [HttpPost]
        public ActionResult EditExpense(Expense C)
        {
            gContext.Entry(C).State=EntityState.Modified;
            int a = gContext.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Data Updated')</script>";
                return RedirectToAction("ViewExpense");
            }
            else
            {
                TempData["UpdateMessage"] = "<script>alert('Data Not Updated')</script>";
            }
            return View();
        }


        [Route("ExpenseView")]
        public ActionResult ViewExpense()
        {
            var data = gContext.Expenses.ToList();
            return View(data);
        }

        [Route("DeleteView")]
        public ActionResult DeleteExpense(int id)
        {
            if(id > 0)
            {
                var ExpenseDelete = gContext.Expenses.Where(model => model.ID == id).FirstOrDefault();
                if(ExpenseDelete != null)
                {
                    gContext.Entry(ExpenseDelete).State = EntityState.Deleted;
                    int a = gContext.SaveChanges();
                    if(a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted.')";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Found.')";
                    }
                }
            }
            return RedirectToAction("ExpenseView");
            
        }

    }
    
}