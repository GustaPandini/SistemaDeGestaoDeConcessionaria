using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaGestaoDeConcessionaria.Application.Execptions;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.Services
{
    public class AutomovelService : IAutomovelService
    {
        private readonly IAutomovelRepository _automovelRepository;
        public AutomovelService(IAutomovelRepository automovelRepository)
        {
            _automovelRepository = automovelRepository;
        }
        public async Task<AutomovelGetDTO> AddAsync(AutomovelPostDTO automovelPostDTO)
        {
            var automovel = new Automovel
            {
                PlacaOuChassi = automovelPostDTO.PlacaOuChassi,
                Marca = automovelPostDTO.Marca,
                Modelo = automovelPostDTO.Modelo,
                Powertrain = automovelPostDTO.Powertrain,
                Versao = automovelPostDTO.Versao,
                Cor = automovelPostDTO.Cor,
                Ano = automovelPostDTO.Ano,
                AnoModelo = automovelPostDTO.AnoModelo,
                Quilometragem = automovelPostDTO.Quilometragem,
                Preco = automovelPostDTO.Preco,
                Blindado = automovelPostDTO.Blindado,
                QuantidadeDonos = automovelPostDTO.QuantidadeDonos,
                Vendido = false,
                Excluido = false
            };
            var automovelExiste = await _automovelRepository.GetByPlacaOuChassiAsync(automovel.PlacaOuChassi);
            if (automovelExiste != null)
            {
                if(automovelExiste.Excluido == true)
                {
                    automovelExiste.Excluido = false;
                    automovelExiste.Marca = automovel.Marca;
                    automovelExiste.Modelo = automovel.Modelo;
                    automovelExiste.Powertrain = automovel.Powertrain;
                    automovelExiste.Versao = automovel.Versao;
                    automovelExiste.Cor = automovel.Cor;
                    automovelExiste.Ano = automovel.Ano;
                    automovelExiste.AnoModelo = automovel.AnoModelo;
                    automovelExiste.Quilometragem = automovel.Quilometragem;
                    automovelExiste.Preco = automovel.Preco;
                    automovelExiste.Blindado = automovel.Blindado;
                    automovelExiste.QuantidadeDonos = automovel.QuantidadeDonos;
                    automovelExiste.Vendido = false;
                    var automovelAtualizado = await _automovelRepository.UpdateAsync(automovelExiste);
                    return new AutomovelGetDTO
                    {
                        idAutomovel = automovelAtualizado.idAutomovel,
                        PlacaOuChassi = automovelAtualizado.PlacaOuChassi,
                        Marca = automovelAtualizado.Marca,
                        Modelo = automovelAtualizado.Modelo,
                        Powertrain = automovelAtualizado.Powertrain,
                        Versao = automovelAtualizado.Versao,
                        Cor = automovelAtualizado.Cor,
                        Ano = automovelAtualizado.Ano,
                        AnoModelo = automovelAtualizado.AnoModelo,
                        Quilometragem = automovelAtualizado.Quilometragem,
                        Preco = automovelAtualizado.Preco,
                        Blindado = automovelAtualizado.Blindado,
                        QuantidadeDonos = automovelAtualizado.QuantidadeDonos,
                        Vendido = automovelAtualizado.Vendido
                    };
                }
                throw new Exception("Já existe um automóvel com essa placa ou chassi cadastrado.");
            }
            var automovelAdicionado = await _automovelRepository.AddAsync(automovel);
            return new AutomovelGetDTO
            {
                idAutomovel = automovelAdicionado.idAutomovel,
                PlacaOuChassi = automovelAdicionado.PlacaOuChassi,
                Marca = automovelAdicionado.Marca,
                Modelo = automovelAdicionado.Modelo,
                Powertrain = automovelAdicionado.Powertrain,
                Versao = automovelAdicionado.Versao,
                Cor = automovelAdicionado.Cor,
                Ano = automovelAdicionado.Ano,
                AnoModelo = automovelAdicionado.AnoModelo,
                Quilometragem = automovelAdicionado.Quilometragem,
                Preco = automovelAdicionado.Preco,
                Blindado = automovelAdicionado.Blindado,
                QuantidadeDonos = automovelAdicionado.QuantidadeDonos,
                Vendido = automovelAdicionado.Vendido
            };
        }

        public async Task<AutomovelGetDTO> DeleteAsync(int idAutomovel)
        {
            var automovelDeletado = await _automovelRepository.DeleteAsync(idAutomovel);
            if (automovelDeletado == null)
            {
                throw new NotFoundExecption("Automóvel não encontrado.");
            }
            return new AutomovelGetDTO
            {
                idAutomovel = automovelDeletado.idAutomovel,
                PlacaOuChassi = automovelDeletado.PlacaOuChassi,
                Marca = automovelDeletado.Marca,
                Modelo = automovelDeletado.Modelo,
                Powertrain = automovelDeletado.Powertrain,
                Versao = automovelDeletado.Versao,
                Cor = automovelDeletado.Cor,
                Ano = automovelDeletado.Ano,
                AnoModelo = automovelDeletado.AnoModelo,
                Quilometragem = automovelDeletado.Quilometragem,
                Preco = automovelDeletado.Preco,
                Blindado = automovelDeletado.Blindado,
                QuantidadeDonos = automovelDeletado.QuantidadeDonos,
                Vendido = automovelDeletado.Vendido
            };
        }

        public async Task<List<AutomovelGetDTO>> GetAllAsync()
        {
            var automoveis = await _automovelRepository.GetAllAsync();
            var listaAutomoveis = new List<AutomovelGetDTO>();
            foreach (var automovel in automoveis)
            {
                if(automovel.Excluido == true)
                {
                    continue;
                }
                listaAutomoveis.Add(new AutomovelGetDTO
                {
                    idAutomovel = automovel.idAutomovel,
                    PlacaOuChassi = automovel.PlacaOuChassi,
                    Marca = automovel.Marca,
                    Modelo = automovel.Modelo,
                    Powertrain = automovel.Powertrain,
                    Versao = automovel.Versao,
                    Cor = automovel.Cor,
                    Ano = automovel.Ano,
                    AnoModelo = automovel.AnoModelo,
                    Quilometragem = automovel.Quilometragem,
                    Preco = automovel.Preco,
                    Blindado = automovel.Blindado,
                    QuantidadeDonos = automovel.QuantidadeDonos,
                    Vendido = automovel.Vendido
                });
            }
            return listaAutomoveis;
        }

        public async Task<AutomovelGetDTO> GetByIdAsync(int idAutomovel)
        {
            var automovel = await _automovelRepository.GetByIdAsync(idAutomovel);
            if (automovel == null)
            {
                throw new NotFoundExecption("Automóvel não encontrado.");
            }
            ;
            if(automovel.Excluido == true)
            {
                return null;
            }
            return new AutomovelGetDTO
            {
                idAutomovel = automovel.idAutomovel,
                PlacaOuChassi = automovel.PlacaOuChassi,
                Marca = automovel.Marca,
                Modelo = automovel.Modelo,
                Powertrain = automovel.Powertrain,
                Versao = automovel.Versao,
                Cor = automovel.Cor,
                Ano = automovel.Ano,
                AnoModelo = automovel.AnoModelo,
                Quilometragem = automovel.Quilometragem,
                Preco = automovel.Preco,
                Blindado = automovel.Blindado,
                QuantidadeDonos = automovel.QuantidadeDonos,
                Vendido = automovel.Vendido
            };
        }

        public async Task<AutomovelGetDTO> GetByPlacaOuChassiAsync(string placaOuChassi)
        {
            var automovel = await _automovelRepository.GetByPlacaOuChassiAsync(placaOuChassi);
            if (automovel == null)
            {
                throw new NotFoundExecption("Automóvel não encontrado.");
            }
            return new AutomovelGetDTO
            {
                idAutomovel = automovel.idAutomovel,
                PlacaOuChassi = automovel.PlacaOuChassi,
                Marca = automovel.Marca,
                Modelo = automovel.Modelo,
                Powertrain = automovel.Powertrain,
                Versao = automovel.Versao,
                Cor = automovel.Cor,
                Ano = automovel.Ano,
                AnoModelo = automovel.AnoModelo,
                Quilometragem = automovel.Quilometragem,
                Preco = automovel.Preco,
                Blindado = automovel.Blindado,
                QuantidadeDonos = automovel.QuantidadeDonos,
                Vendido = automovel.Vendido
            };
        }

        public async Task<AutomovelGetDTO> UpdateAsync(AutomovelPutDTO automovelPutDTO)
        {
            var automovel = new Automovel
            {
                idAutomovel = automovelPutDTO.idAutomovel,
                PlacaOuChassi = automovelPutDTO.PlacaOuChassi,
                Marca = automovelPutDTO.Marca,
                Modelo = automovelPutDTO.Modelo,
                Powertrain = automovelPutDTO.Powertrain,
                Versao = automovelPutDTO.Versao,
                Cor = automovelPutDTO.Cor,
                Ano = automovelPutDTO.Ano,
                AnoModelo = automovelPutDTO.AnoModelo,
                Quilometragem = automovelPutDTO.Quilometragem,
                Preco = automovelPutDTO.Preco,
                Blindado = automovelPutDTO.Blindado,
                QuantidadeDonos = automovelPutDTO.QuantidadeDonos,
                Vendido = automovelPutDTO.Vendido
            };
            var automovelExiste = await _automovelRepository.GetByPlacaOuChassiAsync(automovel.PlacaOuChassi);
            if (automovelExiste != null && automovelExiste.idAutomovel != automovel.idAutomovel)
            {
                if(automovelExiste.Excluido == true)
                {
                    automovelExiste.Excluido = false;
                    automovelExiste.Marca = automovel.Marca;
                    automovelExiste.Modelo = automovel.Modelo;
                    automovelExiste.Powertrain = automovel.Powertrain;
                    automovelExiste.Versao = automovel.Versao;
                    automovelExiste.Cor = automovel.Cor;
                    automovelExiste.Ano = automovel.Ano;
                    automovelExiste.AnoModelo = automovel.AnoModelo;
                    automovelExiste.Quilometragem = automovel.Quilometragem;
                    automovelExiste.Preco = automovel.Preco;
                    automovelExiste.Blindado = automovel.Blindado;
                    automovelExiste.QuantidadeDonos = automovel.QuantidadeDonos;
                    automovelExiste.Vendido = automovel.Vendido;
                    var automovelDeletadoAtualizado = await _automovelRepository.UpdateAsync(automovelExiste);
                    return new AutomovelGetDTO
                    {
                        idAutomovel = automovelDeletadoAtualizado.idAutomovel,
                        PlacaOuChassi = automovelDeletadoAtualizado.PlacaOuChassi,
                        Marca = automovelDeletadoAtualizado.Marca,
                        Modelo = automovelDeletadoAtualizado.Modelo,
                        Powertrain = automovelDeletadoAtualizado.Powertrain,
                        Versao = automovelDeletadoAtualizado.Versao,
                        Cor = automovelDeletadoAtualizado.Cor,
                        Ano = automovelDeletadoAtualizado.Ano,
                        AnoModelo = automovelDeletadoAtualizado.AnoModelo,
                        Quilometragem = automovelDeletadoAtualizado.Quilometragem,
                        Preco = automovelDeletadoAtualizado.Preco,
                        Blindado = automovelDeletadoAtualizado.Blindado,
                        QuantidadeDonos = automovelDeletadoAtualizado.QuantidadeDonos,
                        Vendido = automovelDeletadoAtualizado.Vendido
                    };
                }
                throw new Exception("Já existe um automóvel com essa placa ou chassi cadastrado.");
            }
            var automovelAtualizado = await _automovelRepository.UpdateAsync(automovel);
            if (automovelAtualizado == null)
            {
                return null;
            }
            ;
            return new AutomovelGetDTO
            {
                idAutomovel = automovelAtualizado.idAutomovel,
                PlacaOuChassi = automovelAtualizado.PlacaOuChassi,
                Marca = automovelAtualizado.Marca,
                Modelo = automovelAtualizado.Modelo,
                Powertrain = automovelAtualizado.Powertrain,
                Versao = automovelAtualizado.Versao,
                Cor = automovelAtualizado.Cor,
                Ano = automovelAtualizado.Ano,
                AnoModelo = automovelAtualizado.AnoModelo,
                Quilometragem = automovelAtualizado.Quilometragem,
                Preco = automovelAtualizado.Preco,
                Blindado = automovelAtualizado.Blindado,
                QuantidadeDonos = automovelAtualizado.QuantidadeDonos,
                Vendido = automovelAtualizado.Vendido
            };
        }
    }
}
