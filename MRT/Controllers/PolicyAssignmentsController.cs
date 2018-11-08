using System.Threading.Tasks;
using System.Web.Mvc;
using MRT.Models;
using MRT.ViewModels;
using MRT.Extensions;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers
{
    public class PolicyAssignmentsController : Controller
    {
        private IPolicyService _policyService;
        private IPolicyTypeService _policyTypeService;
        private ICarrierService _carrierService;
        private IPolicyAssignmentService _policyAssignmentService;

        public PolicyAssignmentsController()
        {
            _policyService = new PolicyService();
            _policyTypeService = new PolicyTypeService();
            _carrierService = new CarrierService();
            _policyAssignmentService = new PolicyAssignmentService();
        }

        public PolicyAssignmentsController(IPolicyService policySrv, IPolicyTypeService policyTypeSrv, 
            ICarrierService carrierSrv, IPolicyAssignmentService policyAssignmentSrv)
        {
            _policyService = policySrv;
            _policyTypeService = policyTypeSrv;
            _carrierService = carrierSrv;
            _policyAssignmentService = policyAssignmentSrv;
        }

        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            var policy = await _policyService.GetSinglePolicyAsync(id);

            if (!ModelState.IsValid)
            {
                var newViewModel = new PolicyFormViewModel(policy)
                {
                    PolicyTypes = await _policyTypeService.GetPolicyTypeListAsync()
                };

                return RedirectToAction("Edit", "Policies", newViewModel);
            }

            var newPolicyAssignment = new PolicyAssignmentViewModel()
            {
                PolicyId = policy.Id,
                Policy = policy,
                Carriers = await _carrierService.GetCarrierListAsync()
            };

            return View("PolicyAssignmentForm", newPolicyAssignment);
        }

        [HttpPost]
        public async Task<ActionResult> Save(PolicyAssignment policyAssignment)
        {
            if(!ModelState.IsValid)
            {
                var newViewModel = new PolicyAssignmentViewModel(policyAssignment)
                {
                    Carriers = await _carrierService.GetCarrierListAsync()
                };

                return View("PolicyAssignmentForm", newViewModel);
            }

            var existingPolicyAssignment = await _policyAssignmentService
                .GetSingleActivePolicyAssignmentAsync(policyAssignment.CarrierId);

            if(existingPolicyAssignment.IsNotNull())
                existingPolicyAssignment.IsActive = false;

            _policyAssignmentService.AddPolicyAssignment(policyAssignment);
            await _policyAssignmentService.SavePolicyAssignmentChangesAsync();

            return RedirectToAction("Index", "Policies");
        }
    }
}