using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Example.CodingTask.Core.Base;
using Example.CodingTask.Core.Transient.Base;
using Example.CodingTask.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Service.Entity.Base
{
    public abstract class GuidEntityService<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto> 
        : BaseEntityService<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto>, IGuidEntityService<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto>
            where TEntity : GuidEntity
            where TEntityDto : GuidEntityDto
            where TCreateEntityDto : CreateBaseEntityDto
            where TUpdateEntityDto : UpdateBaseEntityDto
    {
        protected GuidEntityService(IGenericRepository<TEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
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

        public async Task<TEntityDto> UpdateAsync<TEntityUpdateDto>(Guid id, TEntityUpdateDto entityToUpdate, CancellationToken cancellationToken)
        {
            var entity = await Repository.GetByIdAsync(id, cancellationToken);
            var mappedEntity = Mapper.Map(entityToUpdate, entity);
            var result = await Repository.UpdateAsync(mappedEntity, cancellationToken);
            return Mapper.Map<TEntityDto>(result);
        }
    }
}

