using PrimeiroApp.Model;
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
    public partial class AlterarExcluirAnimal : ContentPage
    {
        public AlterarExcluirAnimal(Produto produto)
        {
            InitializeComponent();
            var vm = BindingContext as ProdutoViewModel;
            vm.ProdutoID = produto.ProdutoID;
            vm.Nome = produto.Nome;
        }
    }
}