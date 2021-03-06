using GrubberDemo.Models;
using GrubberDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrubberDemo.Controllers
{
    public class HomeController : Controller
    {
        EmployeeService service = new EmployeeService();
        public ActionResult Index(int? id)
        {
            var result = service.GetEmployeeById(id);
            return View(result);
        }

        public ActionResult AddEditEmployee(EmployeeViewModel employeeViewModel)
        {
            service.AddEditEmployees(employeeViewModel);
            return RedirectToAction("Index");
        }


        public ActionResult GetAllEmployees(int? id)
        {
            var result = service.GetAllEmployees(id);
            return View("AllEmployees",result);
        }

        public ActionResult DeleteEmployee(int id)
        {
            if (id == null || id <= 0) return RedirectToAction("GetAllEmployees");

            var result = service.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");
        }
    }
}