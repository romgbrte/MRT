using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRT.Controllers
{
    public class CodesController : Controller
    {
        // GET: Codes
        public ActionResult Index()
        {
            ViewBag.Title = "Codes";
            ViewBag.CodesActive = "active";
            return View();
        }
    }
}