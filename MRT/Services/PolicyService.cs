using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MRT.Models;
using MRT.ViewModels;
using MRT.DataContexts;

namespace MRT.Services
{
    public class PolicyService
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