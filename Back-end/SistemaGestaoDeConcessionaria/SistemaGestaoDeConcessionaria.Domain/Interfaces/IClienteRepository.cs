using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int idCliente);
        Task<Cliente> GetByCPFAsync(string CPF);
        Task<PagedList<Cliente>> GetAllAsync(int pageNumber, int pageSize);
        Task<Cliente> AddAsync(Cliente cliente);
        Task<Cliente> UpdateAsync(Cliente cliente);
        Task<Cliente> DeleteAsync(int idCliente);
    }
}
