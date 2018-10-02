using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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
        public async Task<ActionResult> New()
        {
            var viewModel = new CarrierFormViewModel()
            {
                StatesNotCovered = await _context.States.ToListAsync()
            };

            ViewBag.Title = "New Carrier";
            return View("CarrierForm", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var carrier = await _context.Carriers.SingleOrDefaultAsync(p => p.Id == id);
            if (carrier == null)
                return HttpNotFound("Carrier does not exist");

            var states = await _context.States.ToListAsync();
            var stateCoverages = await _context.StateCoverages
                .Where(c => c.CarrierId == id)
                .Select(s => s.StateId)
                .ToListAsync();

            var viewModel = new CarrierFormViewModel(carrier)
            {
                StatesCovered = states.Where(s => stateCoverages.Contains(s.Id)).ToList(),
                StatesNotCovered = states.Where(s => !stateCoverages.Contains(s.Id)).ToList()
            };

            ViewBag.Title = "Edit Carrier";
            return View("CarrierForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Carrier carrier)
        {
            if(!ModelState.IsValid)
            {
                var states = await _context.States.ToListAsync();
                var stateCoverages = await _context.StateCoverages
                    .Where(c => c.CarrierId == carrier.Id)
                    .Select(s => s.StateId)
                    .ToListAsync();

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
                var existingCarrier = await _context.Carriers.SingleAsync(c => c.Id == carrier.Id);

                existingCarrier.Name = carrier.Name;
                existingCarrier.BaseRate = carrier.BaseRate;
            }

            await _context.SaveChangesAsync();

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