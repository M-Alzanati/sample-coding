using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Base;
using Example.CodingTask.Core.Transient.Base;

namespace Example.CodingTask.Service.Entity.Base
{
    public interface IGuidEntityService<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto> 
        where TEntity : GuidEntity
        where TEntityDto : GuidEntityDto
        where TCreateEntityDto: CreateBaseEntityDto
        where TUpdateEntityDto : UpdateBaseEntityDto
    {
        Task<IList<TEntityDto>> QueryAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);

        Task<IList<TEntityDto>> GetAll(CancellationToken cancellationToken);

        Task<TEntityDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<TEntityDto> InsertAsync<TEntityCreateDto>(TEntityCreateDto entity, CancellationToken cancellationToken);

        Task<TEntityDto> DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task<TEntityDto> DeleteAsync(TEntity entityToDelete, CancellationToken cancellationToken);

        Task<TEntityDto> UpdateAsync<TEntityUpdateDto>(Guid id, TEntityUpdateDto entityToUpdate, CancellationToken cancellationToken);
    }
}
