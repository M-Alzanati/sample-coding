using Example.CodingTask.Core.Entity;
using Example.CodingTask.Data.Configuration.EntityConfiguration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.CodingTask.Data.Configuration.EntityConfiguration
{
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {

        }
    }
}
