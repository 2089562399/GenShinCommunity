using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原社区.Common
{
    public  interface IDialogHostAware
    {
        /// <summary>
        /// DialogHost名称
        /// </summary>
        string DialogHostName { get; set; }

        /// <summary>
        /// 打开过程中执行
        /// </summary>
        /// <param name="parameters"></param>
        void OnDialogOpend(IDialogParameters parameters);

        /// <summary>
        /// 取消
        /// </summary>
        DelegateCommand CloseCommand { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; set; }
    }
}
