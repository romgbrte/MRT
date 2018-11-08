using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class WCRateDtoService : IWCRateDtoService
    {
        private DataDb _context;

        public WCRateDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<WCRateDto>> GetWCRateDtoListAsync()
        {
            var wcratesDtos = await _context.WCRates
                .Include(ca => ca.Carrier)
                .Include(s => s.State)
                .Include(co => co.Code)
                .ProjectTo<WCRateDto>()
                .ToListAsync();

            return wcratesDtos;
        }
    }
}