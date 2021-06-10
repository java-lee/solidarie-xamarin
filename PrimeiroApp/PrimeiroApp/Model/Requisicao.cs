using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroApp.Model
{
    public class Requisicao
    {
        public string RequisicaoID { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public string ProdutoID { get; set; }

    }
}
