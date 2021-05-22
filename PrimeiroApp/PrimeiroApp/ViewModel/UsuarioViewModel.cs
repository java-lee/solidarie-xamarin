using Newtonsoft.Json;
using PrimeiroApp.Model;
using PrimeiroApp.Service;
using PrimeiroApp.View;
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

    public class UsuarioViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeProperty([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _Email;
        public string Email
        {
            set
            {
                this._Email = value;
                ChangeProperty(_Email);
            }
            get
            {
                return this._Email;
            }
        }

        private string _Senha;
        public string Senha
        {
            set
            {
                this._Senha = value;
                ChangeProperty(_Senha);
            }
            get
            {
                return this._Senha;
            }
        }

        public Command BotaoLogin { get; set; }

        public Command BotaoNovoUsuario { get; set; }

        private async Task AcaoNovoUsuario()
        {
            try
            {
                var service = new UsuarioService();
                if (await service.NovoUsuario(Email, Senha))
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuario Registrado!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível inserir!", "Ok");
                }
            } catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro: " + e.Message, "OK");
            }
        }

        private async Task AcaoLogin()
        {
            try
            {
                var service = new UsuarioService();
                if (await service.Login(Email, Senha))
                {
                    var Usuario = new Usuario() { Email = Email };
                    Preferences.Set("usuario", JsonConvert.SerializeObject(Usuario));
                    MessagingCenter.Send<Cabecalho, string>(new Cabecalho(), "dados_usuario", Email);
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Login Realizado!", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(Pagina1)}");
                    Email = "";
                    Senha = "";
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível logar!", "Ok");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro: " + e.Message, "OK");
            }
        }

        public UsuarioViewModel()
        {
            BotaoLogin = new Command(async () => await AcaoLogin());
            BotaoNovoUsuario = new Command(async () => await AcaoNovoUsuario());
        }

    }
}
