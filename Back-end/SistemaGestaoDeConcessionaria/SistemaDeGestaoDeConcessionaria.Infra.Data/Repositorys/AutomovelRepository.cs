using MySqlX.XDevAPI;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class AutomovelRepository : IAutomovelRepository
    {
        private readonly ApplicationDbContext _context;

        public AutomovelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Automovel> AddAsync(Automovel automovel)
        {
            _context.Automovel.Add(automovel);
            await _context.SaveChangesAsync();
            return automovel;
        }

        public async Task<Automovel> DeleteAsync(int idAutomovel)
        {
            var automovel = await _context.Automovel.FindAsync(idAutomovel);
            if (automovel == null)
            {
                return null;
            }

            _context.Automovel.Remove(automovel);
            await _context.SaveChangesAsync();
            return automovel;
        }

        public async Task<List<Automovel>> GetAllAsync()
        {
            return await _context.Automovel.ToListAsync();
        }

        public async Task<Automovel> GetByIdAsync(int idAutomovel)
        {
            return await _context.Automovel.FindAsync(idAutomovel);
        }

        public async Task<Automovel> UpdateAsync(Automovel automovel)
        {
            _context.Automovel.Update(automovel);
            await _context.SaveChangesAsync();
            return automovel;
        }
    }
}
