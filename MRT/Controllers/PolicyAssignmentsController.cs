using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRT.Models;
using MRT.ViewModels;
using MRT.DataContexts;
using MRT.Extensions;
using MRT.Services;

namespace MRT.Controllers
{
    public class PolicyAssignmentsController : Controller
    {
        private PolicyAssignmentService _policyAssignmentService;
        private PolicyService _policyService;
        private PolicyTypeService _policyTypeService;
        private CarrierService _carrierService;
        public PolicyAssignmentsController()
        {
            _policyAssignmentService = new PolicyAssignmentService();
            _policyService = new PolicyService();
            _policyTypeService = new PolicyTypeService();
            _carrierService = new CarrierService();
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