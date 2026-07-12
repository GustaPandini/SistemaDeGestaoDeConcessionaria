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
                Endereco = clientePostDTO.Endereco,
                Excluido = false
            };
            var clienteExiste = await _clienteRepository.GetByCPFAsync(cliente.CPF);
            if(clienteExiste != null)
            {
                if(clienteExiste.Excluido == true)
                {
                    clienteExiste.Nome = cliente.Nome;
                    clienteExiste.Telefone = cliente.Telefone;
                    clienteExiste.Endereco = cliente.Endereco;
                    clienteExiste.Excluido = false;
                    var clienteDeletadoAtualizado = await _clienteRepository.UpdateAsync(clienteExiste);
                    return new ClienteGetDTO
                    {
                        idCliente = clienteDeletadoAtualizado.idCliente,
                        Nome = clienteDeletadoAtualizado.Nome,
                        CPF = clienteDeletadoAtualizado.CPF,
                        Telefone = clienteDeletadoAtualizado.Telefone,
                        Endereco = clienteDeletadoAtualizado.Endereco
                    };
                }
                throw new Exception("Já existe um cliente com este CPF.");
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
                if(cliente.Excluido == true)
                {
                    continue;
                }
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

        public async Task<ClienteGetDTO> GetByCPFAsync(string CPF)
        {
            var cliente = await _clienteRepository.GetByCPFAsync(CPF);
            if (cliente == null)
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

        public async Task<ClienteGetDTO> GetByIdAsync(int idCliente)
        {
            var cliente = await _clienteRepository.GetByIdAsync(idCliente);
            if(cliente == null)
            {
                return null;
            };
            if(cliente.Excluido == true)
            {
                return null;
            }
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
                Endereco = clientePutDTO.Endereco,
                Excluido = false
            };
            var clienteExistente = await _clienteRepository.GetByCPFAsync(cliente.CPF);
            if (clienteExistente != null && clienteExistente.idCliente != cliente.idCliente)
            {
                if(clienteExistente.Excluido == true)
                {
                    clienteExistente.Nome = cliente.Nome;
                    clienteExistente.Telefone = cliente.Telefone;
                    clienteExistente.Endereco = cliente.Endereco;
                    clienteExistente.Excluido = false;
                    var clienteDeletadoAtualizado = await _clienteRepository.UpdateAsync(clienteExistente);
                    return new ClienteGetDTO
                    {
                        idCliente = clienteDeletadoAtualizado.idCliente,
                        Nome = clienteDeletadoAtualizado.Nome,
                        CPF = clienteDeletadoAtualizado.CPF,
                        Telefone = clienteDeletadoAtualizado.Telefone,
                        Endereco = clienteDeletadoAtualizado.Endereco
                    };
                }
                throw new Exception("Já existe um cliente com este CPF.");
            }
            ;
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
