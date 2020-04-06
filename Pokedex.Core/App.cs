using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Pokedex.Core.ViewModels;
using Pokedex.Repositories.Interfaces;
using Pokedex.Repositories.Web;

namespace Pokedex.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            // TODO: What does this? Looks like IoC Part
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IRepository<Models.Entities.Pokedex>, PokedexRestService>();

            RegisterAppStart<PokedexViewModel>();
        }
    }
}
