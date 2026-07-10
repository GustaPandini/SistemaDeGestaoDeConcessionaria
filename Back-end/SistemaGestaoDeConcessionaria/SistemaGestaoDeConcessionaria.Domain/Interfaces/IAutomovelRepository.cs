using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Interfaces
{
    public interface IAutomovelRepository
    {
        Task<Automovel> GetByIdAsync(int idAutomovel);
        Task<Automovel> GetByPlacaOuChassiAsync(string placaOuChassi);
        Task<List<Automovel>> GetAllAsync();
        Task<Automovel> AddAsync(Automovel automovel);
        Task<Automovel> UpdateAsync(Automovel automovel);
        Task<Automovel> DeleteAsync(int idAutomovel);
    }
}
