using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SBAdmin.Core.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        Task AddAsync(T entity);

        T Update(T entity);

        T Get(Guid id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        bool IsExist(Guid id);

        T Delete(T entity);

        void SaveChanges();
    }
}