using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class PolicyDtoService : IPolicyDtoService
    {
        private DataDb _context;

        public PolicyDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<PolicyDto>> GetPolicyDtoListAsync()
        {
            var policyDtos = await _context.Policies
                .Include(p => p.PolicyType)
                .ProjectTo<PolicyDto>()
                .ToListAsync();

            return policyDtos;
        }
    }
}