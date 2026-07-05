using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class AutomovelRepository : IAutomovelRepository
    {
        public Task<Automovel> AddAsync(Automovel automovel)
        {
            throw new NotImplementedException();
        }

        public Task<Automovel> DeleteAsync(int idAutomovel)
        {
            throw new NotImplementedException();
        }

        public Task<List<Automovel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Automovel> GetByIdAsync(int idAutomovel)
        {
            throw new NotImplementedException();
        }

        public Task<Automovel> UpdateAsync(Automovel automovel)
        {
            throw new NotImplementedException();
        }
    }
}
