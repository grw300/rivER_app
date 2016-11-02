using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace rivER
{
	public partial class RoomPage : ContentPage
	{
		public RoomPage()
		{
			InitializeComponent();

            BindingContext = new RoomViewModel();
		}

		public Command SettingsCommand
		{
			get
			{
				return new Command(() => Navigation.PushModalAsync(new SettingsPage()));
			}
		}
	}
}
