using System;

namespace rivER
{
	public interface IBeaconRangingService
	{
		void AltBeaconStart();
		void StartMonitoring(string uuid, string id);
		event EventHandler<BeaconRangedEventArgs> DidRangeBeacons;
	}
}
