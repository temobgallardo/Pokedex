using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetDataAsync();
    }
}
