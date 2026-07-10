using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Interfaces
{
    public interface IVendaService
    {
        Task<VendaGetDetailDTO> GetByIdAsync(int idVenda);
        Task<List<VendaGetDetailDTO>> GetAllAsync();
        Task<VendaGetDTO> AddAsync(VendaPostDTO vendaPostDTO);
        Task<VendaGetDTO> UpdateAsync(VendaPutDTO vendaPutDTO);
        Task<VendaGetDTO> DeleteAsync(int idVenda);
    }
}
