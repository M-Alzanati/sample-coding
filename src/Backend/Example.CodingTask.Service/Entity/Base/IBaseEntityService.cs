using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Base;
using Example.CodingTask.Core.Transient.Base;

namespace Example.CodingTask.Service.Entity.Base
{
    public interface IBaseEntityService<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseEntityDto
        where TCreateEntityDto : CreateBaseEntityDto
        where TUpdateEntityDto : UpdateBaseEntityDto
    {
        Task<long> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        Task<IList<TEntityDto>> QueryAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        Task<TEntityDto> CreateAsync(TCreateEntityDto createEntityDto, CancellationToken cancellationToken);

        Task<TEntityDto> UpdateAsync(Guid id, TUpdateEntityDto updateEntityDto, CancellationToken cancellationToken);
    }
}
