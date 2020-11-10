using Prism.Ioc;
using Prism.Modularity;
using AuthModule.Views;
using AuthModule.ViewModels;
using Prism.Regions;

namespace AuthModule
{
    public class AuthModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.RegisterRegionServices();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
