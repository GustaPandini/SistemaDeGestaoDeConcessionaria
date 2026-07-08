using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> DeleteAsync(int idCliente)
        {
            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (cliente == null)
            {
                return null;
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int idCliente)
        {
            return await _context.Cliente.FindAsync(idCliente);
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
