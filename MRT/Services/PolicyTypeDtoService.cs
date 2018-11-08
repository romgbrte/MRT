using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Dtos;
using MRT.DataContexts;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class PolicyTypeDtoService : IPolicyTypeDtoService
    {
        private DataDb _context;

        public PolicyTypeDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<PolicyTypeDto>> GetPolicyTypeDtoListAsync()
        {
            var policyTypeDtos = await _context.PolicyTypes.ProjectTo<PolicyTypeDto>().ToListAsync();

            return policyTypeDtos;
        }
    }
}