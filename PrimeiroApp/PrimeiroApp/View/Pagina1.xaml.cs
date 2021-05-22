using Newtonsoft.Json;
using PrimeiroApp.Model;
using PrimeiroApp.Service;
using PrimeiroApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeiroApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina1 : ContentPage
    {
        public Pagina1()
        {
            InitializeComponent();
        }

        private async void ListaAnimais_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var animal = (Animal)e.Item;
            await Navigation.PushAsync(new AlterarExcluirAnimal(animal));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AnimalService service = new AnimalService();
            var vm = BindingContext as AnimalViewModel;
            var usuario = JsonConvert.DeserializeObject<Usuario>(Preferences.Get("usuario", string.Empty));
            vm.Lista = (await service.GetAnimais()).Where(a => a.Usuario == usuario.Email).ToList();
        }
    }
}