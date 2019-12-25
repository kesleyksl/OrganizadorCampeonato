using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class CompetIdorRepositorio : BaseRepositorio<Competidor>, ICompetIdorRepositorio
    {
        public CompetIdorRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }
    }
}
