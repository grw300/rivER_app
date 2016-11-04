using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Flags
{
    public class SettingsViewModel : INotifyPropertyChanged
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

        public string Room
        {
            get
            {
                return Helpers.Settings.Room;
            }
            set
            {
                if (Helpers.Settings.Room != value)
                {
                    Helpers.Settings.Room = value;
                    OnPropertyChanged("PersonnelID");
                }
            }
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
