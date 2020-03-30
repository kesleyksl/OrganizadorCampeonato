using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoRepositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class UsuarioFaseRepositorio : BaseRepositorio<UsuarioFase>, IUsuarioFaseRepositorio
    {
        public UsuarioFaseRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto) : base(organizadorCampeonatoContexto)
        {
        }
        public dynamic GetCompetidoresNaoCadastradoNaFase(int campeonatoId, int faseId)
        {
            dynamic competidores = (from cp in OrganizadorCampeonatoContexto.Competidores
                                     
                                    join cpe in OrganizadorCampeonatoContexto.Campeonatos on cp.CampeonatoId equals cpe.Id

                                    where (cp.StatusInscricaoId == 1 && cpe.Id == campeonatoId )
                                    select new
                                    {

                                        Id = cp.Id,
                                        CampeonatoId = cp.CampeonatoId,

                                        UsuarioId = cp.Usuario.Id,
                                        Usuario = cp.Usuario,


                                        StatusInscricaoId = cp.StatusInscricaoId,

                                    }
                                ).ToList();

            List<Competidor> competidors = new List<Competidor>();

            foreach(dynamic c in competidores)
            {
                competidors.Add(new Competidor
                {
                    Id = c.Id,
                    Usuario = c.Usuario,
                    UsuarioId = c.UsuarioId,
                    StatusInscricaoId = c.StatusInscricaoId

                }) ;
            }
            dynamic cf = GetCompetidoresFase(faseId);

            foreach(dynamic c in cf)
            {
                
                    competidors.RemoveAll(cp => cp.Id == c.Id);
                
            }
            competidores = competidors;

            return competidores;

        }
        public dynamic GetCompetidoresFase(int faseId)
        {
            dynamic competidores = (from cp in OrganizadorCampeonatoContexto.Competidores
                                join uf in OrganizadorCampeonatoContexto.UsuariosFase on cp.Id equals uf.CompetidorId

                                where (uf.FaseId == faseId)
                                select new
                                {

                                    Id = cp.Id,
                                    CampeonatoId = cp.CampeonatoId,
                                    CompetidorFaseId = uf.Id,
                                    UsuarioId = cp.Usuario.Id,
                                    Usuario = cp.Usuario,


                                    StatusInscricaoId = cp.StatusInscricaoId,
                                   
                                 }
                                ).ToList();




            return competidores;
        }
    }
}
