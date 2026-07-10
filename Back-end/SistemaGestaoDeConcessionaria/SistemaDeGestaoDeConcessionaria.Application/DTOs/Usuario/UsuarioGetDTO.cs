using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Usuario
{
    public class UsuarioGetDTO
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
    }
}
