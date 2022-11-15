using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.CodingTask.Common.Configuration
{
    public static class CommonConfiguration
    {
        public static IConfiguration BuildConfiguration(string environmentName)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            return configurationBuilder.Build();
        }

        public static IServiceCollection ConfigureCleverbitCodingTaskCommon(
            this IServiceCollection serviceCollection,
            string environmentName)
        {
            var configuration = BuildConfiguration(environmentName);
            serviceCollection.AddTransient(s => configuration);
            return serviceCollection;
        }
    }
}
