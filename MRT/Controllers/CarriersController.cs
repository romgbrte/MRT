using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRT.Models;
using MRT.ViewModels;
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

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new CarrierFormViewModel()
            {
                StatesNotCovered = _context.States.ToList()
            };

            return View("CarrierForm", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var carrier = _context.Carriers.SingleOrDefault(p => p.Id == id);
            if (carrier == null)
                return HttpNotFound("carrier was null");

            var states = _context.States.ToList();
            var stateCoverages = _context.StateCoverages
                .Where(c => c.CarrierId == id)
                .Select(s => s.StateId)
                .ToList();

            var viewModel = new CarrierFormViewModel(carrier)
            {
                StatesCovered = states.Where(s => stateCoverages.Contains(s.Id)).ToList(),
                StatesNotCovered = states.Where(s => !stateCoverages.Contains(s.Id)).ToList()
            };

            return View("CarrierForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Carrier carrier)
        {
            if(!ModelState.IsValid)
            {
                var states = _context.States.ToList();
                var stateCoverages = _context.StateCoverages
                    .Where(c => c.CarrierId == carrier.Id)
                    .Select(s => s.StateId)
                    .ToList();

                var carrierViewModel = new CarrierFormViewModel(carrier)
                {
                    StatesCovered = states.Where(s => stateCoverages.Contains(s.Id)).ToList(),
                    StatesNotCovered = states.Where(s => !stateCoverages.Contains(s.Id)).ToList()
                };

                return View("CarrierForm", carrierViewModel);
            }

            if (carrier.Id == 0)
                _context.Carriers.Add(carrier);
            else
            {
                var existingCarrier = _context.Carriers.Single(c => c.Id == carrier.Id);

                existingCarrier.Name = carrier.Name;
                existingCarrier.BaseRate = carrier.BaseRate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Carriers");
        }

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