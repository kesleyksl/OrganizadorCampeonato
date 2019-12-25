using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoWeb.Controllers
{
    [Route("api/[controller]")]
    public class CampeonatoController : Controller
    {
        private readonly ICampeonatoRepositorio _campeonatoRepositorio;
        public CampeonatoController(ICampeonatoRepositorio campeonatoRepositorio)
        {
            _campeonatoRepositorio = campeonatoRepositorio;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_campeonatoRepositorio.ObterTodos());

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
  
                _campeonatoRepositorio.Adicionar(campeonato);
                return Created("api/campeonato", campeonato);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
