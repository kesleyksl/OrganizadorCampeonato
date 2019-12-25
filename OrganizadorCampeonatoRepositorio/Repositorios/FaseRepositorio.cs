using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class FaseRepositorio : BaseRepositorio<Fase>, IFaseRepositorio
    {
        public FaseRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }
    }
}
