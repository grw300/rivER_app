using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rivER
{
    public class StateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*
             * The state is tripartate:
             * null:  the request is recieved and no action has been taken               : Color.Transparent
             * true:  the request has been acknowledged                                  : Color.Green
             * false: the request is violating an invariant and an alarm has been raised : Color.Red
             */
            var valueAsBool = (bool?)value;
			return valueAsBool.HasValue ? (valueAsBool.Value ? Color.Green : Color.Red) : Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
