using System.Threading.Tasks;
using System.Data.Entity;
using MRT.Models;
using MRT.DataContexts;
using MRT.Services.Interfaces;

namespace MRT.Services
{
    public class PolicyService : IPolicyService
    {
        private DataDb _context;
        public PolicyService()
        {
            _context = new DataDb();
        }

        public async Task<Policy> GetSinglePolicyAsync(int id)
        {
            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.Id == id);

            return policy;
        }

        public void AddPolicy(Policy policy)
        {
            _context.Policies.Add(policy);
        }

        public async Task<int> SavePolicyChangesAsync()
        {
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}