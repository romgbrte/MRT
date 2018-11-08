using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class StateDtoService : IStateDtoService
    {
        private DataDb _context;

        public StateDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<StateDto>> GetListOfStateDtosAsync()
        {
            var stateDtos = await _context.States.ProjectTo<StateDto>().ToListAsync();

            return stateDtos;
        }
    }
}