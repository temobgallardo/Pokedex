using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Pokedex.Core;
using System.Collections.Generic;
using System.Reflection;

namespace Pokedex.Droid
{
    public class Setup : MvxAppCompatSetup<App>
    {
        // TODO: What does this for?
        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(MvxRecyclerView).Assembly
            };
    }
}