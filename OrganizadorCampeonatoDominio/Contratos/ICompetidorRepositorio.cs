using OrganizadorCampeonatoDominio.Entidades;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Contratos
{
    public interface ICompetIdorRepositorio : IBaseRepositorio<Competidor>
    {
        bool ExisteInscricao(Competidor competidor);
        List<Competidor> GetCompetidores(int campeonatoId);
        List<Competidor> GetCompetidores(int campeonatoId, int status);
        void Competir(Competidor competidor);
        bool EhOrganizador(Competidor competidor);
        void atualizarInscricao(Competidor competidor);
    }
}
