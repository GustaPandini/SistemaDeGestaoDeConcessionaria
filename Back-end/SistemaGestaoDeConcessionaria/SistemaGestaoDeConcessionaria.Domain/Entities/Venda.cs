using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Entities
{
    public class Vendas
    {
        public int idVendas { get; set; }
        public DateOnly DataDaVenda { get; set; }
        public decimal ValorPago { get; set; }
        public string FormaDePagamento { get; set; }
        public int idAutomovel { get; set; }
        public int idCliente { get; set; }
        public Automovel Automovel { get; set; }
        public Cliente Cliente { get; set; }
    }
}
