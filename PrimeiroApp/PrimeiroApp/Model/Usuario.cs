using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroApp.Model
{
    public class Usuario
    {

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string TipoInstituicao { get; set; }

        public string TipoUsuario { get; set; }

        public string Descricao { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Endereco { get; set; }

        public int Numero { get; set; }

        public string Cep { get; set; }

        public string NumeroCaixa { get; set; }

        public string Telefone { get; set; }

        public string Site { get; set; }

        public bool Status { get; set; }

    }
}
