using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Game2048.Converter
{
    public class ValueToColorConverter : IValueConverter
    {
        #region Colors
        private static readonly SolidColorBrush tile2Brush = GetSolidColorBrush(0, 128, 128, 255);
        private static readonly SolidColorBrush tile4Brush = GetSolidColorBrush(95, 158, 160, 255);
        private static readonly SolidColorBrush tile8Brush = GetSolidColorBrush(100, 149, 237, 255);
        private static readonly SolidColorBrush tile16Brush = GetSolidColorBrush(65, 105, 225, 255);
        private static readonly SolidColorBrush tile32Brush = GetSolidColorBrush(70, 130, 180, 255);
        private static readonly SolidColorBrush tile64Brush = GetSolidColorBrush(143, 188, 143, 255);
        private static readonly SolidColorBrush tile128Brush = GetSolidColorBrush(128, 128, 0, 255);
        private static readonly SolidColorBrush tile256Brush = GetSolidColorBrush(45, 107, 47, 255);
        private static readonly SolidColorBrush tile512Brush = GetSolidColorBrush(160, 82, 45, 255);
        private static readonly SolidColorBrush tile1024Brush = GetSolidColorBrush(139, 69, 19, 255);
        private static readonly SolidColorBrush tile2048Brush = GetSolidColorBrush(128, 0, 0, 255);
        private static readonly SolidColorBrush tileEmptyBrush = GetSolidColorBrush(18, 18, 18, 255);
        #endregion
        private static readonly Dictionary<string, Brush> titleBrushes = new()
        {
            { "2", tile2Brush },
            { "4", tile4Brush },
            { "8", tile8Brush },
            { "16", tile16Brush },
            { "32", tile32Brush },
            { "64", tile64Brush },
            { "128", tile128Brush },
            { "256", tile256Brush },
            { "512", tile512Brush },
            { "1024", tile1024Brush },
            { "2048", tile2048Brush },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (titleBrushes.TryGetValue((string)value, out Brush brush))
            {
                return brush;
            }
            else
                return tileEmptyBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static SolidColorBrush GetSolidColorBrush(byte r, byte g, byte b, byte a)
        {
            return new SolidColorBrush(GetColor(r, g, b, a));
        }

        private static Color GetColor(byte r, byte g, byte b, byte a)
        {
            return new Color { R = r, G = g, B = b, A = a };
        }
    }
}