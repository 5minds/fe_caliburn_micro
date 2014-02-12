using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CaliburnProto.Converters
{
    public sealed  class ImageConverter: IValueConverter

    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return new BitmapImage(new Uri((string)value, UriKind.Relative));
            }
            catch
            {
                return new BitmapImage();
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}