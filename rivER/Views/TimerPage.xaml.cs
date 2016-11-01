﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rivER
{
	public partial class TimerPage : ContentPage
	{
		public TimerPage()
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
