using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AltBeaconOrg.BoundBeacon;
using AltBeaconOrg.BoundBeacon.Startup;

namespace rivER.Droid
{
	[Activity(Label = "rivER.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IBeaconConsumer, IBootstrapNotifier
	{
		readonly string[] PermissionsLocation =
		{
			Android.Manifest.Permission.AccessCoarseLocation,
			Android.Manifest.Permission.AccessFineLocation
		};

		const int RequestLocationId = 0;

		public void OnBeaconServiceConnect()
		{
			var beaconService = Xamarin.Forms.DependencyService.Get<IBeaconRangingService>();

			if ((int)Build.VERSION.SdkInt < 23)
			{
				beaconService.AltBeaconStart();
				return;
			}

			RequestPermissions(PermissionsLocation, RequestLocationId);
			beaconService.AltBeaconStart();
		}

		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

		public void DidDetermineStateForRegion(int state, Region region)
		{
			throw new NotImplementedException();
		}

		public void DidEnterRegion(Region region)
		{
			throw new NotImplementedException();
		}

		public void DidExitRegion(Region region)
		{
			throw new NotImplementedException();
		}
	}
}
