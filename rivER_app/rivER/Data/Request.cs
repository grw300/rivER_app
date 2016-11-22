using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace rivER
{
	public class Request : ObservableProperty
	{
		[JsonIgnore]
		private bool? state;

		public string RequestID { get; set; }
		public int EnlapsedTime { get; set; }
		public string Description { get; set; }
		public bool Alarm { get; set; }

		[JsonIgnore]
		public bool? State
		{
			get { return state; }
			set
			{
				if (state != value)
				{
					state = value;

					OnPropertyChanged("State");
				}
			}
		}
	}
}