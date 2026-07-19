using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteGetDTO> GetByIdAsync(int idCliente);
        Task<ClienteGetDTO> GetByCPFAsync(string CPF);
        Task<PagedList<ClienteGetDTO>> GetAllAsync(int pageSize, int pageNumber);
        Task<ClienteGetDTO> AddAsync(ClientePostDTO clientePostDTO);
        Task<ClienteGetDTO> UpdateAsync(ClientePutDTO clientePutDTO);
        Task<ClienteGetDTO> DeleteAsync(int idCliente);
    }
}
