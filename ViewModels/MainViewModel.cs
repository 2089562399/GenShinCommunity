using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 原社区.Common;
using 原社区.Common.DB;
using 原社区.Common.Models;
using 原社区.Extensions;

namespace 原社区.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        /// <summary>
        /// 导航栏命令
        /// </summary>
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }    //delegate 委托
        /// <summary>
        /// <-  ->前后退的命令
        /// </summary>
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }


        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();

            //获取数据库中的角色信息
            CharacterStorage.Characters = MyDBFunction.GetAllCharacter();

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);  //listbox导航栏命令
            this.regionManager = regionManager;



            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });

            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });
        }
        private ObservableCollection<MenuBar> menuBars;
        private IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;
        public ObservableCollection<MenuBar> MenuBars
        {
            get
            {
                return menuBars;
            }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 导航栏按钮的操作
        /// </summary>
        /// <param name="obj"></param>
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
            {
                return;
            }

            //更新注册区域到新的页面
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });

        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "HomeView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "角色介绍", NameSpace = "RoleIntroduction" });
            MenuBars.Add(new MenuBar() { Icon = "NoteboolPlus", Title = "攻略", NameSpace = "GenShinIntroduction" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }

        /// <summary>
        /// 配置首页初始化界面参数
        /// </summary>
        public void Configure()
        {
            CreateMenuBar();
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("HomeView");
        }
    }
}
