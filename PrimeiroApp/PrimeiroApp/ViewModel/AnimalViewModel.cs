using Newtonsoft.Json;
using PrimeiroApp.Model;
using PrimeiroApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimeiroApp.ViewModel
{
    public class AnimalViewModel : INotifyPropertyChanged
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

        private string _Usuario;
        public string Usuario
        {
            set
            {
                this._Usuario = value;
                ChangeProperty();
            }
            get
            {
                return this._Usuario;
            }
        }

        private string _AnimalID;
        public string AnimalID
        {
            set
            {
                this._AnimalID = value;
                ChangeProperty();
            }
            get
            {
                return this._AnimalID;
            }
        }

        private List<Animal> _Lista;
        public List<Animal> Lista
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

        //private AnimalService service = new AnimalService();

        private async Task AcaoNovo()
        {
            try
            {
                /*
                if (await service.NovoAnimal(Nome))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Animal Registrado!", "OK");
                    ListarAnimais();
                }
                else
                {
                */
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível inserir!", "Ok");
                //}
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
                /*
                if (await service.AlterarAnimal(Nome, AnimalID))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Animal Alterado!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    ListarAnimais();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível alterar!", "Ok");
                }
                */
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
                /*
                if (await service.ExcluirAnimal(AnimalID))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Animal Excluído!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    ListarAnimais();
                }
                else
                {
                */
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível excluir!", "Ok");
                //}
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro: " + e.Message, "OK");
            }
        }

        public AnimalViewModel()
        {
            BotaoNovo = new Command(async () => await AcaoNovo());
            BotaoAlterar = new Command(async () => await AcaoAlterar());
            BotaoExcluir = new Command(async () => await AcaoExcluir());
        }

        private async void ListarAnimais()
        {
            var usuario = JsonConvert.DeserializeObject<Usuario>(Preferences.Get("usuario", string.Empty));
            //Lista = (await service.GetAnimais()).Where(a => a.Usuario == usuario.Email).ToList();
            Nome = "";
            AnimalID = "";
        }

    }
}
