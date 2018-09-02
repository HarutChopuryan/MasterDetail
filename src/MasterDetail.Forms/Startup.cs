using Grace.DependencyInjection;

namespace MasterDetail.Forms
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterFormsDependencies(
            this DependencyInjectionContainer container)
        {
            return container;
        }
    }
}