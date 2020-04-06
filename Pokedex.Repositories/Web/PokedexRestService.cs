using Newtonsoft.Json;
using Pokedex.Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Repositories.Web
{
    public class PokedexRestService : IRepository<Models.Entities.Pokedex>
    {
        HttpClient _client;
        private string _uri = @"https://pokeapi.co/api/v2/pokemon/";

        public PokedexRestService() 
        {
            _client = new HttpClient();
        }

        public async Task<Models.Entities.Pokedex> GetDataAsync()
        {
            var uri = new Uri(_uri);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Entities.Pokedex>(content);
            }

            return new Models.Entities.Pokedex();
        }

        public async Task<Models.Entities.PokemonDetail> GetDataAsync(string uriNew)
        {
            var uri = new Uri(uriNew);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Entities.PokemonDetail>(content);
            }

            return new Models.Entities.PokemonDetail();
        }

    }
}
