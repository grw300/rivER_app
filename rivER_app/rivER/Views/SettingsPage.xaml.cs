using Xamarin.Forms;

namespace rivER
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			BindingContext = new SettingsViewModel(Navigation);
		}
	}
}
