using AutoMapper;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Transient.Employee;
using Example.CodingTask.Data.Repository;
using Example.CodingTask.Service.Entity;
using Example.CodingTask.Service.Entity.Interface;
using Example.CodingTask.Service.Mapping;
using Example.CodingTask.Service.Test.Base;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Example.CodingTask.Service.Test
{
    public class EmployeeServiceTests : BaseTests
    {
        private IEmployeeService _sut;
        private IMapper _mapper;
        private Mock<IGenericRepository<Employee>> _mockEmployeeRepository;

        [SetUp]
        public void Initialize()
        {
            _mockEmployeeRepository = AddTransientServiceMock<IGenericRepository<Employee>>();
            _mapper = MapperBuilder.AddProfile(new EmployeeMappingProfile()).Build();
            AddTransientService(_mapper);
            AddTransientService<IEmployeeService, EmployeeService>();
            _sut = CreateScope().ServiceProvider.GetRequiredService<IEmployeeService>();
        }

        [Test]
        public async Task When_CreateEmployee_Should_Return_EmployeeDto()
        {
            // Arrange
            var fakeCreateEmployeeDto = Fixture.Create<CreateEmployeeDto>();
            _mockEmployeeRepository
                .Setup(e => e.InsertAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_mapper.Map<CreateEmployeeDto, Employee>(fakeCreateEmployeeDto));

            // Act
            var result = await _sut.InsertAsync(fakeCreateEmployeeDto, CancellationToken.None);

            // Assert
            result.FirstName.Should().Be(fakeCreateEmployeeDto.FirstName);
            result.LastName.Should().Be(fakeCreateEmployeeDto.LastName);
        }

        [Test]
        public async Task When_GetEmployeeById_Should_Return_EmployeeDto()
        {
            // Arrange
            var fakeEmployee = Fixture.Create<Employee>();
            _mockEmployeeRepository
                .Setup(e => e.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeEmployee);

            // Act
            var result = await _sut.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None);

            // Assert
            result.FirstName.Should().Be(fakeEmployee.FirstName);
            result.LastName.Should().Be(fakeEmployee.LastName);
        }

        [Test]
        public async Task When_UpdateExistingEmployee_Should_Return_EmployeeDto()
        {
            // Arrange
            var fakeEmployee = Fixture.Create<Employee>();
            var fakeUpdateEmployee = Fixture.Create<UpdateEmployeeDto>();

            _mockEmployeeRepository
                .Setup(e => e.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeEmployee);

            _mockEmployeeRepository
                .Setup(e => e.UpdateAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeEmployee);

            // Act
            var result = await _sut.UpdateAsync(It.IsAny<Guid>(), fakeUpdateEmployee, CancellationToken.None);

            // Assert
            result.FirstName.Should().Be(fakeUpdateEmployee.FirstName);
            result.LastName.Should().Be(fakeUpdateEmployee.LastName);
        }

        [Test]
        public async Task When_DeleteExistingEmployee_Should_Return_EmployeeDto()
        {
            // Arrange
            var fakeEmployee = Fixture.Create<Employee>();

            _mockEmployeeRepository
                .Setup(e => e.DeleteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeEmployee);

            // Act
            var result = await _sut.DeleteAsync(It.IsAny<Guid>(), CancellationToken.None);

            // Assert
            result.FirstName.Should().Be(fakeEmployee.FirstName);
            result.LastName.Should().Be(fakeEmployee.LastName);
        }
    }
}
