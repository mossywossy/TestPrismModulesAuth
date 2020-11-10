using Prism;
using Prism.Ioc;
using TestPrismModules.ViewModels;
using TestPrismModules.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Prism.Modularity;
using TestModule1;
using Prism.Events;
using AuthModule;
using System;

namespace TestPrismModules
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var ea = Container.Resolve<IEventAggregator>().GetEvent<LoggedInEvent>().Subscribe(OnUserAuthenticated);

            await NavigationService.NavigateAsync("LoginPage",null,true,true);
        }

        private void OnUserAuthenticated()
        {
            NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterRegionServices();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            
        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<TestModule1Module>();
            moduleCatalog.AddModule<AuthModuleModule>();
        }

        protected override async void OnResume()
        {
            base.OnResume();
            // Logout and redirect to Login Page
            var authService = Container.Resolve<IAuthenticationService>();
            authService.Logout();
            //await NavigationService.NavigateAsync("LoginPage");

        }
    }
}
