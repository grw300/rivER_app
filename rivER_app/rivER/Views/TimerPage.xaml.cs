using Xamarin.Forms;

namespace rivER
{
	public partial class TimerPage : ContentPage
	{
		public TimerPage()
		{
			InitializeComponent();

			BindingContext = new TimerViewModel(Navigation);
		}
	}
}
