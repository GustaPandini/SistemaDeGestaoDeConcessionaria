using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel
{
    public class AutomovelPostDTO
    {
        [Required(ErrorMessage = "É obrigatório informar a placa ou o Chassi do automovel.")]
        [RegularExpression(@"^([a-zA-Z0-9]{7}|[a-zA-Z0-9]{17})$",
            ErrorMessage = "O campo deve conter exatamente 7 caracteres (Placa) ou 17 caracteres (Chassi).")]
        public string PlacaOuChassi { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a marca do automovel.")]
        [MaxLength(50, ErrorMessage = "O campo Marca deve ter no máximo 50 caracteres.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "É obrigatório o modelo do automovel.")]
        [MaxLength(50, ErrorMessage = "O campo Modelo deve ter no máximo 50 caracteres.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o PowerTrain do automovel.")]
        [MaxLength(100, ErrorMessage = "O campo PowerTrain deve ter no máximo 100 caracteres.")]
        public string Powertrain { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a versão do automovel.")]
        [MaxLength(100, ErrorMessage = "O campo Versão deve ter no máximo 100 caracteres.")]
        public string Versao { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a cor do automovel.")]
        [MaxLength(100, ErrorMessage = "O campo Cor deve ter no máximo 100 caracteres.")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o ano do automovel.")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o ano/modelo do automovel.")]
        public int AnoModelo { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a quilometragem do automovel.")]
        public int Quilometragem { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o preço do automovel.")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "É obrigatório informar se o automovel é blindado.")]
        public bool Blindado { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a quantidade de donos que o automovel teve.")]
        public int QuantidadeDonos { get; set; }
    }
}
