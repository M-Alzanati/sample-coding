using AutoMapper;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient.Employee;
using Example.CodingTask.Data.Repository;
using Example.CodingTask.Service.Entity.Base;
using Example.CodingTask.Service.Entity.Interface;

namespace Example.CodingTask.Service.Entity
{
    public class EmployeeService : GuidEntityService<Employee, EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
