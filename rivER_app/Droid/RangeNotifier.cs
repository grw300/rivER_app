using System;
using System.Collections.Generic;
using AltBeaconOrg.BoundBeacon;

namespace rivER.Droid
{
	public class RangeEventArgs : EventArgs
	{
		public Region Region { get; set; }
		public ICollection<AltBeaconOrg.BoundBeacon.Beacon> Beacons { get; set; }
	}

	public class RangeNotifier : Java.Lang.Object, IRangeNotifier
	{
		public event EventHandler<RangeEventArgs> DidRangeBeaconsInRegionComplete;

		public void DidRangeBeaconsInRegion(ICollection<AltBeaconOrg.BoundBeacon.Beacon> beacons, Region region)
		{
			OnDidRangeBeaconsInRegion(beacons, region);
		}

		void OnDidRangeBeaconsInRegion(ICollection<AltBeaconOrg.BoundBeacon.Beacon> beacons, Region region)
		{
			DidRangeBeaconsInRegionComplete?.Invoke(this, new RangeEventArgs { Beacons = beacons, Region = region });
		}
	}
}
