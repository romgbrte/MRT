using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Models;
using MRT.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class StateCoverageDtoService : IStateCoverageDtoService
    {
        private DataDb _context;

        public StateCoverageDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<StateCoverageDto>> GetListOfStateCoverageDtosAsync()
        {
            var stateCoverageDtos = await _context.StateCoverages
                .ProjectTo<StateCoverageDto>()
                .ToListAsync();

            return stateCoverageDtos;
        }

        public async Task<List<StateCoverageDto>> GetListOfStateCoverageDtosByCarrierAsync(int carrierId)
        {
            var stateCoverageDtos = await _context.StateCoverages
                .Where(c => c.CarrierId == carrierId)
                .ProjectTo<StateCoverageDto>()
                .ToListAsync();

            return stateCoverageDtos;
        }

        /*public StateCoverage GetStateCoverageByCarrierAndState(int carrierId, int stateId)
        {
            var stateCoverage = _context.StateCoverages
                .Where(c => c.CarrierId == carrierId)
                .SingleOrDefault(s => s.StateId == stateId);

            return stateCoverage;
        }*/

        public void AddStateCoverage(StateCoverageDto stateCoverageDto)
        {
            _context.StateCoverages.Add(Mapper.Map<StateCoverage>(stateCoverageDto));
        }

        public void RemoveStateCoverage(StateCoverageDto stateCoverageDto)
        {
            var stateCoverage = _context.StateCoverages
                .Where(c => c.CarrierId == stateCoverageDto.CarrierId)
                .FirstOrDefault(s => s.StateId == stateCoverageDto.StateId);

            _context.StateCoverages.Remove(stateCoverage);
        }

        public async Task<int> SaveStateCoverageChangesAsync()
        {
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}