using System.Threading.Tasks;
using MRT.Models;

namespace MRT.Services.Interfaces
{
    public interface IPolicyAssignmentService
    {
        Task<PolicyAssignment> GetSingleActivePolicyAssignmentAsync(int id);

        void AddPolicyAssignment(PolicyAssignment policyAssignment);

        Task<int> SavePolicyAssignmentChangesAsync();
    }
}
