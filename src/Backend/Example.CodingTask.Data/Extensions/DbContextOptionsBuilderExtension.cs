using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Example.CodingTask.Data.Extensions
{
    public static class DbContextOptionsBuilderExtension
    {
        public static DbContextOptionsBuilder ConfigureDbContextOptionsBuilder<TContext>(
            this DbContextOptionsBuilder<TContext> dbContextOptionsBuilder,
            IConfiguration configuration,
            string environmentName,
            ILoggerFactory loggerFactory = null) where TContext : DbContext
        {
            dbContextOptionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .UseLoggerFactory(loggerFactory);

            return dbContextOptionsBuilder;
        }
    }
}

