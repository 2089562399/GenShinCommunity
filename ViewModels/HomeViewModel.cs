using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 原社区.Common.Models;

namespace 原社区.ViewModels
{
    public class HomeViewModel:BindableBase
    {

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
        public HomeViewModel()
        {
            Icons = new ObservableCollection<MainViewIcon>();
            CreateMainViewIcons();
            SelectCommand = new DelegateCommand<MainViewIcon>(Select);
        }

        void Select(MainViewIcon obj)
        {
            MessageBox.Show(obj.Icon);
        }

        void CreateMainViewIcons()
        {
            Icons.Add(new MainViewIcon() { Icon = "/Image/地理志（指南针图标2）.png" });
            Icons.Add(new MainViewIcon() { Icon = "/Image/旅行日志(icon).png" });
            Icons.Add(new MainViewIcon() { Icon = "/Image/地理志（指南针图标2）.png" });
            Icons.Add(new MainViewIcon() { Icon = "/Image/旅行日志(icon).png" });
        }
    }
}
