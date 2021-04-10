using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Chatyx.Infrastructure.Converters
{
    public class ByteArrayToBitmapImageConverter : IValueConverter
    {
        public BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByte)
        {
            BitmapImage img = new();
            using (MemoryStream ms = new(imageByte))
            {
                img.BeginInit();
                {
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.StreamSource = ms; 
                }
                img.EndInit();

                img.Freeze();
            }
            return img;
        }

        public object Convert(object value, Type targetType, object param, CultureInfo culture)
        {
            var imageByte = value as byte[];
            if (imageByte == null) return null;
            return ConvertByteArrayToBitMapImage(imageByte);
        }

        public object ConvertBack(object value, Type targetType, object param, CultureInfo culture)
            => null;
    }
}
