using Expense_Tracker.Model;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Expense_Tracker.Controllers
{
    public class CategoryController : Controller
    {
        readonly
        GContext cContext = new GContext();
        [Route("Category")]
        // GET: Category
        public ActionResult AddCategory()
        {
            return View();
        }

        [Route("AddCategory")]
        [HttpPost]
        // GET: Category
        public ActionResult AddCategory(Category c)
        {
            cContext.Categories.Add(c);

            int b = cContext.SaveChanges();
            if (b > 0)
            {
                ViewBag.InsertMessage = "<script>alert('Data Inserted')</script>";
            }
            else
            {
                ViewBag.InsertMessage = "<script>alert('Data Is Not Inserted')</script>";
            }
            return RedirectToAction("ViewCategory");
        }

        [Route("ViewCategory")]
        public ActionResult ViewCategory()
        {
            var data = cContext.Categories.ToList();
            return View(data);
        }

        [Route("CategoryEdit")]
        public ActionResult EditCategory(int id)
        {
           var row = cContext.Categories.Where(model=>model.CategoryID == id).ToList();  
            return View(row);
        }

        [Route("SaveCategory")]
        [HttpPost]
        public ActionResult EditCategory(Category D)
        {
            cContext.Entry(D).State=EntityState.Modified;
            int b = cContext.SaveChanges();
            if (b > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Data Updated')</script>";  
                return RedirectToAction("ViewCategory");
            }
            else
            {
                TempData["UpdateMessage"] = "<script>alert('Data Not Updated')</script>";
            }
            return View();
        }

        [Route("DelCategory")]
        public ActionResult DeleteCategory(int id)
        {
            if (id > 0)
            {
                var CategoryDelete = cContext.Categories.Where(model => model.CategoryID == id).FirstOrDefault();
                if (CategoryDelete != null)
                {
                    cContext.Entry(CategoryDelete).State = EntityState.Deleted;
                    int a = cContext.SaveChanges();
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
            return RedirectToAction("ViewCategory");

        }
    }
}