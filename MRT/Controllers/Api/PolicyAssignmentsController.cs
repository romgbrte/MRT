using System.Threading.Tasks;
using System.Web.Http;
using MRT.Services;
using MRT.Services.Interfaces;

namespace MRT.Controllers.Api
{
    public class PolicyAssignmentsController : ApiController
    {
        private IPolicyAssignmentDtoService _policyAssignmentDtoService;

        public PolicyAssignmentsController()
        {
            _policyAssignmentDtoService = new PolicyAssignmentDtoService();
        }

        public PolicyAssignmentsController(IPolicyAssignmentDtoService policyAssignmentDtoSrv)
        {
            _policyAssignmentDtoService = policyAssignmentDtoSrv;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPolicyAssignments()
        {
            var policyAssignmentDtos = await _policyAssignmentDtoService
                .GetPolicyAssignmentDtoListAsync();

            return Ok(policyAssignmentDtos);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPolicyAssignment(int id)
        {
            int policyId = id;

            var policyAssignmentDto = await _policyAssignmentDtoService
                .GetPolicyAssignmentDtoByPolicyAsync(policyId);

            return Ok(policyAssignmentDto);
        }
    }
}
