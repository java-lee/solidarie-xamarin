using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using PrimeiroApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrimeiroApp.Service
{
    class AnimalService
    {
        private FirebaseClient chamadaBanco;

        public AnimalService()
        {
            chamadaBanco = new FirebaseClient("https://solidarie-cf3de-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> NovoAnimal(string nome)
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(Preferences.Get("usuario", string.Empty));
                await chamadaBanco.Child("Animais")
                    .PostAsync(new Animal()
                                {
                                    Nome = nome,
                                    Usuario = usuario.Email
                                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> AlterarAnimal(string nome, string animal_id)
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(Preferences.Get("usuario", string.Empty));
                await chamadaBanco
                        .Child("Animais")
                        .Child(animal_id)
                        .PutAsync(new Animal()
                                    { Nome = nome, Usuario = usuario.Email });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> ExcluirAnimal(string animal_id)
        {
            try
            {
                await chamadaBanco.Child("Animais").Child(animal_id).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Animal>> GetAnimais()
        {
            return (await chamadaBanco
              .Child("Animais")
              .OnceAsync<Animal>()).Select(item => new Animal
              {
                  Nome = item.Object.Nome,
                  Usuario = item.Object.Usuario,
                  AnimalID = item.Key
              }).ToList();
        }

    }
}
