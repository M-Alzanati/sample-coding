using Example.CodingTask.Data.Extensions;
using Example.CodingTask.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example.CodingTask.Data.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureCodingTaskContextDb(this IServiceCollection serviceCollection, string environmentName)
        {
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            serviceCollection.AddScoped<ICodingTaskContext>(c =>
            {
                var configuration = c.GetService<IConfiguration>();
                var loggerFactory = c.GetService<ILoggerFactory>();
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<CodingTaskContext>();
                dbContextOptionsBuilder.ConfigureDbContextOptionsBuilder(configuration, environmentName, loggerFactory);
                return new CodingTaskContext(dbContextOptionsBuilder.Options);
            });

            return serviceCollection;
        }
    }
}
