using Autofac;
using Repository.Interfaces;
using Repository.Repositories;

namespace Building
{
    public static class InjectionConfig
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            return builder.Build();
        }
    }
}
