using System.Collections.Generic;
using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Entity
{
    public class User : GuidEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserMatch> UserMatches { set; get; }
    }
}
