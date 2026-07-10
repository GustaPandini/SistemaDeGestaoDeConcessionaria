using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda
{
    public class VendaGetDetailDTO
    {
        public int idVenda { get; set; }
        public DateOnly DataDaVenda { get; set; }
        public decimal ValorPago { get; set; }
        public string FormaDePagamento { get; set; }
        public AutomovelGetDTO Automovel { get; set; }
        public ClienteGetDTO Cliente { get; set; }
    }
}
