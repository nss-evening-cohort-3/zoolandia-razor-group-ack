﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZoolandiaRazor.Controllers
{
    public class HabitatController : Controller
    {
        // GET: Habitat
        public ActionResult Index()
        {
            ViewBag.Message = "Woo-hoooo!  It's habitat time!";
            return View();
        }

        // GET: Habitat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
