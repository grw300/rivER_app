using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace Flags
{
	class FlagViewModel : INotifyPropertyChanged
	{
		private static readonly string RIVER_WEBSERVICE_URL_FORMAT = "http://{0}:{1}/{2}/{3}";

		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		private HttpClient client = new HttpClient();

		private Tuple<bool, int> currentRoomFlag0Color;
		private Tuple<bool, int> currentRoomFlag1Color;
		private Tuple<bool, int> currentRoomFlag2Color;
		private Tuple<bool, int> currentRoomFlag3Color;

		public Tuple<bool, int> CurrentRoomFlag0Color
		{
			get
			{
				return currentRoomFlag0Color;
			}
			set
			{
				if (currentRoomFlag0Color != value)
				{
					currentRoomFlag0Color = value;
					OnPropertyChanged("CurrentRoomFlag0Color");
				}
			}
		}
		public Tuple<bool, int> CurrentRoomFlag1Color
		{
			get
			{
				return currentRoomFlag1Color;
			}
			set
			{
				if (currentRoomFlag1Color != value)
				{
					currentRoomFlag1Color = value;
					OnPropertyChanged("CurrentRoomFlag1Color");
				}
			}
		}
		public Tuple<bool, int> CurrentRoomFlag2Color
		{
			get
			{
				return currentRoomFlag2Color;
			}
			set
			{
				if (currentRoomFlag2Color != value)
				{
					currentRoomFlag2Color = value;
					OnPropertyChanged("CurrentRoomFlag2Color");
				}
			}
		}
		public Tuple<bool, int> CurrentRoomFlag3Color
		{
			get
			{
				return currentRoomFlag3Color;
			}
			set
			{
				if (currentRoomFlag3Color != value)
				{
					currentRoomFlag3Color = value;
					OnPropertyChanged("CurrentRoomFlag3Color");
				}
			}
		}

		public Command FlagClick { get; private set; }
		public Command OnReadClicked { get; private set; }
		public Command OnUpdateClicked { get; private set; }

		private void SetColor(string button)
		{
			Type type = typeof(FlagViewModel);
			var buttonProp = type.GetRuntimeProperty(button);
			var flagColor = (Tuple<bool, int>)buttonProp.GetValue(this);

			var newFlagColor = new Tuple<bool, int>(!flagColor.Item1, flagColor.Item2);

			buttonProp.SetValue(this, newFlagColor);
			UpdateClickedAsync(button);
		}

		public async void ReadClickedAsync()
		{
			var cancelToken = cancellationTokenSource.Token;
			/* 
             * TODO: expand room object to mimic the LabVIEW Room
             */
			try
			{
				await Task.Factory.StartNew(async () =>
				{
					while (true)
					{
						string[] urlStringParams = new string[] {
							Helpers.Settings.ServerAddress,
							Helpers.Settings.ServerPort,
							"RivERWebService",
							string.Format("GetRoom?Room={0}&Command=ReadRoom",  Helpers.Settings.Room)};
						string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

						await Task.Delay(1000);

						if (cancelToken.IsCancellationRequested)
							break;

						try
						{
							HttpResponseMessage response = await client.GetAsync(urlString);

							if (response.IsSuccessStatusCode)
							{
								var content = await response.Content.ReadAsStringAsync();
								var token = JObject.Parse(content);

								var flagJson = token.SelectToken("Flags");
								var flag = JsonConvert.DeserializeObject<Flag>(flagJson.ToString());
								var flags = UpdateCurrentRoomFlagColors(flag).ToList();

								CurrentRoomFlag0Color = flags[0].Color;
								CurrentRoomFlag1Color = flags[1].Color;
								CurrentRoomFlag2Color = flags[2].Color;
								CurrentRoomFlag3Color = flags[3].Color;
							}
						}
						catch (Exception e)
						{
							/*
							 * TODO: this is way too broad; tighten up on the actual exceptions that can be thrown
							 */
							System.Diagnostics.Debug.WriteLine(@"WEB ERROR {0}", e.Message);
						}
					}
				}, cancelToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			}
			catch (OperationCanceledException e)
			{
				System.Diagnostics.Debug.WriteLine("Cancel ReadClickedAsync ex {0}", e.Message);
			}
		}

		public async void UpdateClickedAsync(string button)
		{
			Type type = typeof(FlagViewModel);
			var buttonProp = type.GetRuntimeProperty(button);
			var flagColor = (Tuple<bool, int>)buttonProp.GetValue(this);

			string[] urlStringParams = new string[] {
				Helpers.Settings.ServerAddress,
				Helpers.Settings.ServerPort,
				"RivERWebService",
				"PostRoom"};
			string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

			var postString = string.Format("Room={0}&Data={1}&Command=WriteFlagState",
											Helpers.Settings.Room,
										   JsonConvert.SerializeObject(new { Index = flagColor.Item2, State = flagColor.Item1 }));

			var postContent = new StringContent(postString, Encoding.UTF8, "application/x-www-form-urlencoded");

			try
			{
				HttpResponseMessage response = await client.PostAsync(urlString, postContent);

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					/*
					 * TODO: Verify the personnel ID was posted with content
					 */
				}
			}
			catch (Exception e)
			{
				/*
				 * TODO: this is way too broad; tighten up on the actual exceptions that can be thrown
				 */
				System.Diagnostics.Debug.WriteLine(@"WEB ERROR {0}", e.Message);
			}
		}

		private IEnumerable<FlagColor> UpdateCurrentRoomFlagColors(Flag flag)
		{
			return flag.State.Zip(flag.Color, (s, c) => new FlagColor(s, c));

		}

		public FlagViewModel()
		{
			this.CurrentRoomFlag0Color = new Tuple<bool, int>(false, 0);
			this.CurrentRoomFlag1Color = new Tuple<bool, int>(false, 1);
			this.CurrentRoomFlag2Color = new Tuple<bool, int>(false, 2);
			this.CurrentRoomFlag3Color = new Tuple<bool, int>(false, 3);

			this.FlagClick = new Command(button =>
			{
				SetColor((string)button);

			});
			ReadClickedAsync();
			//this.OnUpdateClicked = new Command(() => UpdateClickedAsync());
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
