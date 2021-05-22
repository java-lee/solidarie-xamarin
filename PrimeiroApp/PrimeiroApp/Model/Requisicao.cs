using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroApp.Model
{
    class Requisicao
    {
        public string Id { get; set; }

        public DateTime DataValidade { get; set; }

        public string Descricao { get; set; }

        //public virtual ICollection<Produto> Produto { get; set; }
        //public ICollection<Produto> Produto { get; set; }

    }
}
