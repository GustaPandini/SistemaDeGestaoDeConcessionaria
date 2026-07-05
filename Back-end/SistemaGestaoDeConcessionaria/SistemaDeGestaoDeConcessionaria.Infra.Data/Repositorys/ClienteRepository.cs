using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {
        public Task<Cliente> AddAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> DeleteAsync(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetByIdAsync(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> UpdateAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
