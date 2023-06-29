using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Legoas.Data.Interfaces
{
    public interface IRepository<T>
    {
        T FindById(int id);
        Task<T> FindByIdAsync(int id);
        T Find(params object[] keyValues);
        Task<T> FindAsync(params object[] keyValues);
        //T FindById(int id, params Expression<Func<T, object>>[] includeProperties);
        //Task<T> FindByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(Expression<Func<T, bool>> whereCond, params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> FindAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> whereCond, params Expression<Func<T, object>>[] includeProperties);
        void InsertRange(IEnumerable<T> entities);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        int Save();
        Task<int> SaveAsync();
        Task<int> SaveAsync(CancellationToken cancellationToken);
        IQueryable<T> SqlQuery(string query, params object[] parameters);
    }
}
