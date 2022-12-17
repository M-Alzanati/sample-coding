using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Data
{
    public class DesignTimeCodingTaskContextFactory : DesignTimeDbContextFactoryBase<CodingTaskContext>
    {
        protected override CodingTaskContext CreateNewInstance(DbContextOptions<CodingTaskContext> options)
        {
            return new CodingTaskContext(options);
        }
    }
}
