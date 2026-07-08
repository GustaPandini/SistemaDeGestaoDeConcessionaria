using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente
{
    public class ClientePostDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo CPF deve ter exatamente 11 dígitos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(13, MinimumLength = 12, ErrorMessage = "O número de Telefone deve estar em formato E.164")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }
    }
}
