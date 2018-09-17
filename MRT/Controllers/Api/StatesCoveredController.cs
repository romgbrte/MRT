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
    [Authorize]
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
        public async Task<IHttpActionResult> GetStatesCovered(int id) // CarrierId
        {
            var statesCovered = await _context.StateCoverages
                .Include(s => s.State)
                .Where(c => c.CarrierId == id)
                .Select(s => s.State)
                .OrderBy(s => s.Id)
                .ProjectTo<StateDto>()
                .ToListAsync();

            return Ok(statesCovered);
        }

        // POST /api/statescovered (create a new StateCoverage record)
        [HttpPost]
        public async Task<IHttpActionResult> CreateStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var existingStateCoverage = await _context.StateCoverages
                .Where(c => c.CarrierId == stateCoverageDto.CarrierId)
                .SingleOrDefaultAsync(s => s.StateId == stateCoverageDto.StateId);

            if (existingStateCoverage != null)
                return BadRequest("Record already exists");

            var newStateCoverage = Mapper.Map<StateCoverageDto, StateCoverage>(stateCoverageDto);
            _context.StateCoverages.Add(newStateCoverage);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE /api/statescovered/# (delete an existing StateCoverage record)
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var stateCoverage = await _context.StateCoverages
                .Where(c => c.CarrierId == stateCoverageDto.CarrierId)
                .SingleOrDefaultAsync(s => s.StateId == stateCoverageDto.StateId);

            if (stateCoverage == null)
                return NotFound();

            _context.StateCoverages.Remove(stateCoverage);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}