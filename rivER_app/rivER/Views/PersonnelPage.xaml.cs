using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rivER
{
	public partial class PersonnelPage : ContentPage
	{
		public PersonnelPage()
		{
			InitializeComponent();

			BindingContext = new PersonnelViewModel(Navigation);
		}

		//public void OnAcknowledge(object sender, EventArgs e)
		//{
		//	var mi = ((MenuItem)sender);
		//	var request = (Request)mi.CommandParameter;
		//	request.State = true;
		//}

		//TODO: Figure out how to disable the menu item from here.
		//void Handle_Clicked(object sender, System.EventArgs e)
		//{
		//	var menuItem = (MenuItem)sender;
		//}
	}
}
