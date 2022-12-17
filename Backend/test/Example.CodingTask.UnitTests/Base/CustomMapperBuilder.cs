using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Example.CodingTask.Service.Test.Base
{
    public class CustomMapperBuilder
    {
        private bool _registered;
        private readonly ServiceCollection _serviceCollection;

        public CustomMapperBuilder(ServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public CustomMapperBuilder AddProfile(params Profile[] mappingProfiles)
        {
            _registered = true;
            _serviceCollection.AddAutoMapper(c =>
            {
                foreach (var mappingProfile in mappingProfiles)
                {
                    c.AddProfile(mappingProfile);
                }
            });

            return this;
        }

        public IMapper Build()
        {
            return _registered ? _serviceCollection.BuildServiceProvider().GetRequiredService<IMapper>() : new Mapper(new MapperConfiguration(c => { }));
        }
    }
}
