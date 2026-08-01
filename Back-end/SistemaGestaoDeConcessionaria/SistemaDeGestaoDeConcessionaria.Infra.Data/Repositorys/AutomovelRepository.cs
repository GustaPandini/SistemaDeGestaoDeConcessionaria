using MySqlX.XDevAPI;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoDeConcessionaria.Domain.Pagination;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Helpers;

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

            automovel.Excluido = true;
            _context.Automovel.Update(automovel);
            await _context.SaveChangesAsync();
            return automovel;
        }

        public async Task<PagedList<Automovel>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Automovel.Include(x => x.Imagens).Where(x => x.Excluido == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Automovel> GetByIdAsync(int idAutomovel)
        {
            return await _context.Automovel.FindAsync(idAutomovel);
        }

        public async Task<Automovel> GetByPlacaOuChassiAsync(string placaOuChassi)
        {
            return await _context.Automovel.AsNoTracking().FirstOrDefaultAsync(a => a.PlacaOuChassi == placaOuChassi);
        }

        public async Task<ImagensAutomovel> GetImagemByIdAsync(int idImagem)
        {
            return await _context.ImagensAutomovel.FirstOrDefaultAsync(i => i.Id == idImagem);
        }

        public async Task<ImagensAutomovel> RemoveImagemAsync(ImagensAutomovel imagem)
        {
            _context.ImagensAutomovel.Remove(imagem);
            await _context.SaveChangesAsync();
            return imagem;
        }

        public async Task<Automovel> UpdateAsync(Automovel automovel)
        {
            _context.Automovel.Update(automovel);
            await _context.SaveChangesAsync();
            return automovel;
        }
    }
}
