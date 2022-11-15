using System;
using System.Collections.Generic;
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
    public abstract class GuidEntityService<TEntity, TEntityDto, TCreateEntityDto> 
        : BaseEntityService<TEntity, TEntityDto, TCreateEntityDto>, IGuidEntityService<TEntity, TEntityDto, TCreateEntityDto>
            where TEntity : GuidEntity
            where TEntityDto : GuidEntityDto
            where TCreateEntityDto : CreateBaseEntityDto
    {
        protected GuidEntityService(IGenericRepository<TEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<IList<TEntityDto>> QueryAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAsync(filter, null, null).ToListAsync(cancellationToken);

            return Mapper.Map<IList<TEntityDto>>(result);
        }

        public async Task<IList<TEntityDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await Repository.GetAsync(null, null, null).ToListAsync(cancellationToken);

            return Mapper.Map<IList<TEntityDto>>(result);
        }

        public async Task<TEntityDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await Repository.GetByIdAsync(id, cancellationToken);
            return Mapper.Map<TEntityDto>(result);
        }

        public async Task<TEntityDto> InsertAsync<TEntityCreateDto>(TEntityCreateDto entity,
            CancellationToken cancellationToken)
        {
            var item = Mapper.Map<TEntityCreateDto, TEntity>(entity);
            var result = await Repository.InsertAsync(item, cancellationToken);
            return Mapper.Map<TEntityDto>(result);
        }

        public async Task<TEntityDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await Repository.DeleteAsync(id, cancellationToken);
            return Mapper.Map<TEntityDto>(result);
        }

        public async Task<TEntityDto> DeleteAsync(TEntity entityToDelete, CancellationToken cancellationToken)
        {
            var result = await Repository.DeleteAsync(entityToDelete, cancellationToken);
            return Mapper.Map<TEntityDto>(result);
        }

        public async Task<TEntityDto> UpdateAsync<TEntityUpdateDto>(Guid id, TEntityUpdateDto entityToUpdate,
            CancellationToken cancellationToken)
        {
            var entity = await Repository.GetByIdAsync(id, cancellationToken);
            var item = Mapper.Map(entityToUpdate, entity);
            var result = await Repository.UpdateAsync(item, cancellationToken);
            return Mapper.Map<TEntityDto>(result);
        }
    }
}

