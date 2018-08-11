using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MRT.Models;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper;

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
        public IHttpActionResult GetWCRates()
        {
            var wcratesDtos = _context.WCRates
                .Include(ca => ca.Carrier)
                .Include(s => s.State)
                .Include(co => co.Code)
                .ToList()
                .Select(Mapper.Map<WCRate, WCRateDto>);

            return Ok(wcratesDtos);
        }
    }
}
