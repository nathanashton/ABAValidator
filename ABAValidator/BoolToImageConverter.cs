namespace ABAValidator
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class BoolToImageConverter : IValueConverter
    {
        public Image TrueImage { get; set; }
        public Image FalseImage { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return null;
            }

            var b = (bool) value;
            if (b)
            {
                var u = new Uri("pack://application:,,,/tick.png");
                var s = new BitmapImage(u);
                return s;
            }
            else
            {
                var u = new Uri("pack://application:,,,/cross.png");
                var s = new BitmapImage(u);
                return s;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}