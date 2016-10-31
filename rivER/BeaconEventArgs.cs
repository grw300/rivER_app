using System;
namespace rivER
{
	public class BeaconEventArgs : EventArgs
	{
		public Beacon beacon;

		public BeaconEventArgs(Beacon beacon)
		{
			this.beacon = beacon;
		}
	}
}
