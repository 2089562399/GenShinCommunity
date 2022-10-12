using System.Windows;
using System.Windows.Input;

namespace 原社区.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>    
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            colorZone.MouseMove += (s, e) =>                       // 头部边框事件
            {
                if (e.LeftButton == MouseButtonState.Pressed)     //鼠标左键被点击
                    this.DragMove();
            };

            MenuBar.SelectionChanged += (s, e) =>
            {
                drawerHost.IsLeftDrawerOpen = false;
            };

            butClose.Click += (s, e) =>
            {
                this.Close();
            };

            butMin.Click += (e, s) => { this.WindowState = WindowState.Minimized; };
            butMax.Click += (e, s) => { this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; };
            colorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (this.WindowState == WindowState.Maximized)
                    {
                        this.WindowState = WindowState.Normal;
                        this.Left = 0;
                        this.Top = 0;
                    }
                    this.DragMove();
                }
            };
        }
    }
}
