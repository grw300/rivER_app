using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace rivER
{
    public class PagerViewModel : INotifyPropertyChanged
    {
        List<Page> pages;

        public List<Page> Pages
        {
            get
            {
                return pages;
            }
            set
            {
                if (pages != value)
                {
                    pages = value;
                    OnPropertyChanged("Pages");
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

