using Xamarin.Forms;
using BottomBar.XamarinForms;

namespace rivER
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			BottomBarPage bottomBarPage = new BottomBarPage();
			bottomBarPage.BarBackgroundColor = Color.Aqua;

			string[] tabTitles = { "Home", "Pager", "Timer" };
			string[] tabColors = { null, "#5D4037", "#7B1FA2" };

			for (int i = 0; i < tabTitles.Length; ++i)
			{
				string title = tabTitles[i];
				string tabColor = tabColors[i];

				FileImageSource icon = (FileImageSource)FileImageSource.FromFile(string.Format("{0}.png", title.ToLowerInvariant()));

				// create tab page
				var tabPage = new rivERPage()
				{
					Title = title,
					Icon = icon
				};

				// set tab color
				if (tabColor != null)
				{
					tabPage.SetTabColor(Color.FromHex(tabColor));
				}

				// set label based on title
				tabPage.UpdateLabel();

				// add tab pag to tab control
				bottomBarPage.Children.Add(tabPage);
			}

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
