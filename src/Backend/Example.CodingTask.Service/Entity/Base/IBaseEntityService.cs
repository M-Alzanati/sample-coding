using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Base;
using Example.CodingTask.Core.Transient.Base;

namespace Example.CodingTask.Service.Entity.Base
{
    public interface IBaseEntityService<TEntity, TEntityDto, TCreateEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseEntityDto
        where TCreateEntityDto : CreateBaseEntityDto
    {
        Task<long> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        Task<IList<TEntityDto>> QueryAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        Task<TEntityDto> CreateAsync(TCreateEntityDto createEntityDto, CancellationToken cancellationToken);
    }
}
