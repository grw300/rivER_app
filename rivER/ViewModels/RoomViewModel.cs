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

		HttpClient client = new HttpClient();

		string currentRoomName;
		Room currentRoom;
		List<Room> rooms;
		IBeacon beacon;

		public RoomViewModel()
		{
			beacon = DependencyService.Get<IBeacon>();

			beacon.DidRangeBeacons += (object sender, BeaconEventArgs e) =>
			{
				this.CurrentRoomName = e.beacon.Value;
			};

			beacon.StartMonitoring("487C659C-1FE2-4D2A-A289-130BBD7E534F", "ER-Rooms");
		}

		public string CurrentRoomName
		{
			get
			{
				return currentRoomName;
			}
			set
			{
				if (currentRoomName != value)
				{
					currentRoomName = value;

					try
					{
						var result = JsonConvert.DeserializeObject<Flag>(GetRoomStateAsync().Result);

						this.CurrentRoom = new Room();

						this.CurrentRoom.Flag = result;
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
							else {
								throw;
							}
						}
					}

					OnPropertyChanged("CurrentRoomName");
				}
			}
		}

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
					OnPropertyChanged("CurrentRoomState");
				}
			}
		}

		public List<FlagColor> FlagColors
		{
			get
			{
				return currentRoom.Flag.FlagColor.ToList();
			}
		}


		public List<Room> Rooms
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

		private Task<string> GetRoomStateAsync()
		{
			/*Hardcoded for the time being; these will correspond to the current room after we setup the beacons.
			,*/
			string[] urlStringParams = new string[] { 
				Helpers.Settings.ServerAddress, "RivERWebService", "GetRoom?Room=102&Command=ReadFlag" };
			
			string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);
			return client.GetStringAsync(urlString);
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
