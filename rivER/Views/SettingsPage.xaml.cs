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

			BindingContext = new SettingsViewModel();
		}

		public void OnOKClicked(object sender, EventArgs args)
		{
			Helpers.Settings.ServerAddress = ServerAddress.Text;
			Helpers.Settings.PersonnelID = PersonnelID.Text;
			Navigation.PopModalAsync();
		}
	}
}
