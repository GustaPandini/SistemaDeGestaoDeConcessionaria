using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _context;

        public VendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Venda> AddAsync(Venda venda)
        {
            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<Venda> DeleteAsync(int idVenda)
        {
            var venda = await _context.Venda.FindAsync(idVenda);
            if (venda == null)
            {
                return null;
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<List<Venda>> GetAllAsync()
        {
            return await _context.Venda.ToListAsync();
        }

        public async Task<Venda> GetByIdAsync(int idVenda)
        {
            return await _context.Venda.FindAsync(idVenda);
        }

        public async Task<Venda> UpdateAsync(Venda venda)
        {
            _context.Venda.Update(venda);
            await _context.SaveChangesAsync();
            return venda;
        }
    }
}
