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
    public class PolicyAssignmentsController : Controller
    {
        private DataDb _context;
        public PolicyAssignmentsController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            var policy = await _context.Policies.SingleAsync(p => p.Id == id);

            if (!ModelState.IsValid)
            {
                var newViewModel = new PolicyFormViewModel(policy)
                {
                    PolicyTypes = await _context.PolicyTypes.ToListAsync()
                };

                return RedirectToAction("Edit", "Policies", newViewModel);
            }

            var newPolicyAssignment = new PolicyAssignmentViewModel()
            {
                PolicyId = policy.Id,
                Policy = policy,
                Carriers = await _context.Carriers.ToListAsync()
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
                    Carriers = await _context.Carriers.ToListAsync()
                };

                return View("PolicyAssignmentForm", newViewModel);
            }

            var existingPolicyAssignment = await _context.PolicyAssignments
                .Where(c => c.CarrierId == policyAssignment.CarrierId)
                .SingleOrDefaultAsync(a => a.IsActive == true);
            if(existingPolicyAssignment != null)
                existingPolicyAssignment.IsActive = false;

            _context.PolicyAssignments.Add(policyAssignment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Policies");
        }

        // GET: PolicyAssignments
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}