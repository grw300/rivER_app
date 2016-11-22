using System;
using BottomBar.XamarinForms;
using Xamarin.Forms;

namespace rivER
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var bottomBarPage = new BottomBarPage();
			bottomBarPage.BarBackgroundColor = Color.Aqua;

			string[] tabTitles = { "Room", "Pager", "Timer" };

			for (int i = 0; i < tabTitles.Length; ++i)
			{
				string title = tabTitles[i];

				var icon = (FileImageSource)ImageSource.FromFile(string.Format("{0}.png", title.ToLowerInvariant()));

				ContentPage tabPage;

				switch (tabTitles[i])
				{
					case "Room":
						tabPage = new RoomPage();
						break;
					case "Pager":
						tabPage = new PersonnelPage();
						break;
					case "Timer":
						tabPage = new TimerPage();
						break;
					default:
						throw new Exception("You're trying to create a page that hasn't been defined");
				}

				// create tab page
				tabPage.Title = title;
				tabPage.Icon = icon;

				// add tab pag to tab control
				bottomBarPage.Children.Add(tabPage);
			}

			/* 
             * TODO: push settings if there's no Server Address set
             */
			MainPage = bottomBarPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
