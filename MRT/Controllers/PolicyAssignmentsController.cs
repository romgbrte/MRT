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
        public ActionResult Create(int id)
        {
            var policy = _context.Policies.Single(p => p.Id == id);

            if (!ModelState.IsValid)
            {
                var newViewModel = new PolicyFormViewModel(policy)
                {
                    PolicyTypes = _context.PolicyTypes.ToList()
                };

                return RedirectToAction("Edit", "Policies", newViewModel);
            }

            var newPolicyAssignment = new PolicyAssignmentViewModel()
            {
                PolicyId = policy.Id,
                Policy = policy,
                Carriers = _context.Carriers.ToList()
            };

            return View("PolicyAssignmentForm", newPolicyAssignment);
        }

        [HttpPost]
        public ActionResult Save(PolicyAssignment policyAssignment)
        {
            if(!ModelState.IsValid)
            {
                var newViewModel = new PolicyAssignmentViewModel(policyAssignment)
                {
                    Carriers = _context.Carriers.ToList()
                };

                return View("PolicyAssignmentForm", newViewModel);
            }

            var existingPolicyAssignment = _context.PolicyAssignments
                .Where(c => c.CarrierId == policyAssignment.CarrierId)
                .SingleOrDefault(a => a.IsActive == true);
            if(existingPolicyAssignment != null)
                existingPolicyAssignment.IsActive = false;

            _context.PolicyAssignments.Add(policyAssignment);
            _context.SaveChanges();

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