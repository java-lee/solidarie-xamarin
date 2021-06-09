using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroApp.Service
{
    abstract class CoreService<T>
    {
        public FirebaseClient chamadaBanco;

        public CoreService()
        {
            chamadaBanco = new FirebaseClient(FirebaseUrl);
        }

        public string FirebaseUrl = "https://solidarie-cf3de-default-rtdb.firebaseio.com/";
        protected abstract string NomeNoBanco {get;}



        public async Task<bool> Novo(T model)
        {
            try
            {
                await chamadaBanco.Child(NomeNoBanco)
                    .PostAsync(model);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Alterar(T model, string Id)
        {
            try
            {
                await chamadaBanco
                        .Child(NomeNoBanco)
                        .Child(Id)
                        .PutAsync(model);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Excluir(string Id)
        {
            try
            {
                await chamadaBanco.Child(NomeNoBanco).Child(Id).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public abstract Task<List<T>> Get();



    }
}
