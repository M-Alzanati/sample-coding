using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient;
using Example.CodingTask.Service.Entity.Base;

namespace Example.CodingTask.Service.Entity.Interface
{
    public interface IUserMatchService : IBaseEntityService<UserMatch, UserMatchDto, CreateUserMatchDto>
    {
    }
}
