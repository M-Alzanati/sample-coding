using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Entity
{
    public class Employee : GuidEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
