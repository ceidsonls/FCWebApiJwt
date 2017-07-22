using System;
using FCamaraDev.Repository.Repositories.Interfaces;
using FCamaraDev.Infra.Data.Contexto;

namespace FCamaraDev.Repository.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        #region Propriedades

        private bool killed;

        private readonly FCamaraContext fCamaraContext;

        private IRepository<T> tEntityRepository;

        #endregion

        #region Construtores

        public UnitOfWork()
        {
            fCamaraContext = new FCamaraContext();
        }

        public UnitOfWork(FCamaraContext db)
        {
            fCamaraContext = db;
        }

        #endregion

        #region Repositórios

        IRepository<T> IUnitOfWork<T>.TEntityRepository
        {
            get
            {
                if (tEntityRepository == null)
                {
                    tEntityRepository = new RepositoryBase<T>(fCamaraContext);
                }

                return tEntityRepository;
            }
        }

        #endregion

        #region Métodos

        public void Commit()
        {
            fCamaraContext.SaveChanges();
        }

        protected virtual void Dispose(bool kill)
        {
            if (!killed)
            {
                if (kill)
                {
                    fCamaraContext.Dispose();
                }
            }

            killed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
