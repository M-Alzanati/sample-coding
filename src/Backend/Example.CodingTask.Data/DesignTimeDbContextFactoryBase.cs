using System;
using Example.CodingTask.Common.Configuration;
using Example.CodingTask.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example.CodingTask.Data
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureCleverbitCodingTaskCommon(environmentName);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TContext>();
            dbContextOptionsBuilder.ConfigureDbContextOptionsBuilder(configuration, environmentName, loggerFactory);

            return CreateNewInstance(dbContextOptionsBuilder.Options);
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
    }
}
