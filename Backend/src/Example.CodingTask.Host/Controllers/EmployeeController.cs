using System.Threading;
using System.Threading.Tasks;
using Example.CodingTask.Core.Transient.Employee;
using Example.CodingTask.Service.Entity.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // POST api/employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto, CancellationToken cancellationToken)
        {
            return Ok(await _employeeService.InsertAsync(createEmployeeDto, cancellationToken));
        }

        // GET api/employee
        [HttpGet]
        public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
        {
            return Ok(await _employeeService.GetAll(cancellationToken));
        }

        // GET api/employee/employeeId
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId, CancellationToken cancellationToken)
        {
            return Ok(await _employeeService.GetByIdAsync(employeeId, cancellationToken));
        }

        // PUT api/employee/employeeId
        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, UpdateEmployeeDto updateEmployeeDto, CancellationToken cancellationToken)
        {
            return Ok(await _employeeService.UpdateAsync(employeeId, updateEmployeeDto, cancellationToken));
        }

        // DELETE api/employee/employeeId
        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId, CancellationToken cancellationToken)
        {
            return Ok(await _employeeService.DeleteAsync(employeeId, cancellationToken));
        }
    }
}
