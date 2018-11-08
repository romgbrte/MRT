using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Models;

namespace MRT.Services.Interfaces
{
    public interface IPolicyTypeService
    {
        Task<List<PolicyType>> GetPolicyTypeListAsync();
    }
}
