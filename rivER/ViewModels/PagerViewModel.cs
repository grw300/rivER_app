using System;

using Xamarin.Forms;

namespace rivER
{
	public class PagerViewModel : ContentPage
	{
		public PagerViewModel()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

