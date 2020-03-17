using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class CampeonatoRepositorio : BaseRepositorio<Campeonato>, ICampeonatoRepositorio
    {
        public CampeonatoRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }


        public List<Campeonato> CampeonatosUsuario(int usuarioId)
        {
            return OrganizadorCampeonatoContexto.Campeonatos.Where(c => c.UsuarioId == usuarioId).ToList();
        }
    }
}
