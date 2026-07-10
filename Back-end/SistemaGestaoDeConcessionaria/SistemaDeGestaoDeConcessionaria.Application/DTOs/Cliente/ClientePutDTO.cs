using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente
{
    public class ClientePutDTO
    {
        [Required(ErrorMessage = "É obrigatório informar o Id do Cliente que você quer alterar.")]
        public int idCliente { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo CPF deve ter exatamente 11 dígitos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(13, MinimumLength = 12, ErrorMessage = "O campo Telefone deve ter entre 12 e 13 dígitos.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }
    }
}
