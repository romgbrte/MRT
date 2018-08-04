using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRT.Models;
using MRT.DataContexts;

namespace MRT.Controllers
{
    public class CarriersController : Controller
    {
        private DataDb _context;
        public CarriersController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Carriers
        public ActionResult Index()
        {
            ViewBag.Title = "Carriers";
            ViewBag.CarriersActive = "active";
            return View();
        }
    }
}