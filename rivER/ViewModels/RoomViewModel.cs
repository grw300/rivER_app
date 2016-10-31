using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace rivER
{
	public class RoomViewModel : INotifyPropertyChanged
	{
		string currentRoom;
		List<string> rooms;
		IBeacon beacon;

		public RoomViewModel()
		{
			beacon = DependencyService.Get<IBeacon>();

			beacon.DidRangeBeacons += (object sender, BeaconEventArgs e) =>
			{
				this.CurrentRoom = e.beacon.Value;
			};

			beacon.StartMonitoring("487C659C-1FE2-4D2A-A289-130BBD7E534F", "ER-Rooms");
		}

		public string CurrentRoom
		{
			get
			{
				return currentRoom;
			}
			set
			{
				if (currentRoom != value)
				{
					currentRoom = value;
					OnPropertyChanged("CurrentRoom");
				}
			}
		}

		public List<string> Rooms
		{
			get
			{
				return rooms;
			}
			set
			{
				if (rooms != value)
				{
					rooms = value;
					OnPropertyChanged("Rooms");
				}
			}
		}
				

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
