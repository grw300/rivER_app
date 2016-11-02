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

namespace rivER
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        private static readonly string RIVER_WEBSERVICE_URL_FORMAT = "http://{0}/{1}/{2}";

        private HttpClient client = new HttpClient();

        private IEnumerable<FlagColor> currentRoomFlagColors;
        private List<Room> nextRooms;
        private IBeacon beacon;

        public Room CurrentRoom { get; set; }

        public IEnumerable<FlagColor> CurrentRoomFlagColors
        {
            get
            {
                //return new List<FlagColor>()
                //{
                //    new FlagColor(false, 0) ,
                //    new FlagColor(false, 1) ,
                //    new FlagColor(false, 2) ,
                //    new FlagColor(false, 3)
                //};
                return currentRoomFlagColors;
            }
            set
            {
                if (currentRoomFlagColors != value)
                {
                    currentRoomFlagColors = value;
                    OnPropertyChanged("CurrentRoomFlagColors");
                }
            }
        }

        public string CurrentRoomName
        {
            get
            {
                return this.CurrentRoom?.Name;
            }
            set
            {
                if (this.CurrentRoom?.Name != value)
                {
                    this.CurrentRoom.Name = value;
                    OnPropertyChanged("CurrentRoomName");
                }
            }
        }

        public bool CurrentRoomOccupied
        {
            get
            {
                return this.CurrentRoom.Occupied;
            }
            set
            {
                if (this.CurrentRoom.Occupied != value)
                {
                    this.CurrentRoom.Occupied = value;
                    OnPropertyChanged("CurrentRoomName");
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
                    OnPropertyChanged("Rooms");
                }
            }
        }

        private async Task SetCurrentRoomFlagAsync()
        {
            string[] urlStringParams = new string[] {
                Helpers.Settings.ServerAddress, "RivERWebService", "GetRoom?Room=102&Command=ReadFlag" };
            string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

            try
            {
                HttpResponseMessage response = await client.GetAsync(urlString);
                //Condition: true
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    /*var content = @"{'State': ['false','false','false','false'],
                                     'Color': ['0','1','2','3']
                        }";*/
                    this.CurrentRoom.Flag = JsonConvert.DeserializeObject<Flag>(content);
                    this.CurrentRoomFlagColors = UpdateCurrentRoomFlagColors();
                }
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    // Handle the HttpRequest exception.
                    if (e is HttpRequestException)
                    {
                        System.Diagnostics.Debug.WriteLine(@"HTTP ERROR {0}", e.Message);
                    }
                    // Rethrow any other exception.
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private IEnumerable<FlagColor> UpdateCurrentRoomFlagColors()
        {
            return CurrentRoom.Flag.State.Zip(this.CurrentRoom.Flag.Color, (s, c) => new FlagColor(s, c));

        }

        private async void RoomViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentRoomName")
            {
                await SetCurrentRoomFlagAsync();
            }

        }

        public RoomViewModel()
        {
            beacon = DependencyService.Get<IBeacon>();

            this.CurrentRoom = new Room();

            PropertyChanged += RoomViewModel_PropertyChanged;

            beacon.DidRangeBeacons += (object sender, BeaconEventArgs e) =>
            {
                this.CurrentRoomName = e.beacon.Value;
            };

            beacon.StartMonitoring("487C659C-1FE2-4D2A-A289-130BBD7E534F", "ER-Rooms");
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
