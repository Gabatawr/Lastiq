using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Lastiq.Infrastructure.Converters
{
    class StickBoolToColor : IValueConverter
    {
        private Color NewStick = (Color)ColorConverter.ConvertFromString("#FFE600");
        private Color CompletedStick = (Color)ColorConverter.ConvertFromString("#52FF00");
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is bool completed && completed is true)
                return CompletedStick;
            else return NewStick;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => NewStick;
    }
}
