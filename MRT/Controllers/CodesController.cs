using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRT.Models;
using MRT.DataContexts;

namespace MRT.Controllers
{
    public class CodesController : Controller
    {
        private DataDb _context;
        public CodesController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Codes
        public ActionResult Index()
        {
            ViewBag.Title = "Codes";
            ViewBag.CodesActive = "active";
            return View();
        }
    }
}