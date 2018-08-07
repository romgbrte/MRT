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
    public class PoliciesController : ApiController
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

        // GET /api/policies
        [HttpGet]
        public IHttpActionResult GetPolicies()
        {
            var policies = _context.Policies
                .Include(p => p.PolicyType)
                .ToList();

            return Ok(policies.Select(Mapper.Map<Policy, PolicyDto>));
        }
    }
}
