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
    public class StateService
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