using Newtonsoft.Json;
using Pokedex.Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Repositories.Web
{
    public class PokedexRestService : IRepository
    {
        private static readonly HttpClient _client = new HttpClient();
        private string _uri = @"https://pokeapi.co/api/v2/pokemon/";

        public PokedexRestService() { }

        public async Task<T> GetDataAsync<T>() where T : class, new()
        {
            var uri = new Uri(_uri);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return new T();
        }

        public async Task<T> GetDataAsync<T>(string newUri) where T : class, new()
        {
            var uri = new Uri(newUri);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return new T();
        }

    }
}
