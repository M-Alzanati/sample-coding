using System.Reflection;
using Example.CodingTask.Data.Configuration;
using Example.CodingTask.Service.Entity;
using Example.CodingTask.Service.Entity.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.CodingTask.Service.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureExampleCodingTaskService(this IServiceCollection serviceCollection, IConfiguration configuration, string environmentName)
        {
            serviceCollection.ConfigureCodingTaskContextDb(environmentName);
            serviceCollection.ConfigureMapping();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static void ConfigureMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}

