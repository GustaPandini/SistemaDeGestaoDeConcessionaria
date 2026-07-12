using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteAsync(int idUsuario)
        {
            var usuario = await _context.Usuario.FindAsync(idUsuario);
            if(usuario == null)
            {
                return null;
            }

            usuario.Excluido = true;
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuario.FindAsync(email);
        }

        public async Task<Usuario> GetByIdAsync(int idUsuario)
        {
            return await _context.Usuario.FindAsync(idUsuario);
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
