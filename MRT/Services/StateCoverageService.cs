using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MRT.Models;
using MRT.ViewModels;
using MRT.DataContexts;

namespace MRT.Services
{
    public class StateCoverageService
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

        public async Task<List<StateCoverage>> GetListOfStateCoveragesAsync(int id)
        {
            var stateCoverages = await _context.StateCoverages.Where(c => c.CarrierId == id).ToListAsync();

            return stateCoverages;
        }
    }
}