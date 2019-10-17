using Autofac;

namespace Building
{
    class Program
    {
        private static void Main(string[] args)
        {
            var container = InjectionConfig.BuildContainer();
            var application = container.Resolve<Application>();
            application.Run();
        }
    }
}