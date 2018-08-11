using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRT.Controllers
{
    public class CarriersController : Controller
    {
        // GET: Carriers
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Carriers";
            ViewBag.CarriersActive = "active";
            return View();
        }
    }
}