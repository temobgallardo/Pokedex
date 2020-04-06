using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.ViewModels
{
    public class ParentViewModel: MvxViewModel
    {
        private string _title;
        public string Title
        {
            set => SetProperty(ref _title, value);
            get => _title;
        }

        protected IMvxNavigationService _navigationService;

        public ParentViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
