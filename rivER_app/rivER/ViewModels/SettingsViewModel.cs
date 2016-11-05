using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace rivER
{
	public class SettingsViewModel : BaseViewModel
    {
        public string ServerAddress
        {
            get
            {
                return Helpers.Settings.ServerAddress;
            }
            set
            {
                if (Helpers.Settings.ServerAddress != value)
                {
                    Helpers.Settings.ServerAddress = value;
                    OnPropertyChanged("ServerAddress");
                }
            }
        }

        public string PersonnelID
        {
            get
            {
                return Helpers.Settings.PersonnelID;
            }
            set
            {
                if (Helpers.Settings.PersonnelID != value)
                {
                    Helpers.Settings.PersonnelID = value;
                    OnPropertyChanged("PersonnelID");
                }
            }
        }

		public SettingsViewModel(INavigation navigation) : base(navigation)
		{
			Commands.Add("SetSettings", new Command(SetSettings));
		}

		void SetSettings()
		{
			Helpers.Settings.ServerAddress = ServerAddress;
			Helpers.Settings.PersonnelID = PersonnelID;
			Navigation.PopModalAsync();
		}
	}
}
