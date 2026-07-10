using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Interfaces
{
    public interface IAutomovelService
    {
        Task<AutomovelGetDTO> GetByIdAsync(int idAutomovel);
        Task<List<AutomovelGetDTO>> GetAllAsync();
        Task<AutomovelGetDTO> AddAsync(AutomovelPostDTO automovelPostDTO);
        Task<AutomovelGetDTO> UpdateAsync(AutomovelPutDTO automovelPutDTO);
        Task<AutomovelGetDTO> DeleteAsync(int idAutomovel);
    }
}
