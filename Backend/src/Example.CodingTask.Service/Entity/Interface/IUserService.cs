using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient.Base;
using Example.CodingTask.Service.Entity.Base;

namespace Example.CodingTask.Service.Entity.Interface
{
    public interface IUserService : IGuidEntityService<User, UserDto, CreateBaseEntityDto, UpdateBaseEntityDto>
    {
        Task<UserDto> GetUserByPasswordAndEmail(string email, string hashPassword, CancellationToken cancellationToken);
    }
}
