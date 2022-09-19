using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using 原社区.ViewModels;
using 原社区.Views;

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
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<GenShinIntroduction, GenShinIntroductionModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<RoleIntroduction, RoleIntroductionModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();   //Register For Navigation 航行登记
        }
    }
}
