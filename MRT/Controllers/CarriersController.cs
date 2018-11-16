using System.Threading.Tasks;
using System.Linq;
using System.Web.Mvc;
using MRT.Models;
using MRT.ViewModels;
using MRT.Extensions;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers
{
    public class CarriersController : Controller
    {
        private ICarrierService _carrierService;
        private IStateService _stateService;
        private IStateCoverageService _stateCoverageService;

        public CarriersController()
        {
            _carrierService = new CarrierService();
            _stateService = new StateService();
            _stateCoverageService = new StateCoverageService();
        }

        public CarriersController(ICarrierService carrierSrv, 
            IStateService stateSrv, IStateCoverageService stateCoverageSrv)
        {
            _carrierService = carrierSrv;
            _stateService = stateSrv;
            _stateCoverageService = stateCoverageSrv;
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

            var stateCoverages = await _stateCoverageService.GetListOfStateCoveragesByCarrierAsync(id);
            // Extract only the State.Ids in order to build the State lists in the ViewModel
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

                var stateCoverages = await _stateCoverageService.GetListOfStateCoveragesByCarrierAsync(carrier.Id);
                // Extract only the State.Ids in order to build the State lists in the ViewModel
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