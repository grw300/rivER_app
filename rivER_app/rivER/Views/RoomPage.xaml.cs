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

			BindingContext = new RoomViewModel(Navigation);
		}
	}
}
