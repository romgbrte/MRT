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

        // get a list of the states covered by a carrier
        [HttpGet]
        public async Task<IHttpActionResult> GetStatesCovered(int id) // CarrierId
        {
            int carrierId = id;

            var stateCoverages = await _stateCoverageDtoService.GetListOfStateCoverageDtosByCarrierAsync(carrierId);
            var statesCovered = stateCoverages.Select(s => s.State)
                .OrderBy(s => s.Id)
                .ToList();

            return Ok(statesCovered);
        }

        // create a new StateCoverage record
        [HttpPost]
        public async Task<IHttpActionResult> CreateStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var existingStateCoverages = await _stateCoverageDtoService
                .GetListOfStateCoverageDtosByCarrierAsync(stateCoverageDto.CarrierId);

            var existingCoverage = existingStateCoverages.FirstOrDefault(s => s.StateId == stateCoverageDto.StateId);
            
            if(existingCoverage != null)
                return BadRequest("Record already exists");

            _stateCoverageDtoService.AddStateCoverage(stateCoverageDto);
            await _stateCoverageDtoService.SaveStateCoverageChangesAsync();

            return Ok();
        }

        // delete an existing StateCoverage record
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStateCoverage(StateCoverageDto stateCoverageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var carrierStateCoverages = await _stateCoverageDtoService
                .GetListOfStateCoverageDtosByCarrierAsync(stateCoverageDto.CarrierId);

            int numberExisting = carrierStateCoverages.Where(s => s.StateId == stateCoverageDto.StateId).Count();
            if (numberExisting == 0)
                return NotFound();

            for(int i = 0; i < numberExisting; i++)
                _stateCoverageDtoService.RemoveStateCoverage(stateCoverageDto);
            await _stateCoverageDtoService.SaveStateCoverageChangesAsync();

            return Ok();
        }
    }
}