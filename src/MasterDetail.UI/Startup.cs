using Grace.DependencyInjection;

namespace MasterDetail.UI
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterUIDependencies(this DependencyInjectionContainer container)
        {
            return container;
        }
    }
}