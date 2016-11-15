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
        public RoomViewModel currentRoom;

        private ObservableCollection<Room> nextRooms;

        private IRivERWebService rivERWebService;
        private IBeaconRangingService beaconRangingService;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public RoomViewModel CurrentRoom
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
            currentRoom = new RoomViewModel(navigation);

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
                this.CurrentRoom.Room = await rivERWebService.GetRoomReadRoom(roomNumber.Value);
                GetBedVacantAsync();
                GetFlagsAsync();
            }
            else
            {
                if (this.CurrentRoom.RoomNumber.HasValue)
                {
                    await rivERWebService.PostPersonnelOutOfRoom(this.CurrentRoom.RoomNumber.Value, Helpers.Settings.PersonnelID);
                    cancellationTokenSource.Cancel();
                    this.CurrentRoom.Room = new Room();
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
                            var bedVacant = await rivERWebService.GetRoomReadBedVacant(this.CurrentRoom.RoomNumber.Value);
                            if (bedVacant != this.CurrentRoom.BedVacant)
                            {
                                this.CurrentRoom.BedVacant = bedVacant;
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
