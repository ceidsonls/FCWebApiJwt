using System.Data.Entity;
using System.Linq;
using FCamaraDev.Infra.Data.Contexto;
using FCamaraDev.Repository.Repositories.Interfaces;

namespace FCamaraDev.Repository.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Propriedades

        private readonly FCamaraContext fCamaraContext;

        #endregion

        #region Construtor

        public RepositoryBase(FCamaraContext db)
        {
            fCamaraContext = db;
        }

        #endregion

        #region Métodos

        public void Atualizar(T entity)
        {
            fCamaraContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }

        public void Excluir(int id)
        {
            fCamaraContext.Set<T>().Remove(fCamaraContext.Set<T>().Find(id));
            Commit();
        }

        public void Excluir(T entity)
        {
            fCamaraContext.Set<T>().Remove(entity);
            Commit();
        }

        public void Inserir(T entity)
        {
            fCamaraContext.Set<T>().Add(entity);
            Commit();
        }

        public T ObterPorId(int? id)
        {
            return fCamaraContext.Set<T>().Find(id);
        }

        public IQueryable<T> ObterTodos()
        {
            return fCamaraContext.Set<T>();
        }

        private void Commit()
        {
            fCamaraContext.SaveChanges();
        }

        #endregion
    }
}
