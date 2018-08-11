﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRT.Controllers
{
    public class PoliciesController : Controller
    {
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