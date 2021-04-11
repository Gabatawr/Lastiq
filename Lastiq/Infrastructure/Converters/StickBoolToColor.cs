using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Lastiq.Infrastructure.Converters
{
    class StickBoolToColor : IValueConverter
    {
        private SolidColorBrush NewStick = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE600")) { Opacity = 0.64 };
        private SolidColorBrush CompletedStick = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#52FF00")) { Opacity = 0.64 };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool completed && completed is true)
                return CompletedStick;
            else return NewStick;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => NewStick;
    }
}