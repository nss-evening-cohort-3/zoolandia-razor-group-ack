using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;

namespace ZoolandiaRazor.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            ZoolandiaRepo my_repo = new ZoolandiaRepo();
            ViewBag.Employees = my_repo.GetAllEmployees();
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepo my_repo = new ZoolandiaRepo();
            ViewBag.Employee = my_repo.GetEmployeeById(id);
            return View();
        }
    }
}
