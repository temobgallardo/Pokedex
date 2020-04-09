using Android.App;
using Android.OS;
// If fails maybe due to this.
// Use java interop
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Java.Interop;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Pokedex.Core.ViewModels;
using static Android.Support.V7.Widget.SearchView;

namespace Pokedex.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    class PokedexView : MvxAppCompatActivity<PokedexViewModel>, IOnQueryTextListener, IMenuItemOnActionExpandListener
    {
        private SearchView _searchView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main_pokedex);
            SupportActionBar.Title = ViewModel.Title;

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.rv_pokedex);
            var decorationItem = new DividerItemDecoration(recyclerView.Context, 1);
            recyclerView.AddItemDecoration(decorationItem);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);

            var item = menu.FindItem(Resource.Id.action_search);
            _searchView = item.ActionView as Android.Support.V7.Widget.SearchView;
            _searchView.SetOnQueryTextListener(this);
            item.SetOnActionExpandListener(this);
            _searchView.SetIconifiedByDefault(false);

            return base.OnCreateOptionsMenu(menu);
        }

        public bool OnQueryTextChange(string newText)
        {
            ViewModel.SearchPokemonCommand.Execute(newText);
            return true;
        }   

        public bool OnQueryTextSubmit(string newText)
        {
            ViewModel.SearchPokemonCommand.Execute(newText);
            return true;
        }

        public bool OnMenuItemActionCollapse(IMenuItem item)
        {
            return true;
        }

        public bool OnMenuItemActionExpand(IMenuItem item)
        {
            return true;
        }
    }
}