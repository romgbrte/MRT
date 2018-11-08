using System.Threading.Tasks;
using System.Web.Http;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers.Api
{
    public class PoliciesController : ApiController
    {
        private IPolicyDtoService _policyDtoService;

        public PoliciesController()
        {
            _policyDtoService = new PolicyDtoService();
        }

        public PoliciesController(IPolicyDtoService policyDtoSrv)
        {
            _policyDtoService = policyDtoSrv;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPolicies()
        {
            var policyDtos = await _policyDtoService.GetPolicyDtoListAsync();

            return Ok(policyDtos);
        }
    }
}
