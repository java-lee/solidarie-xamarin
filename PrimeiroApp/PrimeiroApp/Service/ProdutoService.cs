using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using PrimeiroApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrimeiroApp.Service
{
    class ProdutoService : CoreService<Produto>
    {
        protected override string NomeNoBanco => "Produtos";


        public override async Task<List<Produto>> Get()
        {
            return (await chamadaBanco
             .Child(NomeNoBanco)
             .OnceAsync<Produto>()).Select(item => new Produto
             {
                 Nome = item.Object.Nome,
                 Genero = item.Object.Genero,
                 Id = item.Key
             }).ToList();
        }
    }
}
