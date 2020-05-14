using Microsoft.EntityFrameworkCore;
using SBAdmin.Core.Repositories;
using SBAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SBAdmin.Api.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected HRDbContext context;

        public Repository(HRDbContext context)
        {
            this.context = context;
        }
        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public virtual T Get(Guid id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }


        public virtual T Update(T entity)
        {
            return context.Update(entity).Entity;
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual bool IsExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual T Delete(T entity)
        {
            return context.Remove(entity).Entity;
        }

        public async Task AddAsync(T entity)
        {
            await context.AddAsync(entity);
        }
    }
}