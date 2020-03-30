using OrganizadorCampeonatoDominio.Entidades;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Contratos
{
    public interface IUsuarioFaseRepositorio : IBaseRepositorio<UsuarioFase>
    {
        dynamic GetCompetidoresFase(int faseId);
        dynamic GetCompetidoresNaoCadastradoNaFase(int campeonatoId, int faseId);

    }
}
