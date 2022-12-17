using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Transient;

namespace Example.CodingTask.Service.Entity.Interface
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> Authenticate(LoginRequestDto model, CancellationToken cancellationToken);

        Task<LoginResponseDto> GetAccessTokenByRefreshToken(LoginResponseDto dto, CancellationToken cancellationToken);
    }
}
