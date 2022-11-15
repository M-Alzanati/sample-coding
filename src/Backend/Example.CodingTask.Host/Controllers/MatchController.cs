using System;
using System.Linq;
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
    [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly IUserMatchService _userMatchService;
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService, IUserMatchService userMatchService)
        {
            _userMatchService = userMatchService;
            _matchService = matchService;
        }

        // POST api/match/play/{matchId}
        [HttpPost("play/{matchId}")]
        public async Task<IActionResult> PlayMatch(Guid matchId, CancellationToken cancellationToken)
        {
            var userClaim = User.Claims.FirstOrDefault(e => e.Type == "uuid");

            return Ok(await _userMatchService.CreateAsync(new CreateUserMatchDto
            {
                MatchId = matchId,
                UserId = Guid.Parse(userClaim.Value),
                Value = new Random().Next(1, 100)
            }, cancellationToken));
        }

        // Get api/match
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPlayedMatches(CancellationToken cancellationToken)
        {
            return Ok(await _matchService.GetPlayedMatches(cancellationToken));
        }

        // GET api/match/current
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentMatch(CancellationToken cancellationToken)
        {
            var userClaim = User.Claims.FirstOrDefault(e => e.Type == "uuid"); 

            return Ok(await _matchService.GetCurrentMatch(Guid.Parse(userClaim.Value), cancellationToken));
        }
    }
}
