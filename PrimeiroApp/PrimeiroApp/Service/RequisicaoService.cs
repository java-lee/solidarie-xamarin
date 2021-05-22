using PrimeiroApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroApp.Service
{
    class RequisicaoService : CoreService<Requisicao>
    {
        protected override string NomeNoBanco => "Requisicao";

        public override Task<List<Requisicao>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
