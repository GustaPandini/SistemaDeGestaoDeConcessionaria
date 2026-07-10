using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteGetDTO> AddAsync(ClientePostDTO clientePostDTO)
        {
            var cliente = new Cliente
            {
                Nome = clientePostDTO.Nome,
                CPF = clientePostDTO.CPF,
                Telefone = clientePostDTO.Telefone,
                Endereco = clientePostDTO.Endereco
            };
            var clienteAdicionado = await _clienteRepository.AddAsync(cliente);
            return new ClienteGetDTO
            {
                idCliente = clienteAdicionado.idCliente,
                Nome = clienteAdicionado.Nome,
                CPF = clienteAdicionado.CPF,
                Telefone = clienteAdicionado.Telefone,
                Endereco = clienteAdicionado.Endereco
            };

        }

        public async Task<ClienteGetDTO> DeleteAsync(int idCliente)
        {
            var clienteDeletado = await _clienteRepository.DeleteAsync(idCliente);
            if (clienteDeletado == null)
            {
                return null;
            }
            return new ClienteGetDTO
            {
                idCliente = clienteDeletado.idCliente,
                Nome = clienteDeletado.Nome,
                CPF = clienteDeletado.CPF,
                Telefone = clienteDeletado.Telefone,
                Endereco = clienteDeletado.Endereco
            };
        }

        public async Task<List<ClienteGetDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var listaClientes = new List<ClienteGetDTO>();
            foreach (var cliente in clientes)
            {
                listaClientes.Add(new ClienteGetDTO
                {
                    idCliente = cliente.idCliente,
                    Nome = cliente.Nome,
                    CPF = cliente.CPF,
                    Telefone = cliente.Telefone,
                    Endereco = cliente.Endereco
                });
            }
            return listaClientes;
        }

        public async Task<ClienteGetDTO> GetByIdAsync(int idCliente)
        {
            var cliente = await _clienteRepository.GetByIdAsync(idCliente);
            if(cliente == null)
            {
                return null;
            };
            return new ClienteGetDTO
            {
                idCliente = cliente.idCliente,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco
            };
        }

        public async Task<ClienteGetDTO> UpdateAsync(ClientePutDTO clientePutDTO)
        {
            var cliente = new Cliente
            {
                idCliente = clientePutDTO.idCliente,
                Nome = clientePutDTO.Nome,
                CPF = clientePutDTO.CPF,
                Telefone = clientePutDTO.Telefone,
                Endereco = clientePutDTO.Endereco
            };
            var clienteAtualizado = await _clienteRepository.UpdateAsync(cliente);
            if(clienteAtualizado == null)
            {
                return null;
            };
            return new ClienteGetDTO
            {
                idCliente = clienteAtualizado.idCliente,
                Nome = clienteAtualizado.Nome,
                CPF = clienteAtualizado.CPF,
                Telefone = clienteAtualizado.Telefone,
                Endereco = clienteAtualizado.Endereco
            };
        }
    }
}
