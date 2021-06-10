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
    public partial class AlterarExcluirRequisicao : ContentPage
    {
        private Requisicao Requisicao;
        private Produto Produto;
        public AlterarExcluirRequisicao(Requisicao requisicao)
        {
            InitializeComponent();
            Requisicao = requisicao;
            var vm = BindingContext as RequisicaoViewModel;
            vm.RequisicaoID = requisicao.RequisicaoID;
            vm.Descricao = Requisicao.Descricao;
            vm.ProdutoID = requisicao.ProdutoID;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ProdutoService service = new ProdutoService();
            var vm = BindingContext as RequisicaoViewModel;
            vm.ProdutoID = (await service.Get()).First().ProdutoID;
            vm.ListaProduto = (await service.Get());
        }
    }
}