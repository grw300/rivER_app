using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace rivER
{
	public abstract class BaseViewModel : ObservableProperty
	{
		public INavigation Navigation { get; protected set; }
		public Dictionary<string, ICommand> Commands { get; protected set; }

		protected BaseViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Commands = new Dictionary<string, ICommand>();
			Commands.Add("SettingsPageCommand", new Command(() => Navigation.PushModalAsync(new SettingsPage())));
		}
	}
}
