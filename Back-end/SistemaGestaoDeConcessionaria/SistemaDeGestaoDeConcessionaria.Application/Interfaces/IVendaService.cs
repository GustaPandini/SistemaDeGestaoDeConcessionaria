using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Interfaces
{
    public interface IVendaService
    {
        Task<VendaGetDetailDTO> GetByIdAsync(int idVenda);
        Task<PagedList<VendaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<VendaGetDTO> AddAsync(VendaPostDTO vendaPostDTO);
        Task<VendaGetDTO> UpdateAsync(VendaPutDTO vendaPutDTO);
        Task<VendaGetDTO> DeleteAsync(int idVenda);
    }
}
