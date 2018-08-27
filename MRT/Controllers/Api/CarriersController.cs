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
                .Select(Mapper.Map<Carrier, CarrierDto>)
                .ToList();
            var stateCoverages = _context.StateCoverages.ToList();
            var states = _context.States.ToList();

            foreach (var carrierDto in carrierDtos)
            {
                var carrierStates = stateCoverages
                    .Where(c => c.CarrierId == carrierDto.Id)
                    .Select(s => s.StateId)
                    .ToList();
                carrierDto.StatesCovered = states.Where(s => carrierStates.Contains(s.Id))
                    .Select(Mapper.Map<State, StateDto>)
                    .ToList();
                carrierDto.StatesNotCovered = new List<StateDto>();
            }

            return Ok(carrierDtos);
        }
    }
}