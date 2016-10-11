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
            ZoolandiaRepo myRepo = new ZoolandiaRepo();
            ViewBag.Animals = myRepo.GetAllAnimals(); 
            return View();
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepo myRepo = new ZoolandiaRepo();
            ViewBag.Animal = myRepo.GetAnimalById(id);
            return View();
        }

    }
}
