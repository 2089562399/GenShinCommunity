using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 原社区.Common;
using 原社区.Extensions;

namespace 原社区.ViewModels.Dialogs
{
    public class GeographySectionShowDialogModel : IDialogHostAware
    {
        public string DialogHostName {get;set;}
        public DelegateCommand CloseCommand {get;set;}
        public string Path {get;set;}

        public void OnDialogOpend(IDialogParameters parameters)
        {
            CloseCommand = new DelegateCommand(Close);
        }

        private void Close()
        {
            DialogHost.Close(DialogHostName);
        }

        public GeographySectionShowDialogModel()
        {

        }
    }
}
