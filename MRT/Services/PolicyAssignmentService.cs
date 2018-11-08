using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using MRT.Models;
using MRT.DataContexts;
using MRT.Services.Interfaces;

namespace MRT.Services
{
    public class PolicyAssignmentService : IPolicyAssignmentService
    {
        private DataDb _context;
        public PolicyAssignmentService()
        {
            _context = new DataDb();
        }

        public async Task<PolicyAssignment> GetSingleActivePolicyAssignmentAsync(int id)
        {
            var existingPolicyAssignment = await _context.PolicyAssignments
                .Where(c => c.CarrierId == id)
                .SingleOrDefaultAsync(a => a.IsActive == true);

            return existingPolicyAssignment;
        }

        public void AddPolicyAssignment(PolicyAssignment policyAssignment)
        {
            _context.PolicyAssignments.Add(policyAssignment);
        }

        public async Task<int> SavePolicyAssignmentChangesAsync()
        {
            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}