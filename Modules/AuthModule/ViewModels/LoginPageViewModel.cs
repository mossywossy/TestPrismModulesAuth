using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthModule.ViewModels
{

    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        public DelegateCommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            LoginCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<LoggedInEvent>().Publish();
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
