using Firebase.Database;
using Firebase.Database.Query;
using PrimeiroApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroApp.Service
{
    public class UsuarioService
    {

        private FirebaseClient chamadaBanco;

        public UsuarioService()
        {
            chamadaBanco = new FirebaseClient("https://solidarie-cf3de-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> ExisteUsuario(string email)
        {
            var usuario = (await chamadaBanco.Child("Usuarios").OnceAsync<Usuario>())
                            .Where(u => u.Object.Email == email).FirstOrDefault();
            return (usuario != null);
        }

        public async Task<bool> NovoUsuario(string email, string senha)
        {
            if (await ExisteUsuario(email) == false)
            {
                await chamadaBanco.Child("Usuarios")
                    .PostAsync(
                        new Usuario()
                        {
                            Email = email,
                            Senha = senha,
                        });
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Login(string email, string senha)
        {
            var usuario = (await chamadaBanco.Child("Usuarios").OnceAsync<Usuario>())
                            .Where(u => u.Object.Email == email)
                            .Where(u => u.Object.Senha == senha)
                            .FirstOrDefault();
            return (usuario != null);
        }


    }
}
