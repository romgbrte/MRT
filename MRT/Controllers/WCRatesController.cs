﻿using System.Web.Mvc;

namespace MRT.Controllers
{
    public class WCRatesController : Controller
    {
        // GET: WCRates
        public ActionResult Index()
        {
            ViewBag.Title = "Worker's Compensation Rates";
            ViewBag.WCRatesActive = "active";
            return View("Index");
        }
    }
}