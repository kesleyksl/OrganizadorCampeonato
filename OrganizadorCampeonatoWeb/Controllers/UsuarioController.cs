using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonatoWeb.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                
                var usuarioCadastrado = _usuarioRepositorio.Obter(usuario.Email);
                if(usuarioCadastrado != null)
                {
                    return BadRequest("E-mail já cadastrado no sistema");
                }

                usuario.Senha = Auxiliary.Cryptography.Encrypt(usuario.Senha);
                _usuarioRepositorio.Adicionar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Senha = Auxiliary.Cryptography.Encrypt(usuario.Senha);
                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
               if(usuarioRetorno != null)
                {
                    return Ok(usuarioRetorno);
                }

                
                return BadRequest("Usuário ou senha inválido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
