using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rivER
{
	public class RoomsViewModel : BaseViewModel
	{
		Room currentRoom;
		ObservableCollection<Room> nextRooms;

		IBeaconRangingService beaconRangingService;
		IRivERWebService rivERWebService;
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

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
					//TODO: This is silly, there must be a better way.
					Flags = value.Flags;
					BedVacant = value.BedVacant;
					InRoomPersonnel = value.InRoomPersonnel;
					RoomRequests = value.RoomRequests;
					BeaconId = value.BeaconId;
					BedURL = value.BedURL;
					RoomNumber = value.RoomNumber;

					currentRoom = value;
					OnPropertyChanged("Room");
				}
			}
		}

		public Flags Flags
		{
			get
			{
				return currentRoom.Flags;
			}
			set
			{
				if (currentRoom.Flags != value)
				{
					currentRoom.Flags = value;
					OnPropertyChanged("Flags");
				}
			}
		}
		public bool? BedVacant
		{
			get
			{
				return currentRoom.BedVacant;
			}
			set
			{
				if (currentRoom.BedVacant != value)
				{
					currentRoom.BedVacant = value;
					OnPropertyChanged("BedVacant");
				}
			}
		}
		public List<string> InRoomPersonnel
		{
			get
			{
				return currentRoom.InRoomPersonnel;
			}
			set
			{
				if (currentRoom.InRoomPersonnel != value)
				{
					currentRoom.InRoomPersonnel = value;
					OnPropertyChanged("InRoomPersonnel");
				}
			}
		}
		public List<string> RoomRequests
		{
			get
			{
				return currentRoom.RoomRequests;
			}
			set
			{
				if (currentRoom.RoomRequests != value)
				{
					currentRoom.RoomRequests = value;
					OnPropertyChanged("RoomRequests");
				}
			}
		}
		public string BeaconId
		{
			get
			{
				return currentRoom.BeaconId;
			}
			set
			{
				if (currentRoom.BeaconId != value)
				{
					currentRoom.BeaconId = value;
					OnPropertyChanged("BeaconId");
				}
			}
		}
		public string BedURL
		{
			get
			{
				return currentRoom.BedURL;
			}
			set
			{
				if (currentRoom.BedURL != value)
				{
					currentRoom.BedURL = value;
					OnPropertyChanged("BedURL");
				}
			}
		}
		public int? RoomNumber
		{
			get
			{
				return currentRoom.RoomNumber;
			}
			set
			{
				if (currentRoom.RoomNumber != value)
				{
					currentRoom.RoomNumber = value;
					OnPropertyChanged("RoomNumber");
				}
			}
		}


		public ObservableCollection<Room> NextRooms
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
			currentRoom = new Room();

			beaconRangingService.DidRangeBeacons += Beacon_DidRangeBeacons;

			beaconRangingService.StartMonitoring("B9407F30-F5F8-466E-AFF9-25556B57FE6D", "ER-Rooms");
			//beaconRangingService.StartMonitoring("487C659C-1FE2-4D2A-A289-130BBD7E534F", "ER-Rooms");

		}

		async Task OnBeaconDidRangeBeaconsAsync(BeaconRangedEventArgs e)
		{
			var newRoomNumber = e.beaconMinorID;

			if (newRoomNumber.HasValue)
			{
				try
				{
					if (RoomNumber.HasValue)
					{
						await rivERWebService.PostPersonnelOutOfRoom(RoomNumber.Value, Helpers.Settings.PersonnelID);
					}
					await rivERWebService.PostPersonnelIntoRoom(newRoomNumber.Value, Helpers.Settings.PersonnelID);
					CurrentRoom = await rivERWebService.GetRoomReadRoom(newRoomNumber.Value);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				GetBedVacantAsync();
				GetFlagsAsync();
			}
			else
			{
				if (RoomNumber.HasValue)
				{
					try
					{
						await rivERWebService.PostPersonnelOutOfRoom(RoomNumber.Value, Helpers.Settings.PersonnelID);
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine(ex.Message);
					}
					cancellationTokenSource.Cancel();
					CurrentRoom = new Room();
				}
			}
		}

		async void GetBedVacantAsync()
		{
			var token = cancellationTokenSource.Token;

			try
			{
				await Task.Factory.StartNew(async () =>
				{
					while (true)
					{
						if (RoomNumber.HasValue)
						{
							BedVacant = await rivERWebService.GetRoomReadBedVacant(RoomNumber.Value);
						}

						await Task.Delay(1000);

						if (token.IsCancellationRequested)
							break;
					}
				}, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			}
			catch (OperationCanceledException e)
			{
				System.Diagnostics.Debug.WriteLine("Cancel GetBedVacantAsync ex {0}", e.Message);
			}
		}

		async void GetFlagsAsync()
		{
			var token = cancellationTokenSource.Token;

			try
			{
				await Task.Factory.StartNew(async () =>
				{
					while (true)
					{
						if (RoomNumber.HasValue)
						{
							Flags = await rivERWebService.GetRoomReadFlags(RoomNumber.Value);
						}

						await Task.Delay(1000);

						if (token.IsCancellationRequested)
							break;
					}
				}, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			}
			catch (OperationCanceledException e)
			{
				System.Diagnostics.Debug.WriteLine("Cancel GetBedVacantAsync ex {0}", e.Message);
			}
		}

		async void Beacon_DidRangeBeacons(object sender, BeaconRangedEventArgs e)
		{
			await OnBeaconDidRangeBeaconsAsync(e);
		}
	}
}
