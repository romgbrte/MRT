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
    public class WCRatesController : ApiController
    {
        private DataDb _context;
        public WCRatesController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/wcrates
        [HttpGet]
        public async Task<IHttpActionResult> GetWCRates()
        {
            var wcratesDtos = await _context.WCRates
                .Include(ca => ca.Carrier)
                .Include(s => s.State)
                .Include(co => co.Code)
                .ProjectTo<WCRateDto>()
                .ToListAsync();

            return Ok(wcratesDtos);
        }
    }
}
