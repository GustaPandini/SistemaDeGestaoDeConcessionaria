using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Helpers;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

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

            venda.Excluido = true;
            _context.Venda.Update(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<PagedList<Venda>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Venda
                .Include(x => x.Automovel)
                .Include(x => x.Cliente)
                .Where(x => x.Excluido == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Venda> GetByIdAsync(int idVenda)
        {
            return await _context.Venda
                .Include(x => x.Automovel)
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.idVenda == idVenda);
        }

        public async Task<Venda> UpdateAsync(Venda venda)
        {
            _context.Venda.Update(venda);
            await _context.SaveChangesAsync();
            return venda;
        }
    }
}
