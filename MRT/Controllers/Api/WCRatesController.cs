using System.Threading.Tasks;
using System.Web.Http;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers.Api
{
    public class WCRatesController : ApiController
    {
        private IWCRateDtoService _wcRateDtoService;

        public WCRatesController()
        {
            _wcRateDtoService = new WCRateDtoService();
        }

        public WCRatesController(IWCRateDtoService wcRateDtoSrv)
        {
            _wcRateDtoService = wcRateDtoSrv;
        }

        // GET /api/wcrates
        [HttpGet]
        public async Task<IHttpActionResult> GetWCRates()
        {
            var wcRateDtos = await _wcRateDtoService.GetWCRateDtoListAsync();

            return Ok(wcRateDtos);
        }
    }
}
