using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Query(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        Task InsertOrUpdate(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> ListarPorNome(string Nome);
    }
}