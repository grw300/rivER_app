using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace rivER
{
	public class Room
	{
		public Flags Flags { get; set; }
		public bool? BedVacant { get; set; }
		public List<string> InRoomPersonnel { get; set; }
		public List<string> RoomRequests { get; set; }
		public string BeaconId { get; set; }
		public string BedURL { get; set; }
		public int? RoomNumber { get; set; }

		public Room()
		{
			this.Flags = new Flags();
			this.Flags.State = new bool[] { false, false, false, false };
			this.Flags.Color = new int[] { -1, -1, -1, -1 };
		}
	}
}

