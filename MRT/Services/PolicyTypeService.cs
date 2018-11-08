using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using MRT.Models;
using MRT.DataContexts;
using MRT.Services.Interfaces;

namespace MRT.Services
{
    public class PolicyTypeService : IPolicyTypeService
    {
        private DataDb _context;
        public PolicyTypeService()
        {
            _context = new DataDb();
        }

        public async Task<List<PolicyType>> GetPolicyTypeListAsync()
        {
            var policyTypes = await _context.PolicyTypes.ToListAsync();

            return policyTypes;
        }
    }
}