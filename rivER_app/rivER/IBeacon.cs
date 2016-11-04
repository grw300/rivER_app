using System;
namespace rivER
{
	public interface IBeacon
	{
		void AltBeaconStart();
		void StartMonitoring(string uuid, string id);
		event EventHandler<BeaconEventArgs> DidRangeBeacons;
	}
}
