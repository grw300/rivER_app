using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text;

namespace rivER
{
	public class RoomsViewModel : BaseViewModel
	{
		public Room currentRoom = new Room();

		private List<Room> nextRooms;

		private IRivERWebService rivERWebService;
		private IBeaconRangingService beaconRangingService;

		public Room CurrentRoom
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

		public List<Room> NextRooms
		{
			get
			{
				return nextRooms;
			}
			set
			{
				if (nextRooms != value)
				{
					nextRooms = value;
					OnPropertyChanged("NextRooms");
				}
			}
		}

		public RoomsViewModel(INavigation navigation) : base(navigation)
		{
			rivERWebService = new RivERWebService();

			beaconRangingService = DependencyService.Get<IBeaconRangingService>();
			beaconRangingService.DidRangeBeacons += Beacon_DidRangeBeacons;

			//beaconRangingService.StartMonitoring("B9407F30-F5F8-466E-AFF9-25556B57FE6D", "ER-Rooms");
			beaconRangingService.StartMonitoring("487C659C-1FE2-4D2A-A289-130BBD7E534F", "ER-Rooms");
		}

		async Task OnBeaconDidRangeBeaconsAsync(BeaconRangedEventArgs e)
		{
			var roomNumber = e.beaconMinorID;

			if (roomNumber.HasValue)
			{
				await rivERWebService.PostPersonnelIntoRoom(roomNumber.Value, Helpers.Settings.PersonnelID);
				this.CurrentRoom = await rivERWebService.GetRoomReadRoom(roomNumber.Value);
			}
			else
			{
				if (this.CurrentRoom.RoomNumber.HasValue)
				{
					await rivERWebService.PostPersonnelOutOfRoom(this.CurrentRoom.RoomNumber.Value, Helpers.Settings.PersonnelID);
					this.CurrentRoom = new Room();
				}
			}
		}

		async void Beacon_DidRangeBeacons(object sender, BeaconRangedEventArgs e)
		{
			await OnBeaconDidRangeBeaconsAsync(e);
		}

	}
}
