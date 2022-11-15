using Example.CodingTask.Utilities.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace Example.CodingTask.Utilities.Configuration
{
    public static class UtilityConfiguration
    {
        public static void ConfigureCleverbitCodingTaskServiceService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHashService, HashService>();
        }
    }
}
