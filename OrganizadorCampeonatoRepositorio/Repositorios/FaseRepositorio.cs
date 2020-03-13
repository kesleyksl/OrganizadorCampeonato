using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;
using System.Collections.Generic;
using System.Linq;
namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class FaseRepositorio : BaseRepositorio<Fase>, IFaseRepositorio
    {
        public FaseRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }

        public List<Fase> ObterFases(int campeonatoId)
        {
            return OrganizadorCampeonatoContexto.Fases.Where(f => f.CampeonatoId == campeonatoId).ToList();
        }
    }
}
