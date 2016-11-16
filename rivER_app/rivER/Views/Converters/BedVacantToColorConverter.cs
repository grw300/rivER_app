using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rivER
{
    public class BedVacantToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*
             * The occupancy is determined by sensors
             * and read from the server. We represent
             * 'occupied' (true) as Green and 
             * 'unoccupied' (false) as Gray.
             */
            var valueAsBool = (bool?)value;
			return valueAsBool.HasValue ? (valueAsBool.Value ? Color.Green : Color.Red) : Color.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
