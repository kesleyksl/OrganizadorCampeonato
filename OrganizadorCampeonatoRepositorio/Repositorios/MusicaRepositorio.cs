using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class MusicaRepositorio : BaseRepositorio<Musica>, IMusicaRepositorio
    {
        public MusicaRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }
    }
}
