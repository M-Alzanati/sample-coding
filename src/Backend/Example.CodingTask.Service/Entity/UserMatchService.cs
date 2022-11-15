using AutoMapper;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient;
using Example.CodingTask.Data.Repository;
using Example.CodingTask.Service.Entity.Base;
using Example.CodingTask.Service.Entity.Interface;

namespace Example.CodingTask.Service.Entity
{
    public class UserMatchService : BaseEntityService<UserMatch, UserMatchDto, CreateUserMatchDto>, IUserMatchService
    {
        public UserMatchService(IGenericRepository<UserMatch> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
