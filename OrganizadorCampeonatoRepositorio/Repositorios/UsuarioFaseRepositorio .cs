using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class UsuarioFaseRepositorio : BaseRepositorio<UsuarioFase>, IUsuarioFaseRepositorio
    {
        public UsuarioFaseRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }
    }
}
