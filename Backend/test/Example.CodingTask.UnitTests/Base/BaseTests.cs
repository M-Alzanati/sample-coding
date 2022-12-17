using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Example.CodingTask.Service.Test.Base
{
    public class BaseTests
    {
        protected Fixture Fixture;
        protected ServiceCollection ServiceCollection;
        protected CustomMapperBuilder MapperBuilder;
        private IServiceScope _scope;

        [OneTimeSetUp]
        public void InitializeBase()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            ServiceCollection = new ServiceCollection();
            MapperBuilder = new CustomMapperBuilder(ServiceCollection);
        }

        protected void AddTransientService<T>(T transient) where T : class
        {
            ServiceCollection.AddTransient(t => transient);
        }

        protected void AddTransientService<TInterface, T>()
            where TInterface : class
            where T : class, TInterface
        {
            ServiceCollection.AddTransient<TInterface, T>();
        }

        protected Mock<T> AddTransientServiceMock<T>() where T : class
        {
            var mock = new Mock<T>();
            ServiceCollection.AddTransient(t => mock.Object);

            return mock;
        }

        protected IServiceScope CreateScope()
        {
            var serviceProvider = ServiceCollection.BuildServiceProvider();
            var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            _scope = serviceScopeFactory.CreateScope();
            return _scope;
        }

        [TearDown]
        public virtual void Dispose()
        {
            _scope.Dispose();
        }
    }
}
