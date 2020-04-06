using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Repositories.Interfaces;
using System.Threading.Tasks;
using Pokedex.Models.Entities;
using System;

namespace Pokedex.Core.ViewModels
{
    public class PokemonDetailViewModel: ParentViewModel, IMvxViewModel<Models.Entities.PokemonDetail>
    {
        private string _detail;
        public string Detail
        {
            private set => SetProperty(ref _detail, value);
            get => _detail;
        }

        private string _url;
        public string Url
        {
            private set => SetProperty(ref _url, value);
            get => _url;
        }

        public IMvxAsyncCommand GoBackCommand { get; set; }

        // TODO: Why the repositorie's initialization throw and exception of type MvvmCross.Exceptions.MvxException: 'Failed to construct and initialize ViewModel for type Pokedex.Core.ViewModels.PokemonDetailViewModel from locator MvxDefaultViewModelLocator - check InnerException for more information'
        public PokemonDetailViewModel(IMvxNavigationService navigation/*, IRepository repository*/) : base(navigation)
        {
            //_repository = repository;
            GoBackCommand = new MvxAsyncCommand(Back);
        }        

        public async Task Back()
        {
            await _navigationService.Close(this);
        }

        public async void Prepare(PokemonDetail parameter)
        {
            _url = parameter.sprites.front_shiny;
            Detail = @"Pokemon Details" + Environment.NewLine +
                    "Name = " + parameter.name + Environment.NewLine +
                    "Height = " + parameter.height + Environment.NewLine +
                    "Weight = " + parameter.weight + Environment.NewLine +
                    ""; 
        }
    }
}
