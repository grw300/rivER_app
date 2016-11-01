using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rivER
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();
		}

		public void OnOKClicked(object sender, EventArgs args)
		{
			Navigation.PopModalAsync();
		}
	}
}
