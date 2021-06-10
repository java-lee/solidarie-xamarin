using PrimeiroApp.Model;
using PrimeiroApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp.ViewModel
{
    class ProdutoViewModel : INotifyPropertyChanged
    {
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

        private string _ProdutoID;
        public string ProdutoID
        {
            set
            {
                this._ProdutoID = value;
                ChangeProperty();
            }
            get
            {
                return this._ProdutoID;
            }
        }



        private List<Produto> _Lista;
        public List<Produto> Lista
        {
            set
            {
                this._Lista = value;
                ChangeProperty();
            }
            get
            {
                return this._Lista;
            }
        }

        public Command BotaoNovo { get; set; }
        public Command BotaoAlterar { get; set; }
        public Command BotaoExcluir { get; set; }

        private ProdutoService service = new ProdutoService();

        private Produto GetProduto()
        {
            return new Produto()
            {
                Nome = Nome,
                Genero = Genero,
            };
        }

        private async Task AcaoNovo()
        {
            try
            {
               
                if (await service.Novo(GetProduto()))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Produto Registrado!", "OK");
                    ListarProduto();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível inserir!", "Ok");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro: " + e.Message, "OK");
            }
        }

        private async Task AcaoAlterar()
        {
            try
            {
                if (await service.Alterar(GetProduto(), ProdutoID))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Produto Alterado!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    ListarProduto();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível alterar!", "Ok");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro: " + e.Message, "OK");
            }
        }

        private async Task AcaoExcluir()
        {
            try
            {
                if (await service.Excluir(ProdutoID))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Produto Excluído!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    ListarProduto();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível excluir!", "Ok");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro: " + e.Message, "OK");
            }
        }

        public ProdutoViewModel()
        {
            BotaoNovo = new Command(async () => await AcaoNovo());
            BotaoAlterar = new Command(async () => await AcaoAlterar());
            BotaoExcluir = new Command(async () => await AcaoExcluir());
        }

        private async void ListarProduto()
        {

            Lista = await service.Get();
            Nome = "";
            Genero = "";
            ProdutoID = "";
        }

    }
}
