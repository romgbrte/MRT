using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper.QueryableExtensions;

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

        [HttpGet]
        public async Task<IHttpActionResult> GetPolicies()
        {
            var policies = await _context.Policies
                .Include(p => p.PolicyType)
                .ProjectTo<PolicyDto>()
                .ToListAsync();

            return Ok(policies);
        }
    }
}
