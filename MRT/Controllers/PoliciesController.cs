using System;
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
    [Authorize]
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

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new PolicyFormViewModel()
            {
                PolicyTypes = _context.PolicyTypes.ToList()
            };

            return View("PolicyForm", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var policy = _context.Policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
                return HttpNotFound();

            var viewModel = new PolicyFormViewModel(policy)
            {
                PolicyTypes = _context.PolicyTypes.ToList()
            };

            return View("PolicyForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Policy policy)
        {
            if(!ModelState.IsValid)
            {
                var newViewModel = new PolicyFormViewModel(policy)
                {
                    PolicyTypes = _context.PolicyTypes.ToList()
                };

                return View("PolicyForm", newViewModel);
            }

            if (policy.Id == 0)
            {
                _context.Policies.Add(policy);
                _context.SaveChanges();

                return RedirectToAction("Create", "PolicyAssignments", new { id = policy.Id });
            }
            else
            {
                var existingPolicy = _context.Policies.Single(p => p.Id == policy.Id);

                existingPolicy.Number = policy.Number;
                existingPolicy.StartDate = policy.StartDate;
                existingPolicy.EndDate = policy.EndDate;
                existingPolicy.PolicyTypeId = policy.PolicyTypeId;
                existingPolicy.FundingRate = policy.FundingRate;
                existingPolicy.CollateralRate = policy.CollateralRate;
                existingPolicy.LossRate = policy.LossRate;

                _context.SaveChanges();

                return RedirectToAction("Index", "Policies");
            }
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