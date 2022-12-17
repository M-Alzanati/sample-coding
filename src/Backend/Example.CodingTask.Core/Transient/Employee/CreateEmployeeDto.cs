using Example.CodingTask.Core.Transient.Base;

namespace Example.CodingTask.Core.Transient.Employee
{
    public class CreateEmployeeDto : CreateBaseEntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
