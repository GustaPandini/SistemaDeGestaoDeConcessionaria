using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Account
{
    public interface IAuthenticate
    {
        public string GenerateToken(int idUsuario, string email, string role);
        Task<Usuario> GetUsuarioByEmail(string email);
        Task<bool> UsuarioExiste(string email);
        Task<bool> AuthenticateAsync(string email, string senha);
    }
}
