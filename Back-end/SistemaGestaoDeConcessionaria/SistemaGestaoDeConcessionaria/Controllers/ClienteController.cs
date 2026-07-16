using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;

namespace SistemaGestaoDeConcessionaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpPost]
        public async Task<ActionResult> AddCliente(ClientePostDTO clientePostDTO)
        {
            var clienteAdicionado = await _clienteService.AddAsync(clientePostDTO);
            return Ok(new { message = "Cliente íncluido com sucesso!" });
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCliente(ClientePutDTO clientePutDTO)
        {
            var clienteAtualizado = await _clienteService.UpdateAsync(clientePutDTO);
            return Ok(new { message = "Cliente atualizado com sucesso!" });
        }
        [HttpDelete("{idCliente}")]
        public async Task<ActionResult> DeleteCliente(int idCliente)
        {
            var clienteDeletado = await _clienteService.DeleteAsync(idCliente);
            return Ok(new { message = "Cliente deletado com sucesso!" });
        }
        [HttpGet("{idCliente}")]
        public async Task<ActionResult> GetClienteById(int idCliente)
        {
            var cliente = await _clienteService.GetByIdAsync(idCliente);
            return Ok(cliente);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }
    }
}
