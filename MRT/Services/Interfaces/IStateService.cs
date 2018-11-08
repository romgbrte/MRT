using System.Collections.Generic;
using System.Threading.Tasks;
using MRT.Models;

namespace MRT.Services.Interfaces
{
    public interface IStateService
    {
        Task<List<State>> GetListOfStatesAsync();
    }
}
