using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository();
            ViewBag.Animals = myRepo.GetAllAnimals();
            return View();
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository();
            ViewBag.Animal = myRepo.GetAnimalById(id);
            return View();
        }

    }
}
