using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper.QueryableExtensions;

namespace MRT.Controllers.Api
{
    [Authorize]
    public class CodesController : ApiController
    {
        private DataDb _context;
        public CodesController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/codes
        [HttpGet]
        public async Task<IHttpActionResult> GetCodes()
        {
            var codeDtos = await _context.Codes
                .ProjectTo<CodeDto>()
                .ToListAsync();

            return Ok(codeDtos);
        }
    }
}
