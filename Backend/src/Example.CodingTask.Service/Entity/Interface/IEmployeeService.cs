using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient.Employee;
using Example.CodingTask.Service.Entity.Base;

namespace Example.CodingTask.Service.Entity.Interface
{
    public interface IEmployeeService : IGuidEntityService<Employee, EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto>
    {
    }
}
