using System;
using Xamarin.Forms;
using AltBeaconOrg.BoundBeacon;
using System.Linq;

[assembly: Dependency(typeof(rivER.Droid.BeaconRangingService))]
namespace rivER.Droid
{
    public class BeaconRangingService : Java.Lang.Object, IBeaconRangingService
	{

        BeaconManager beaconManager;
        MonitorNotifier monitorNotifier;
        RangeNotifier rangeNotifier;
        Region beaconRegion;

		public event EventHandler<BeaconRangedEventArgs> DidRangeBeacons;

        public void StartMonitoring(string uuid, string id)
        {
            beaconManager = BeaconManager.GetInstanceForApplication(Forms.Context.ApplicationContext);
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
				if (e.Beacons.Count > 0)
				{
					var beacon = (e.Beacons.Count > 1) ?
						e?.Beacons.Aggregate((b1, b2) => b1.Distance < b2.Distance ? b1 : b2) : e.Beacons.FirstOrDefault();
					
					int? roomBeacon;

					if (isBetween(beacon.Distance, 0, 2))
					{
						roomBeacon = beacon.Id3.ToInt();
					}
					else
					{
						roomBeacon = null;
					}

					OnDidRangeBeacons(new BeaconRangedEventArgs(roomBeacon));
				}
			};
            beaconManager.SetBackgroundMode(false);
            beaconManager.Bind((IBeaconConsumer)Forms.Context);
        }

		static bool isBetween(double x, double lower, double upper)
		{
			return lower <= x && x <= upper;
		}

        public void AltBeaconStart()
        {
            beaconManager.StartMonitoringBeaconsInRegion(beaconRegion);
            beaconManager.StartRangingBeaconsInRegion(beaconRegion);
        }
        protected virtual void OnDidRangeBeacons(BeaconRangedEventArgs e)
        {
            DidRangeBeacons?.Invoke(this, e);
        }

    }
}
