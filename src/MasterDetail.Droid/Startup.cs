using Grace.DependencyInjection;

namespace MasterDetail.Droid
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterDroidDependencies(
            this DependencyInjectionContainer container)
        {
            return container;
        }
    }
}