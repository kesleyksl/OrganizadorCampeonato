using OrganizadorCampeonatoDominio.Entidades;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Contratos
{
    public interface IFaseRepositorio : IBaseRepositorio<Fase>
    {
        List<Fase> ObterFases(int campeonatoId);
        
    }
}
