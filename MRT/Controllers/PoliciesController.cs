using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRT.Models;
using MRT.DataContexts;

namespace MRT.Controllers
{
    public class PoliciesController : Controller
    {
        private DataDb _context;
        public PoliciesController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Policies
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Policies";
            ViewBag.PoliciesActive = "active";
            return View();
        }
    }
}