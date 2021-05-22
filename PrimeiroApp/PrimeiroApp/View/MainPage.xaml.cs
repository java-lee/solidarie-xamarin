using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimeiroApp
{

    public partial class MainPage : Shell
    {

        public MainPage()
        {
            InitializeComponent();
            Preferences.Clear();
        }

        
    }
}
