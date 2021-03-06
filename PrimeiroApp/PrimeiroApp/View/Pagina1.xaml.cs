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
        private async void ListaProduto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Produto = (Produto)e.Item;
            await Navigation.PushAsync(new AlterarExcluirAnimal(Produto));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ProdutoService service = new ProdutoService();
            var vm = BindingContext as ProdutoViewModel;
            vm.Lista = await service.Get();
        }
    }
}