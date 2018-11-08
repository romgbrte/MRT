using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class CarrierDtoService : ICarrierDtoService
    {
        private DataDb _context;
        public CarrierDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<CarrierDto>> GetCarrierDtoListAsync()
        {
            var carriers = await _context.Carriers
                .ProjectTo<CarrierDto>()
                .ToListAsync();

            return carriers;
        }
    }
}