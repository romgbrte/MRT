using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MRT.Models;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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

        [HttpGet]
        public async Task<IHttpActionResult> GetPolicyAssignments()
        {
            var policyAssignments = await _context.PolicyAssignments
                .Include(c => c.Carrier)
                .Include(p => p.Policy)
                .ProjectTo<PolicyAssignmentDto>()
                .ToListAsync();

            return Ok(policyAssignments);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPolicyAssignments(int id)
        {
            var policyAssignmentDto = await _context.PolicyAssignments
                .Include(c => c.Carrier)
                .ProjectTo<PolicyAssignmentDto>()
                .SingleAsync(p => p.PolicyId == id);

            return Ok(policyAssignmentDto);
        }
        
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
