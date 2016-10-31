using System;
using Xamarin.Forms;
using AltBeaconOrg.BoundBeacon;
using System.Linq;

[assembly: Dependency(typeof(rivER.Droid.Beacon))]
namespace rivER.Droid
{
	public class Beacon : Java.Lang.Object, IBeacon
	{

		BeaconManager beaconManager;
		MonitorNotifier monitorNotifier;
		RangeNotifier rangeNotifier;
		Region beaconRegion;

		public event EventHandler<BeaconEventArgs> DidRangeBeacons;

		public void StartMonitoring(string uuid, string id)
		{
			beaconManager = BeaconManager.GetInstanceForApplication(Xamarin.Forms.Forms.Context.ApplicationContext);
			beaconManager.BeaconParsers.Add(new BeaconParser().
												SetBeaconLayout("m:2-3=0215,i:4-19,i:20-21,i:22-23,p:24-24"));
			
			beaconRegion = new Region(id, Identifier.Parse(uuid), null, null);

			monitorNotifier = new MonitorNotifier();
			rangeNotifier = new RangeNotifier();

			beaconManager.SetRangeNotifier(rangeNotifier);
			beaconManager.SetMonitorNotifier(monitorNotifier);

			monitorNotifier.EnterRegionComplete += (object obj, MonitorEventArgs e) =>
			{
				//This can be used for firing events when personnel come into hospitals.
			};

			rangeNotifier.DidRangeBeaconsInRegionComplete += (object sender, RangeEventArgs e) =>
			{
				var beacon = e.Beacons.Aggregate((b1, b2) => b1.Distance < b2.Distance ? b1 : b2);
				var roomBeacon = new RoomBeacon(beacon.Id3.ToString());
				OnDidRangeBeacons(new BeaconEventArgs(roomBeacon));
			};

			beaconManager.SetBackgroundMode(false);
			beaconManager.Bind((IBeaconConsumer)Xamarin.Forms.Forms.Context);
		}

		public void AltBeaconStart()
		{
			beaconManager.StartMonitoringBeaconsInRegion(beaconRegion);
			beaconManager.StartRangingBeaconsInRegion(beaconRegion);
		}
		protected virtual void OnDidRangeBeacons(BeaconEventArgs e)
		{
			DidRangeBeacons?.Invoke(this, e);
		}

	}
}
