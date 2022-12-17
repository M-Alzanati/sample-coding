using Example.CodingTask.Core.Base;

namespace Example.CodingTask.Core.Persistent
{
    public class EmployeeDto : GuidEntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
