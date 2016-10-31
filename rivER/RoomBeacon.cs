using System;
namespace rivER
{
	sealed public class RoomBeacon : Beacon
	{
		public RoomBeacon(string room)
		{
			Value = room;
		}
		public override string Value { get; protected set; }
	}
}
