using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Entities
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
