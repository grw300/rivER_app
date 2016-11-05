using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace rivER
{
	public class PagerViewModel : BaseViewModel
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

		public PagerViewModel(INavigation navigation) : base(navigation) { }
	}
}

