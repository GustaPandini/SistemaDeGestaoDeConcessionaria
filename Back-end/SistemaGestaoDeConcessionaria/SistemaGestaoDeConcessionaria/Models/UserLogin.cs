using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoDeConcessionaria.API.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Email deve ter no máximo 200 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Senha deve ter no máximo 200 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo Nome deve ter no mínimo 8 caracteres.")]
        public string Senha { get; set; }
    }
}
