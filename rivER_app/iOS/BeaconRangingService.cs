using System;
using Foundation;
using Xamarin.Forms;
using CoreLocation;
using System.Linq;

[assembly: Dependency(typeof(rivER.iOS.BeaconRangingService))]
namespace rivER.iOS
{
	public class BeaconRangingService : IBeaconRangingService
	{
		CLLocationManager locationManager = new CLLocationManager();
		CLBeaconRegion beaconRegion;
        int? previousBeacon;

		public event EventHandler<BeaconRangedEventArgs> DidRangeBeacons;

		public void StartMonitoring(string uuid, string id)
		{
			var beaconUUID = new NSUuid(uuid);
			beaconRegion = new CLBeaconRegion(beaconUUID, id);

			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationManager.RequestAlwaysAuthorization();
            locationManager.DistanceFilter = 0.5;

            locationManager.RegionEntered += (object sender, CLRegionEventArgs e) =>
			{
				//This can be used for firing events when personnel come into hospitals.
			};

			locationManager.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) =>
			{
				if (e?.Beacons.Length > 0)
				{
					var beacon = e.Beacons.FirstOrDefault();
                    int? roomBeacon;

                    switch (beacon.Proximity)
					{

						case CLProximity.Far:
                        case CLProximity.Unknown:
                            roomBeacon = null;
                            break;
                        default:
							roomBeacon = beacon.Minor.Int32Value;
							break;
					}

                    if (roomBeacon != previousBeacon)
                    {
                        OnDidRangeBeacons(new BeaconRangedEventArgs(roomBeacon));
                    }
                    previousBeacon = roomBeacon;
                }
			};

			locationManager.StartMonitoring(beaconRegion);
			locationManager.StartRangingBeacons(beaconRegion);
		}
		protected virtual void OnDidRangeBeacons(BeaconRangedEventArgs e)
		{
			DidRangeBeacons?.Invoke(this, e);
		}

		public void AltBeaconStart()
		{
			throw new NotImplementedException("You should never call this in iOS, it's only to support AltBeacons on Android.");
		}
	}
}
