using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient;
using Example.CodingTask.Service.Entity.Interface;
using Example.CodingTask.Utilities.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Example.CodingTask.Service.Entity
{
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly ConcurrentDictionary<UserDto, string> UsersRefreshTokens = new ConcurrentDictionary<UserDto, string>();
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IHashService _hashService;

        public AuthenticationService(IUserService userService, IHashService hashService, IConfiguration config)
        {
            _configuration = config;
            _userService = userService;
            _hashService = hashService;
        }

        public async Task<LoginResponseDto> Authenticate(LoginRequestDto model, CancellationToken cancellationToken)
        {
            var hashPassword = await _hashService.HashText(model.Password);
            var user = await _userService.GetUserByPasswordAndEmail(model.UserName, hashPassword, cancellationToken);

            return user == null ? null : AuthenticateUser(user);
        }

        public async Task<LoginResponseDto> GetAccessTokenByRefreshToken(LoginResponseDto dto, CancellationToken cancellationToken)
        {
            var claim = GetPrincipalFromExpiredToken(dto.Token);
            if (claim == null) return null;

            var userClaim = claim.Claims.FirstOrDefault(e => e.Type == "uuid");
            var user = await _userService.GetByIdAsync(Guid.Parse(userClaim.Value), cancellationToken);

            var oldRefreshToken = UsersRefreshTokens.FirstOrDefault(e => e.Key.Id == user.Id);
            if (oldRefreshToken.Key != null && oldRefreshToken.Value == dto.RefreshToken)
            {
                UsersRefreshTokens.Remove(oldRefreshToken.Key, out var value);
            }
            else
            {
                throw new AuthenticationException();
            }

            return AuthenticateUser(user);
        }

        private LoginResponseDto AuthenticateUser(UserDto user)
        {
            if (user == null) return null;

            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            UsersRefreshTokens.AddOrUpdate(user, refreshToken, (s, t) => refreshToken);

            return new LoginResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = token,
                RefreshToken = refreshToken
            };
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Issuer"],
                ClockSkew = TimeSpan.FromMinutes(30),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private string GenerateJwtToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uuid", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                permClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
