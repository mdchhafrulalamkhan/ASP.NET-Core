using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // Start code for this project - ~RJ~

        DatabaseContext db = new DatabaseContext();


        // Start code for Index page - ~RJ~

        public IActionResult Index()
        {
            List<Employee> data = db.Employee.ToList();
            return View(data);
        }

        // End code for Index page - ~RJ~


        // Start code for Create page - ~RJ~
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            db.Employee.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // End code for Create page - ~RJ~


        // Start code for Edit and Update Action - ~RJ~
        public IActionResult Update(int Id)
        {
            Employee model = db.Employee.Find(Id);
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Update(Employee model)
        {
            db.Employee.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // End code for Edit and Update Action - ~RJ~


        // Start code for Delete Action - ~RJ~

        public IActionResult Delete(int Id)
        {
            Employee RJ = db.Employee.Find(Id);
            if (RJ != null)
            {
                db.Employee.Remove(RJ);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // End code for Delete Action - ~RJ~
    }
}