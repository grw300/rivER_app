using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rivER
{
	public partial class PagerPage : ContentPage
	{
		public PagerPage()
		{
			InitializeComponent();
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
