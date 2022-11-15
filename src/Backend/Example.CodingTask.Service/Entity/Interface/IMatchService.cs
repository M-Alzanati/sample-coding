using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient.Base;
using Example.CodingTask.Service.Entity.Base;

namespace Example.CodingTask.Service.Entity.Interface
{
    public interface IMatchService : IGuidEntityService<Match, MatchDto, CreateBaseEntityDto>
    {
        Task<IList<UserMatchDto>> GetPlayedMatches(CancellationToken cancellationToken);

        Task<MatchDto> GetCurrentMatch(Guid userId, CancellationToken cancellationToken);
    }
}
