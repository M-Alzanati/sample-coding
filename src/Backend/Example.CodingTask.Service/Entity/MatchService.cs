using System;
using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Service.Entity
{
    public class MatchService : GuidEntityService<Match, MatchDto, CreateBaseEntityDto>, IMatchService
    {
        private readonly IGenericRepository<UserMatch> _userMatchRepository;

        public MatchService(IGenericRepository<Match> repository, IGenericRepository<UserMatch> userMatchRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _userMatchRepository = userMatchRepository;
        }

        public async Task<IList<UserMatchDto>> GetPlayedMatches(CancellationToken cancellationToken)
        {
            var time = DateTime.Now;
            var userMatches = await _userMatchRepository.GetAsync(e => e.Match.TimeStamp < time, null, new List<string>
            {
                $"{nameof(UserMatch.Match)}",
                $"{nameof(UserMatch.User)}"
            }).ToListAsync(cancellationToken);

            var result = userMatches
                .GroupBy(e => e.MatchId)
                .Select(match => match.ToList().OrderByDescending(e => e.Value).FirstOrDefault())
                .ToList();

            return Mapper.Map<IList<UserMatchDto>>(result);
        }

        public async Task<MatchDto> GetCurrentMatch(Guid userId, CancellationToken cancellationToken)
        {
            var time = DateTime.Now;

            var currentMatch = await Repository.GetAsync(
                filter: e => e.TimeStamp > time, 
                orderBy: e => e.OrderBy(d => d.TimeStamp), 
                includeProperties: null).FirstOrDefaultAsync(cancellationToken);

            var userMatch = await _userMatchRepository
                .GetAsync(e => e.UserId == userId && e.MatchId == currentMatch.Id)
                .CountAsync(cancellationToken: cancellationToken);

            return userMatch > 0 ? null : Mapper.Map<MatchDto>(currentMatch);
        }
    }
}
