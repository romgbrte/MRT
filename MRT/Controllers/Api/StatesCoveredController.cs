using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using MRT.Dtos;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers.Api
{
    public class StatesCoveredController : ApiController
    {
        private IStateCoverageDtoService _stateCoverageDtoService;

        public StatesCoveredController()
        {
            _stateCoverageDtoService = new StateCoverageDtoService();
        }

        public StatesCoveredController(IStateCoverageDtoService stateCoverageDtoSrv)
        {
            _stateCoverageDtoService = stateCoverageDtoSrv;
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> GetStatesCovered(int id)
        {
            int carrierId = id;

            var stateCoverages = await _stateCoverageDtoService
                .GetListOfStateCoverageDtosByCarrierAsync(carrierId);
            // From the list of a Carrier's StateCoverages, extract and sort only the States
            var statesCovered = stateCoverages.Select(s => s.State)
                .OrderBy(s => s.Id)
                .ToList();

            return Ok(statesCovered);
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> CreateStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var existingStateCoverages = await _stateCoverageDtoService
                .GetListOfStateCoverageDtosByCarrierAsync(stateCoverageDto.CarrierId);

            // Is the State being added to coverage already covered by this Carrier?
            var existingCoverage = existingStateCoverages
                .FirstOrDefault(s => s.StateId == stateCoverageDto.StateId);
            if(existingCoverage != null)
                return BadRequest("Record already exists");

            _stateCoverageDtoService.AddStateCoverage(stateCoverageDto);
            await _stateCoverageDtoService.SaveStateCoverageChangesAsync();

            return Ok();
        }
        
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var carrierStateCoverages = await _stateCoverageDtoService
                .GetListOfStateCoverageDtosByCarrierAsync(stateCoverageDto.CarrierId);

            // Is the State being removed from this Carrier's coverage not listed as being covered?
            int numberExisting = carrierStateCoverages
                .Where(s => s.StateId == stateCoverageDto.StateId)
                .Count();
            if (numberExisting == 0)
                return NotFound();
            
            // Remove any number of StateCoverages for this State by this Carrier
            for(int i = 0; i < numberExisting; i++)
                _stateCoverageDtoService.RemoveStateCoverage(stateCoverageDto);
            await _stateCoverageDtoService.SaveStateCoverageChangesAsync();

            return Ok();
        }
    }
}