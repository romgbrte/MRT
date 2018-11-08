using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using MRT.Models;
using MRT.DataContexts;
using MRT.Services.Interfaces;

namespace MRT.Services
{
    public class StateService : IStateService
    {
        private DataDb _context;
        public StateService()
        {
            _context = new DataDb();
        }

        public async Task<List<State>> GetListOfStatesAsync()
        {
            var states = await _context.States.ToListAsync();

            return states;
        }
    }
}