using OrganizadorCampeonatoDominio.Entidades;

namespace OrganizadorCampeonatoDominio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Obter(string email, string senha);

    }
}
