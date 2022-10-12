using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 原社区.Common.Models;
using 原社区.Extensions;

namespace 原社区.ViewModels
{
    public class HomeViewModel:BindableBase
    {
        private readonly IRegionManager regionManager;
        /// <summary>
        /// 定义一个数MainViewIcon数组
        /// </summary>
        private ObservableCollection<MainViewIcon> icons;

        public ObservableCollection<MainViewIcon> Icons
        {
            get { return icons; }
            set { icons = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 导航命令
        /// </summary>
        public DelegateCommand<MainViewIcon> SelectCommand { get; private set; }    //delegate 委托
        public HomeViewModel(IRegionManager regionManager)
        {
            Icons = new ObservableCollection<MainViewIcon>();
            CreateMainViewIcons();
            SelectCommand = new DelegateCommand<MainViewIcon>(Select);
            this.regionManager = regionManager;
        }

        void Select(MainViewIcon obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
            {
                return;
            }

            //更新注册区域到新的页面
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                PrismManager.journal = back.Context.NavigationService.Journal;
            });
        }

        void CreateMainViewIcons()
        {
            Icons.Add(new MainViewIcon() { Name="角色图鉴", Icon = "/Image/地理志（指南针图标2）.png" , NameSpace="RoleIntroduction" });
            Icons.Add(new MainViewIcon() { Name="地理志", Icon = "/Image/旅行日志(icon).png",NameSpace="GeographySectionView" });
            Icons.Add(new MainViewIcon() { Name="原神攻略", Icon = "/Image/地理志（指南针图标2）.png",NameSpace= "GenShinIntroduction" });
            Icons.Add(new MainViewIcon() { Name="设置", Icon = "/Image/旅行日志(icon).png" ,NameSpace="SettingsView" });
        }
    }
}
