using System;
using Xamarin.Forms;

namespace rivER
{
	public partial class RoomPage : ContentPage
	{
		void HandleItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null) return;
			((ListView)sender).SelectedItem = null;
		}

		public RoomPage()
		{
			InitializeComponent();

			BindingContext = new RoomsViewModel(Navigation);
		}

		//public void OnStateChange(object sender, EventArgs e)
		//{
		//	var viewCell = ((ViewCell)sender);
		//	var request = (Request)viewCell.BindingContext;
		//	var menuItem = (MenuItem)sender;
		//	var request = (Request)menuItem.CommandParameter;

		//	if (request.State.HasValue)
		//	{
		//		this.requestsListView....
		//	}
		//}
	}
}
