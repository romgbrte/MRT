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
    public class CarrierService
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