using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Automovel;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaDeGestaoDeConcessionaria.Application.Services;

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
        public async Task<ActionResult> AddAutomovel(AutomovelPostDTO automovelPostDTO)
        {
            var automovelAdicionado = await _automovelService.AddAsync(automovelPostDTO);
            if (automovelAdicionado == null)
            {
                return BadRequest("Não foi possível adicionar o automóvel.");

            }
            return Ok(new { message = "Automóvel íncluido com sucesso!" });
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAutomovel(AutomovelPutDTO automovelPutDTO)
        {
            var automovelAtualizado = await _automovelService.UpdateAsync(automovelPutDTO);
            if (automovelAtualizado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar esse automóvel!.");
            }
            return Ok(new { message = "Automóvel atualizado com sucesso!" });
        }
        [HttpDelete("{idAutomovel}")]
        public async Task<ActionResult> DeleteAutomovel(int idAutomovel)
        {
            var automovelDeletado = await _automovelService.DeleteAsync(idAutomovel);
            if (automovelDeletado == null)
            {
                return NotFound("Automóvel não encontrado.");
            }
            return Ok(new { message = "Automóvel deletado com sucesso!" });
        }
        [HttpGet("{idAutomovel}")]
        public async Task<ActionResult> GetAutomovelById(int idAutomovel)
        {
            var automovel = await _automovelService.GetByIdAsync(idAutomovel);
            if (automovel == null)
            {
                return NotFound("Automovel não encontrado.");
            }
            return Ok(automovel);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAutomoveis()
        {
            var automovel = await _automovelService.GetAllAsync();
            return Ok(automovel);
        }
    }
}
