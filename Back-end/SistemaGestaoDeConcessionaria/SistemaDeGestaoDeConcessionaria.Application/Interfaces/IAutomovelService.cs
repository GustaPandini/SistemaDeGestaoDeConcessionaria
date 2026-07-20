using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Interfaces
{
    public interface IAutomovelService
    {
        Task<AutomovelGetDTO> GetByIdAsync(int idAutomovel);
        Task<AutomovelGetDTO> GetByPlacaOuChassiAsync(string placaOuChassi);
        Task<PagedList<AutomovelGetDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<AutomovelGetDTO> AddAsync(AutomovelPostDTO automovelPostDTO);
        Task<AutomovelGetDTO> UpdateAsync(AutomovelPutDTO automovelPutDTO);
        Task<AutomovelGetDTO> DeleteAsync(int idAutomovel);
        Task<PagedList<AutomovelGetDTO>> GetAllDeslogadoAsync(int pageNumber, int pageSize);
    }
}
