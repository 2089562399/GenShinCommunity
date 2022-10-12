using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Windows;
using 原社区.Common;
using 原社区.Extensions;
using 原社区.ViewModels;
using 原社区.ViewModels.Dialogs;
using 原社区.ViewModels.SettingsChildViewModels;
using 原社区.Views;
using 原社区.Views.Dialogs;
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

            StaticListItems.DBinitialization();        //调用静态方法获取数据库内容初始化
            return Container.Resolve<MainView>();
        }


        /// <summary>
        /// 配置首页初始化界面参数
        /// </summary>
        protected override void OnInitialized()
        {

            //var dialog = Container.Resolve<IDialogService>();
            //dialog.ShowDialog("LoginView", callback =>
            //{


            //    if (callback.Result == ButtonResult.OK)
            //    {
            //        Application.Current.Shutdown();
            //        return;
            //    }
            //    var service = App.Current.MainWindow.DataContext as IConfigureService;
            //    if (service != null)
            //    {
            //        service.Configure();
            //    }

            //    base.OnInitialized();

            //});

            var service =  App.Current.MainWindow.DataContext as IConfigureService;
            if (service !=null)
            {
                service.Configure();
            }
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            

            containerRegistry.Register<IDialogHostService, DialogHostService>();
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();       //登录时的加载界面


            containerRegistry.RegisterForNavigation<GeographySectionView, GeographySectionModel>();
            containerRegistry.RegisterForNavigation<MoreContent, MoreContentModel>();
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<GenShinIntroduction, GenShinIntroductionModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<RoleIntroduction, RoleIntroductionModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();   //Register For Navigation 航行登记
            containerRegistry.RegisterForNavigation<GeographySectionShowDialogView, GeographySectionShowDialogModel>();//对话窗口
        }
    }
}
