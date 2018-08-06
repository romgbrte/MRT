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
            var carriers = _context.Carriers.ToList();
            var statesCovered = _context
                .StateCoverages
                .Include(s => s.State)
                .ToList();

            foreach(var carrier in carriers)
            {
                carrier.StatesCovered = statesCovered
                    .Where(s => s.CarrierId == carrier.Id)
                    .ToList();
            }

            return Ok(carriers.Select(Mapper.Map<Carrier, CarrierDto>));
        }
    }
}