using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Venda;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaDeGestaoDeConcessionaria.Application.Services;

namespace SistemaGestaoDeConcessionaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }
        [HttpPost]
        public async Task<ActionResult> AddVenda(VendaPostDTO vendaPostDTO)
        {
            var vendaAdicionado = await _vendaService.AddAsync(vendaPostDTO);
            if (vendaAdicionado == null)
            {
                return BadRequest("Não foi possível adicionar a venda.");

            }
            return Ok(new { message = "Venda íncluido com sucesso!" });
        }
        [HttpPut]
        public async Task<ActionResult> UpdateVenda(VendaPutDTO vendaPutDTO)
        {
            var vendaAtualizada = await _vendaService.UpdateAsync(vendaPutDTO);
            if (vendaAtualizada == null)
            {
                return BadRequest("Ocorreu um erro ao alterar essa venda!.");
            }
            return Ok(new { message = "Venda atualizada com sucesso!" });
        }
        [HttpDelete("{idVenda}")]
        public async Task<ActionResult> DeleteVenda(int idVenda)
        {
            var vendaDeletada = await _vendaService.DeleteAsync(idVenda);
            if (vendaDeletada == null)
            {
                return NotFound("Venda não encontrada.");
            }
            return Ok(new { message = "Venda deletada com sucesso!" });
        }
        [HttpGet("{idVenda}")]
        public async Task<ActionResult> GetVendaById(int idVenda)
        {
            var venda = await _vendaService.GetByIdAsync(idVenda);
            if (venda == null)
            {
                return NotFound("Venda não encontrada.");
            }
            return Ok(venda);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllVendas()
        {
            var vendas = await _vendaService.GetAllAsync();
            return Ok(vendas);
        }
    }
}
