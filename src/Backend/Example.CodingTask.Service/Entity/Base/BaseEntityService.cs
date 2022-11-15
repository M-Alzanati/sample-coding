using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Example.CodingTask.Core.Base;
using Example.CodingTask.Core.Transient.Base;
using Example.CodingTask.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Service.Entity.Base
{
    public abstract class BaseEntityService<TEntity, TEntityDto, TCreateEntityDto> : IBaseEntityService<TEntity, TEntityDto, TCreateEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseEntityDto
        where TCreateEntityDto : CreateBaseEntityDto
    {
        protected readonly IGenericRepository<TEntity> Repository;

        protected readonly IMapper Mapper;

        protected BaseEntityService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAsync(expression, null, null).ToListAsync(cancellationToken);

            return result.Count;
        }

        public async Task<IList<TEntityDto>> QueryAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAsync(expression, null, null).ToListAsync(cancellationToken);

            return Mapper.Map<IList<TEntity>, IList<TEntityDto>>(result.ToList());
        }

        public virtual async Task<TEntityDto> CreateAsync(TCreateEntityDto createEntityDto, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TCreateEntityDto, TEntity>(createEntityDto);

            var result = await Repository.InsertAsync(entity, cancellationToken);

            return Mapper.Map<TEntity, TEntityDto>(result);
        }
    }
}

