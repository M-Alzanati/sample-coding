using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient.Base;
using Example.CodingTask.Data.Repository;
using Example.CodingTask.Service.Entity.Base;
using Example.CodingTask.Service.Entity.Interface;

namespace Example.CodingTask.Service.Entity
{
    public class UserService : GuidEntityService<User, UserDto, CreateBaseEntityDto>, IUserService
    {
        public UserService(IGenericRepository<User> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<UserDto> GetUserByPasswordAndEmail(string email, string hashPassword, CancellationToken cancellationToken)
        {
            var result = await QueryAsync(u => u.UserName == email && u.Password == hashPassword, cancellationToken);
            return result.Single();
        }
    }
}
