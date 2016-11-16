using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections.ObjectModel;

namespace rivER
{
    public class RoomsViewModel : BaseViewModel
    {

        private ObservableCollection<Room> nextRooms;

        private IRivERWebService rivERWebService;
        private IBeaconRangingService beaconRangingService;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		private Room currentRoom;
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
					this.Flags = value.Flags;
					this.BedVacant = value.BedVacant;
					this.InRoomPersonnel = value.InRoomPersonnel;
					this.RoomRequests = value.RoomRequests;
					this.BeaconId = value.BeaconId;
					this.BedURL = value.BedURL;
					this.RoomNumber = value.RoomNumber;

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
            var roomNumber = e.beaconMinorID;



			if (roomNumber.HasValue)
            {
				try
				{
					if (this.RoomNumber.HasValue)
					{
						await rivERWebService.PostPersonnelOutOfRoom(this.RoomNumber.Value, Helpers.Settings.PersonnelID);
					}
					await rivERWebService.PostPersonnelIntoRoom(roomNumber.Value, Helpers.Settings.PersonnelID);
					this.CurrentRoom = await rivERWebService.GetRoomReadRoom(roomNumber.Value);
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
                if (this.CurrentRoom.RoomNumber.HasValue)
                {
					try
					{
						await rivERWebService.PostPersonnelOutOfRoom(this.CurrentRoom.RoomNumber.Value, Helpers.Settings.PersonnelID);
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine(ex.Message);
					}
					cancellationTokenSource.Cancel();
                    this.CurrentRoom = new Room();
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
                        if (this.CurrentRoom.RoomNumber.HasValue)
                        {
                            var bedVacant = await rivERWebService.GetRoomReadBedVacant(this.RoomNumber.Value);
							this.BedVacant = bedVacant;
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
                        if (this.CurrentRoom.RoomNumber.HasValue)
                        {
                            var flags = await rivERWebService.GetRoomReadFlags(this.CurrentRoom.RoomNumber.Value);
                            if (flags != this.CurrentRoom.Flags)
                            {
                                this.CurrentRoom.Flags = flags;
                            }
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
