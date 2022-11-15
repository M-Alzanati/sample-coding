using System;
using System.Collections.Generic;
using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Entity
{
    public class Match : GuidEntity
    {
        public string Name { set; get; }

        public DateTime TimeStamp { set; get; }

        public virtual ICollection<UserMatch> UserMatches { set; get; }
    }
}
