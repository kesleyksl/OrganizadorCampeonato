using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class JuradoRepositorio : BaseRepositorio<Jurado>, IJuradoRepositorio
    {
        public JuradoRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }
    }
}
