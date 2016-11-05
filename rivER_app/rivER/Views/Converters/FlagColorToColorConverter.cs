using System;
using System.Globalization;
using Xamarin.Forms;

namespace rivER
{
	public class FlagColorToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var valueAsFlagColor = (Tuple<bool, int>)value;
			Color color;

			/* 
             * Item1 is wether the specific flag is off (false) or on (true).
             * Item2 corresponds to colors (0: Blue, 1: Red, 2: Green, 3: Yellow).
             * 'off' colors are darker, 'on' colors are brighter
             * TODO: Item2 could be an enum or struct for the available flag colors
             *       That would allow for much easier addition of colors.
             */
			if (valueAsFlagColor.Item1)
			{
				switch (valueAsFlagColor.Item2)
				{
					case 0:
						color = Color.FromHex("#ED1C24");
						break;
					case 1:
						color = Color.FromHex("#00A2E8");
						break;
					case 2:
						color = Color.FromHex("#22B14C");
						break;
					case 3:
						color = Color.FromHex("#FFF200");
						break;
					default:
						color = Color.FromHex("#808080");
						break;
				}
			}
			else
			{
				switch (valueAsFlagColor.Item2)
				{
					case 0:
						color = Color.FromHex("#6C0000");
						break;
					case 1:
						color = Color.FromHex("#114451");
						break;
					case 2:
						color = Color.FromHex("#4D620B");
						break;
					case 3:
						color = Color.FromHex("#9B9400");
						break;
					default:
						color = Color.FromHex("#808080");
						break;
				}
			}
			return color;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}

}

