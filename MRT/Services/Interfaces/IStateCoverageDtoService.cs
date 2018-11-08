using MRT.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRT.Services.Interfaces
{
    public interface IStateCoverageDtoService
    {
        Task<List<StateCoverageDto>> GetListOfStateCoverageDtosAsync();

        Task<List<StateCoverageDto>> GetListOfStateCoverageDtosByCarrierAsync(int carrierId);

        Task<StateCoverageDto> GetStateCoverageByCarrierAndStateAsync(int carrierId, int stateId);

        void AddStateCoverage(StateCoverageDto stateCoverageDto);

        void RemoveStateCoverage(StateCoverageDto stateCoverageDto);

        Task<int> SaveStateCoverageChangesAsync();
    }
}
