using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Dtos;

namespace MRT.Services.Interfaces
{
    public interface IPolicyAssignmentDtoService
    {
        Task<List<PolicyAssignmentDto>> GetPolicyAssignmentDtoListAsync();

        Task<PolicyAssignmentDto> GetPolicyAssignmentDtoByPolicyAsync(int policyId);
    }
}
