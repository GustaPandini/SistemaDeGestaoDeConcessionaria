using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<Venda> GetByIdAsync(int idVenda);
        Task<List<Venda>> GetAllAsync();
        Task<Venda> AddAsync(Venda venda);
        Task<Venda> UpdateAsync(Venda venda);
        Task<Venda> DeleteAsync(int idVenda);
    }
}
