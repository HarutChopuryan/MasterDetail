using Grace.DependencyInjection;

namespace MasterDetail.Core
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterCoreDependencies(this DependencyInjectionContainer container)
        {
            return container;
        }
    }
}