using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;


namespace 原社区.Extensions
{
    internal class MyAnimation
    {
        #region [=====属性=====]

        #endregion

        #region [=====私有变量=====]

        #endregion

        #region [=====辅助过程=====]

        #endregion

        #region [=====发布方法=====]

        /// <summary>
        /// 鼠标进入离开缩放控件
        /// </summary>
        /// <param name="element">UI对象</param>
        /// <param name="zoomValue">放大比例,如1.1</param>
        /// <param name="duration">时间间隔,单位：毫秒</param>
        public static void ZoomAnimation(UIElement element, double zoomValue, int duration)
        {
            //构建RenderTransform
            element.RenderTransform = new ScaleTransform(1, 1);

            //===鼠标进入放大
            var zoomSto = new Storyboard();
            //Y轴
            var zoomAni = new DoubleAnimation()
            {
                From = 1,
                To = zoomValue,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };
            Storyboard.SetTarget(zoomAni, element);
            Storyboard.SetTargetProperty(zoomAni, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
            //Storyboard.SetTargetProperty(zoomAni, new PropertyPath(ScaleTransform.ScaleYProperty));
            zoomSto.Children.Add(zoomAni);
            //X轴
            zoomAni = new DoubleAnimation()
            {
                From = 1,
                To = zoomValue,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };
            Storyboard.SetTarget(zoomAni, element);
            Storyboard.SetTargetProperty(zoomAni, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            zoomSto.Children.Add(zoomAni);

            element.MouseEnter += delegate (object sender, System.Windows.Input.MouseEventArgs e)
            {
                zoomSto.Begin();
            };

            //===鼠标离开恢复
            var zoomStol = new Storyboard();
            //Y轴
            zoomAni = new DoubleAnimation()
            {
                From = zoomValue,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };
            Storyboard.SetTarget(zoomAni, element);
            Storyboard.SetTargetProperty(zoomAni, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
            zoomStol.Children.Add(zoomAni);
            //X轴
            zoomAni = new DoubleAnimation()
            {
                From = zoomValue,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration))
            };
            Storyboard.SetTarget(zoomAni, element);
            Storyboard.SetTargetProperty(zoomAni, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            zoomStol.Children.Add(zoomAni);

            element.MouseLeave += delegate (object sender, System.Windows.Input.MouseEventArgs e)
            {
                zoomStol.Begin();
            };

        }

        public static Storyboard MoveAnimation(UIElement contral, Point curPoint, Point movePoint, double duration)
        {
            TranslateTransform ts;
            if (contral.RenderTransform == null)
            {
                ts = new TranslateTransform(0, 0);
                contral.RenderTransform = ts;
            }
            else if (!(contral.RenderTransform is TranslateTransform))
            {
                ts = new TranslateTransform(0, 0);
                contral.RenderTransform = ts;
            }
            else
            {
                ts = (TranslateTransform)contral.RenderTransform;
            }
            //修正当前位置
            curPoint.X = curPoint.X + ts.X;
            curPoint.Y = curPoint.Y + ts.Y;

            var sb = new Storyboard();
            //X轴
            DoubleAnimation doubleAnimationX = new DoubleAnimation(ts.X, movePoint.X - curPoint.X + ts.X, new Duration(TimeSpan.FromMilliseconds(duration)));
            doubleAnimationX.EasingFunction = new BackEase()
            {
                Amplitude = 0.3,
                EasingMode = EasingMode.EaseInOut
            };
            Storyboard.SetTarget(doubleAnimationX, contral);
            Storyboard.SetTargetProperty(doubleAnimationX, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            sb.Children.Add(doubleAnimationX);

            //Y轴
            DoubleAnimation doubleAnimationY = new DoubleAnimation(ts.Y, movePoint.Y - curPoint.Y + ts.Y, new Duration(TimeSpan.FromMilliseconds(duration)));
            doubleAnimationY.EasingFunction = new BackEase()
            {
                Amplitude = 0.3,
                EasingMode = EasingMode.EaseInOut
            };
            Storyboard.SetTarget(doubleAnimationY, contral);
            Storyboard.SetTargetProperty(doubleAnimationY, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
            sb.Children.Add(doubleAnimationY);

            return sb;
        }

        /// <summary>
        /// 快速动画[可叠加]
        /// </summary>
        public static Storyboard FastAnimation(Storyboard storyboard, UIElement contral, string property, double from, double to, double duration)
        {
            var sb = storyboard;
            if (storyboard == null)
            {
                sb = new Storyboard();
            }
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, new Duration(TimeSpan.FromMilliseconds(duration)));
            Storyboard.SetTarget(doubleAnimation, contral);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(property));
            sb.Children.Add(doubleAnimation);
            return sb;
        }

        /// <summary>
        /// 路径动画
        /// </summary>
        public static Storyboard PathAnimation(UIElement contral, Path path, double duration)
        {
            contral.RenderTransform = new MatrixTransform();

            MatrixAnimationUsingPath matrixAnimation = new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = path.Data.GetFlattenedPathGeometry();
            matrixAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            matrixAnimation.IsOffsetCumulative = false;
            matrixAnimation.DoesRotateWithTangent = true;

            Storyboard story = new Storyboard();
            story.Children.Add(matrixAnimation);
            Storyboard.SetTarget(matrixAnimation, contral);
            Storyboard.SetTargetProperty(matrixAnimation, new PropertyPath("(UIElement.RenderTransform).(MatrixTransform.Matrix)"));
            return story;
        }

        #endregion
    }
}
