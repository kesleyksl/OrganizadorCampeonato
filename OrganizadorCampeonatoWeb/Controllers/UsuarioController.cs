using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoDominio.Enums;
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
        private readonly ICompetIdorRepositorio _competidorRepositorio;
        private readonly IUsuarioFaseRepositorio _usuarioFaseRepositorio;
        
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ICompetIdorRepositorio competIdorRepositorio, IUsuarioFaseRepositorio usuarioFaseRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _competidorRepositorio = competIdorRepositorio;
            _usuarioFaseRepositorio = usuarioFaseRepositorio;

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
                try
                {
                    usuario.Senha = Auxiliary.Cryptography.Encrypt(usuario.Senha);
                    var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
                    if (usuarioRetorno != null)
                    {
                        return Ok(usuarioRetorno);
                    }
                }
                catch (Exception ex)
                {

                }
               

                
                return BadRequest("Usuário ou senha inválido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("ConfirmarInscricao")]
        public ActionResult ConfirmarInscricao([FromBody] Competidor competidor)
        {
            try
            {
                
                _competidorRepositorio.atualizarInscricao(competidor);
                    return Ok();

               

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
          
        }

        [HttpPost("Competir")]
        public ActionResult Competir([FromBody] Competidor competidor)
        {
            try
            {
                if (_competidorRepositorio.ExisteInscricao(competidor))
                    return BadRequest("Competidor já inscrito nesse campeonato");
                else if (_competidorRepositorio.EhOrganizador(competidor))
                    return BadRequest("Você não pode competir no seu próprio campeonato");

                competidor.StatusInscricaoId = (int)StatusCompetidorEnum.Pendente;
                _competidorRepositorio.Competir(competidor);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
