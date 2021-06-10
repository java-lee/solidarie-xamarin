using PrimeiroApp.Model;
using PrimeiroApp.Service;
using PrimeiroApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeiroApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina2 : ContentPage
    {
        public Pagina2()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ProdutoService serviceProduto = new ProdutoService();
            RequisicaoService serviceRequisicao = new RequisicaoService();
            var vm = BindingContext as RequisicaoViewModel;
            vm.ListaProduto = await serviceProduto.Get();
            vm.ListaRequisicao = await serviceRequisicao.Get();
        }

        private async void ListaRequisicao_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var requisicao = (Requisicao)e.Item;
            await Navigation.PushAsync(new AlterarExcluirRequisicao(requisicao));
        }
    }
}