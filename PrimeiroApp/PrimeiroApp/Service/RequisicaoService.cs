using PrimeiroApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroApp.Service
{
    class RequisicaoService : CoreService<Requisicao>
    {
        protected override string NomeNoBanco => "Requisicao";

        public async override Task<List<Requisicao>> Get()
        {
            return (await chamadaBanco
             .Child(NomeNoBanco)
             .OnceAsync<Requisicao>()).Select(item => new Requisicao
             {
                 Descricao = item.Object.Descricao,
                 DataValidade = item.Object.DataValidade,
                 ProdutoID = item.Object.ProdutoID,
                 RequisicaoID = item.Key
             }).ToList();
        }
    }
}
