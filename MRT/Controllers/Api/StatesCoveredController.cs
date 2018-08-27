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
    public class StatesCoveredController : ApiController
    {
        private DataDb _context;
        public StatesCoveredController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/statescovered/# (get a list of the states covered by a carrier)
        public IHttpActionResult GetStatesCovered(int id) // CarrierId
        {
            var statesCovered = _context.StateCoverages
                .Include(s => s.State)
                .Where(c => c.CarrierId == id)
                .Select(s => s.State)
                .OrderBy(s => s.Id)
                .Select(Mapper.Map<State, StateDto>)
                .ToList();

            return Ok(statesCovered);
        }

        // POST /api/statescovered (create a new StateCoverage record)
        [HttpPost]
        public IHttpActionResult CreateStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var existingStateCoverage = _context.StateCoverages
                .Where(c => c.CarrierId == stateCoverageDto.CarrierId)
                .SingleOrDefault(s => s.StateId == stateCoverageDto.StateId);

            if (existingStateCoverage != null)
                return BadRequest("Record already exists");

            var newStateCoverage = Mapper.Map<StateCoverageDto, StateCoverage>(stateCoverageDto);
            _context.StateCoverages.Add(newStateCoverage);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/statescovered/# (delete an existing StateCoverage record)
        [HttpDelete]
        public IHttpActionResult DeleteStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var stateCoverage = _context.StateCoverages
                .Where(c => c.CarrierId == stateCoverageDto.CarrierId)
                .SingleOrDefault(s => s.StateId == stateCoverageDto.StateId);

            if (stateCoverage == null)
                return NotFound();

            _context.StateCoverages.Remove(stateCoverage);
            _context.SaveChanges();

            return Ok();
        }
    }
}