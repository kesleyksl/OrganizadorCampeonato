using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using System;
using System.IO;
using System.Linq;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizadorCampeonatoWeb.Controllers
{
    [Route("api/[controller]")]
    public class FaseController : Controller
    {
        private readonly IFaseRepositorio _faseRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        private ICampeonatoRepositorio _campeonatoRepositorio;
        private IUsuarioFaseRepositorio _usuarioFaseRepositorio;

        public FaseController(IFaseRepositorio faseRepositorio,
                                       IHttpContextAccessor httpContextAccessor,
                                       IHostingEnvironment hostingEnvironment, ICampeonatoRepositorio campeonatoRepositorio, IUsuarioFaseRepositorio usuarioFaseRepositorio)
        {
            _faseRepositorio = faseRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _campeonatoRepositorio = campeonatoRepositorio;
            _usuarioFaseRepositorio = usuarioFaseRepositorio;

        }

        [HttpGet]
        public IActionResult Get()
        {


            try
            {
                object teste = _faseRepositorio.ObterTodos();

                return Json(teste);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }
        }

        public IActionResult Post([FromBody]Fase fase)
        {
            try
            {
                fase.Validate();
                if (!fase.EhValido)
                {
                    return BadRequest(fase.ObterMensagemValidacao());
                }
                if (fase.Id > 0)
                {
                    fase.TipoFase = null;
                    _faseRepositorio.Atualizar(fase);
                }
                else
                {
                    _faseRepositorio.Adicionar(fase);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpPost("Todas")]
        public IActionResult Todas([FromBody]Campeonato campeonato)
        {
            campeonato.Validate();
            if (!campeonato.EhValido)
            {
                return BadRequest(campeonato.ObterMensagemValidacao());
            }


            return Json(_faseRepositorio.ObterFases(campeonato.Id));
        }
         [HttpPost("CadastrarCompetidor")]
        public IActionResult CadastrarCompetidor([FromBody]UsuarioFase usuarioFase)
        {


            if (usuarioFase.CompetidorId > 0 && usuarioFase.FaseId > 0)
            {
                
                _usuarioFaseRepositorio.Adicionar(usuarioFase);
            }
            else
            {
                return BadRequest("Não foi possível concluir a operação");
            }

            return Ok();
        }
         [HttpPost("GetCompetidoresFase")]
        public IActionResult GetCompetidoresFase([FromBody]int faseId)
        {
            dynamic competidores;

            if (faseId > 0)
            {
                
                competidores =  _usuarioFaseRepositorio.GetCompetidoresFase(faseId);
            }
            else
            {
                return BadRequest("Não foi possível concluir a operação");
            }

            return Json(competidores);
        }

        
         [HttpPost("GetCompetidoresNaoCadastradoNaFase")]
        public IActionResult GetCompetidoresNaoCadastradoNaFase([FromBody]JObject campeonatoFase)
        {
            dynamic competidores;
            int faseId = int.Parse(campeonatoFase["faseId"].ToString());
            int campeonatoId = int.Parse(campeonatoFase["campeonatoId"].ToString());
            if (faseId> 0)
            {
                
                competidores =  _usuarioFaseRepositorio.GetCompetidoresNaoCadastradoNaFase(campeonatoId, faseId);
            }
            else
            {
                return BadRequest("Não foi possível concluir a operação");
            }

            return Json(competidores);
        }


        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Fase fase)
        {
            try
            {
                _faseRepositorio.Remover(fase);
                return Json(_campeonatoRepositorio.ObterPorId(fase.CampeonatoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("DeletarCompetidor")]
        public IActionResult DeletarCompetidor([FromBody]JObject jobject)
        {
            UsuarioFase fase = new UsuarioFase { CompetidorId = int.Parse(jobject["competidorId"].ToString()), FaseId = int.Parse(jobject["faseId"].ToString()), Id = int.Parse(jobject["usuarioFaseId"].ToString()) };

            try
            {
                _usuarioFaseRepositorio.Remover(fase);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
