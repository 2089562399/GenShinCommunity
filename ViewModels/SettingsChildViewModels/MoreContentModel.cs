using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using 原社区.Common;
using 原社区.Common.Models;
using 原社区.Extensions;

namespace 原社区.ViewModels.SettingsChildViewModels
{
    public class MoreContentModel: BindableBase 
    {


        public DelegateCommand<Image> MLBDCommand { set; private get; }
        public DelegateCommand enen { set; private get; }

        public MoreContentModel()
        {
            MLBDCommand = new DelegateCommand<Image>(PresentThing);
            enen = new DelegateCommand(eeee);

        }

        private void eeee()
        {

            MessageBox.Show("nish");
        }

        private void PresentThing(Image obj)
        {
            MessageBox.Show("ee");
        }
    }
}
