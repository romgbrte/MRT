using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MRT.DataContexts;
using MRT.Dtos;
using MRT.Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace MRT.Services
{
    public class CodeDtoService : ICodeDtoService
    {
        private DataDb _context;
        public CodeDtoService()
        {
            _context = new DataDb();
        }

        public async Task<List<CodeDto>> GetCodeDtoListAsync()
        {
            var codeDtos = await _context.Codes.ProjectTo<CodeDto>().ToListAsync();

            return codeDtos;
        }
    }
}