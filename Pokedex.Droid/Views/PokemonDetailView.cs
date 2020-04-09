using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Pokedex.Core.ViewModels;

namespace Pokedex.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = false)]
    public class PokemonDetailView : MvxAppCompatActivity<PokemonDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_pokemon_detail);
            SupportActionBar.Title = ViewModel.Title;
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ViewModel.GoBackCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

    }
}