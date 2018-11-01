using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Mvc;
using MRT.Models;
using MRT.ViewModels;
using MRT.Extensions;
using MRT.Services;

namespace MRT.Controllers
{
    public class CarriersController : Controller
    {
        private CarrierService _carrierService;
        private StateService _stateService;
        private StateCoverageService _stateCoverageService;
        public CarriersController()
        {
            _carrierService = new CarrierService();
            _stateService = new StateService();
            _stateCoverageService = new StateCoverageService();
        }

        [HttpGet]
        public async Task<ActionResult> New()
        {
            var viewModel = new CarrierFormViewModel()
            {
                StatesNotCovered = await _stateService.GetListOfStatesAsync()
            };

            ViewBag.Title = "New Carrier";
            return View("CarrierForm", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var carrier = await _carrierService.GetSingleCarrierAsync(id);
            if (carrier.IsNull())
                return HttpNotFound("Carrier does not exist");

            var states = await _stateService.GetListOfStatesAsync();

            var stateCoverages = await _stateCoverageService.GetListOfStateCoveragesAsync(id);
            var stateCoverageIds = stateCoverages.Select(s => s.StateId);

            var viewModel = new CarrierFormViewModel(carrier)
            {
                StatesCovered = states.Where(s => stateCoverageIds.Contains(s.Id)).ToList(),
                StatesNotCovered = states.Where(s => !stateCoverageIds.Contains(s.Id)).ToList()
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
                var states = await _stateService.GetListOfStatesAsync();

                var stateCoverages = await _stateCoverageService.GetListOfStateCoveragesAsync(carrier.Id);
                var stateCoverageIds = stateCoverages.Select(s => s.StateId);

                var carrierViewModel = new CarrierFormViewModel(carrier)
                {
                    StatesCovered = states.Where(s => stateCoverageIds.Contains(s.Id)).ToList(),
                    StatesNotCovered = states.Where(s => !stateCoverageIds.Contains(s.Id)).ToList()
                };

                return View("CarrierForm", carrierViewModel);
            }

            if (carrier.Id == 0)
                _carrierService.AddCarrier(carrier);
            else
            {
                var existingCarrier = await _carrierService.GetSingleCarrierAsync(carrier.Id);

                existingCarrier.Name = carrier.Name;
                existingCarrier.BaseRate = carrier.BaseRate;
            }

            await _carrierService.SaveCarrierChangesAsync();

            return RedirectToAction("Index", "Carriers");
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Carriers";
            ViewBag.CarriersActive = "active";
            return View("Index");
        }
    }
}