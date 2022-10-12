using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Threading;
using System.Windows;

namespace 原社区.ViewModels.Dialogs
{
    /// <summary>
    /// 进入主界面的加载界面
    /// </summary>
    public class LoginViewModel : BindableBase, IDialogAware
    {
        #region 属性
        public event Action<IDialogResult> RequestClose;
        Timer timer = null;
        #endregion

        #region 辅助方法
        /// <summary>
        /// 计时线程结束方法
        /// </summary>
        /// <param name="state"></param>
        private void timerUP(object state)
        {
            //停止计时,时间到达
            timer.Change(Timeout.Infinite, 0);
            timer = null;

            //使用Dispatcher访问另一个线程，由于wpf无法进行两个不同进程的访问
            ThreadStart ts = new ThreadStart(EnterMianWindow);
            Thread td = new Thread(ts);
            td.Start();
        }
        /// <summary>
        /// 进入主界面的线程任务
        /// </summary>
        private void EnterMianWindow()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            });

        }
        #endregion

        #region 发布方法
        public LoginViewModel()
        {
            timer = new Timer(new TimerCallback(timerUP));
            //立即开始计时，5000毫秒启动，1000间隔
            timer.Change(4000, 1000);
        }
        #endregion

        #region 实现接口
        string IDialogAware.Title => throw new NotImplementedException();
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }


        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        #endregion
    }
}
