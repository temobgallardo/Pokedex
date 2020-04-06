using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Repositories.Interfaces;
using System.Threading.Tasks;
using Pokedex.Models.Entities;

namespace Pokedex.Core.ViewModels
{
    public class PokemonDetailViewModel: ParentViewModel, IMvxViewModel<Models.Entities.Pokemon>
    {
        private string _detail;
        public string Detail
        {
            private set => SetProperty(ref _detail, value);
            get => _detail;
        }
        private Models.Entities.PokemonDetail _pokemonDetail;
        public Models.Entities.PokemonDetail pokemonDetail;


        private IRepository<Models.Entities.PokemonDetail> _repository;
        public IMvxAsyncCommand GoBackCommand { get; set; }

        // TODO: Why the repositorie's initialization throw and exception of type MvvmCross.Exceptions.MvxException: 'Failed to construct and initialize ViewModel for type Pokedex.Core.ViewModels.PokemonDetailViewModel from locator MvxDefaultViewModelLocator - check InnerException for more information'
        public PokemonDetailViewModel(IMvxNavigationService navigation /*, IRepository<Models.Entities.PokemonDetail> repository*/) : base(navigation)
        {
            //_repository = repository;
            GoBackCommand = new MvxAsyncCommand(Back);
        }        

        public async Task Back()
        {
            await _navigationService.Close(this);
        }

        public void Prepare(Pokemon parameter)
        {
            Detail = parameter.detail;            
        }
    }
}
