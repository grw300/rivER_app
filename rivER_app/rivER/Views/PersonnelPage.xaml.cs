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

        public void OnStateChange(object sender, EventArgs e)
        {
            var viewCell = ((ViewCell)sender);
            var request = (Request)viewCell.BindingContext;
            if (request.State.HasValue)
            {
                viewCell.ContextActions.RemoveAt(0);
            }
        }

        //TODO: Figure out how to disable the menu item from here.
        //void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //	var menuItem = (MenuItem)sender;
        //}
    }
}
