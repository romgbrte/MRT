using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Models;
using MRT.Services.Interfaces;

namespace MRT.Services
{
    public class CarrierService : ICarrierService
    {
        private DataDb _context;
        public CarrierService()
        {
            _context = new DataDb();
        }

        public async Task<List<Carrier>> GetCarrierListAsync()
        {
            var carriers = await _context.Carriers.ToListAsync();

            return carriers;
        }

        public async Task<Carrier> GetSingleCarrierAsync(int id)
        {
            var carrier = await _context.Carriers.SingleOrDefaultAsync(p => p.Id == id);

            return carrier;
        }

        public void AddCarrier(Carrier carrier)
        {
            _context.Carriers.Add(carrier);
        }

        public async Task<int> SaveCarrierChangesAsync()
        {
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}