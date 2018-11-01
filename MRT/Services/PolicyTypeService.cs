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
    public class PolicyTypeService
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