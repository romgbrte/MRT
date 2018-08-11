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
    public class CarriersController : ApiController
    {
        private DataDb _context;
        public CarriersController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/carriers
        [HttpGet]
        public IHttpActionResult GetCarriers()
        {
            var carrierDtos = _context.Carriers
                .ToList()
                .Select(Mapper.Map<Carrier, CarrierDto>);
            var stateCoverageDtos = _context.StateCoverages
                .Include(s => s.State)
                .ToList()
                .Select(Mapper.Map<StateCoverage, StateCoverageDto>);

            foreach(var carrier in carrierDtos)
            {
                carrier.StatesCovered = stateCoverageDtos
                    .Where(c => c.CarrierId == carrier.Id)
                    .ToList();
            }

            return Ok(carrierDtos);
        }
    }
}