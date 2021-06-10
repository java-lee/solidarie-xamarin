using Newtonsoft.Json;
using PrimeiroApp.Model;
using PrimeiroApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimeiroApp.ViewModel
{
    public class RequisicaoViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeProperty([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _Descricao;
        public string Descricao
        {
            set
            {
                this._Descricao = value;
                ChangeProperty();
            }
            get
            {
                return this._Descricao;
            }
        }

        private DateTime _DataValidade;
        public DateTime DataValidade
        {
            set
            {
                this._DataValidade = value;
                ChangeProperty();
            }
            get
            {
                return this._DataValidade;
            }
        }

        private string _ProdutoID;
        public string ProdutoID
        {
            set
            {
                this._ProdutoID= value;
                ChangeProperty();
            }
            get
            {
                return this._ProdutoID;
            }
        }

        private string _RequisicaoID;
        public string RequisicaoID
        {
            set
            {
                this._RequisicaoID = value;
                ChangeProperty();
            }
            get
            {
                return this._RequisicaoID;
            }
        }

        private List<Requisicao> _ListaRequisicao;
        public List<Requisicao> ListaRequisicao
        {
            set
            {
                this._ListaRequisicao = value;
                ChangeProperty();
            }
            get
            {
                return this._ListaRequisicao;
            }
        }

        private List<Produto> _ListaProduto;
        public List<Produto> ListaProduto
        {
            set
            {
                this._ListaProduto = value;
                ChangeProperty();
            }
            get
            {
                return this._ListaProduto;
            }
        }

        public Command BotaoNovo { get; set; }
        public Command BotaoAlterar { get; set; }
        public Command BotaoExcluir { get; set; }

        private RequisicaoService serviceRequisicao = new RequisicaoService();
        private ProdutoService serviceProduto = new ProdutoService();

        private Requisicao GetRequisicao()
        {
            return new Requisicao()
            {
                Descricao = Descricao,
                DataValidade = DataValidade,
                ProdutoID = ProdutoID,
            };
        }

        private async Task AcaoNovo()
        {
            try
            {

                if (await serviceRequisicao.Novo(GetRequisicao()))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Requisição Registrada!", "OK");
                    Listar();
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
                if (await serviceRequisicao.Alterar(GetRequisicao(), RequisicaoID))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Requisicao Alterada!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    Listar();
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
                if (await serviceRequisicao.Excluir(RequisicaoID))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Requisicao Excluída!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    Listar();
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

        public RequisicaoViewModel()
        {
            BotaoNovo = new Command(async () => await AcaoNovo());
            BotaoAlterar = new Command(async () => await AcaoAlterar());
            BotaoExcluir = new Command(async () => await AcaoExcluir());
        }

        private async void Listar()
        {
            ListaProduto = await serviceProduto.Get();
            ListaRequisicao = await serviceRequisicao.Get();
            Descricao = "";
            RequisicaoID = "";
            ProdutoID = null;
        }

    }
}

