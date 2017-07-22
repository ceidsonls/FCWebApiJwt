using System;

namespace FCamaraDev.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> TEntityRepository { get; }

        void Commit();
    }
}
