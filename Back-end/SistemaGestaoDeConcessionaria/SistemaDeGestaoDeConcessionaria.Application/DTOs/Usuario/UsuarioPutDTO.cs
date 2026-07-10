using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Usuario
{
    public class UsuarioPutDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Email deve ter no máximo 200 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Senha deve ter no máximo 200 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo Nome deve ter no mínimo 8 caracteres.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Perfil é obrigatório.")]
        public string Perfil { get; set; }
    }
}
