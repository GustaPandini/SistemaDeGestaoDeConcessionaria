using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda
{
    public class VendaPutDTO
    {
        [Required(ErrorMessage = "É obrigatório informar o ID da venda que você quer alterar.")]
        public int idVenda { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a data da venda.")]
        public DateTime DataDaVenda { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o valor pago pelo automovel.")]
        public decimal ValorPago { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a forma de pagamento.")]
        [MaxLength(50, ErrorMessage = "O campo Forma de pagamento deve ter no máximo 50 caracteres.")]
        public string FormaDePagamento { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o automovel vendido.")]
        public int idAutomovel { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o cliente que comprou o automovel.")]
        public int idCliente { get; set; }
    }
}
