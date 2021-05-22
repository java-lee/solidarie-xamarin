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
        public AlterarExcluirAnimal(Animal animal)
        {
            InitializeComponent();
            var vm = BindingContext as AnimalViewModel;
            vm.AnimalID = animal.AnimalID;
            vm.Nome = animal.Nome;
        }
    }
}