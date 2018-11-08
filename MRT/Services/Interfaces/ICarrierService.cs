using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Models;

namespace MRT.Services.Interfaces
{
    public interface ICarrierService
    {
        Task<List<Carrier>> GetCarrierListAsync();

        Task<Carrier> GetSingleCarrierAsync(int id);

        void AddCarrier(Carrier carrier);

        Task<int> SaveCarrierChangesAsync();
    }
}
