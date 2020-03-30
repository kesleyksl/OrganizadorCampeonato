using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrganizadorCampeonatoWeb.Controllers
{
    [Route("api/[controller]")]
    public class CampeonatoController : Controller
    {
        private readonly ICampeonatoRepositorio _campeonatoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        private ICompetIdorRepositorio _competidorRepositorio;
        public CampeonatoController(ICampeonatoRepositorio campeonatoRepositorio,
                                        IHttpContextAccessor httpContextAccessor,
                                        IHostingEnvironment hostingEnvironment, ICompetIdorRepositorio competIdorRepositorio)
        {
            _campeonatoRepositorio = campeonatoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _competidorRepositorio = competIdorRepositorio;

        }

        [HttpGet]
        public IActionResult Get()
        {


            try
            {
                object teste = _campeonatoRepositorio.ObterTodos();

                return Json(teste);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }
        }
        [HttpPost("GetCompetidores")]
        public IActionResult GetCompetidores([FromBody]int campeonatoId)
        {
            try
            {
                object competidores = _competidorRepositorio.GetCompetidores(campeonatoId);
                return Json(competidores);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpPost("GetCompetidoresStatus")]
        public IActionResult GetCompetidoresStatus([FromBody]JObject jsonObject)
        {
            try
            {
                int status = int.Parse(jsonObject["status"].ToString());
                int campeonatoId = int.Parse(jsonObject["campeonatoId"].ToString());
                object competidores = _competidorRepositorio.GetCompetidores(campeonatoId, status);
                return Json(competidores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        public IActionResult Post([FromBody]Campeonato campeonato)
        {
            try
            {
                campeonato.Validate();
                if (!campeonato.EhValido)
                {
                    return BadRequest(campeonato.ObterMensagemValidacao());
                }
                if(campeonato.Id > 0)
                {
                    _campeonatoRepositorio.Atualizar(campeonato);
                }
                else
                {
                    _campeonatoRepositorio.Adicionar(campeonato);
                }
              
                return Created("api/campeonato", campeonato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Campeonato campeonato)
        {
            try
            {
                _campeonatoRepositorio.Remover(campeonato);
                return Json(_campeonatoRepositorio.ObterTodos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao);
                var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;

                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                return Json(novoNomeArquivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("Campeonatos")]
        public IActionResult Campeonatos([FromBody]Usuario usuario)
        {
            try
            {
                List<Campeonato> campeonatos = new List<Campeonato>();

                campeonatos = _campeonatoRepositorio.CampeonatosUsuario(usuario.Id);
                return Json(campeonatos);
            }
            catch
            {
                return BadRequest();
            }
        }



        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();

            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-") + "." + extensao;

            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";
            return novoNomeArquivo;
        }
    }
}
