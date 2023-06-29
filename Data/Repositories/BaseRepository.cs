using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Legoas.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : BaseEntity
    {
        private IMyDBContext context;
        private DbSet<T> dbSet;

        public BaseRepository(IMyDBContext dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<T>();
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public T Find(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public async Task<T> FindAsync(params object[] keyValues)
        {

            return await dbSet.FindAsync(keyValues);
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    result = result.Include(includeProperty);
                }
            }
            return result;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> whereCond, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    result = result.Include(includeProperty);
                }
            }
            return result.Where(whereCond);
        }

        public async Task<ICollection<T>> FindAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    result = result.Include(includeProperty);
                }
            }
            return await result.ToListAsync();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> whereCond, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    result = result.Include(includeProperty);
                }
            }
            return await result.Where(whereCond).ToListAsync();
        }

        public virtual void InsertRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            //dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            Delete(FindById(id));
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual IQueryable<T> SqlQuery(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(System.Threading.CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

    }
}
