using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Lastiq.Infrastructure.Converters
{
    class NameShorter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            if (text == null) return "U";

            return text[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => "U";
    }
}
