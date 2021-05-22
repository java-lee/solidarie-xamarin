using Newtonsoft.Json;
using PrimeiroApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeiroApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cabecalho : ContentView
    {
        public Cabecalho()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Cabecalho, string>(this, "dados_usuario", (sender, value) => {
                lblUsuario.Text = value;
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            Shell.Current.GoToAsync($"//{nameof(Login)}");
        }

    }
}