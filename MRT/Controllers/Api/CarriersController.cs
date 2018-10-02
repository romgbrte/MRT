using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using MRT.Models;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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

        [HttpGet]
        public async Task<IHttpActionResult> GetCarriers()
        {
            var carrierDtos = await _context.Carriers
                .ProjectTo<CarrierDto>()
                .ToListAsync();
            var stateCoverages = await _context.StateCoverages.ToListAsync();
            var states = await _context.States.ToListAsync();

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