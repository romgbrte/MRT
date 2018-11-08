using System.Threading.Tasks;
using MRT.Models;

namespace MRT.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<Policy> GetSinglePolicyAsync(int id);

        void AddPolicy(Policy policy);

        Task<int> SavePolicyChangesAsync();
    }
}
