using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            IEnumerable<string> includeProperties = null);

        IQueryable<TEntity> AsQueryable();

        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task<TEntity> DeleteAsync(TEntity entityToDelete, CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate, CancellationToken cancellationToken);
    }
}
