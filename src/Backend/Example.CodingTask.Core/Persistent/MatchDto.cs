using System;
using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Persistent
{
    public class MatchDto : GuidEntityDto
    {
        public string Name { set; get; }

        public DateTime TimeStamp { set; get; }
    }
}
