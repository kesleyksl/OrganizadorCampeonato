using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;
using System.Linq;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }

        public Usuario Obter(string email, string senha)
        {
            return OrganizadorCampeonatoContexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
