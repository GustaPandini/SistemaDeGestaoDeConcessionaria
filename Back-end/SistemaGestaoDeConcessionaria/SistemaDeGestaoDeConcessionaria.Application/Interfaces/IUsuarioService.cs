using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGetDTO> GetByIdAsync(int idUsuario);
        Task<UsuarioGetDTO> GetByEmailAsync(string email);
        Task<List<UsuarioGetDTO>> GetAllAsync();
        Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO);
        Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO usuarioPutDTO);
        Task<UsuarioGetDTO> DeleteAsync(int idUsuario);
    }
}
