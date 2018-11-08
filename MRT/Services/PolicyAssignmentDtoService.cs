using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class PolicyAssignmentDtoService : IPolicyAssignmentDtoService
    {
        private DataDb _context;

        public PolicyAssignmentDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<PolicyAssignmentDto>> GetPolicyAssignmentDtoListAsync()
        {
            var policyAssignmentDtos = await _context.PolicyAssignments
                .Include(c => c.Carrier)
                .Include(p => p.Policy)
                .ProjectTo<PolicyAssignmentDto>()
                .ToListAsync();

            return policyAssignmentDtos;
        }

        public async Task<PolicyAssignmentDto> GetPolicyAssignmentDtoByPolicyAsync(int policyId)
        {
            var policyAssignmentDto = await _context.PolicyAssignments
                .Include(c => c.Carrier)
                .ProjectTo<PolicyAssignmentDto>()
                .SingleAsync(p => p.PolicyId == policyId);

            return policyAssignmentDto;
        }
    }
}