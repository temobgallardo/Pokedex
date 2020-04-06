using System.Collections.Generic;
using System.Threading.Tasks;


namespace Pokedex.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<T> GetDataAsync<T>() where T : class, new();
        Task<T> GetDataAsync<T>(string newUri) where T : class, new();
    }
}