using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Transient;
using Example.CodingTask.Service.Entity.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model, CancellationToken cancellationToken)
        {
            return Ok(await _authenticationService.Authenticate(model, cancellationToken));
        }

        // POST api/auth/refresh
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] LoginResponseDto model, CancellationToken cancellationToken)
        {
            return Ok(await _authenticationService.GetAccessTokenByRefreshToken(model, cancellationToken));
        }
    }
}
