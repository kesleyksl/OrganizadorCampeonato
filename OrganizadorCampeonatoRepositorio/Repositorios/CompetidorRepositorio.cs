using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class CompetIdorRepositorio : BaseRepositorio<Competidor>, ICompetIdorRepositorio
    {
        public CompetIdorRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
          
        }
        public bool ExisteInscricao(Competidor competidor)
        {
            var competidorExistente = OrganizadorCampeonatoContexto.Competidores.Where(c => c.UsuarioId == competidor.UsuarioId && c.CampeonatoId == competidor.CampeonatoId).SingleOrDefault();
            if (competidorExistente != null)
            {
                return true;

            }

            return false;
        }
        public List<Competidor> GetCompetidores(int campeonatoId)
        {
            return OrganizadorCampeonatoContexto.Competidores.Where(c => c.CampeonatoId == campeonatoId).ToList();
        }
        public void Competir(Competidor competidor)
        {



            OrganizadorCampeonatoContexto.Competidores.Add(competidor);
            OrganizadorCampeonatoContexto.SaveChanges();


            return;
        }

        public bool EhOrganizador(Competidor competidor)
        {
            var ehOrganizador = OrganizadorCampeonatoContexto.Campeonatos.Where(c => c.Id == competidor.CampeonatoId && c.UsuarioId == competidor.UsuarioId).SingleOrDefault();

            if (ehOrganizador != null)
                return true;

            return false;
        }
    }
}
