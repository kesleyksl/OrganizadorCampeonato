using OrganizadorCampeonatoDominio.Entidades;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Contratos
{
    public interface ICampeonatoRepositorio : IBaseRepositorio<Campeonato>
    {
         List<Campeonato> CampeonatosUsuario(int usuarioId);
    }
}
