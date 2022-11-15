using System;
using Example.CodingTask.Core.Transient.Base;

namespace Example.CodingTask.Core.Transient
{
    public class CreateUserMatchDto : CreateBaseEntityDto
    {
        public Guid MatchId { set; get; }

        public Guid UserId { set; get; }

        public int Value { set; get; }
    }
}
