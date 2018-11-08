using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Dtos;

namespace MRT.Services.Interfaces
{
    public interface ICodeDtoService
    {
        Task<List<CodeDto>> GetCodeDtoListAsync();
    }
}
