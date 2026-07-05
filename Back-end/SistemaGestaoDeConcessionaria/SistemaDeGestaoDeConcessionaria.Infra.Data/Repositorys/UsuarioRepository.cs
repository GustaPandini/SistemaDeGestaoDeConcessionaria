using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Usuario> AddAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> DeleteAsync(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
