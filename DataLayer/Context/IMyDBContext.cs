using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Legoas.Data.Context
{
    public interface IMyDBContext
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry(object o);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
