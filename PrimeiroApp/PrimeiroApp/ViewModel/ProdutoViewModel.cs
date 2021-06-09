using PrimeiroApp.Model;
using PrimeiroApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace PrimeiroApp.ViewModel
{
    class ProdutoViewModel : INotifyPropertyChanged
    {

        public Command BotaoRegistrar { get; set; }

        public ProdutoViewModel()
        {
            BotaoRegistrar = new Command(() => registrarProduto());
        }

        public async void registrarProduto()
        {
            ProdutoService service = new ProdutoService();
            Produto produto = new Produto();
            produto.Genero = Genero;
            produto.Nome = Nome;
            await service.Novo(produto);
            await Application.Current.MainPage.DisplayAlert("Salvo", "Produto salvo com sucesso!", "OK");
            Nome = "";
            Genero = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeProperty([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _Nome;
        public string Nome
        {
            set
            {
                this._Nome = value;
                ChangeProperty();
            }
            get
            {
                return this._Nome;
            }
        }

        private string _Genero;
        public string Genero
        {
            set
            {
                this._Genero = value;
                ChangeProperty();
            }
            get
            {
                return this._Genero;
            }
        }
    }
}
