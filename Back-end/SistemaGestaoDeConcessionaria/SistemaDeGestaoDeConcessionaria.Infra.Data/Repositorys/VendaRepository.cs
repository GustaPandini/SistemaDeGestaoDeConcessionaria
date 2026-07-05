using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class VendaRepository : IVendaRepository
    {
        public Task<Venda> AddAsync(Venda venda)
        {
            throw new NotImplementedException();
        }

        public Task<Venda> DeleteAsync(int idVenda)
        {
            throw new NotImplementedException();
        }

        public Task<List<Venda>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Venda> GetByIdAsync(int idVenda)
        {
            throw new NotImplementedException();
        }

        public Task<Venda> UpdateAsync(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}
