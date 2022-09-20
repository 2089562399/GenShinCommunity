using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using 原社区.ViewModels;
using 原社区.ViewModels.SettingsChildViewModels;
using 原社区.Views;
using 原社区.Views.SettingsChildView;

namespace 原社区
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MoreContent>();
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<GenShinIntroduction, GenShinIntroductionModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<RoleIntroduction, RoleIntroductionModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();   //Register For Navigation 航行登记
        }
    }
}
