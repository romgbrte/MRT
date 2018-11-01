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
using MRT.Extensions;
using MRT.Services;

namespace MRT.Controllers
{
    public class PoliciesController : Controller
    {
        private PolicyService _policyService;
        private PolicyTypeService _policyTypeService;
        public PoliciesController()
        {
            _policyService = new PolicyService();
            _policyTypeService = new PolicyTypeService();
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