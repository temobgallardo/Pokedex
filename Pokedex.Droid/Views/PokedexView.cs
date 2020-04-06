using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Pokedex.Core.ViewModels;

namespace Pokedex.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    class PokedexView : MvxAppCompatActivity<PokedexViewModel>
    {
        private Button _btnGetPokemons;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main_pokedex);
            SupportActionBar.Title = ViewModel.Title;

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.rv_pokedex);
            var decorationItem = new DividerItemDecoration(recyclerView.Context, 1);
            recyclerView.AddItemDecoration(decorationItem);
            _btnGetPokemons = FindViewById<Button>(Resource.Id.btn_getPokemons);

            /**
            _btnGetPokemons.SetOnClickListener{
                
            };
    */
        }

    }
}