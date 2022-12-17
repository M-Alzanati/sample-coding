using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Utilities.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Example.CodingTask.Data
{
    public interface ICodingTaskContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task Seed(IHashService hashService);
    }
}
