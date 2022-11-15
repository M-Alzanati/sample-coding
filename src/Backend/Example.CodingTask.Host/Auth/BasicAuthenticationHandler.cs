using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Service.Entity.Interface;
using Example.CodingTask.Utilities.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace Example.CodingTask.Host.Auth
{
    /// <summary>
    /// Authentication handler which handles BasicAuthentication header for API methods
    /// </summary>
    /// <seealso cref="AuthenticationHandler{AuthenticationSchemeOptions}" />
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string MissingAuthorizationHeaderError = "Missing Authorization Header";
        private const string InvalidAuthorizationHeaderError = "Invalid Authorization Header";
        private const string InternalAuthorizationError = "An internal authorization error occured. Please contact administrator.";
        private const string InvalidUserNameOrPassword = "Invalid Username or Password";

        private readonly IUserService _userService;
        private readonly IHashService _hashService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService,
            IHashService hashService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
            _hashService = hashService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
                return AuthenticateResult.Fail(MissingAuthorizationHeaderError);

            string userName;
            string password;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                userName = credentials[0];
                password = credentials[1];
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An exception occured when reading authorization header");
                return AuthenticateResult.Fail(InvalidAuthorizationHeaderError);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return AuthenticateResult.Fail(InvalidUserNameOrPassword);
            }

            var hashPassword = await _hashService.HashText(password);

            UserDto user;

            try
            {
                user = await _userService.GetUserByPasswordAndEmail( userName, hashPassword, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An exception occured when querying user");
                return AuthenticateResult.Fail(InternalAuthorizationError);
            }

            if (user == null)
                return AuthenticateResult.Fail(InvalidUserNameOrPassword);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
