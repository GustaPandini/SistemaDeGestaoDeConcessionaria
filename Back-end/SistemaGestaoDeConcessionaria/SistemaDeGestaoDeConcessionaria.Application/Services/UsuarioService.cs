using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Usuario;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var usuario = new Usuario
            {
                Nome = usuarioPostDTO.Nome,
                Email = usuarioPostDTO.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = usuarioPostDTO.Perfil,
                Excluido = false
            };
            var usuarioExiste = await _usuarioRepository.GetByEmailAsync(usuario.Email);
            if(usuarioExiste != null)
            {
                if(usuarioExiste.Excluido == true)
                {
                    usuarioExiste.Excluido = false;
                    usuarioExiste.Nome = usuarioPostDTO.Nome;
                    usuarioExiste.PasswordHash = passwordHash;
                    usuarioExiste.PasswordSalt = passwordSalt;
                    usuarioExiste.Perfil = usuarioPostDTO.Perfil;
                    var usuarioDeletadoAtualizado = await _usuarioRepository.UpdateAsync(usuarioExiste);
                    return new UsuarioGetDTO
                    {
                        idUsuario = usuarioDeletadoAtualizado.idUsuario,
                        Nome = usuarioDeletadoAtualizado.Nome,
                        Email = usuarioDeletadoAtualizado.Email,
                        Perfil = usuarioDeletadoAtualizado.Perfil
                    };
                }
                throw new Exception("Já existe um usuario com este Email.");
            }
            var usuarioCriado = await _usuarioRepository.AddAsync(usuario);
            return new UsuarioGetDTO
            {
                idUsuario = usuario.idUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> DeleteAsync(int idUsuario)
        {
            var usuarioDeletado = await _usuarioRepository.DeleteAsync(idUsuario);
            if (usuarioDeletado == null)
            {
                return null;
            }
            return new UsuarioGetDTO
            {
                idUsuario = usuarioDeletado.idUsuario,
                Nome = usuarioDeletado.Nome,
                Email = usuarioDeletado.Email,
                Perfil = usuarioDeletado.Perfil
            };
        }

        public async Task<List<UsuarioGetDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var listaUsuarios = new List<UsuarioGetDTO>();
            foreach (var usuario in usuarios)
            {
                if(usuario.Excluido == true)
                {
                    continue;
                }
                listaUsuarios.Add(new UsuarioGetDTO
                {
                    idUsuario = usuario.idUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Perfil = usuario.Perfil
                });
            }
            return listaUsuarios;
        }

        public async Task<UsuarioGetDTO> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null)
            {
                return null;
            };
            return new UsuarioGetDTO
            {
                idUsuario = usuario.idUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> GetByIdAsync(int idUsuario)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(idUsuario);
            if (usuario == null)
            {
                return null;
            };
            if(usuario.Excluido == true)
            {
                return null;
            }
            return new UsuarioGetDTO
            {
                idUsuario = usuario.idUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO usuarioPutDTO)
        {
            var usuario = new Usuario
            {
                idUsuario = usuarioPutDTO.idUsuario,
                Nome = usuarioPutDTO.Nome,
                Email = usuarioPutDTO.Email,
                Perfil = usuarioPutDTO.Perfil
            };
            var usuarioExiste = await _usuarioRepository.GetByEmailAsync(usuario.Email);
            if (usuarioExiste != null && usuarioExiste.idUsuario != usuario.idUsuario)
            {
                if(usuarioExiste.Excluido == true)
                {
                    usuarioExiste.Excluido = false;
                    usuarioExiste.Nome = usuarioPutDTO.Nome;
                    usuarioExiste.Email = usuarioPutDTO.Email;
                    usuarioExiste.Perfil = usuarioPutDTO.Perfil;
                    var usuarioDeletadoAtualizado = await _usuarioRepository.UpdateAsync(usuarioExiste);
                    return new UsuarioGetDTO
                    {
                        idUsuario = usuarioDeletadoAtualizado.idUsuario,
                        Nome = usuarioDeletadoAtualizado.Nome,
                        Email = usuarioDeletadoAtualizado.Email,
                        Perfil = usuarioDeletadoAtualizado.Perfil
                    };
                }
                throw new Exception("Já existe um usuario com este Email.");
            };
            var usuarioAtualizado = await _usuarioRepository.UpdateAsync(usuario);
            if (usuarioAtualizado == null)
            {
                return null;
            };
            return new UsuarioGetDTO
            {
                idUsuario = usuarioAtualizado.idUsuario,
                Nome = usuarioAtualizado.Nome,
                Email = usuarioAtualizado.Email,
                Perfil = usuarioAtualizado.Perfil
            };
        }
    }
}
