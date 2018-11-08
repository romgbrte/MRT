using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using MRT.Dtos;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers.Api
{
    public class CarriersController : ApiController
    {
        private ICarrierDtoService _carrierDtoService;
        private IStateDtoService _stateDtoService;
        private IStateCoverageDtoService _stateCoverageDtoService;

        public CarriersController()
        {
            _carrierDtoService = new CarrierDtoService();
            _stateDtoService = new StateDtoService();
            _stateCoverageDtoService = new StateCoverageDtoService();
        }

        public CarriersController(ICarrierDtoService carrierDtoSrv, 
            IStateDtoService stateDtoSrv, IStateCoverageDtoService stateCoverageDtoSrv)
        {
            _carrierDtoService = carrierDtoSrv;
            _stateDtoService = stateDtoSrv;
            _stateCoverageDtoService = stateCoverageDtoSrv;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCarriers()
        {
            var carrierDtos = await _carrierDtoService.GetCarrierDtoListAsync();
            var stateCoverages = await _stateCoverageDtoService.GetListOfStateCoverageDtosAsync();
            var states = await _stateDtoService.GetListOfStateDtosAsync();

            foreach (var carrierDto in carrierDtos)
            {
                var carrierStates = stateCoverages
                    .Where(c => c.CarrierId == carrierDto.Id)
                    .Select(s => s.StateId)
                    .ToList();
                carrierDto.StatesCovered = states.Where(s => carrierStates.Contains(s.Id)).ToList();
                carrierDto.StatesNotCovered = new List<StateDto>();
            }

            return Ok(carrierDtos);
        }
    }
}