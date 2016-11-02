/*using System;
using System.Globalization;
using Xamarin.Forms;

namespace rivER
{
	public class FlagColorToColorConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string valueAsFlagColor = Enum.TryParse<FlagColor>( (value);
			switch (valueAsString)
			{
				case (""):
					{
						return Color.Default;
					}
				case ("Accent"):
					{
						return Color.Accent;
					}
				default:
					{
						return Color.FromHex(value.ToString());
					}
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}

}*/

