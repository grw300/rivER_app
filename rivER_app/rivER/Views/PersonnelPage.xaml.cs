using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rivER
{
	public partial class PersonnelPage : ContentPage
	{
		PersonnelViewModel personnelViewModel;
		public PersonnelPage()
		{
			InitializeComponent();

			personnelViewModel = new PersonnelViewModel(Navigation);
			BindingContext = personnelViewModel;
		}

		public void OnStateChange(object sender, EventArgs e)
		{
			var viewCell = ((ViewCell)sender);
			var request = (Request)viewCell.BindingContext;
			if (request.State.HasValue)
			{
				viewCell.ContextActions.RemoveAt(0);
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		protected override void OnAppearing()
		{
			base.OnDisappearing();
		}

		//TODO: Figure out how to disable the menu item from here.
		//void Handle_Clicked(object sender, System.EventArgs e)
		//{
		//	var menuItem = (MenuItem)sender;
		//}
	}
}
