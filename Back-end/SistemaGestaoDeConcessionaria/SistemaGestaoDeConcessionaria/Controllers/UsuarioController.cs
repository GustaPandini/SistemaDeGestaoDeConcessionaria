using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Cliente;
using SistemaDeGestaoDeConcessionaria.Application.DTOs.Usuario;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaDeGestaoDeConcessionaria.Application.Services;
using SistemaGestaoDeConcessionaria.API.Models;
using SistemaGestaoDeConcessionaria.Domain.Account;

namespace SistemaGestaoDeConcessionaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuario(UsuarioPostDTO usuarioPostDTO)
        {
            var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
            var token = _authenticate.GenerateToken(usuario.idUsuario, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> GetToken(UserLogin usuarioLogin)
        {
            var usuario = await _authenticate.GetUsuarioByEmail(usuarioLogin.Email);
            if(usuario == null)
            {
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            }

            var usuarioValido = await _authenticate.AuthenticateAsync(usuarioLogin.Email, usuarioLogin.Senha);
            if(!usuarioValido)
            {
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            }

            var token = _authenticate.GenerateToken(usuario.idUsuario, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }
    }
}
