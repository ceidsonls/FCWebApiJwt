
using System.Collections.Generic;
using System.Linq;
namespace FCamaraDev.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObterTodos();
        T ObterPorId(int? id);
        void Inserir(T entity);
        void Excluir(T entity);
        void Excluir(int id);
        void Atualizar(T entity);
    }
}
