using System.Threading.Tasks;
using System.Web.Mvc;
using MRT.Models;
using MRT.ViewModels;
using MRT.Extensions;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers
{
    public class PoliciesController : Controller
    {
        private IPolicyService _policyService;
        private IPolicyTypeService _policyTypeService;

        public PoliciesController()
        {
            _policyService = new PolicyService();
            _policyTypeService = new PolicyTypeService();
        }

        public PoliciesController(IPolicyService policySrv, IPolicyTypeService policyTypeSrv)
        {
            _policyService = policySrv;
            _policyTypeService = policyTypeSrv;
        }

        [HttpGet]
        public async Task<ActionResult> New()
        {
            var viewModel = new PolicyFormViewModel()
            {
                PolicyTypes = await _policyTypeService.GetPolicyTypeListAsync()
            };

            ViewBag.Title = "New Policy";
            return View("PolicyForm", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var policy = await _policyService.GetSinglePolicyAsync(id);
            if (policy.IsNull())
                return HttpNotFound();

            var viewModel = new PolicyFormViewModel(policy)
            {
                PolicyTypes = await _policyTypeService.GetPolicyTypeListAsync()
            };

            ViewBag.Title = "Edit Policy";
            return View("PolicyForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Policy policy)
        {
            if(!ModelState.IsValid)
            {
                var newViewModel = new PolicyFormViewModel(policy)
                {
                    PolicyTypes = await _policyTypeService.GetPolicyTypeListAsync()
                };

                return View("PolicyForm", newViewModel);
            }

            if (policy.Id == 0)
            {
                _policyService.AddPolicy(policy);
                await _policyService.SavePolicyChangesAsync();

                // Redirect so that the new Policy can be assigned to a Carrier
                return RedirectToAction("Create", "PolicyAssignments", new { id = policy.Id });
            }
            else
            {
                var existingPolicy = await _policyService.GetSinglePolicyAsync(policy.Id);

                existingPolicy.Number = policy.Number;
                existingPolicy.StartDate = policy.StartDate;
                existingPolicy.EndDate = policy.EndDate;
                existingPolicy.PolicyTypeId = policy.PolicyTypeId;
                existingPolicy.FundingRate = policy.FundingRate;
                existingPolicy.CollateralRate = policy.CollateralRate;
                existingPolicy.LossRate = policy.LossRate;

                await _policyService.SavePolicyChangesAsync();

                return RedirectToAction("Index", "Policies");
            }
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Policies";
            ViewBag.PoliciesActive = "active";
            return View("Index");
        }
    }
}