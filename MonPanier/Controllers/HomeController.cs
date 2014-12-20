﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{
    public class HomeController : MasterController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "La description de votre application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Votre page de contact.";

            return View();
        }
    }
}