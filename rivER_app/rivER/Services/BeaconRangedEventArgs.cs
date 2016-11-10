using System;

namespace rivER
{
	public class BeaconRangedEventArgs : EventArgs
	{
		public int? beaconMinorID;

		public BeaconRangedEventArgs(int? beaconMinorID)
		{
			this.beaconMinorID = beaconMinorID;
		}
	}
}
