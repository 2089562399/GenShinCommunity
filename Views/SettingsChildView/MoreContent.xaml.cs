using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 原社区.Views.SettingsChildView
{
    /// <summary>
    /// MoreContent.xaml 的交互逻辑
    /// </summary>
    public partial class MoreContent : UserControl
    {
        public MoreContent()
        {
            InitializeComponent();
        }

        private void ss(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("点击了秃瓢");
        }
    }
}
