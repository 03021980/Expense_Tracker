using Expense_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expense_Tracker.Controllers
{
    public class MonthlyBudgetController : Controller
    {
        readonly
        GContext mContext = new GContext();
        [Route("MonthBudget")]
        // GET: MonthlyBudget
        public ActionResult AddMonthlyBudget()
        {
            return View();
        }
        [HttpPost]
        [Route("AddMonthBudget")]
        public ActionResult AddMonthlyBudget(MonthlyBudget m)
        {
            mContext.MonthlyBudgets.Add(m);

            int b = mContext.SaveChanges();
            if (b > 0)
            {
                ViewBag.InsertMessage = "<script>alert('Data Inserted')</script>";
            }
            else
            {
                ViewBag.InsertMessage = "<script>alert('Data Is Not Inserted')</script>";
            }
            return RedirectToAction("ViewMonthlyBudget");
        }

        [Route("ViewBudget")]
        public ActionResult ViewMonthlyBudget()
        {
            var data = mContext.MonthlyBudgets.ToList();
            return View(data);
        }

        [Route("DelLimit")]
        public ActionResult DeleteLimit(int id)
        {
            if (id > 0)
            {
                var LimitDelete = mContext.MonthlyBudgets.Where(model => model.ID == id).FirstOrDefault();
                if (LimitDelete != null)
                {
                    mContext.Entry(LimitDelete).State = EntityState.Deleted;
                    int a = mContext.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted.')";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Found.')";
                    }
                }
            }
            return RedirectToAction("ViewMonthlyBudget");
        }

        [Route("BudgetEdit")]
        public ActionResult EditBudget(int id)
        {
            var row = mContext.MonthlyBudgets.Where(model => model.ID == id).FirstOrDefault();
            return View(row);
        }

        [Route("SaveBudget")]
        [HttpPost]
        public ActionResult EditBudget(MonthlyBudget m)
        {
            mContext.Entry(m).State = EntityState.Modified;
            int a = mContext.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Data Updated')</script>";
                return RedirectToAction("ViewBudget");
            }
            else
            {
                TempData["UpdateMessage"] = "<script>alert('Data Not Updated')</script>";
            }
            return View();
        }
    }
}