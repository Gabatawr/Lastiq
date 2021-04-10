using System.Windows;
using System.Windows.Controls;

namespace Chatyx.Infrastructure.Extensions
{
    public class ScrollViewerExtensions
    {
        public static readonly DependencyProperty AutoDropProperty = DependencyProperty.RegisterAttached("AutoDrop", typeof(bool), typeof(ScrollViewerExtensions), new PropertyMetadata(false, AutoDropChanged));

        private static void AutoDropChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is ScrollViewer scroll && scroll != null)
            {
                if (e.NewValue != null && (bool)e.NewValue)
                {
                    scroll.ScrollToEnd();
                    scroll.ScrollChanged += ScrollChanged;
                }
                else scroll.ScrollChanged -= ScrollChanged;
            }
        }

        public static bool GetAutoDrop(ScrollViewer scroll)
            => (bool)scroll.GetValue(AutoDropProperty);

        public static void SetAutoDrop(ScrollViewer scroll, bool value)
            => scroll.SetValue(AutoDropProperty, value);

        private static bool autoDropValue = true;
        private static void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (sender is ScrollViewer scroll && scroll != null)
            {
                if (e.ExtentHeightChange == 0)
                    autoDropValue = scroll.VerticalOffset == scroll.ScrollableHeight;

                if (autoDropValue && e.ExtentHeightChange != 0)
                    scroll.ScrollToVerticalOffset(scroll.ExtentHeight);
            }
        }
    }
}
