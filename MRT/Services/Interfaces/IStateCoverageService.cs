using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Models;

namespace MRT.Services.Interfaces
{
    public interface IStateCoverageService
    {
        Task<List<StateCoverage>> GetListOfStateCoveragesAsync();

        Task<List<StateCoverage>> GetListOfStateCoveragesByCarrierAsync(int carrierId);
    }
}
