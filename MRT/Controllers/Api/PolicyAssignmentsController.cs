using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MRT.Models;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper;

namespace MRT.Controllers.Api
{
    public class PolicyAssignmentsController : ApiController
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

        // GET /api/policyassignments
        [HttpGet]
        public IHttpActionResult GetPolicyAssignments()
        {
            var policyAssignments = _context.PolicyAssignments
                .Include(c => c.Carrier)
                .Include(p => p.Policy)
                .ToList();

            return Ok(policyAssignments.Select(Mapper.Map<PolicyAssignment, PolicyAssignmentDto>));
        }

        // GET /api/policyassignments/#
        [HttpGet]
        public IHttpActionResult GetPolicyAssignment(int id)
        {
            var policyAssignment = _context.PolicyAssignments
                .Include(c => c.Carrier)
                .Single(p => p.PolicyId == id);

            return Ok(Mapper.Map<PolicyAssignment, PolicyAssignmentDto>(policyAssignment));
        }

        // POST /api/policyassignments
        [Authorize]
        [HttpPost]
        public IHttpActionResult CreatePolicyAssignment(PolicyAssignmentDto policyAssignmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("There was an error with carrier assignment");

            var currentPolicyAssignment = _context.PolicyAssignments
                .Where(c => c.CarrierId == policyAssignmentDto.CarrierId)
                .Single(a => a.IsActive);
            currentPolicyAssignment.IsActive = false;

            _context.PolicyAssignments.Add(Mapper.Map<PolicyAssignmentDto, PolicyAssignment>(policyAssignmentDto));
            _context.SaveChanges();

            return Ok();
        }
    }
}
