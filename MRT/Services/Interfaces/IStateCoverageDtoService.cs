using MRT.Dtos;
using MRT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRT.Services.Interfaces
{
    public interface IStateCoverageDtoService
    {
        Task<List<StateCoverageDto>> GetListOfStateCoverageDtosAsync();

        Task<List<StateCoverageDto>> GetListOfStateCoverageDtosByCarrierAsync(int carrierId);

        //StateCoverage GetStateCoverageByCarrierAndState(int carrierId, int stateId);

        void AddStateCoverage(StateCoverageDto stateCoverageDto);

        void RemoveStateCoverage(StateCoverageDto stateCoverageDto);

        Task<int> SaveStateCoverageChangesAsync();
    }
}
