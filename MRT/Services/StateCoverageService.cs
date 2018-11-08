using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using MRT.Models;
using MRT.DataContexts;
using MRT.Services.Interfaces;

namespace MRT.Services
{
    public class StateCoverageService : IStateCoverageService
    {
        private DataDb _context;

        public StateCoverageService()
        {
            _context = new DataDb();
        }

        public async Task<List<StateCoverage>> GetListOfStateCoveragesAsync()
        {
            var stateCoverages = await _context.StateCoverages.ToListAsync();

            return stateCoverages;
        }

        public async Task<List<StateCoverage>> GetListOfStateCoveragesByCarrierAsync(int carrierId)
        {
            var stateCoverages = await _context.StateCoverages.Where(c => c.CarrierId == carrierId).ToListAsync();

            return stateCoverages;
        }
    }
}