using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace rivER
{
	public class RoomViewModel : INotifyPropertyChanged
	{
		private static readonly string RIVER_WEBSERVICE_URL_FORMAT = "http://{0}/{1}/{2}";

		HttpClient client = new HttpClient();

		string currentRoom;
		bool currentRoomState;
		List<Room> rooms;
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

					try
					{
						var result = JsonConvert.DeserializeObject<Flag>(GetRoomStateAsync().Result);

						this.CurrentRoomState = result.FlagState[0];
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

					OnPropertyChanged("CurrentRoom");
				}
			}
		}

		public bool CurrentRoomState
		{
			get
			{
				return currentRoomState;
			}
			set
			{
				if (currentRoomState != value)
				{
					currentRoomState = value;
					OnPropertyChanged("CurrentRoomState");
				}
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
