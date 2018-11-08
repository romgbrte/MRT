using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers.Api
{
    public class CodesController : ApiController
    {
        private ICodeDtoService _codeService;
        public CodesController()
        {
            _codeService = new CodeDtoService();
        }
        public CodesController(ICodeDtoService codeSrv)
        {
            _codeService = codeSrv;
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> GetCodes()
        {
            var codeDtos = await _codeService.GetCodeDtoListAsync();

            return Ok(codeDtos);
        }
    }
}
