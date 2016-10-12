using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;

namespace ZoolandiaRazor.Controllers
{
    public class HabitatController : Controller
    {
        // GET: Habitat
        public ActionResult Index()
        {
            ZoolandiaRepo my_repo = new ZoolandiaRepo();
            ViewBag.Habitats = my_repo.GetAllHabitats();
            return View();
        }

        // GET: Habitat/Details/5
        public ActionResult Details(int id)
        {
            ZoolandiaRepo my_repo = new ZoolandiaRepo();
            ViewBag.Habitat = my_repo.GetHabitatById(id);
            return View();
        }

    }
}
