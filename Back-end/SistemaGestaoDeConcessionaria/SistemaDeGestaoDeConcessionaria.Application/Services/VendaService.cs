using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaGestaoDeConcessionaria.Application.Execptions;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SistemaDeGestaoDeConcessionaria.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IAutomovelRepository _automovelRepository;
        public VendaService(IVendaRepository vendaRepository, IAutomovelRepository automovelRepository)
        {
            _vendaRepository = vendaRepository;
            _automovelRepository = automovelRepository;
        }
        public async Task<VendaGetDTO> AddAsync(VendaPostDTO vendaPostDTO)
        {
            var automovel = await _automovelRepository.GetByIdAsync(vendaPostDTO.idAutomovel);
            if (automovel == null || automovel.Excluido)
            {
                throw new NotFoundExecption("Automóvel não encontrado!");
            }
            if (automovel.Vendido)
            {
                throw new Exception("Este automóvel já foi vendido e não pode ser cadastrado em uma nova venda!");
            }

            var venda = new Venda
            {
                DataDaVenda = vendaPostDTO.DataDaVenda,
                ValorPago = vendaPostDTO.ValorPago,
                FormaDePagamento = vendaPostDTO.FormaDePagamento,
                idAutomovel = vendaPostDTO.idAutomovel,
                idCliente = vendaPostDTO.idCliente,
                Excluido = false
            };
            var vendaAdicionada = await _vendaRepository.AddAsync(venda);
            automovel.Vendido = true;
            await _automovelRepository.UpdateAsync(automovel);
            return new VendaGetDTO
            {
                idVenda = vendaAdicionada.idVenda,
                DataDaVenda = vendaAdicionada.DataDaVenda,
                ValorPago = vendaAdicionada.ValorPago,
                FormaDePagamento = vendaAdicionada.FormaDePagamento,
                idAutomovel = vendaAdicionada.idAutomovel,
                idCliente = vendaAdicionada.idCliente
            };
        }

        public async Task<VendaGetDTO> DeleteAsync(int idVenda)
        {
            var vendaDeletada = await _vendaRepository.DeleteAsync(idVenda);
            if (vendaDeletada == null)
            {
                throw new NotFoundExecption("Venda não encontrada.");
            }

            var automovel = await _automovelRepository.GetByIdAsync(vendaDeletada.idAutomovel);
            if (automovel != null)
            {
                automovel.Vendido = false;
                await _automovelRepository.UpdateAsync(automovel);
            }

            return new VendaGetDTO
            {
                idVenda = vendaDeletada.idVenda,
                DataDaVenda = vendaDeletada.DataDaVenda,
                ValorPago = vendaDeletada.ValorPago,
                FormaDePagamento = vendaDeletada.FormaDePagamento,
                idAutomovel = vendaDeletada.idAutomovel,
                idCliente = vendaDeletada.idCliente
            };
        }

        public async Task<List<VendaGetDetailDTO>> GetAllAsync()
        {
            var vendas = await _vendaRepository.GetAllAsync();
            var listaVendasDetail = new List<VendaGetDetailDTO>();
            listaVendasDetail.AddRange(vendas
                .Where(venda => !venda.Excluido)
                .Select(venda => new VendaGetDetailDTO
                {
                    idVenda = venda.idVenda,
                    DataDaVenda = venda.DataDaVenda,
                    ValorPago = venda.ValorPago,
                    FormaDePagamento = venda.FormaDePagamento,
                    Automovel = new AutomovelGetDTO
                    {
                        idAutomovel = venda.Automovel.idAutomovel,
                        PlacaOuChassi = venda.Automovel.PlacaOuChassi,
                        Marca = venda.Automovel.Marca,
                        Modelo = venda.Automovel.Modelo,
                        Powertrain = venda.Automovel.Powertrain,
                        Versao = venda.Automovel.Versao,
                        Cor = venda.Automovel.Cor,
                        Ano = venda.Automovel.Ano,
                        AnoModelo = venda.Automovel.AnoModelo,
                        Quilometragem = venda.Automovel.Quilometragem,
                        Preco = venda.Automovel.Preco,
                        Blindado = venda.Automovel.Blindado,
                        QuantidadeDonos = venda.Automovel.QuantidadeDonos,
                        Vendido = venda.Automovel.Vendido
                    },
                    Cliente = new ClienteGetDTO
                    {
                        idCliente = venda.Cliente.idCliente,
                        Nome = venda.Cliente.Nome,
                        CPF = venda.Cliente.CPF,
                        Telefone = venda.Cliente.Telefone,
                        Endereco = venda.Cliente.Endereco
                    }
                }));
            return listaVendasDetail;
        }

        public async Task<VendaGetDetailDTO> GetByIdAsync(int idVenda)
        {
            var venda = await _vendaRepository.GetByIdAsync(idVenda);
            if (venda == null)
            {
                throw new NotFoundExecption("Venda não encontrada.");
            }
            ;
            if (venda.Excluido == true)
            {
                return null;
            }
            return new VendaGetDetailDTO
            {
                idVenda = venda.idVenda,
                DataDaVenda = venda.DataDaVenda,
                ValorPago = venda.ValorPago,
                FormaDePagamento = venda.FormaDePagamento,
                Automovel = new AutomovelGetDTO
                {
                    idAutomovel = venda.Automovel.idAutomovel,
                    PlacaOuChassi = venda.Automovel.PlacaOuChassi,
                    Marca = venda.Automovel.Marca,
                    Modelo = venda.Automovel.Modelo,
                    Powertrain = venda.Automovel.Powertrain,
                    Versao = venda.Automovel.Versao,
                    Cor = venda.Automovel.Cor,
                    Ano = venda.Automovel.Ano,
                    AnoModelo = venda.Automovel.AnoModelo,
                    Quilometragem = venda.Automovel.Quilometragem,
                    Preco = venda.Automovel.Preco,
                    Blindado = venda.Automovel.Blindado,
                    QuantidadeDonos = venda.Automovel.QuantidadeDonos,
                    Vendido = venda.Automovel.Vendido
                },
                Cliente = new ClienteGetDTO
                {
                    idCliente = venda.Cliente.idCliente,
                    Nome = venda.Cliente.Nome,
                    CPF = venda.Cliente.CPF,
                    Telefone = venda.Cliente.Telefone,
                    Endereco = venda.Cliente.Endereco
                }
            };
        }

        public async Task<VendaGetDTO> UpdateAsync(VendaPutDTO vendaPutDTO)
        {
            var venda = await _vendaRepository.GetByIdAsync(vendaPutDTO.idVenda);
            if (venda == null)
            {
                throw new NotFoundExecption("Venda não encontrada.");
            }
            var automovel = await _automovelRepository.GetByIdAsync(vendaPutDTO.idAutomovel);
            if (automovel == null || automovel.Excluido)
            {
                throw new NotFoundExecption("Automóvel não encontrado!");
            }

            venda.idVenda = vendaPutDTO.idVenda;
            venda.DataDaVenda = vendaPutDTO.DataDaVenda;
            venda.ValorPago = vendaPutDTO.ValorPago;
            venda.FormaDePagamento = vendaPutDTO.FormaDePagamento;
            venda.idAutomovel = vendaPutDTO.idCliente;
            venda.idCliente = vendaPutDTO.idAutomovel;

            var vendaAtualizada = await _vendaRepository.UpdateAsync(venda);
            if (vendaAtualizada == null)
            {
                return null;
            }
            ;
            return new VendaGetDTO
            {
                idVenda = vendaAtualizada.idVenda,
                DataDaVenda = vendaAtualizada.DataDaVenda,
                ValorPago = vendaAtualizada.ValorPago,
                FormaDePagamento = vendaAtualizada.FormaDePagamento,
                idAutomovel = vendaAtualizada.idAutomovel,
                idCliente = vendaAtualizada.idCliente
            };
        }
    }
}
