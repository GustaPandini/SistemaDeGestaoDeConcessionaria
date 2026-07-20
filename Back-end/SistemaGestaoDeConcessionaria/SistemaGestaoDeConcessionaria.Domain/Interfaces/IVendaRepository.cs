using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<Venda> GetByIdAsync(int idVenda);
        Task<PagedList<Venda>> GetAllAsync(int pageNumber, int pageSize);
        Task<Venda> AddAsync(Venda venda);
        Task<Venda> UpdateAsync(Venda venda);
        Task<Venda> DeleteAsync(int idVenda);
    }
}
