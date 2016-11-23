using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace rivER
{
	public class Request : ObservableProperty
	{
		[JsonIgnore]
		private bool? state;

        [JsonIgnore]
        private bool alarm;


        public string RequestID { get; set; }
		public int EnlapsedTime { get; set; }
		public string Description { get; set; }
		public bool Alarm {
            get
            {
                return alarm;
            }
            set
            {
                if (alarm != value)
                {
                    alarm = value;
                }
                if (alarm)
                {
                    State = false;
                }
            }
        }

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