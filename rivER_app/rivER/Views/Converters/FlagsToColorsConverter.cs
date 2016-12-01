using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace rivER
{
	public class FlagsToColorsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var valueAsFlags = (Flags)value;
			var flagColors = valueAsFlags.State.Zip(valueAsFlags.Color, (s, c) => new FlagColor(s, c));
			List<Color> colors = new List<Color>();

			/* 
             * Item1 is wether the specific flag is off (false) or on (true).
             * Item2 corresponds to colors (0: Blue, 1: Red, 2: Green, 3: Yellow).
             * 'off' colors are darker, 'on' colors are brighter
             * TODO: Item2 could be an enum or struct for the available flag colors
             *       That would allow for much easier addition of colors.
             */
			foreach (var flagColor in flagColors)
			{
				if (flagColor.Color.Item1)
				{
					switch (flagColor.Color.Item2)
					{
						case 0:
							colors.Add(Color.FromHex("#ED1C24"));
							break;
						case 1:
							colors.Add(Color.FromHex("#00A2E8"));
							break;
						case 2:
							colors.Add(Color.FromHex("#22B14C"));
							break;
						case 3:
							colors.Add(Color.FromHex("#FFF200"));
							break;
						default:
							colors.Add(Color.FromHex("#808080"));
							break;
					}
				}
				else
				{
					switch (flagColor.Color.Item2)
					{
						case 0:
							colors.Add(Color.FromHex("#6C0000"));
							break;
						case 1:
							colors.Add(Color.FromHex("#114451"));
							break;
						case 2:
							colors.Add(Color.FromHex("#4D620B"));
							break;
						case 3:
							colors.Add(Color.FromHex("#9B9400"));
							break;
						default:
							colors.Add(Color.FromHex("#808080"));
							break;
					}
				}
			}
			return colors;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}

}

