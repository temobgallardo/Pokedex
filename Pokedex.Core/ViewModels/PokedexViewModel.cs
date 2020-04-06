using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Core.ViewModels
{
    public class PokedexViewModel : ParentViewModel
    {
        public string _pokemonName;
        public string PokemonName 
        {
            set => SetProperty(ref _pokemonName, value);
            get => _pokemonName;
        }

        public string _pokemonUrl;
        public string PokemonUrl
        {
            set => SetProperty(ref _pokemonUrl, value);
            get => _pokemonUrl;
        }

        private IRepository _repository;
        public IMvxAsyncCommand GetPokemonsCommand { private set; get; }
        public IMvxAsyncCommand<Models.Entities.Pokemon> PokemonSelectedCommand { private set; get; }

        public MvxObservableCollection<Models.Entities.Pokemon> Pokemons { private set; get; }

        public PokedexViewModel(IMvxNavigationService navigationService, IRepository repository) : base(navigationService)
        {
            Title = "Pokedex";
            _repository = repository;
            GetPokemonsCommand = new MvxAsyncCommand(GetPokemons);
            Pokemons = new MvxObservableCollection<Models.Entities.Pokemon>();
            PokemonSelectedCommand = new MvxAsyncCommand<Models.Entities.Pokemon>(OnPokemonSelected);
        }

        private async Task OnPokemonSelected(Models.Entities.Pokemon pokemon) 
        {
            var pokemonDetail = await _repository.GetDataAsync<Models.Entities.PokemonDetail>(pokemon.url);
            await _navigationService.Navigate<PokemonDetailViewModel, Models.Entities.PokemonDetail>(pokemonDetail);
        }

        private async Task GetPokemons()
        {
            var pokedex = await _repository.GetDataAsync<Models.Entities.Pokedex>();

            if (pokedex != null) {
                var pokemons = pokedex.results;
                if (pokemons != null && pokemons.Any()) 
                {
                    Pokemons.AddRange(pokedex.results);
                }
            }                        
        }
    }
}
