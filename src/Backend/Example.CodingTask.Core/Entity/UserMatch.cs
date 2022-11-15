using System;
using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Entity
{
    public class UserMatch : BaseEntity
    {
        public Guid UserId { set; get; }

        public virtual User User { set; get; }

        public Guid MatchId { set; get; }

        public virtual Match Match { set; get; }

        public int Value { set; get; }
    }
}
