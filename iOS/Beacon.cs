using System;
using Foundation;
using Xamarin.Forms;
using CoreLocation;
using System.Linq;

[assembly: Dependency(typeof(rivER.iOS.Beacon))]
namespace rivER.iOS
{
	public class Beacon : IBeacon
	{
		CLLocationManager locationManager = new CLLocationManager();
		CLBeaconRegion beaconRegion;

		public event EventHandler<BeaconEventArgs> DidRangeBeacons;

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
                    var roomBeacon = new RoomBeacon();

                    switch (beacon.Proximity)
					{

						case CLProximity.Far:
                        case CLProximity.Unknown:
                            roomBeacon.Value = "Not in a room.";
                            OnDidRangeBeacons(new BeaconEventArgs(roomBeacon));
                            break;
                        default:
                            roomBeacon.Value = beacon.Minor.StringValue;
							OnDidRangeBeacons(new BeaconEventArgs(roomBeacon));
							break;
					}
				}
			};

			locationManager.StartMonitoring(beaconRegion);
			locationManager.StartRangingBeacons(beaconRegion);
		}
		protected virtual void OnDidRangeBeacons(BeaconEventArgs e)
		{
			DidRangeBeacons?.Invoke(this, e);
		}

		public void AltBeaconStart()
		{
			throw new NotImplementedException("You should never call this in iOS, it's only to support AltBeacons");
		}
	}
}
