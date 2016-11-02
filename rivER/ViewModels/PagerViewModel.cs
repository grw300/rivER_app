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

	public class Page
	{
		public string From { get; set; }
		public string Message { get; set; }
	}
}

