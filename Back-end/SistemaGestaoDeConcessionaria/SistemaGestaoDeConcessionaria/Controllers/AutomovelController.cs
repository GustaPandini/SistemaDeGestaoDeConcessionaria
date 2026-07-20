using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaDeGestaoDeConcessionaria.Application.Services;
using SistemaGestaoDeConcessionaria.API.Extensions;
using SistemaGestaoDeConcessionaria.API.Models;

namespace SistemaGestaoDeConcessionaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomovelController : Controller
    {
        private readonly IAutomovelService _automovelService;
        public AutomovelController(IAutomovelService automovelService)
        {
            _automovelService = automovelService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddAutomovel(AutomovelPostDTO automovelPostDTO)
        {
            var automovelAdicionado = await _automovelService.AddAsync(automovelPostDTO);
            return Ok(new { message = "Automóvel íncluido com sucesso!" });
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateAutomovel(AutomovelPutDTO automovelPutDTO)
        {
            var automovelAtualizado = await _automovelService.UpdateAsync(automovelPutDTO);
            return Ok(new { message = "Automóvel atualizado com sucesso!" });
        }
        [HttpDelete("{idAutomovel}")]
        [Authorize]
        public async Task<ActionResult> DeleteAutomovel(int idAutomovel)
        {
            var automovelDeletado = await _automovelService.DeleteAsync(idAutomovel);
            return Ok(new { message = "Automóvel deletado com sucesso!" });
        }
        [HttpGet("{idAutomovel}")]
        [Authorize]
        public async Task<ActionResult> GetAutomovelById(int idAutomovel)
        {
            var automovel = await _automovelService.GetByIdAsync(idAutomovel);
            return Ok(automovel);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllAutomoveis([FromQuery] PaginationParams paginationParams)
        {
            var automovel = await _automovelService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader
                (new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, automovel.TotalCount, automovel.TotalPages));
            return Ok(automovel);
        }

        [HttpGet("Deslogado")]
        public async Task<ActionResult> GetAllDeslogadoAsync([FromQuery] PaginationParams paginationParams)
        {
            var automovel = await _automovelService.GetAllDeslogadoAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader
                (new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, automovel.TotalCount, automovel.TotalPages));
            return Ok(automovel);
        }

    }
}
