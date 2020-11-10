using System;
using Prism.Navigation;

namespace AuthModule
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly INavigationService _navigationService;

        public AuthenticationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Logout()
        {
            _navigationService.NavigateAsync("LoginPage");
        }
    }
}
