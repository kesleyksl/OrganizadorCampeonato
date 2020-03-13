using OrganizadorCampeonatoDominio.Contratos;
using OrganizadorCampeonatoRepositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoRepositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {


        protected readonly OrganizadorCampeonatoContexto OrganizadorCampeonatoContexto;
        public BaseRepositorio(OrganizadorCampeonatoContexto organizadorCampeonatoContexto)
        {
            OrganizadorCampeonatoContexto = organizadorCampeonatoContexto;

        }
        public void Adicionar(TEntity entity)
        {
            OrganizadorCampeonatoContexto.Set<TEntity>().Add(entity);
            OrganizadorCampeonatoContexto.SaveChanges();

        }

        public void Atualizar(TEntity entity)
        {
            OrganizadorCampeonatoContexto.Set<TEntity>().Update(entity);
            OrganizadorCampeonatoContexto.SaveChanges();
        }

       

        public TEntity ObterPorId(int id)
        {
            return OrganizadorCampeonatoContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return OrganizadorCampeonatoContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            OrganizadorCampeonatoContexto.Remove(entity);
            OrganizadorCampeonatoContexto.SaveChanges();

        }

        public void Dispose()
        {
            OrganizadorCampeonatoContexto.Dispose();
        }

    }
}
