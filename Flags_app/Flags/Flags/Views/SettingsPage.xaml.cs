using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Flags
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			BindingContext = new SettingsViewModel();
		}

		public void OnOKClicked(object sender, EventArgs args)
		{
			Helpers.Settings.ServerAddress = ServerAddress.Text;
			Helpers.Settings.Room = Room.Text;
			Navigation.PopModalAsync();
		}
	}
}
