using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ViewModel
{
    public class PlayerColor : IValueConverter
    {
        // implementatie van interface aan de hand van xaml welke kleur deze moet krijgen

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Player)
            {
                if (value.ToString().Equals("B"))
                {
                    return new SolidColorBrush(Colors.Black);
                }
                else if (value.ToString().Equals("W"))
                {
                    return new SolidColorBrush(Colors.Yellow);
                }

            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
