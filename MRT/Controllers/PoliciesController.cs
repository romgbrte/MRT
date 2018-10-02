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

namespace MRT.Controllers
{
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
        public async Task<ActionResult> New()
        {
            var viewModel = new PolicyFormViewModel()
            {
                PolicyTypes = await _context.PolicyTypes.ToListAsync()
            };

            ViewBag.Title = "New Policy";
            return View("PolicyForm", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.Id == id);
            if (policy == null)
                return HttpNotFound();

            var viewModel = new PolicyFormViewModel(policy)
            {
                PolicyTypes = await _context.PolicyTypes.ToListAsync()
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
                    PolicyTypes = await _context.PolicyTypes.ToListAsync()
                };

                return View("PolicyForm", newViewModel);
            }

            if (policy.Id == 0)
            {
                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();

                return RedirectToAction("Create", "PolicyAssignments", new { id = policy.Id });
            }
            else
            {
                var existingPolicy = await _context.Policies.SingleAsync(p => p.Id == policy.Id);

                existingPolicy.Number = policy.Number;
                existingPolicy.StartDate = policy.StartDate;
                existingPolicy.EndDate = policy.EndDate;
                existingPolicy.PolicyTypeId = policy.PolicyTypeId;
                existingPolicy.FundingRate = policy.FundingRate;
                existingPolicy.CollateralRate = policy.CollateralRate;
                existingPolicy.LossRate = policy.LossRate;

                await _context.SaveChangesAsync();

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