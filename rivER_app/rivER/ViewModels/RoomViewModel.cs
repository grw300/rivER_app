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
	public class RoomViewModel : BaseViewModel
	{
		#region TODO: this stuff and its methods should be in a Model!
		private static readonly string RIVER_WEBSERVICE_URL_FORMAT = "http://{0}/{1}/{2}";

		private HttpClient client = new HttpClient();
		private Tuple<string, StringContent> leaveRoom;

		public Room CurrentRoom { get; set; }
		public PersonnelID Personnel { get; set; }

		private IBeacon beacon;
		#endregion

		private IEnumerable<FlagColor> currentRoomFlagColors;
		private List<Room> nextRooms;



		public IEnumerable<FlagColor> CurrentRoomFlagColors
		{
			get
			{
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
				return this.CurrentRoom.Name;
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
					OnPropertyChanged("CurrentRoomOccupied");
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

		private async Task GetCurrentRoomAsync()
		{
			if (this.leaveRoom != null)
			{
				await client.PostAsync(this.leaveRoom.Item1, this.leaveRoom.Item2);
				this.leaveRoom = null;
			}

			/* 
 			 * TODO: expand room object to mimic the LabVIEW Room
 			 */
			string[] urlStringParams = new string[] {
				Helpers.Settings.ServerAddress,
				"RivERWebService",
				string.Format("GetRoom?Room={0}&Command=ReadRoom",  CurrentRoom.Name)};
			string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

			try
			{
				HttpResponseMessage response = await client.GetAsync(urlString);

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var token = JObject.Parse(content);

					var flag = token.SelectToken("Flags");
					this.CurrentRoom.Flag = JsonConvert.DeserializeObject<Flag>(flag.ToString());
					this.CurrentRoomFlagColors = UpdateCurrentRoomFlagColors();
					this.CurrentRoomOccupied = !(bool)token.SelectToken("BedVacant");
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
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(@"WEB ERROR {0}", e.Message);
			}
		}

		private async Task PostInRoomPersonellAsync()
		{
			string[] urlStringParams = new string[] {
				Helpers.Settings.ServerAddress,
				"RivERWebService",
				"PostRoom"};

			string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);
			var postString = string.Format("Room={0}&Data={1}&Command=AddPersonnel",
										CurrentRoom.Name,
										JsonConvert.SerializeObject(this.Personnel));

			try
			{
				var postContent = new StringContent(postString, Encoding.UTF8, "application/x-www-form-urlencoded");

				HttpResponseMessage response = await client.PostAsync(urlString, postContent);

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					/*
					 * TODO: Verify the personnel ID was posted with content
					 */
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
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(@"WEB ERROR {0}", e.Message);
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
				string[] urlStringParams = new string[] {
				Helpers.Settings.ServerAddress,
				"RivERWebService",
				"PostRoom"};

				await GetCurrentRoomAsync();
				await PostInRoomPersonellAsync();

				string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);
				var postString = string.Format("Room={0}&Data={1}&Command=RemovePersonnel",
											CurrentRoom.Name,
											JsonConvert.SerializeObject(this.Personnel));

				try
				{
					var postContent = new StringContent(postString, Encoding.UTF8, "application/x-www-form-urlencoded");

					this.leaveRoom = new Tuple<string, StringContent>(
						urlString,
						postContent
					);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(@"WEB ERROR {0}", ex.Message);
				}
			}

		}

		public RoomViewModel(INavigation navigation) : base(navigation)
		{
			beacon = DependencyService.Get<IBeacon>();

			this.CurrentRoom = new Room();
			this.Personnel = new PersonnelID();
			this.CurrentRoomFlagColors = new List<FlagColor>()
			{
				new FlagColor(false,-1),
				new FlagColor(false,-1),
				new FlagColor(false,-1),
				new FlagColor(false,-1)
			};

			var test = this.Commands;

			PropertyChanged += RoomViewModel_PropertyChanged;

			beacon.DidRangeBeacons += (object sender, BeaconEventArgs e) =>
			{
				this.CurrentRoomName = e.beacon.Value;
			};



			beacon.StartMonitoring("B9407F30-F5F8-466E-AFF9-25556B57FE6D", "ER-Rooms");
		}
	}
}
