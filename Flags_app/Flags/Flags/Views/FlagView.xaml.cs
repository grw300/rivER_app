using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Flags
{
    public partial class FlagView : ContentPage
    {
        public FlagView()
        {
            InitializeComponent();
            this.BindingContext = new FlagViewModel();
        }

        public Command SettingsCommand
        {
            get
            {
                return new Command(() => Navigation.PushModalAsync(new SettingsPage()));
            }
        }
    }
}
