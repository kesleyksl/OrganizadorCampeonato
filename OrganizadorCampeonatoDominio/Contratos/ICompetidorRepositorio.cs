using OrganizadorCampeonatoDominio.Entidades;

namespace OrganizadorCampeonatoDominio.Contratos
{
    public interface ICompetIdorRepositorio : IBaseRepositorio<Competidor>
    {
        bool ExisteInscricao(Competidor competidor);

        void Competir(Competidor competidor);
        bool EhOrganizador(Competidor competidor);
    }
}
