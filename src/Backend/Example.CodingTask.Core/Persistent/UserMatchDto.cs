using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Persistent
{
    public class UserMatchDto : BaseEntityDto
    {
        public UserDto User{ set; get; }

        public MatchDto Match { set; get; }

        public int Value { set; get; }
    }
}
